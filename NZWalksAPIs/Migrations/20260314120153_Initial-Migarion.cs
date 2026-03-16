using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalksAPIs.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigarion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deficulties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regionspoperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regionspoperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalksProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LenghtInKm = table.Column<double>(type: "float", nullable: false),
                    WalkImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalksProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalksProperties_Deficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Deficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalksProperties_Regionspoperties_RegionsId",
                        column: x => x.RegionsId,
                        principalTable: "Regionspoperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WalksProperties_DifficultyId",
                table: "WalksProperties",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_WalksProperties_RegionsId",
                table: "WalksProperties",
                column: "RegionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalksProperties");

            migrationBuilder.DropTable(
                name: "Deficulties");

            migrationBuilder.DropTable(
                name: "Regionspoperties");
        }
    }
}
