---Crea un triger para poder insertar valores en una tabla con campos calculados en case de que no deje insertar
CREATE TRIGGER SetComputedColumnValue
ON Meta
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Meta (Nombre, FechaCreacion, TotalTareas, TareasCompletadas, PorcentajeCumplimiento)
    SELECT Nombre, FechaCreacion, (select dbo.GetTotalTareas(inserted.Id)), 
    (select dbo.GetTotalTareasCompletadas(inserted.Id)),
    (select dbo.GetTareasCompletionPercentage(inserted.Id))
    FROM inserted
END