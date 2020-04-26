using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Froom.Data.Migrations
{
    public partial class InitialCreate : Migration
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
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    CampusName = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => new { x.Name, x.CampusName });
                    table.UniqueConstraint("AK_Building_CampusName_Name", x => new { x.CampusName, x.Name });
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
                    CampusName = table.Column<string>(nullable: false),
                    BuildingName = table.Column<string>(nullable: false),
                    FloorNumber = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingContents", x => new { x.CampusName, x.BuildingName, x.FloorNumber });
                    table.UniqueConstraint("AK_BuildingContents_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingContents_Floor_FloorNumber",
                        column: x => x.FloorNumber,
                        principalTable: "Floor",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingContents_Building_CampusName_BuildingName",
                        columns: x => new { x.CampusName, x.BuildingName },
                        principalTable: "Building",
                        principalColumns: new[] { "CampusName", "Name" },
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
                    UserId = table.Column<Guid>(nullable: false),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Report_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
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
                        name: "FK_Reservation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
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
                columns: new[] { "Id", "Name", "Role" },
                values: new object[] { new Guid("81bf9d10-810f-464b-b999-e2cb02ab6c4c"), "SeedUser", 0 });

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "Name", "CampusName", "Address", "Id" },
                values: new object[,]
                {
                    { "R1", "EHV", "Unknown", 1 },
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

            migrationBuilder.InsertData(
                table: "BuildingContents",
                columns: new[] { "CampusName", "BuildingName", "FloorNumber", "Id" },
                values: new object[,]
                {
                    { "EHV", "R1", "BG", 1 },
                    { "EHV", "R1", "1e", 2 },
                    { "EHV", "R1", "2e", 3 },
                    { "EHV", "R1", "3e", 4 }
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
                columns: new[] { "Id", "Duration", "RoomId", "StartTime", "UserId" },
                values: new object[] { 1, new TimeSpan(0, 1, 0, 0, 0), 1, new DateTime(2020, 5, 5, 8, 45, 0, 0, DateTimeKind.Unspecified), new Guid("81bf9d10-810f-464b-b999-e2cb02ab6c4c") });

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
                name: "IX_Report_UserId",
                table: "Report",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RoomId",
                table: "Reservation",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                column: "UserId");

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
                name: "Floor");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Campus");
        }
    }
}
