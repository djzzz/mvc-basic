using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc_basic.Migrations
{
    public partial class Migratio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countrys",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countrys", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageID);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_cities_countrys_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countrys",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.PeopleId);
                    table.ForeignKey(
                        name: "FK_people_cities_CityId",
                        column: x => x.CityId,
                        principalTable: "cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguagePeople",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagePeople", x => new { x.LanguageId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_LanguagePeople_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguagePeople_people_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "people",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageID", "Name" },
                values: new object[,]
                {
                    { 1, "Spanish" },
                    { 2, "France" }
                });

            migrationBuilder.InsertData(
                table: "countrys",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "England" },
                    { 2, "Russia" },
                    { 4, "Sweden" },
                    { 3, "Spain" }
                });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "CityId", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "London" },
                    { 2, 1, "Birmingham" },
                    { 3, 1, "Glasgow" },
                    { 4, 1, "Liverpool" },
                    { 5, 2, "Moscow" },
                    { 6, 2, "Saint Petersburg" },
                    { 7, 2, "Novosibirsk" },
                    { 8, 2, "Yekaterinburg" },
                    { 13, 4, "Stockholm" },
                    { 14, 4, "Gothenburg" },
                    { 15, 4, "Malmö" },
                    { 16, 4, "Uppsala" },
                    { 9, 3, "Madrid" },
                    { 10, 3, "Barcelona" },
                    { 11, 3, "Valencia" },
                    { 12, 3, "Seville" }
                });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "PeopleId", "CityId", "Name", "Number" },
                values: new object[,]
                {
                    { 1, 1, "Simon", 123 },
                    { 2, 4, "Frans", 123 },
                    { 3, 5, "Roger", 123 },
                    { 6, 13, "Shan", 123 },
                    { 7, 14, "Elf", 123 },
                    { 4, 9, "Alf", 123 },
                    { 5, 12, "Bruno", 123 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cities_CountryId",
                table: "cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePeople_PeopleId",
                table: "LanguagePeople",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_people_CityId",
                table: "people",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguagePeople");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "countrys");
        }
    }
}
