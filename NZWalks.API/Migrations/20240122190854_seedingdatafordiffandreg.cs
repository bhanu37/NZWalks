using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class seedingdatafordiffandreg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficultys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5b974dfc-f341-4f96-b806-5a33d9fab18e"), "Easy" },
                    { new Guid("67fcfa6a-9c3d-425b-a529-74c017fedbd1"), "Hard" },
                    { new Guid("e941cda3-902d-4088-a349-3f04390454ec"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("36a7d891-22e5-4f3b-8a56-61b92a58d7c2"), "BOP", "Bay of Plenty", "SomeBopImage.jpg" },
                    { new Guid("68fd2b61-45a7-4c92-b81a-9dfb85a1d3e5"), "AKL", "Auckland", "SomeAucklandImage.jpg" },
                    { new Guid("8f462aa2-6152-48a5-b6ef-3d90b8f76b8f"), "STL", "Southland", "SomeSouthlandImage.jpg" },
                    { new Guid("a5e37c91-7f9d-45b1-b7cc-c0a3f2a6bd8e"), "NSN", "Nelson", "SomeNelsonImage.jpg" },
                    { new Guid("d4320f6b-9f2c-4ee4-a9db-815e02b7c5e1"), "WLG", "Wellington", "SomeWellingtonImage.jpg" },
                    { new Guid("e9c4f3a8-7bcf-473d-b0d8-2c9d3feef98d"), "NTL", "Northland", "SomeNorthlandImage.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficultys",
                keyColumn: "Id",
                keyValue: new Guid("5b974dfc-f341-4f96-b806-5a33d9fab18e"));

            migrationBuilder.DeleteData(
                table: "Difficultys",
                keyColumn: "Id",
                keyValue: new Guid("67fcfa6a-9c3d-425b-a529-74c017fedbd1"));

            migrationBuilder.DeleteData(
                table: "Difficultys",
                keyColumn: "Id",
                keyValue: new Guid("e941cda3-902d-4088-a349-3f04390454ec"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("36a7d891-22e5-4f3b-8a56-61b92a58d7c2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("68fd2b61-45a7-4c92-b81a-9dfb85a1d3e5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8f462aa2-6152-48a5-b6ef-3d90b8f76b8f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a5e37c91-7f9d-45b1-b7cc-c0a3f2a6bd8e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d4320f6b-9f2c-4ee4-a9db-815e02b7c5e1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e9c4f3a8-7bcf-473d-b0d8-2c9d3feef98d"));
        }
    }
}
