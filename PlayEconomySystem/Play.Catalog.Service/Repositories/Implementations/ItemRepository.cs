using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories.Implementations
{
    public class ItemRepository
    {
        private const string collectionName = "items";
        private readonly NpgsqlCollection<Item> dbCollection;
    }
}
