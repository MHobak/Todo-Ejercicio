using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EnableCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Meta_MetaId",
                table: "Tarea");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Meta_MetaId",
                table: "Tarea",
                column: "MetaId",
                principalTable: "Meta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Meta_MetaId",
                table: "Tarea");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Meta_MetaId",
                table: "Tarea",
                column: "MetaId",
                principalTable: "Meta",
                principalColumn: "Id");
        }
    }
}
