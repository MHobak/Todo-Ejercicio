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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION dbo.GetTotalTareas");
            migrationBuilder.Sql("DROP FUNCTION dbo.GetTotalTareasCompletadas");
        }
    }
}
