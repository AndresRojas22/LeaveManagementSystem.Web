using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d278c2d4-b79e-4db9-803a-7e76a803a9e0", null, "Administrator", "ADMINISTRATOR" },
                    { "da0bd94c-8740-4966-b73f-ab473ebb2e3b", null, "Employee", "EMPLOYEE" },
                    { "dfbb7190-a1ac-4486-8901-301a954e4778", null, "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "08c8d0e3-6ccc-4cf2-92aa-2fa1bb99bbdb", 0, "24389467-dbcc-4ada-a417-6a35eef4a86e", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEJ3QOvTIyd93aubLCodxRT3FJB3WnnL4YDMyOqtbVH9Vk/uWfCBTFHlV0pqmh+3YgQ==", null, false, "3a7de3f9-26a8-4232-bf56-347e0600c82f", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d278c2d4-b79e-4db9-803a-7e76a803a9e0", "08c8d0e3-6ccc-4cf2-92aa-2fa1bb99bbdb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da0bd94c-8740-4966-b73f-ab473ebb2e3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfbb7190-a1ac-4486-8901-301a954e4778");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d278c2d4-b79e-4db9-803a-7e76a803a9e0", "08c8d0e3-6ccc-4cf2-92aa-2fa1bb99bbdb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d278c2d4-b79e-4db9-803a-7e76a803a9e0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08c8d0e3-6ccc-4cf2-92aa-2fa1bb99bbdb");
        }
    }
}
