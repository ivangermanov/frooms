using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Froom.Data.Migrations
{
    public partial class IsNew_Notifications : Migration
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
                keyValue: new Guid("468665e7-05ea-4210-92d2-96cf682131da"));

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "Notification",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Notification",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsNew", "Message", "Title", "UserId" },
                values: new object[] { true, "Seeded notification text.", "Seeded Notification", new Guid("91dd26e6-2c14-42c1-ac7d-c00457d0bc0e") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsBlocked", "Name", "Role" },
                values: new object[] { new Guid("91dd26e6-2c14-42c1-ac7d-c00457d0bc0e"), "seeduser@gmail.com", false, "SeedUser", 0 });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "Duration", "RoomId", "StartTime", "UserId" },
                values: new object[] { 1, new TimeSpan(0, 1, 0, 0, 0), 1, new DateTime(2020, 5, 5, 8, 45, 0, 0, DateTimeKind.Unspecified), new Guid("91dd26e6-2c14-42c1-ac7d-c00457d0bc0e") });
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
                keyValue: new Guid("91dd26e6-2c14-42c1-ac7d-c00457d0bc0e"));

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Notification");

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Message", "UserId" },
                values: new object[] { "SeededNotification", new Guid("468665e7-05ea-4210-92d2-96cf682131da") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsBlocked", "Name", "Role" },
                values: new object[] { new Guid("468665e7-05ea-4210-92d2-96cf682131da"), "seeduser@gmail.com", false, "SeedUser", 0 });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "Duration", "RoomId", "StartTime", "UserId" },
                values: new object[] { 1, new TimeSpan(0, 1, 0, 0, 0), 1, new DateTime(2020, 5, 5, 8, 45, 0, 0, DateTimeKind.Unspecified), new Guid("468665e7-05ea-4210-92d2-96cf682131da") });
        }
    }
}
