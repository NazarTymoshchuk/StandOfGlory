using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access.Migrations
{
    public partial class RenameDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Battalions_BattalionId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cards_CardId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_CityId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Heroes");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CityId",
                table: "Heroes",
                newName: "IX_Heroes_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CardId",
                table: "Heroes",
                newName: "IX_Heroes_CardId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_BattalionId",
                table: "Heroes",
                newName: "IX_Heroes_BattalionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heroes",
                table: "Heroes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Battalions_BattalionId",
                table: "Heroes",
                column: "BattalionId",
                principalTable: "Battalions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Cards_CardId",
                table: "Heroes",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Cities_CityId",
                table: "Heroes",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Battalions_BattalionId",
                table: "Heroes");

            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Cards_CardId",
                table: "Heroes");

            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Cities_CityId",
                table: "Heroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heroes",
                table: "Heroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Heroes",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "Genres");

            migrationBuilder.RenameIndex(
                name: "IX_Heroes_CityId",
                table: "Movies",
                newName: "IX_Movies_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Heroes_CardId",
                table: "Movies",
                newName: "IX_Movies_CardId");

            migrationBuilder.RenameIndex(
                name: "IX_Heroes_BattalionId",
                table: "Movies",
                newName: "IX_Movies_BattalionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Battalions_BattalionId",
                table: "Movies",
                column: "BattalionId",
                principalTable: "Battalions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cards_CardId",
                table: "Movies",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_CityId",
                table: "Movies",
                column: "CityId",
                principalTable: "Genres",
                principalColumn: "Id");
        }
    }
}
