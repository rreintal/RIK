using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class secondMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParticipantType",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "PaymentMethodType",
                table: "Participants");

            migrationBuilder.AddColumn<Guid>(
                name: "ParticipantTypeId",
                table: "Participants",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodTypeId",
                table: "Participants",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ParticipantType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethodType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethodType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ParticipantTypeId",
                table: "Participants",
                column: "ParticipantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PaymentMethodTypeId",
                table: "Participants",
                column: "PaymentMethodTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_ParticipantType_ParticipantTypeId",
                table: "Participants",
                column: "ParticipantTypeId",
                principalTable: "ParticipantType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_PaymentMethodType_PaymentMethodTypeId",
                table: "Participants",
                column: "PaymentMethodTypeId",
                principalTable: "PaymentMethodType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_ParticipantType_ParticipantTypeId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_PaymentMethodType_PaymentMethodTypeId",
                table: "Participants");

            migrationBuilder.DropTable(
                name: "ParticipantType");

            migrationBuilder.DropTable(
                name: "PaymentMethodType");

            migrationBuilder.DropIndex(
                name: "IX_Participants_ParticipantTypeId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_PaymentMethodTypeId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "ParticipantTypeId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "PaymentMethodTypeId",
                table: "Participants");

            migrationBuilder.AddColumn<int>(
                name: "ParticipantType",
                table: "Participants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodType",
                table: "Participants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
