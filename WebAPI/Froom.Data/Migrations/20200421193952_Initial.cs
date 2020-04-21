using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Froom.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.Id);
                    table.UniqueConstraint("AK_Campus_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    Number = table.Column<string>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => new { x.Number, x.Order });
                    table.UniqueConstraint("AK_Floor_Number", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CampusName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                    table.UniqueConstraint("AK_Building_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Building_Campus_CampusName",
                        column: x => x.CampusName,
                        principalTable: "Campus",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingContents",
                columns: table => new
                {
                    BuildingName = table.Column<string>(nullable: false),
                    FloorNumber = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingContents", x => new { x.BuildingName, x.FloorNumber });
                    table.UniqueConstraint("AK_BuildingContents_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingContents_Building_BuildingName",
                        column: x => x.BuildingName,
                        principalTable: "Building",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingContents_Floor_FloorNumber",
                        column: x => x.FloorNumber,
                        principalTable: "Floor",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Number = table.Column<string>(nullable: false),
                    DetailsId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(nullable: true),
                    Points = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => new { x.Number, x.DetailsId });
                    table.UniqueConstraint("AK_Room_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_BuildingContents_DetailsId",
                        column: x => x.DetailsId,
                        principalTable: "BuildingContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNumber = table.Column<int>(nullable: true),
                    RoomId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Report_User_UserNumber",
                        column: x => x.UserNumber,
                        principalTable: "User",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNumber = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_User_UserNumber",
                        column: x => x.UserNumber,
                        principalTable: "User",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(nullable: false),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Picture_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Campus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "EHV" },
                    { 2, "TIL" },
                    { 3, "VNL" }
                });

            migrationBuilder.InsertData(
                table: "Floor",
                columns: new[] { "Number", "Order" },
                values: new object[,]
                {
                    { "BG", 0 },
                    { "1e", 1 },
                    { "2e", 2 },
                    { "3e", 3 },
                    { "4e", 4 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Number", "Name", "Role" },
                values: new object[,]
                {
                    { 3634571, "Brice, Tom", 0 },
                    { 3638459, "Karnstein, Mircalla", 0 },
                    { 4516348, "Ashwoode, Mary", 0 },
                    { 1274628, "O'Connor, Edmond", 0 },
                    { 3947204, "Ruthyn, Maud", 0 },
                    { 2475253, "Knollys, Monica", 0 },
                    { 7492568, "Ruthyn, Silas", 0 },
                    { 7245343, "Hawkes, Meg", 0 },
                    { 8538245, "Toole, Larry", 0 },
                    { 3635673, "Cresswell, Penrose", 0 }
                });

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "Id", "Address", "CampusName", "Name" },
                values: new object[,]
                {
                    { 1, "Unknown", "EHV", "R1" },
                    { 2, "Unknown", "EHV", "R3R4" },
                    { 3, "Unknown", "EHV", "R5" },
                    { 4, "Unknown", "EHV", "EK" },
                    { 5, "Unknown", "EHV", "ER" },
                    { 6, "Unknown", "EHV", "ES" },
                    { 7, "Unknown", "EHV", "S1" },
                    { 8, "Unknown", "EHV", "S2" },
                    { 9, "Unknown", "EHV", "S3" },
                    { 10, "Unknown", "EHV", "TF" },
                    { 11, "Unknown", "EHV", "TQ" }
                });

            migrationBuilder.InsertData(
                table: "BuildingContents",
                columns: new[] { "BuildingName", "FloorNumber", "Id" },
                values: new object[,]
                {
                    { "R1", "BG", 1 },
                    { "R1", "1e", 2 },
                    { "R1", "2e", 3 },
                    { "R1", "3e", 4 }
                });

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
                table: "Reservation",
                columns: new[] { "Id", "Duration", "RoomId", "StartTime", "UserNumber" },
                values: new object[] { 1, new TimeSpan(0, 1, 0, 0, 0), 1, new DateTime(2020, 5, 5, 8, 45, 0, 0, DateTimeKind.Unspecified), 4516348 });

            migrationBuilder.CreateIndex(
                name: "IX_Building_CampusName",
                table: "Building",
                column: "CampusName");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingContents_FloorNumber",
                table: "BuildingContents",
                column: "FloorNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Campus_Name",
                table: "Campus",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ReportId",
                table: "Picture",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_RoomId",
                table: "Report",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_UserNumber",
                table: "Report",
                column: "UserNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RoomId",
                table: "Reservation",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserNumber",
                table: "Reservation",
                column: "UserNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Room_DetailsId",
                table: "Room",
                column: "DetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BuildingContents");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "Campus");
        }
    }
}
