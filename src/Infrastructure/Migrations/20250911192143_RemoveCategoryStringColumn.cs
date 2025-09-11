using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpiManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCategoryStringColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Epis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Epis",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
