using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc_basic.Migrations
{
    public partial class userroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "119d5dcc-d721-4dc0-9f91-bc4374a26348", "3381f96c-b196-4f94-8b5f-ede01bfefcc6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce5756c7-479b-4305-9d7a-f9ad17cc3f71", "5445cc50-618f-41a7-9558-e0c6c9c59670", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birth", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f25a19ce-0146-4cdf-a39c-fdbeebd8d13a", 0, new DateTime(1800, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), "31f454bd-7a27-4aa3-862e-754f67501faf", "admin@admin.com", false, "Admin", "Adminson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEH4qtCHwh0KX0F6xqrGDchNdLMDcnp7MBDc+LmVuHiSBmzl6I3PWhZdO5P74KH9q0g==", null, false, "a9d35f69-74ff-4a7c-bdb6-2ba18b106ae3", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "f25a19ce-0146-4cdf-a39c-fdbeebd8d13a", "119d5dcc-d721-4dc0-9f91-bc4374a26348" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce5756c7-479b-4305-9d7a-f9ad17cc3f71");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "f25a19ce-0146-4cdf-a39c-fdbeebd8d13a", "119d5dcc-d721-4dc0-9f91-bc4374a26348" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "119d5dcc-d721-4dc0-9f91-bc4374a26348");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f25a19ce-0146-4cdf-a39c-fdbeebd8d13a");
        }
    }
}
