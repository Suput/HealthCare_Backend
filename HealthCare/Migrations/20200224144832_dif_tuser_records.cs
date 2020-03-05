using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HealthCare.Migrations
{
    public partial class dif_tuser_records : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "TelegramUsers");

            migrationBuilder.DropColumn(
                name: "Dia",
                table: "TelegramUsers");

            migrationBuilder.DropColumn(
                name: "Pulse",
                table: "TelegramUsers");

            migrationBuilder.DropColumn(
                name: "Sys",
                table: "TelegramUsers");

            migrationBuilder.CreateTable(
                name: "HealthRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TelegramUserId = table.Column<int>(nullable: false),
                    Sys = table.Column<int>(nullable: false),
                    Dia = table.Column<int>(nullable: false),
                    Pulse = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthRecord_TelegramUsers_TelegramUserId",
                        column: x => x.TelegramUserId,
                        principalTable: "TelegramUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecord_TelegramUserId",
                table: "HealthRecord",
                column: "TelegramUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthRecord");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "TelegramUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Dia",
                table: "TelegramUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pulse",
                table: "TelegramUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sys",
                table: "TelegramUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
