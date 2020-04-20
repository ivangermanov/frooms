using Microsoft.EntityFrameworkCore.Migrations;

namespace Froom.Data.Migrations
{
    public partial class ChangeUserNumberToId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_User_UserNumber",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_User_UserNumber",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_UserNumber",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Report_UserNumber",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserNumber",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "UserNumber",
                table: "Report");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "User",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reservation",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Report",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_UserId",
                table: "Report",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_User_UserId",
                table: "Report",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_User_UserId",
                table: "Reservation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_User_UserId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_User_UserId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Report_UserId",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Report");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserNumber",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserNumber",
                table: "Report",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserNumber",
                table: "Reservation",
                column: "UserNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Report_UserNumber",
                table: "Report",
                column: "UserNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_User_UserNumber",
                table: "Report",
                column: "UserNumber",
                principalTable: "User",
                principalColumn: "Number");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_User_UserNumber",
                table: "Reservation",
                column: "UserNumber",
                principalTable: "User",
                principalColumn: "Number");
        }
    }
}
