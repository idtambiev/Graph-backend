using Microsoft.EntityFrameworkCore.Migrations;

namespace Graph.DataAccess.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vectors_Graphs_GraphId",
                table: "Vectors");

            migrationBuilder.DropIndex(
                name: "IX_Vectors_GraphId",
                table: "Vectors");

            migrationBuilder.RenameColumn(
                name: "GraphId",
                table: "Vectors",
                newName: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vectors_RelationId",
                table: "Vectors",
                column: "RelationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vectors_Relations_RelationId",
                table: "Vectors",
                column: "RelationId",
                principalTable: "Relations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vectors_Relations_RelationId",
                table: "Vectors");

            migrationBuilder.DropIndex(
                name: "IX_Vectors_RelationId",
                table: "Vectors");

            migrationBuilder.RenameColumn(
                name: "RelationId",
                table: "Vectors",
                newName: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Vectors_GraphId",
                table: "Vectors",
                column: "GraphId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vectors_Graphs_GraphId",
                table: "Vectors",
                column: "GraphId",
                principalTable: "Graphs",
                principalColumn: "Id");
        }
    }
}
