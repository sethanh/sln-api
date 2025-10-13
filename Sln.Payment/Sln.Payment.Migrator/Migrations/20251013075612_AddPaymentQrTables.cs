using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sln.Payment.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentQrTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PaymentQrTransaction");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PaymentQr");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "PaymentQrTransaction",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PaymentQrTransaction",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<long>(
                name: "PaymentQrId",
                table: "PaymentQrTransaction",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "PaymentQr",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AccountNo",
                table: "PaymentQr",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "BinCode",
                table: "PaymentQr",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PaymentQr",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentQrTransaction_PaymentQrId",
                table: "PaymentQrTransaction",
                column: "PaymentQrId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentQrTransaction_PaymentQr_PaymentQrId",
                table: "PaymentQrTransaction",
                column: "PaymentQrId",
                principalTable: "PaymentQr",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentQrTransaction_PaymentQr_PaymentQrId",
                table: "PaymentQrTransaction");

            migrationBuilder.DropIndex(
                name: "IX_PaymentQrTransaction_PaymentQrId",
                table: "PaymentQrTransaction");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PaymentQrTransaction");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PaymentQrTransaction");

            migrationBuilder.DropColumn(
                name: "PaymentQrId",
                table: "PaymentQrTransaction");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "PaymentQr");

            migrationBuilder.DropColumn(
                name: "AccountNo",
                table: "PaymentQr");

            migrationBuilder.DropColumn(
                name: "BinCode",
                table: "PaymentQr");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PaymentQr");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PaymentQrTransaction",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PaymentQr",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
