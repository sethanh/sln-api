using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sln.Payment.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class InitConnectMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "Account",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "AccountConnection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AccountRequestId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    AccountAcceptId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModificationId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountConnection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountConnection_Account_AccountAcceptId",
                        column: x => x.AccountAcceptId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountConnection_Account_AccountRequestId",
                        column: x => x.AccountRequestId,
                        principalTable: "Account",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AccountNotification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Action = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Body = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReferenceId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ReferenceObjectName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    BodyJson = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReadAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModificationId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountNotification_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Account_PhotoId",
                table: "Account",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountConnection_AccountAcceptId",
                table: "AccountConnection",
                column: "AccountAcceptId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountConnection_AccountRequestId",
                table: "AccountConnection",
                column: "AccountRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountNotification_AccountId",
                table: "AccountNotification",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Photo_PhotoId",
                table: "Account",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Photo_PhotoId",
                table: "Account");

            migrationBuilder.DropTable(
                name: "AccountConnection");

            migrationBuilder.DropTable(
                name: "AccountNotification");

            migrationBuilder.DropIndex(
                name: "IX_Account_PhotoId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Account");
        }
    }
}
