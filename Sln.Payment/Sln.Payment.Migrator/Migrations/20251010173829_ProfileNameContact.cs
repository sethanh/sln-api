using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sln.Payment.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class ProfileNameContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileName",
                table: "Contact",
                type: "varchar(88)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ProfileName",
                table: "Contact",
                column: "ProfileName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contact_ProfileName",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ProfileName",
                table: "Contact");
        }
    }
}
