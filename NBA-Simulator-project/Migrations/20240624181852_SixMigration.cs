using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBA_Simulator_project.Migrations
{
    /// <inheritdoc />
    public partial class SixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Phase",
                table: "Matches",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phase",
                table: "Matches");
        }
    }
}
