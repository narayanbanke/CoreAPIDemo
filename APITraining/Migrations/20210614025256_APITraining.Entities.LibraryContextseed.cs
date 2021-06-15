using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APITraining.Migrations
{
    public partial class APITrainingEntitiesLibraryContextseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Author",
                columns: new[] { "AuthorId", "FirstName", "Genre", "LastName" },
                values: new object[] { new Guid("618f7fa8-ee10-4526-b10a-eaaaeda0e3bd"), "Bob", "Drama", "Ross" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Author",
                columns: new[] { "AuthorId", "FirstName", "Genre", "LastName" },
                values: new object[] { new Guid("a1ddcb51-b5fa-4c3e-aede-816cff74393d"), "David", "Fantasy", "Miller" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: new Guid("618f7fa8-ee10-4526-b10a-eaaaeda0e3bd"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: new Guid("a1ddcb51-b5fa-4c3e-aede-816cff74393d"));
        }
    }
}
