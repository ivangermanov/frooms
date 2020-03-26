using Microsoft.EntityFrameworkCore.Migrations;

namespace Froom.Data.Migrations
{
    public partial class AddRoomPointsAndShape : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Points",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Shape",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Shape",
                table: "Rooms");
        }
    }
}
