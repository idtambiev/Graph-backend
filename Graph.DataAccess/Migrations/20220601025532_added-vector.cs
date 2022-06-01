using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Graph.DataAccess.Migrations
{
    public partial class addedvector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GraphId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vectors_Graphs_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graphs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VectorItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    VectorId = table.Column<int>(type: "int", nullable: false),
                    VectorTowards = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VectorItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VectorItems_Vectors_VectorId",
                        column: x => x.VectorId,
                        principalTable: "Vectors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VectorItems_VectorId",
                table: "VectorItems",
                column: "VectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vectors_GraphId",
                table: "Vectors",
                column: "GraphId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VectorItems");

            migrationBuilder.DropTable(
                name: "Vectors");
        }
    }
}
