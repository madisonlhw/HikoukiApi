using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HikoukiApi.Migrations
{
    /// <inheritdoc />
    public partial class _30may264 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airplanes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    registration = table.Column<string>(type: "text", nullable: false),
                    aircraft_type_code_id = table.Column<int>(type: "integer", nullable: false),
                    type_code_variant_id = table.Column<int>(type: "integer", nullable: true),
                    serial_number = table.Column<string>(type: "text", nullable: false),
                    line_number = table.Column<string>(type: "text", nullable: true),
                    airline_id = table.Column<int>(type: "integer", nullable: true),
                    alternate_operator_name = table.Column<string>(type: "text", nullable: true),
                    is_gov_or_military = table.Column<bool>(type: "boolean", nullable: false),
                    is_special_livery = table.Column<bool>(type: "boolean", nullable: false),
                    special_livery_name = table.Column<string>(type: "text", nullable: true),
                    remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_airplanes", x => x.id);
                    table.ForeignKey(
                        name: "fk_airplanes_aircraft_type_codes_aircraft_type_code_id",
                        column: x => x.aircraft_type_code_id,
                        principalTable: "aircraft_type_codes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_airplanes_airlines_airline_id",
                        column: x => x.airline_id,
                        principalTable: "airlines",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_airplanes_type_code_variants_type_code_variant_id",
                        column: x => x.type_code_variant_id,
                        principalTable: "type_code_variants",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_airplanes_aircraft_type_code_id",
                table: "airplanes",
                column: "aircraft_type_code_id");

            migrationBuilder.CreateIndex(
                name: "ix_airplanes_airline_id",
                table: "airplanes",
                column: "airline_id");

            migrationBuilder.CreateIndex(
                name: "ix_airplanes_type_code_variant_id",
                table: "airplanes",
                column: "type_code_variant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "airplanes");
        }
    }
}
