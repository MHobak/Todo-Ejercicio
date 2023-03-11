using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMetaView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW [dbo].[MetaView] AS
                SELECT Id, Nombre, FechaCreacion, 
                (dbo.GetTotalTareas(Id)) AS TotalTareas,
                (dbo.GetTotalTareasCompletadas(Id)) AS TareasCompletadas,
                (dbo.GetTareasCompletionPercentage(Id)) AS PorcentajeCumplimiento
                FROM [dbo].[Meta]
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.MetaView");
        }
    }
}
