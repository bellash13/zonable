using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace zonable.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingId = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "default"),
                    TimeZone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingId);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 14, 12, 30, 2, 958, DateTimeKind.Utc).AddTicks(9873), "John Doe" },
                    { 2, new DateTime(2025, 5, 14, 12, 30, 2, 958, DateTimeKind.Utc).AddTicks(9876), "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "SettingId", "TimeZone" },
                values: new object[,]
                {
                    { "local", "W. Central Africa Standard Time" },
                    { "utc", "UTC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
