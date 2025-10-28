using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Matchmaking.Migrations.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMatchAddPlaylistAndScenarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaylistId",
                table: "Matches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScenarioId",
                table: "Matches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlaylistId",
                table: "Matches",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ScenarioId",
                table: "Matches",
                column: "ScenarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Playlists_PlaylistId",
                table: "Matches",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Scenarios_ScenarioId",
                table: "Matches",
                column: "ScenarioId",
                principalTable: "Scenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Playlists_PlaylistId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Scenarios_ScenarioId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_PlaylistId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_ScenarioId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ScenarioId",
                table: "Matches");
        }
    }
}
