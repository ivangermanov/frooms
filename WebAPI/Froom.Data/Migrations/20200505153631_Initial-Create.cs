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
                values: new object[,]
                {
                    { new Guid("4ccb9c19-fdb7-471a-94d3-2748ebea7d15"), "SeedUser", 0 },
                    { new Guid("5c861938-98ba-41d2-9e24-da3610e34544"), "Ivan Germanov", 1 }
                });

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
                    { "EHV", "R1", "3e", 4 },
                    { "EHV", "R1", "4e", 5 }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Number", "DetailsId", "Capacity", "Id", "Points" },
                values: new object[,]
                {
                    { "0.183", 1, 40, 1, "[{\"X\":68.378906,\"Y\":-4.039618},{\"X\":40.957031,\"Y\":-4.390229},{\"X\":40.78125,\"Y\":5.178482},{\"X\":68.818359,\"Y\":5.090944},{\"X\":68.554688,\"Y\":26.273714},{\"X\":97.207031,\"Y\":25.958045},{\"X\":97.558594,\"Y\":-3.688855},{\"X\":68.378906,\"Y\":-4.039618}]" },
                    { "1.19", 2, 10, 2, "[{\"X\":-151.347656,\"Y\":-69.349339},{\"X\":-150.996094,\"Y\":-55.875311},{\"X\":-128.847656,\"Y\":-56.170023},{\"X\":-128.847656,\"Y\":-69.472969}]" },
                    { "1.05", 2, 30, 3, "[{\"X\":-216.738281,\"Y\":-67.101656},{\"X\":-216.650391,\"Y\":-60.020952},{\"X\":-183.867187,\"Y\":-60.152442},{\"X\":-183.691406,\"Y\":-66.998844}]" },
                    { "2.24", 3, 20, 4, "[{\"X\":-26.367188,\"Y\":-33.137551},{\"X\":-26.71875,\"Y\":-12.726084},{\"X\":-5.449219,\"Y\":-12.726084},{\"X\":-5.273438,\"Y\":-34.016242},{\"X\":-26.367188,\"Y\":-33.137551}]" },
                    { "2.01", 3, 20, 5, "[{\"X\":-37.265625,\"Y\":-2.108899},{\"X\":-37.265625,\"Y\":19.642588},{\"X\":-14.765625,\"Y\":19.311143},{\"X\":-15.46875,\"Y\":-2.460181},{\"X\":-37.265625,\"Y\":-2.108899}]" },
                    { "3.41", 4, 50, 6, "[{\"X\":-150.820312,\"Y\":-66.372755},{\"X\":-150.996094,\"Y\":-49.61071},{\"X\":-129.19921,\"Y\":-49.496675},{\"X\":-129.199219,\"Y\":-66.302205},{\"X\":-150.820312,\"Y\":-66.372755}]" },
                    { "3.44C", 4, 20, 7, "[{\"X\":-48.691406,\"Y\":-66.372755},{\"X\":-48.515625,\"Y\":-53.956086},{\"X\":-25.3125,\"Y\":-53.748711},{\"X\":-25.3125,\"Y\":-66.443107},{\"X\":-48.691406,\"Y\":-66.372755}]" },
                    { "4.109", 5, 20, 8, "[{\"X\":-302.783203,\"Y\":45.336702},{\"X\":-321.416016,\"Y\":45.02695},{\"X\":-333.808594,\"Y\":42.488302},{\"X\":-333.896484,\"Y\":22.268764},{\"X\":-321.591797,\"Y\":18.979026},{\"X\":-288.984375,\"Y\":19.311143},{\"X\":-287.666016,\"Y\":22.674847},{\"X\":-287.578125,\"Y\":42.811522},{\"X\":-288.808594,\"Y\":42.682435},{\"X\":-289.072266,\"Y\":47.15984},{\"X\":-287.578125,\"Y\":47.338823},{\"X\":-287.666016,\"Y\":59.175928},{\"X\":-290.214844,\"Y\":59.085739},{\"X\":-295.400391,\"Y\":59.085739},{\"X\":-295.576172,\"Y\":52.855864},{\"X\":-302.783203,\"Y\":52.855864}]" }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "Duration", "RoomId", "StartTime", "UserId" },
                values: new object[] { 1, new TimeSpan(0, 1, 0, 0, 0), 1, new DateTime(2020, 5, 5, 8, 45, 0, 0, DateTimeKind.Unspecified), new Guid("4ccb9c19-fdb7-471a-94d3-2748ebea7d15") });

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
