using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Matchmaking.Migrations.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIntermediateLobby : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClientVersion",
                table: "Tickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "IntermediateLobbyId",
                table: "Tickets",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IntermediateLobbies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Regions = table.Column<int[]>(type: "integer[]", nullable: false),
                    PlatformGroupId = table.Column<int>(type: "integer", nullable: false),
                    DevicePreferences = table.Column<int>(type: "integer", nullable: false),
                    ClientVersion = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntermediateLobbies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntermediateLobbies_Platforms_PlatformGroupId",
                        column: x => x.PlatformGroupId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IntermediateLobbyId",
                table: "Tickets",
                column: "IntermediateLobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateLobbies_PlatformGroupId",
                table: "IntermediateLobbies",
                column: "PlatformGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_IntermediateLobbies_IntermediateLobbyId",
                table: "Tickets",
                column: "IntermediateLobbyId",
                principalTable: "IntermediateLobbies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_IntermediateLobbies_IntermediateLobbyId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "IntermediateLobbies");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_IntermediateLobbyId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ClientVersion",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IntermediateLobbyId",
                table: "Tickets");
        }
    }
}
