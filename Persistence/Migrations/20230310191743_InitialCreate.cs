using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "Nombre de la meta"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 3, 10, 13, 17, 43, 367, DateTimeKind.Local).AddTicks(8209), comment: "Fecha de creación de la meta")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meta", x => x.Id);
                },
                comment: "Tabla de Metas");

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "Nombre de la tarea"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 3, 10, 13, 17, 43, 368, DateTimeKind.Local).AddTicks(794), comment: "Fecha de creación de la tarea"),
                    EsImportante = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Indicador de importancia de una tarea"),
                    Estado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Abierta", comment: "Estado de completado de la tarea"),
                    MetaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarea_Meta_MetaId",
                        column: x => x.MetaId,
                        principalTable: "Meta",
                        principalColumn: "Id");
                },
                comment: "Tabla de Tareas");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_Id",
                table: "Meta",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_Id",
                table: "Tarea",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_MetaId",
                table: "Tarea",
                column: "MetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Meta");
        }
    }
}
