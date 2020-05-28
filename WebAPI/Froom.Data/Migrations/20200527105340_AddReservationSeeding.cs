using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Froom.Data.Migrations
{
    public partial class AddReservationSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "Duration", "RoomId", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 30, 0, 0), 1, new DateTime(2020, 5, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5c861938-98ba-41d2-9e24-da3610e34544") },
                    { 15, new TimeSpan(0, 0, 30, 0, 0), 6, new DateTime(2020, 5, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab81a843-3e70-4cd2-9c89-d6b5719c3a6b") },
                    { 14, new TimeSpan(0, 0, 30, 0, 0), 5, new DateTime(2020, 5, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab81a843-3e70-4cd2-9c89-d6b5719c3a6b") },
                    { 13, new TimeSpan(0, 0, 30, 0, 0), 4, new DateTime(2020, 5, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab81a843-3e70-4cd2-9c89-d6b5719c3a6b") },
                    { 12, new TimeSpan(0, 0, 30, 0, 0), 3, new DateTime(2020, 5, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab81a843-3e70-4cd2-9c89-d6b5719c3a6b") },
                    { 11, new TimeSpan(0, 0, 30, 0, 0), 2, new DateTime(2020, 5, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("05847a38-8ea2-4232-966e-512d4159c554") },
                    { 10, new TimeSpan(0, 0, 30, 0, 0), 1, new DateTime(2020, 5, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("05847a38-8ea2-4232-966e-512d4159c554") },
                    { 16, new TimeSpan(0, 0, 30, 0, 0), 7, new DateTime(2020, 5, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab81a843-3e70-4cd2-9c89-d6b5719c3a6b") },
                    { 9, new TimeSpan(0, 0, 30, 0, 0), 8, new DateTime(2020, 5, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("05847a38-8ea2-4232-966e-512d4159c554") },
                    { 7, new TimeSpan(0, 0, 30, 0, 0), 6, new DateTime(2020, 5, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("05847a38-8ea2-4232-966e-512d4159c554") },
                    { 6, new TimeSpan(0, 0, 30, 0, 0), 5, new DateTime(2020, 5, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5c861938-98ba-41d2-9e24-da3610e34544") },
                    { 5, new TimeSpan(0, 0, 30, 0, 0), 1, new DateTime(2020, 5, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5c861938-98ba-41d2-9e24-da3610e34544") },
                    { 4, new TimeSpan(0, 0, 30, 0, 0), 4, new DateTime(2020, 5, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5c861938-98ba-41d2-9e24-da3610e34544") },
                    { 3, new TimeSpan(0, 0, 30, 0, 0), 3, new DateTime(2020, 5, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5c861938-98ba-41d2-9e24-da3610e34544") },
                    { 2, new TimeSpan(0, 0, 30, 0, 0), 2, new DateTime(2020, 5, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5c861938-98ba-41d2-9e24-da3610e34544") },
                    { 8, new TimeSpan(0, 0, 30, 0, 0), 7, new DateTime(2020, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("05847a38-8ea2-4232-966e-512d4159c554") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsBlocked", "Name", "Role" },
                values: new object[] { new Guid("ac408ff3-2e5d-4975-96a8-83e6e67f9e03"), "jeffrey.chan@student.fontys.nl", false, "Chan,Jeffrey J.K.B.", 1 });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "Duration", "RoomId", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 17, new TimeSpan(0, 0, 30, 0, 0), 8, new DateTime(2020, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ac408ff3-2e5d-4975-96a8-83e6e67f9e03") },
                    { 18, new TimeSpan(0, 0, 30, 0, 0), 1, new DateTime(2020, 5, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ac408ff3-2e5d-4975-96a8-83e6e67f9e03") },
                    { 19, new TimeSpan(0, 0, 30, 0, 0), 2, new DateTime(2020, 5, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ac408ff3-2e5d-4975-96a8-83e6e67f9e03") },
                    { 20, new TimeSpan(0, 0, 30, 0, 0), 3, new DateTime(2020, 5, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ac408ff3-2e5d-4975-96a8-83e6e67f9e03") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ac408ff3-2e5d-4975-96a8-83e6e67f9e03"));
        }
    }
}
