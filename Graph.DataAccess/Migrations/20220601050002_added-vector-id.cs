using Microsoft.EntityFrameworkCore.Migrations;

namespace Graph.DataAccess.Migrations
{
    public partial class addedvectorid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VectorId",
                table: "Relations",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VectorId",
                table: "Relations");
        }
    }
}
