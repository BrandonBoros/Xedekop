using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xedekop.Server.Migrations
{
    /// <inheritdoc />
    public partial class fixedorderitemagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Pokemons_PokemonId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_PokemonId",
                table: "OrderItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_PokemonId",
                table: "OrderItem",
                column: "PokemonId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Pokemons_PokemonId",
                table: "OrderItem",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
