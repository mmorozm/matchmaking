using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Matchmaking.Migrations.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PLaylistType",
                table: "Playlists",
                newName: "PlaylistType");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Playlists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TicketId = table.Column<Guid>(type: "uuid", nullable: false),
                    MatchId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    Present = table.Column<bool>(type: "boolean", nullable: false),
                    PresentChanged = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Registered = table.Column<bool>(type: "boolean", nullable: false),
                    RegisteredChanged = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MatchId",
                table: "Reservations",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TicketId",
                table: "Reservations",
                column: "TicketId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Playlists");

            migrationBuilder.RenameColumn(
                name: "PlaylistType",
                table: "Playlists",
                newName: "PLaylistType");
        }
    }
}
