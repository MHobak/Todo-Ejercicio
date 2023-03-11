CREATE FUNCTION dbo.GetTareasCompletionPercentage(@MetaId INT)
RETURNS DECIMAL(5,2)
AS
BEGIN
    DECLARE @Total DECIMAL(5,2);
    SET @Total = (
        SELECT 
			(
				CASE
				-- Si las tareas de la meta = 0 regresar 0 para no dividir entre 0
				WHEN (SELECT COUNT(1) FROM Tarea WHERE Tarea.MetaId = @MetaId) = 0.0 THEN 0.0 
				ELSE (
				--dividir la cantidad de tareas completadas entre el total
					(SELECT COUNT(1) FROM Tarea WHERE Tarea.MetaId = @MetaId AND Tarea.Estado = 'Completada') * 100.0 / 
					(SELECT COUNT(1) FROM Tarea WHERE Tarea.MetaId = @MetaId)
				) END
			)
		)
    RETURN @Total
END

