using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlquilerAutos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ArregloTipoDeCombustible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdDescripcion",
                table: "TipoCombustibles",
                newName: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "TipoCombustibles",
                newName: "IdDescripcion");
        }
    }
}
