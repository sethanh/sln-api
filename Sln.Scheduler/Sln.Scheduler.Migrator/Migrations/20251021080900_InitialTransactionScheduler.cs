using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sln.Payment.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class InitialTransactionScheduler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "job_info",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    job_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    job_event = table.Column<int>(type: "int", nullable: false),
                    job_type = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    object_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    transaction_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    job_status = table.Column<int>(type: "int", nullable: true),
                    data = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    send_time = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_info", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_job_info_object_id",
                table: "job_info",
                column: "object_id");

            migrationBuilder.CreateIndex(
                name: "ix_job_info_transaction_id",
                table: "job_info",
                column: "transaction_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "job_info");
        }
    }
}
