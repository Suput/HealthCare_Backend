using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare.Migrations
{
    public partial class health_record_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecord_TelegramUsers_TelegramUserId",
                table: "HealthRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HealthRecord",
                table: "HealthRecord");

            migrationBuilder.RenameTable(
                name: "HealthRecord",
                newName: "HealthRecords");

            migrationBuilder.RenameIndex(
                name: "IX_HealthRecord_TelegramUserId",
                table: "HealthRecords",
                newName: "IX_HealthRecords_TelegramUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HealthRecords",
                table: "HealthRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_TelegramUsers_TelegramUserId",
                table: "HealthRecords",
                column: "TelegramUserId",
                principalTable: "TelegramUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_TelegramUsers_TelegramUserId",
                table: "HealthRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HealthRecords",
                table: "HealthRecords");

            migrationBuilder.RenameTable(
                name: "HealthRecords",
                newName: "HealthRecord");

            migrationBuilder.RenameIndex(
                name: "IX_HealthRecords_TelegramUserId",
                table: "HealthRecord",
                newName: "IX_HealthRecord_TelegramUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HealthRecord",
                table: "HealthRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecord_TelegramUsers_TelegramUserId",
                table: "HealthRecord",
                column: "TelegramUserId",
                principalTable: "TelegramUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
