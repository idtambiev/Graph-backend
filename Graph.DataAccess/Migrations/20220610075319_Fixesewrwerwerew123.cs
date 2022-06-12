using Microsoft.EntityFrameworkCore.Migrations;

namespace Graph.DataAccess.Migrations
{
    public partial class Fixesewrwerwerew123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Relations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Relations");
        }
    }
}
