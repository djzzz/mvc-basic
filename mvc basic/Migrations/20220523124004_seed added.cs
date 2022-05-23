using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc_basic.Migrations
{
    public partial class seedadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "City", "Name", "Number" },
                values: new object[,]
                {
                    { 1, "London", "Charls", 123 },
                    { 2, "Sweden", "Carl", 123 },
                    { 3, "USA", "Luzy", 123 },
                    { 4, "Italy", "Mario", 123 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "people",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "people",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "people",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "people",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
