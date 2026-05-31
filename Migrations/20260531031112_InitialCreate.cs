using System;
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
                name: "airlines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    iata = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    icao = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_airlines", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "airports",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    iata = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    icao = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    alternate_name = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_airports", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "aircraft_spotting",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    aircraft_id = table.Column<int>(type: "integer", nullable: false),
                    type_code_variant_id = table.Column<int>(type: "integer", nullable: true),
                    airline_id = table.Column<int>(type: "integer", nullable: true),
                    airport_id = table.Column<int>(type: "integer", nullable: true),
                    airport_location = table.Column<string>(type: "text", nullable: false),
                    camera = table.Column<string>(type: "text", nullable: false),
                    lens = table.Column<string>(type: "text", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aircraft_spotting", x => x.id);
                    table.ForeignKey(
                        name: "fk_aircraft_spotting_airlines_airline_id",
                        column: x => x.airline_id,
                        principalTable: "airlines",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_aircraft_spotting_airplanes_aircraft_id",
                        column: x => x.aircraft_id,
                        principalTable: "airplanes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_aircraft_spotting_airports_airport_id",
                        column: x => x.airport_id,
                        principalTable: "airports",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_aircraft_spotting_type_code_variants_type_code_variant_id",
                        column: x => x.type_code_variant_id,
                        principalTable: "type_code_variants",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_aircraft_spotting_aircraft_id",
                table: "aircraft_spotting",
                column: "aircraft_id");

            migrationBuilder.CreateIndex(
                name: "ix_aircraft_spotting_airline_id",
                table: "aircraft_spotting",
                column: "airline_id");

            migrationBuilder.CreateIndex(
                name: "ix_aircraft_spotting_airport_id",
                table: "aircraft_spotting",
                column: "airport_id");

            migrationBuilder.CreateIndex(
                name: "ix_aircraft_spotting_type_code_variant_id",
                table: "aircraft_spotting",
                column: "type_code_variant_id");

            migrationBuilder.CreateIndex(
                name: "ix_aircraft_type_codes_icao",
                table: "aircraft_type_codes",
                column: "icao",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "ix_airports_iata",
                table: "airports",
                column: "iata",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_airports_icao",
                table: "airports",
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
                name: "aircraft_spotting");

            migrationBuilder.DropTable(
                name: "airplanes");

            migrationBuilder.DropTable(
                name: "airports");

            migrationBuilder.DropTable(
                name: "airlines");

            migrationBuilder.DropTable(
                name: "type_code_variants");

            migrationBuilder.DropTable(
                name: "aircraft_type_codes");
        }
    }
}
