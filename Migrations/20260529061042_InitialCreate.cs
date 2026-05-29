using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HikoukiApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aircraft_type_codes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    icao = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    manufacturer = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aircraft_type_codes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "type_code_variants",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    aircraft_type_code_id = table.Column<int>(type: "integer", nullable: false),
                    variant_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_type_code_variants", x => x.id);
                    table.ForeignKey(
                        name: "fk_type_code_variants_aircraft_type_codes_aircraft_type_code_id",
                        column: x => x.aircraft_type_code_id,
                        principalTable: "aircraft_type_codes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_aircraft_type_codes_icao",
                table: "aircraft_type_codes",
                column: "icao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_type_code_variants_aircraft_type_code_id_variant_name",
                table: "type_code_variants",
                columns: new[] { "aircraft_type_code_id", "variant_name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "type_code_variants");

            migrationBuilder.DropTable(
                name: "aircraft_type_codes");
        }
    }
}
