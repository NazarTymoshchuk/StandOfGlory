using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access.Migrations
{
    public partial class AddBattalions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Battalions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dzhokhar Dudayev Battalion" },
                    { 2, "Skala Battalion" },
                    { 3, "Sheikh Mansur Battalion" },
                    { 4, "Chechen volunteers on the side of Ukraine" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Battalions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Battalions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Battalions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Battalions",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
