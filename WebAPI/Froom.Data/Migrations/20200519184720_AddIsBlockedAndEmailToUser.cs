using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Froom.Data.Migrations
{
    public partial class AddIsBlockedAndEmailToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2e54132b-2059-4f11-b316-e97026657f24"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("468665e7-05ea-4210-92d2-96cf682131da"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("05847a38-8ea2-4232-966e-512d4159c554"),
                column: "Email",
                value: "y.buzykina@student.fontys.nl");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5c861938-98ba-41d2-9e24-da3610e34544"),
                column: "Email",
                value: "i.germanov@student.fontys.nl");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsBlocked", "Name", "Role" },
                values: new object[] { new Guid("468665e7-05ea-4210-92d2-96cf682131da"), "seeduser@gmail.com", false, "SeedUser", 0 });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "Duration", "RoomId", "StartTime", "UserId" },
                values: new object[] { 1, new TimeSpan(0, 1, 0, 0, 0), 1, new DateTime(2020, 5, 5, 8, 45, 0, 0, DateTimeKind.Unspecified), new Guid("468665e7-05ea-4210-92d2-96cf682131da") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("468665e7-05ea-4210-92d2-96cf682131da"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "User");

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("2e54132b-2059-4f11-b316-e97026657f24"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name", "Role" },
                values: new object[] { new Guid("2e54132b-2059-4f11-b316-e97026657f24"), "SeedUser", 0 });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "Duration", "RoomId", "StartTime", "UserId" },
                values: new object[] { 1, new TimeSpan(0, 1, 0, 0, 0), 1, new DateTime(2020, 5, 5, 8, 45, 0, 0, DateTimeKind.Unspecified), new Guid("2e54132b-2059-4f11-b316-e97026657f24") });
        }
    }
}
