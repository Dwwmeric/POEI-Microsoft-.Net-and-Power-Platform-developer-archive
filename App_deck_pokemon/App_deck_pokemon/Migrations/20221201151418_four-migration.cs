using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appdeckpokemon.Migrations
{
    /// <inheritdoc />
    public partial class fourmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pokemon",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(name: "full_name", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "url_pokemon",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pokemonid = table.Column<int>(name: "pokemon_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_url_pokemon", x => x.id);
                    table.ForeignKey(
                        name: "FK_url_pokemon_pokemon_pokemon_id",
                        column: x => x.pokemonid,
                        principalTable: "pokemon",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_url_pokemon_pokemon_id",
                table: "url_pokemon",
                column: "pokemon_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "url_pokemon");

            migrationBuilder.DropTable(
                name: "pokemon");
        }
    }
}
