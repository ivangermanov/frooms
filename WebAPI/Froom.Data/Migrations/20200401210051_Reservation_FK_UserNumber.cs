using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Froom.Data.Migrations
{
    public partial class Reservation_FK_UserNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Users_Id_Number",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "UserNumber",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Number",
                table: "Users",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Number",
                table: "Users",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserNumber",
                table: "Reservations",
                column: "UserNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserNumber",
                table: "Reservations",
                column: "UserNumber",
                principalTable: "Users",
                principalColumn: "Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserNumber",
                table: "Reservations");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Number",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Number",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserNumber",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UserNumber",
                table: "Reservations");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_Number",
                table: "Users",
                columns: new[] { "Id", "Number" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
