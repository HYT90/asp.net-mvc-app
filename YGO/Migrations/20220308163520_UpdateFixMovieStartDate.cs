using Microsoft.EntityFrameworkCore.Migrations;

namespace YGO.Migrations
{
    public partial class UpdateFixMovieStartDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StratDate",
                table: "Movies",
                newName: "StartDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Movies",
                newName: "StratDate");
        }
    }
}
