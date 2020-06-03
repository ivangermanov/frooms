using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Froom.Data.Migrations
{
    public partial class ChangeDurationToEndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Building",
                keyColumns: new[] { "Name", "CampusName" },
                keyValues: new object[] { "EK", "EHV" });

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumns: new[] { "Name", "CampusName" },
                keyValues: new object[] { "ER", "EHV" });

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumns: new[] { "Name", "CampusName" },
                keyValues: new object[] { "ES", "EHV" });

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumns: new[] { "Name", "CampusName" },
                keyValues: new object[] { "R3R4", "EHV" });

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumns: new[] { "Name", "CampusName" },
                keyValues: new object[] { "R5", "EHV" });

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumns: new[] { "Name", "CampusName" },
                keyValues: new object[] { "S1", "EHV" });

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumns: new[] { "Name", "CampusName" },
                keyValues: new object[] { "S2", "EHV" });

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumns: new[] { "Name", "CampusName" },
                keyValues: new object[] { "S3", "EHV" });

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumns: new[] { "Name", "CampusName" },
                keyValues: new object[] { "TF", "EHV" });

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumns: new[] { "Name", "CampusName" },
                keyValues: new object[] { "TQ", "EHV" });

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Reservation");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Reservation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Reservation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 5, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 5, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 5, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 5, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 5, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 5, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 5, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 5, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 6, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 6, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 6, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 6, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 7, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 7, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 7, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 7, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 8, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 8, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 10, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 10, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 10, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 5, 10, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 10, 11, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Reservation");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Reservation",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Reservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "Name", "CampusName", "Address", "Id" },
                values: new object[,]
                {
                    { "R3R4", "EHV", "Unknown", 2 },
                    { "R5", "EHV", "Unknown", 3 },
                    { "EK", "EHV", "Unknown", 4 },
                    { "ER", "EHV", "Unknown", 5 },
                    { "ES", "EHV", "Unknown", 6 },
                    { "S1", "EHV", "Unknown", 7 },
                    { "S2", "EHV", "Unknown", 8 },
                    { "S3", "EHV", "Unknown", 9 },
                    { "TF", "EHV", "Unknown", 10 },
                    { "TQ", "EHV", "Unknown", 11 }
                });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 5, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 5, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 5, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 6, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 6, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 7, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 7, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 7, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 7, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 10, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 10, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Duration", "StartTime" },
                values: new object[] { new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 5, 10, 11, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
