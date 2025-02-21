using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DateMe.Migrations
{
    /// <inheritdoc />
    public partial class Betterversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "Applications",
                newName: "MovieId");

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "Applications",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "Applications",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Applications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "CopiedToPlex",
                table: "Applications",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Miscellaneous" },
                    { 2, "Drama" },
                    { 3, "Television" },
                    { 4, "Horror/Suspense" },
                    { 5, "Comedy" },
                    { 6, "Family" },
                    { 7, "Action/Adventure" },
                    { 8, "VHS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CategoryId",
                table: "Applications",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Categories_CategoryId",
                table: "Applications",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Categories_CategoryId",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Applications_CategoryId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "CopiedToPlex",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Applications",
                newName: "MovieID");

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "Applications",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "Applications",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Applications",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
