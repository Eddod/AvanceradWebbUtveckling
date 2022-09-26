using Microsoft.EntityFrameworkCore.Migrations;

namespace AvanceradWebbUtveckling.Migrations
{
    public partial class PropertiesAddedToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountOfBooks",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfBooks",
                table: "Books");
        }
    }
}
