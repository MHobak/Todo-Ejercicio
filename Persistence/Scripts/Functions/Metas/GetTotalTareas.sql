CREATE FUNCTION dbo.GetTotalTareas(@MetaId INT)
RETURNS INT
AS
BEGIN
    DECLARE @Total iNT;
    SET @Total = (SELECT COUNT(1) FROM Tarea WHERE MetaId = @MetaId)
    RETURN @Total
END