using Microsoft.EntityFrameworkCore.Migrations;

namespace Froom.Data.Migrations
{
    public partial class ConsistencyNamingForCancelledReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "Reservation");

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "Reservation",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "Reservation");

            migrationBuilder.AddColumn<bool>(
                name: "Cancelled",
                table: "Reservation",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
