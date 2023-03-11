using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateFunctions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var getTotalTareasFunction = System.IO.File.ReadAllText(@"Script//Functions/Metas/GetTotalTareas.sql");
            var getTotalTareasCompletadasFuntion = System.IO.File.ReadAllText(@"Script//Functions/Metas/GetTotalTareas.sql");
            var getTareasCompletionPercentageFunction = System.IO.File.ReadAllText(@"Script//Functions/Metas/GetTotalTareas.sql");

            migrationBuilder.Sql(getTotalTareasFunction);
            migrationBuilder.Sql(getTotalTareasCompletadasFuntion);
            migrationBuilder.Sql(getTareasCompletionPercentageFunction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION dbo.GetTotalTareas");
            migrationBuilder.Sql("DROP FUNCTION dbo.GetTotalTareasCompletadas");
            migrationBuilder.Sql("DROP FUNCTION dbo.GetTareasCompletionPercentage");
        }
    }
}
