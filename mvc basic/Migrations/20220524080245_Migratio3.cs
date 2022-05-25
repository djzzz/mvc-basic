using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc_basic.Migrations
{
    public partial class Migratio3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LanguagePeople",
                columns: new[] { "LanguageId", "PeopleId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguagePeople",
                keyColumns: new[] { "LanguageId", "PeopleId" },
                keyValues: new object[] { 1, 1 });
        }
    }
}
