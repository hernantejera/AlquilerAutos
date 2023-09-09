using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlquilerAutos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_IdTipoCombustible",
                table: "Vehiculo",
                column: "IdTipoCombustible");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdUsuario",
                table: "Reservas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdVehiculo",
                table: "Reservas",
                column: "IdVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdFormaDePago",
                table: "Pagos",
                column: "IdFormaDePago");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdReserva",
                table: "Pagos",
                column: "IdReserva");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_FormaDePagos_IdFormaDePago",
                table: "Pagos",
                column: "IdFormaDePago",
                principalTable: "FormaDePagos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Reservas_IdReserva",
                table: "Pagos",
                column: "IdReserva",
                principalTable: "Reservas",
                principalColumn: "IdReserva",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Usuarios_IdUsuario",
                table: "Reservas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Vehiculo_IdVehiculo",
                table: "Reservas",
                column: "IdVehiculo",
                principalTable: "Vehiculo",
                principalColumn: "IdVehiculo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculo_TipoCombustibles_IdTipoCombustible",
                table: "Vehiculo",
                column: "IdTipoCombustible",
                principalTable: "TipoCombustibles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_FormaDePagos_IdFormaDePago",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Reservas_IdReserva",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_IdUsuario",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Vehiculo_IdVehiculo",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculo_TipoCombustibles_IdTipoCombustible",
                table: "Vehiculo");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculo_IdTipoCombustible",
                table: "Vehiculo");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_IdUsuario",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_IdVehiculo",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_IdFormaDePago",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_IdReserva",
                table: "Pagos");
        }
    }
}
