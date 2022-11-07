using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class MovieInsteadBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40580c09-af8d-4e46-aa65-06da2573d294");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd855295-78e6-412c-b418-0266b87ebcb1");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9ae673c9-6222-47b8-9824-f7a482f03652", "6c0b6e9b-7548-4610-bd0b-16a01cae8106", "User", "USER" },
                    { "c51adc43-6efa-4908-8d11-a58197995133", "346223b2-c643-4f98-ada4-61a6e94a7c14", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Comedy", "Adventures of Hercules", 1992 },
                    { 2, "Drama", "Rain", 1981 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ae673c9-6222-47b8-9824-f7a482f03652");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c51adc43-6efa-4908-8d11-a58197995133");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40580c09-af8d-4e46-aa65-06da2573d294", "ad2372a7-43dc-466e-ba72-6b1c5c9b5c88", "User", "USER" },
                    { "fd855295-78e6-412c-b418-0266b87ebcb1", "d49d37d2-0e6e-4ce1-860e-bfa8126ce683", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Adventures of Hercules", 1992 },
                    { 2, "Rain", 1981 }
                });
        }
    }
}
