using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPIs.Migrations
{
    /// <inheritdoc />
    public partial class Seeddataforregionanddifficulty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Deficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0d914a9a-eb9a-43ce-8193-30c55d1ac8ac"), "Easy" },
                    { new Guid("614ffc6f-81f6-4d1d-bc99-58aff329f3b1"), "Medium" },
                    { new Guid("e89da2b2-3be3-4761-8d90-00371b8ca5b8"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regionspoperties",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0d914a9a-eb9a-43ce-8193-30c55d1ac8ac"), "AKL", "Auckland", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Auckland_skyline_from_Mt_Eden.jpg/2560px-Auckland_skyline_from_Mt_Eden.jpg" },
                    { new Guid("614ffc6f-81f6-4d1d-bc99-58aff329f3b1"), "WLG", "Wellington", "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7e/Wellington_City.jpg/2560px-Wellington_City.jpg" },
                    { new Guid("e89da2b2-3be3-4761-8d90-00371b8ca5b8"), "CHC", "Christchurch", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/Christchurch_Cathedral_Square.jpg/2560px-Christchurch_Cathedral_Square.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Deficulties",
                keyColumn: "Id",
                keyValue: new Guid("0d914a9a-eb9a-43ce-8193-30c55d1ac8ac"));

            migrationBuilder.DeleteData(
                table: "Deficulties",
                keyColumn: "Id",
                keyValue: new Guid("614ffc6f-81f6-4d1d-bc99-58aff329f3b1"));

            migrationBuilder.DeleteData(
                table: "Deficulties",
                keyColumn: "Id",
                keyValue: new Guid("e89da2b2-3be3-4761-8d90-00371b8ca5b8"));

            migrationBuilder.DeleteData(
                table: "Regionspoperties",
                keyColumn: "Id",
                keyValue: new Guid("0d914a9a-eb9a-43ce-8193-30c55d1ac8ac"));

            migrationBuilder.DeleteData(
                table: "Regionspoperties",
                keyColumn: "Id",
                keyValue: new Guid("614ffc6f-81f6-4d1d-bc99-58aff329f3b1"));

            migrationBuilder.DeleteData(
                table: "Regionspoperties",
                keyColumn: "Id",
                keyValue: new Guid("e89da2b2-3be3-4761-8d90-00371b8ca5b8"));
        }
    }
}
