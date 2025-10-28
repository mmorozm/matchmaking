using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Matchmaking.Migrations.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMinMaxPlayersSettingToPlaylistScenarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Playlists");

            migrationBuilder.AddColumn<bool>(
                name: "EnableBots",
                table: "Scenarios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxPlayers",
                table: "Scenarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinPlayers",
                table: "Scenarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamCount",
                table: "Scenarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxPlayersOverride",
                table: "Playlists",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinPlayersOverride",
                table: "Playlists",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamCountOverride",
                table: "Playlists",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnableBots",
                table: "Scenarios");

            migrationBuilder.DropColumn(
                name: "MaxPlayers",
                table: "Scenarios");

            migrationBuilder.DropColumn(
                name: "MinPlayers",
                table: "Scenarios");

            migrationBuilder.DropColumn(
                name: "TeamCount",
                table: "Scenarios");

            migrationBuilder.DropColumn(
                name: "MaxPlayersOverride",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "MinPlayersOverride",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "TeamCountOverride",
                table: "Playlists");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Playlists",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
