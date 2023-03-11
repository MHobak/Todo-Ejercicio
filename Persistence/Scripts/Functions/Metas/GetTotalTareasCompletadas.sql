CREATE FUNCTION dbo.GetTotalTareasCompletadas(@MetaId INT)
RETURNS INT
AS
BEGIN
    DECLARE @Total iNT;
    SET @Total = (SELECT COUNT(1) FROM Tarea WHERE MetaId = @MetaId AND Estado = 'Completada')
    RETURN @Total
END