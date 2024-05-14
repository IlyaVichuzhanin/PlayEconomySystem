using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Play.Catalog.Service.Migrations
{
    /// <inheritdoc />
    public partial class SeedCouponTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("4e049de7-4ea3-464c-a4e1-c365578a4743"), new DateTimeOffset(new DateTime(2024, 5, 13, 18, 33, 16, 854, DateTimeKind.Unspecified).AddTicks(2576), new TimeSpan(0, 5, 0, 0, 0)), "New Item", "Some name", 1.2m },
                    { new Guid("fe45d474-97df-45ac-aa28-711b4d86eff5"), new DateTimeOffset(new DateTime(2024, 5, 13, 18, 33, 16, 854, DateTimeKind.Unspecified).AddTicks(2628), new TimeSpan(0, 5, 0, 0, 0)), "New Item2", "Some name2", 1.5m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("4e049de7-4ea3-464c-a4e1-c365578a4743"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("fe45d474-97df-45ac-aa28-711b4d86eff5"));
        }
    }
}
