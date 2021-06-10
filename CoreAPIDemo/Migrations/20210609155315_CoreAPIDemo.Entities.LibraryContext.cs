using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreAPIDemo.Migrations
{
    public partial class CoreAPIDemoEntitiesLibraryContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "dbo",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Genre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "dbo",
                columns: table => new
                {
                    BookId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    AuthorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "dbo",
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Author",
                columns: new[] { "AuthorId", "FirstName", "Genre", "LastName" },
                values: new object[] { new Guid("08d31834-e711-4e4e-a196-b8ec5431aad3"), "Bob", "Drama", "Ross" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Author",
                columns: new[] { "AuthorId", "FirstName", "Genre", "LastName" },
                values: new object[] { new Guid("499b7f6d-7c1e-458b-9d6f-50ffe0eb13c0"), "David", "Fantasy", "Miller" });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                schema: "dbo",
                table: "Book",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "dbo");
        }
    }
}
