using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_ParticipantType_ParticipantTypeId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_PaymentMethodType_PaymentMethodTypeId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethodType",
                table: "PaymentMethodType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipantType",
                table: "ParticipantType");

            migrationBuilder.RenameTable(
                name: "PaymentMethodType",
                newName: "PaymentMethodTypes");

            migrationBuilder.RenameTable(
                name: "ParticipantType",
                newName: "ParticipantTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethodTypes",
                table: "PaymentMethodTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipantTypes",
                table: "ParticipantTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_ParticipantTypes_ParticipantTypeId",
                table: "Participants",
                column: "ParticipantTypeId",
                principalTable: "ParticipantTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Participants_ParticipantTypes_ParticipantTypeId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_PaymentMethodTypes_PaymentMethodTypeId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethodTypes",
                table: "PaymentMethodTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipantTypes",
                table: "ParticipantTypes");

            migrationBuilder.RenameTable(
                name: "PaymentMethodTypes",
                newName: "PaymentMethodType");

            migrationBuilder.RenameTable(
                name: "ParticipantTypes",
                newName: "ParticipantType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethodType",
                table: "PaymentMethodType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipantType",
                table: "ParticipantType",
                column: "Id");

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
    }
}
