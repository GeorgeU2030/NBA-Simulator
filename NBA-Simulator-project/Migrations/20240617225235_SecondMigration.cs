using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBA_Simulator_project.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Seasons_SeasonId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Teams_HomeTeamId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Teams_VisitorTeamId",
                table: "Match");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Match",
                table: "Match");

            migrationBuilder.RenameTable(
                name: "Match",
                newName: "Matches");

            migrationBuilder.RenameIndex(
                name: "IX_Match_VisitorTeamId",
                table: "Matches",
                newName: "IX_Matches_VisitorTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_SeasonId",
                table: "Matches",
                newName: "IX_Matches_SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_HomeTeamId",
                table: "Matches",
                newName: "IX_Matches_HomeTeamId");

            migrationBuilder.AddColumn<string>(
                name: "Conference",
                table: "SeasonTeams",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Division",
                table: "SeasonTeams",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Seasons_SeasonId",
                table: "Matches",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_VisitorTeamId",
                table: "Matches",
                column: "VisitorTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Seasons_SeasonId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_HomeTeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_VisitorTeamId",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Conference",
                table: "SeasonTeams");

            migrationBuilder.DropColumn(
                name: "Division",
                table: "SeasonTeams");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "Match");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_VisitorTeamId",
                table: "Match",
                newName: "IX_Match_VisitorTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_SeasonId",
                table: "Match",
                newName: "IX_Match_SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_HomeTeamId",
                table: "Match",
                newName: "IX_Match_HomeTeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Match",
                table: "Match",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Seasons_SeasonId",
                table: "Match",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Teams_HomeTeamId",
                table: "Match",
                column: "HomeTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Teams_VisitorTeamId",
                table: "Match",
                column: "VisitorTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
