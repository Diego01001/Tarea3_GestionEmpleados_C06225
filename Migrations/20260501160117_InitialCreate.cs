using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tarea3_GestionEmpleados_C06225.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    Apellidos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Departamento = table.Column<string>(type: "TEXT", nullable: false),
                    Salario = table.Column<decimal>(type: "TEXT", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "Activo", "Apellidos", "Departamento", "FechaIngreso", "Nombre", "Salario" },
                values: new object[,]
                {
                    { 1, true, "Pérez", "TI", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", 850000m },
                    { 2, true, "Rodríguez", "RRHH", new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", 600000m },
                    { 3, true, "Sánchez", "TI", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos", 950000m },
                    { 4, true, "López", "Contabilidad", new DateTime(2020, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana", 550000m },
                    { 5, true, "García", "TI", new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis", 1200000m },
                    { 6, true, "Martínez", "Ventas", new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elena", 450000m },
                    { 7, true, "Gómez", "Marketing", new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", 700000m },
                    { 8, true, "Vargas", "RRHH", new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofía", 620000m },
                    { 9, true, "Castro", "TI", new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego", 1500000m },
                    { 10, true, "Mora", "Ventas", new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucía", 480000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
