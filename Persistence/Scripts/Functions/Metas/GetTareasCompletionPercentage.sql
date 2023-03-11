CREATE FUNCTION dbo.GetTareasCompletionPercentage(@MetaId INT)
RETURNS INT
AS
BEGIN
    DECLARE @Total DECIMAL(5,2);
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

