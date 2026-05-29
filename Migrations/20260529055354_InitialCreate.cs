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
                name: "AircraftTypeCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Icao = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftTypeCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeCodeVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AircraftTypeCodeId = table.Column<int>(type: "integer", nullable: false),
                    VariantName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCodeVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeCodeVariants_AircraftTypeCodes_AircraftTypeCodeId",
                        column: x => x.AircraftTypeCodeId,
                        principalTable: "AircraftTypeCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AircraftTypeCodes_Icao",
                table: "AircraftTypeCodes",
                column: "Icao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeCodeVariants_AircraftTypeCodeId_VariantName",
                table: "TypeCodeVariants",
                columns: new[] { "AircraftTypeCodeId", "VariantName" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeCodeVariants");

            migrationBuilder.DropTable(
                name: "AircraftTypeCodes");
        }
    }
}
