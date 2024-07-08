using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08c8d0e3-6ccc-4cf2-92aa-2fa1bb99bbdb",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9209cc3-dc3d-4591-a9c8-12f68a211ad8", new DateOnly(2001, 7, 19), "Default", "Admin", "AQAAAAIAAYagAAAAEMUCTHT6Oc+VZpQVNyI7zbdDTAgQlc/V8LmlMeDm5cDf4gx3hIz+H309elZg5/G58A==", "b7676bd6-385b-498b-a2aa-30c78f95001f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08c8d0e3-6ccc-4cf2-92aa-2fa1bb99bbdb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24389467-dbcc-4ada-a417-6a35eef4a86e", "AQAAAAIAAYagAAAAEJ3QOvTIyd93aubLCodxRT3FJB3WnnL4YDMyOqtbVH9Vk/uWfCBTFHlV0pqmh+3YgQ==", "3a7de3f9-26a8-4232-bf56-347e0600c82f" });
        }
    }
}
