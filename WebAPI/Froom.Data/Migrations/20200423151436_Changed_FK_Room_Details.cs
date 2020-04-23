using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Froom.Data.Migrations
{
    public partial class Changed_FK_Room_Details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_BuildingContents_DetailsId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_DetailsId",
                table: "Room");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_BuildingContents_Id",
                table: "BuildingContents");

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "Number", "DetailsId" },
                keyValues: new object[] { "03", 3 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "Number", "DetailsId" },
                keyValues: new object[] { "05", 3 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "Number", "DetailsId" },
                keyValues: new object[] { "10", 3 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "Number", "DetailsId" },
                keyValues: new object[] { "71", 3 });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "Number", "DetailsId" },
                keyValues: new object[] { "40", 3 });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("735689ae-868e-486f-8a6c-7063f186e905"));

            migrationBuilder.DropColumn(
                name: "DetailsId",
                table: "Room");

            migrationBuilder.AddColumn<string>(
                name: "BuildingName",
                table: "Room",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FloorNumber",
                table: "Room",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                columns: new[] { "Number", "BuildingName", "FloorNumber" });

            migrationBuilder.UpdateData(
                table: "BuildingContents",
                keyColumns: new[] { "BuildingName", "FloorNumber" },
                keyValues: new object[] { "R1", "1e" },
                column: "Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BuildingContents",
                keyColumns: new[] { "BuildingName", "FloorNumber" },
                keyValues: new object[] { "R1", "2e" },
                column: "Id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "BuildingContents",
                keyColumns: new[] { "BuildingName", "FloorNumber" },
                keyValues: new object[] { "R1", "3e" },
                column: "Id",
                value: 4);

            migrationBuilder.UpdateData(
                table: "BuildingContents",
                keyColumns: new[] { "BuildingName", "FloorNumber" },
                keyValues: new object[] { "R1", "BG" },
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Number", "BuildingName", "FloorNumber", "Capacity", "Id", "Points" },
                values: new object[,]
                {
                    { "40", "R1", "2e", 40, 1, null },
                    { "10", "R1", "2e", 10, 2, null },
                    { "05", "R1", "2e", 30, 3, null },
                    { "03", "R1", "2e", 20, 4, null },
                    { "71", "R1", "2e", 20, 5, null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name", "Role" },
                values: new object[] { new Guid("4a5302a1-db21-423a-882a-c3ac5476fd61"), "SeedUser", 0 });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "Duration", "RoomId", "StartTime", "UserId" },
                values: new object[] { 1, new TimeSpan(0, 1, 0, 0, 0), 1, new DateTime(2020, 5, 5, 8, 45, 0, 0, DateTimeKind.Unspecified), new Guid("4a5302a1-db21-423a-882a-c3ac5476fd61") });

            migrationBuilder.CreateIndex(
                name: "IX_Room_BuildingName_FloorNumber",
                table: "Room",
                columns: new[] { "BuildingName", "FloorNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Room_BuildingContents_BuildingName_FloorNumber",
                table: "Room",
                columns: new[] { "BuildingName", "FloorNumber" },
                principalTable: "BuildingContents",
                principalColumns: new[] { "BuildingName", "FloorNumber" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_BuildingContents_BuildingName_FloorNumber",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_BuildingName_FloorNumber",
                table: "Room");

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "Number", "BuildingName", "FloorNumber" },
                keyValues: new object[] { "03", "R1", "2e" });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "Number", "BuildingName", "FloorNumber" },
                keyValues: new object[] { "05", "R1", "2e" });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "Number", "BuildingName", "FloorNumber" },
                keyValues: new object[] { "10", "R1", "2e" });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "Number", "BuildingName", "FloorNumber" },
                keyValues: new object[] { "71", "R1", "2e" });

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumns: new[] { "Number", "BuildingName", "FloorNumber" },
                keyValues: new object[] { "40", "R1", "2e" });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4a5302a1-db21-423a-882a-c3ac5476fd61"));

            migrationBuilder.DropColumn(
                name: "BuildingName",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "Room");

            migrationBuilder.AddColumn<int>(
                name: "DetailsId",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                columns: new[] { "Number", "DetailsId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_BuildingContents_Id",
                table: "BuildingContents",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Number", "DetailsId", "Capacity", "Id", "Points" },
                values: new object[,]
                {
                    { "40", 3, 40, 1, null },
                    { "10", 3, 10, 2, null },
                    { "05", 3, 30, 3, null },
                    { "03", 3, 20, 4, null },
                    { "71", 3, 20, 5, null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name", "Role" },
                values: new object[] { new Guid("735689ae-868e-486f-8a6c-7063f186e905"), "SeedUser", 0 });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "Duration", "RoomId", "StartTime", "UserId" },
                values: new object[] { 1, new TimeSpan(0, 1, 0, 0, 0), 1, new DateTime(2020, 5, 5, 8, 45, 0, 0, DateTimeKind.Unspecified), new Guid("735689ae-868e-486f-8a6c-7063f186e905") });

            migrationBuilder.CreateIndex(
                name: "IX_Room_DetailsId",
                table: "Room",
                column: "DetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_BuildingContents_DetailsId",
                table: "Room",
                column: "DetailsId",
                principalTable: "BuildingContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
