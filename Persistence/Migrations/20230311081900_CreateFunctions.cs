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
            migrationBuilder.Sql(@"
                CREATE FUNCTION dbo.GetTotalTareas(@MetaId INT)
                RETURNS INT
                AS
                BEGIN
                    DECLARE @Total iNT;
                    SET @Total = (SELECT COUNT(1) FROM Tarea WHERE MetaId = @MetaId)
                    RETURN @Total
                END
            ");

            migrationBuilder.Sql(@"
                CREATE FUNCTION dbo.GetTotalTareasCompletadas(@MetaId INT)
                RETURNS INT
                AS
                BEGIN
                    DECLARE @Total iNT;
                    SET @Total = (SELECT COUNT(1) FROM Tarea WHERE MetaId = @MetaId AND Estado = 'Completada')
                    RETURN @Total
                END
            ");

            migrationBuilder.Sql(@"
                CREATE FUNCTION dbo.GetTareasCompletionPercentage(@MetaId INT)
                RETURNS INT
                AS
                BEGIN
                    DECLARE @Total iNT;
                    SET @Total = (
                        SELECT CAST(
			                (CASE 
			                WHEN (SELECT COUNT(1) FROM Tarea WHERE Tarea.MetaId = @MetaId) = 0 THEN 0 -- Si las tareas de la meta = 0 regresar 0 para no dividir entre 0
			                ELSE (
				                (SELECT COUNT(1) FROM Tarea WHERE Tarea.MetaId = @MetaId AND Tarea.Estado = 'Completada') * 100.0 / --dividir la cantidad de tareas completadas entre el total
				                (SELECT COUNT(1) FROM Tarea WHERE Tarea.MetaId = @MetaId)
			                ) END) AS DECIMAL(5,2) 
		                )
                    )
                    RETURN @Total
                END
            ");
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
