using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookProject.Resource.Api.Migrations
{
    public partial class EditEntityBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Books");
        }
    }
}
