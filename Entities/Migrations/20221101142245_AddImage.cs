using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class AddImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ae673c9-6222-47b8-9824-f7a482f03652");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c51adc43-6efa-4908-8d11-a58197995133");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b7cb7f71-7628-4689-9cf5-fc8a4f2e475b", "836714a1-8d4c-4acd-94ce-b03c5dead4dc", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7bb2f7e-e9d2-434e-b45e-d4b414f28c0a", "8b1fc18b-8872-41e8-88d0-ba80af6e9e39", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7cb7f71-7628-4689-9cf5-fc8a4f2e475b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7bb2f7e-e9d2-434e-b45e-d4b414f28c0a");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ae673c9-6222-47b8-9824-f7a482f03652", "6c0b6e9b-7548-4610-bd0b-16a01cae8106", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c51adc43-6efa-4908-8d11-a58197995133", "346223b2-c643-4f98-ada4-61a6e94a7c14", "Administrator", "ADMINISTRATOR" });
        }
    }
}
