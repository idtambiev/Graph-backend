using Microsoft.EntityFrameworkCore.Migrations;

namespace Graph.DataAccess.Migrations
{
    public partial class Fixesewrwerwerew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Oriented",
                table: "Relations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Oriented",
                table: "Relations");
        }
    }
}
