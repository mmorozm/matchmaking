using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Matchmaking.Migrations.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Matches",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Matches");
        }
    }
}
