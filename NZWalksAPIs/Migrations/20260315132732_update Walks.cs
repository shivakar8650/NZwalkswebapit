using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalksAPIs.Migrations
{
    /// <inheritdoc />
    public partial class updateWalks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalksProperties_Regionspoperties_RegionsId",
                table: "WalksProperties");

            migrationBuilder.DropIndex(
                name: "IX_WalksProperties_RegionsId",
                table: "WalksProperties");

            migrationBuilder.DropColumn(
                name: "RegionsId",
                table: "WalksProperties");

            migrationBuilder.CreateIndex(
                name: "IX_WalksProperties_RegionId",
                table: "WalksProperties",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_WalksProperties_Regionspoperties_RegionId",
                table: "WalksProperties",
                column: "RegionId",
                principalTable: "Regionspoperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalksProperties_Regionspoperties_RegionId",
                table: "WalksProperties");

            migrationBuilder.DropIndex(
                name: "IX_WalksProperties_RegionId",
                table: "WalksProperties");

            migrationBuilder.AddColumn<Guid>(
                name: "RegionsId",
                table: "WalksProperties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WalksProperties_RegionsId",
                table: "WalksProperties",
                column: "RegionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_WalksProperties_Regionspoperties_RegionsId",
                table: "WalksProperties",
                column: "RegionsId",
                principalTable: "Regionspoperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
