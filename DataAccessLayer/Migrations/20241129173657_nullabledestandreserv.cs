using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class nullabledestandreserv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservationns_Destinations_DestinationId",
                table: "Reservationns");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationId",
                table: "Reservationns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservationns_Destinations_DestinationId",
                table: "Reservationns",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservationns_Destinations_DestinationId",
                table: "Reservationns");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationId",
                table: "Reservationns",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservationns_Destinations_DestinationId",
                table: "Reservationns",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId");
        }
    }
}
