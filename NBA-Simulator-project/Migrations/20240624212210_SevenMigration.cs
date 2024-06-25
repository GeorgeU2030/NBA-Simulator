using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NBA_Simulator_project.Migrations
{
    /// <inheritdoc />
    public partial class SevenMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Seasons_SeasonId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Phase",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "SeasonId",
                table: "Matches",
                newName: "SerieId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_SeasonId",
                table: "Matches",
                newName: "IX_Matches_SerieId");

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SerieId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeasonId = table.Column<int>(type: "integer", nullable: false),
                    WinsHome = table.Column<int>(type: "integer", nullable: true),
                    WinsVisitor = table.Column<int>(type: "integer", nullable: true),
                    Phase = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.SerieId);
                    table.ForeignKey(
                        name: "FK_Series_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Series_SeasonId",
                table: "Series",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Series_SerieId",
                table: "Matches",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "SerieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Series_SerieId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.RenameColumn(
                name: "SerieId",
                table: "Matches",
                newName: "SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_SerieId",
                table: "Matches",
                newName: "IX_Matches_SeasonId");

            migrationBuilder.AddColumn<int>(
                name: "Phase",
                table: "Matches",
                type: "integer",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Seasons_SeasonId",
                table: "Matches",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
