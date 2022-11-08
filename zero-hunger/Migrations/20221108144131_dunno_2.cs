using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zero_hunger.Migrations
{
    public partial class dunno_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_User_UserId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_UserId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Restaurant");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_ManagedByUserId",
                table: "Restaurant",
                column: "ManagedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_User_ManagedByUserId",
                table: "Restaurant",
                column: "ManagedByUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_User_ManagedByUserId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_ManagedByUserId",
                table: "Restaurant");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Restaurant",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_UserId",
                table: "Restaurant",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_User_UserId",
                table: "Restaurant",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
