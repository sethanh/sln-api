using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sln.Management.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Update_Total_BoardTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "BoardTask",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "BoardTask");
        }
    }
}
