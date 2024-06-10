using System.Linq.Expressions;

namespace Mango.Services.CouponAPISpecification;

internal class ComposeSpecification<T> : Specification<T>
{
    private readonly Func<Expression, Expression, Expression> _compose;
    private readonly Specification<T> _first;
    private readonly Specification<T> _second;

    protected ComposeSpecification(Func<Expression, Expression, Expression> compose,
        Specification<T> first,
        Specification<T> second)
    {
        _compose = compose;
        _first = first;
        _second = second;
    }

    protected override Expression<Func<T, bool>> ToExpression()
    {
        var parameter = Expression.Parameter(typeof(T));
        var replacedFirst = ReplaceParameter(_first.Predicate, parameter);
        var replacedSecond = ReplaceParameter(_second.Predicate, parameter);

        return Expression.Lambda<Func<T, bool>>(_compose(replacedFirst, replacedSecond), parameter);
    }

    private static Expression ReplaceParameter(Expression<Func<T, bool>> expression, Expression parameter)
    {
        return new ReplaceExpressionVisitor(expression.Parameters[0], parameter)
            .Visit(expression.Body)!;
    }

    private class ReplaceExpressionVisitor : ExpressionVisitor
    {
        private readonly Expression _old;
        private readonly Expression _new;

        public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
        {
            _old = oldValue;
            _new = newValue;
        }

        public override Expression? Visit(Expression? node)
        {
            return node == _old ? _new : base.Visit(node);
        }
    }
}
