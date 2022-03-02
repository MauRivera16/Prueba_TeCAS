using Microsoft.EntityFrameworkCore.Migrations;

namespace Prueba_TeCAS.Migrations
{
    public partial class modelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    ApellidoP = table.Column<string>(nullable: false),
                    ApellidoM = table.Column<string>(nullable: false),
                    Genero = table.Column<string>(nullable: false),
                    Matricula = table.Column<string>(maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CuentasAhorro",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente_id = table.Column<int>(nullable: false),
                    Saldo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasAhorro", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CuentasAhorro_Clientes_Cliente_id",
                        column: x => x.Cliente_id,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentasAhorro_Cliente_id",
                table: "CuentasAhorro",
                column: "Cliente_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuentasAhorro");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
