using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare.Migrations
{
    public partial class separate_id_telUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TelegramUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TelegramUsers");
        }
    }
}
