using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikoukiApi.Migrations
{
    /// <inheritdoc />
    public partial class _30may263 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "airports",
                type: "character varying(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "country",
                table: "airports");
        }
    }
}
