using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedpaymenttype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodTypeId",
                table: "Participants",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PaymentMethodTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethodTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PaymentMethodTypeId",
                table: "Participants",
                column: "PaymentMethodTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_PaymentMethodTypes_PaymentMethodTypeId",
                table: "Participants",
                column: "PaymentMethodTypeId",
                principalTable: "PaymentMethodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_PaymentMethodTypes_PaymentMethodTypeId",
                table: "Participants");

            migrationBuilder.DropTable(
                name: "PaymentMethodTypes");

            migrationBuilder.DropIndex(
                name: "IX_Participants_PaymentMethodTypeId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "PaymentMethodTypeId",
                table: "Participants");
        }
    }
}
