using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tb_techtales_api.Migrations
{
    /// <inheritdoc />
    public partial class AddGithubLinkToProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GithubLink",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GithubLink",
                table: "Projects");
        }
    }
}
