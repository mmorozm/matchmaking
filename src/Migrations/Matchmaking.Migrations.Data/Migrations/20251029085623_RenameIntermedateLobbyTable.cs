using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Matchmaking.Migrations.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameIntermedateLobbyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntermediateLobbies_Platforms_PlatformGroupId",
                table: "IntermediateLobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_IntermediateLobbies_IntermediateLobbyId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IntermediateLobbies",
                table: "IntermediateLobbies");

            migrationBuilder.RenameTable(
                name: "IntermediateLobbies",
                newName: "IntermediateLobby");

            migrationBuilder.RenameIndex(
                name: "IX_IntermediateLobbies_PlatformGroupId",
                table: "IntermediateLobby",
                newName: "IX_IntermediateLobby_PlatformGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IntermediateLobby",
                table: "IntermediateLobby",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IntermediateLobby_Platforms_PlatformGroupId",
                table: "IntermediateLobby",
                column: "PlatformGroupId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_IntermediateLobby_IntermediateLobbyId",
                table: "Tickets",
                column: "IntermediateLobbyId",
                principalTable: "IntermediateLobby",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntermediateLobby_Platforms_PlatformGroupId",
                table: "IntermediateLobby");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_IntermediateLobby_IntermediateLobbyId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IntermediateLobby",
                table: "IntermediateLobby");

            migrationBuilder.RenameTable(
                name: "IntermediateLobby",
                newName: "IntermediateLobbies");

            migrationBuilder.RenameIndex(
                name: "IX_IntermediateLobby_PlatformGroupId",
                table: "IntermediateLobbies",
                newName: "IX_IntermediateLobbies_PlatformGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IntermediateLobbies",
                table: "IntermediateLobbies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IntermediateLobbies_Platforms_PlatformGroupId",
                table: "IntermediateLobbies",
                column: "PlatformGroupId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_IntermediateLobbies_IntermediateLobbyId",
                table: "Tickets",
                column: "IntermediateLobbyId",
                principalTable: "IntermediateLobbies",
                principalColumn: "Id");
        }
    }
}
