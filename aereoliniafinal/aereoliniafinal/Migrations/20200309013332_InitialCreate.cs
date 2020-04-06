using Microsoft.EntityFrameworkCore.Migrations;

namespace aereoliniafinal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aviones",
                columns: table => new
                {
                    AvionesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(nullable: false),
                    Eye = table.Column<string>(nullable: false),
                    Capacidad = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviones", x => x.AvionesID);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    PaisID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.PaisID);
                });

            migrationBuilder.CreateTable(
                name: "TipoEmpleado",
                columns: table => new
                {
                    TipoEmpleadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmpleado", x => x.TipoEmpleadoID);
                });

            migrationBuilder.CreateTable(
                name: "TipoSexo",
                columns: table => new
                {
                    TipoSexoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sexo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSexo", x => x.TipoSexoID);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    CiudadesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    PaisID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.CiudadesID);
                    table.ForeignKey(
                        name: "FK_Ciudades_Pais_PaisID",
                        column: x => x.PaisID,
                        principalTable: "Pais",
                        principalColumn: "PaisID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    TipoEmpleadoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadosID);
                    table.ForeignKey(
                        name: "FK_Empleados_TipoEmpleado_TipoEmpleadoID",
                        column: x => x.TipoEmpleadoID,
                        principalTable: "TipoEmpleado",
                        principalColumn: "TipoEmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    PaisID = table.Column<int>(nullable: false),
                    TipoSexoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                    table.ForeignKey(
                        name: "FK_Cliente_Pais_PaisID",
                        column: x => x.PaisID,
                        principalTable: "Pais",
                        principalColumn: "PaisID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cliente_TipoSexo_TipoSexoID",
                        column: x => x.TipoSexoID,
                        principalTable: "TipoSexo",
                        principalColumn: "TipoSexoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vuelos",
                columns: table => new
                {
                    VuelosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    FechaSalida = table.Column<string>(nullable: false),
                    FechaLlegada = table.Column<string>(nullable: false),
                    AvionesID = table.Column<int>(nullable: false),
                    CiudadesID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.VuelosID);
                    table.ForeignKey(
                        name: "FK_Vuelos_Aviones_AvionesID",
                        column: x => x.AvionesID,
                        principalTable: "Aviones",
                        principalColumn: "AvionesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vuelos_Ciudades_CiudadesID",
                        column: x => x.CiudadesID,
                        principalTable: "Ciudades",
                        principalColumn: "CiudadesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_PaisID",
                table: "Ciudades",
                column: "PaisID");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PaisID",
                table: "Cliente",
                column: "PaisID");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_TipoSexoID",
                table: "Cliente",
                column: "TipoSexoID");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_TipoEmpleadoID",
                table: "Empleados",
                column: "TipoEmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_AvionesID",
                table: "Vuelos",
                column: "AvionesID");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_CiudadesID",
                table: "Vuelos",
                column: "CiudadesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Vuelos");

            migrationBuilder.DropTable(
                name: "TipoSexo");

            migrationBuilder.DropTable(
                name: "TipoEmpleado");

            migrationBuilder.DropTable(
                name: "Aviones");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
