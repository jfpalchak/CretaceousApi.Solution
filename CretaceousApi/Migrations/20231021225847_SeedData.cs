using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CretaceousApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Name", "Species" },
                values: new object[,]
                {
                    { 1, 7, "Matilda", "Woolly Mammoth" },
                    { 2, 10, "Rexie", "Dinosaur" },
                    { 3, 2, "Matilda", "Dinosaur" },
                    { 4, 4, "Pip", "Shark" },
                    { 5, 22, "Bartholomew", "Dinosaur" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 5);
        }
    }
}
