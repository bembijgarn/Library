using Microsoft.EntityFrameworkCore.Migrations;

namespace LemondoDATA.Migrations
{
    public partial class adduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_author_AuthorId",
                table: "books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_books",
                table: "books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_author",
                table: "author");

            migrationBuilder.RenameTable(
                name: "books",
                newName: "BOOKS");

            migrationBuilder.RenameTable(
                name: "author",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_books_AuthorId",
                table: "BOOKS",
                newName: "IX_BOOKS_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BOOKS",
                table: "BOOKS",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BOOKS_Author_AuthorId",
                table: "BOOKS",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOOKS_Author_AuthorId",
                table: "BOOKS");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BOOKS",
                table: "BOOKS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "BOOKS",
                newName: "books");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "author");

            migrationBuilder.RenameIndex(
                name: "IX_BOOKS_AuthorId",
                table: "books",
                newName: "IX_books_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_books",
                table: "books",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_author",
                table: "author",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_books_author_AuthorId",
                table: "books",
                column: "AuthorId",
                principalTable: "author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
