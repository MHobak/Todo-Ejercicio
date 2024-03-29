CREATE DATABASE [TodoDB]
GO

USE [TodoDB]
GO
/****** Object:  UserDefinedFunction [dbo].[GetTareasCompletionPercentage]    Script Date: 3/21/2023 10:30:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

                CREATE FUNCTION [dbo].[GetTareasCompletionPercentage](@MetaId INT)
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
            
GO
/****** Object:  UserDefinedFunction [dbo].[GetTotalTareas]    Script Date: 3/21/2023 10:30:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

                CREATE FUNCTION [dbo].[GetTotalTareas](@MetaId INT)
                RETURNS INT
                AS
                BEGIN
                    DECLARE @Total iNT;
                    SET @Total = (SELECT COUNT(1) FROM Tarea WHERE MetaId = @MetaId)
                    RETURN @Total
                END
            
GO
/****** Object:  UserDefinedFunction [dbo].[GetTotalTareasCompletadas]    Script Date: 3/21/2023 10:30:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

                CREATE FUNCTION [dbo].[GetTotalTareasCompletadas](@MetaId INT)
                RETURNS INT
                AS
                BEGIN
                    DECLARE @Total iNT;
                    SET @Total = (SELECT COUNT(1) FROM Tarea WHERE MetaId = @MetaId AND Estado = 'Completada')
                    RETURN @Total
                END
            
GO
/****** Object:  Table [dbo].[Meta]    Script Date: 3/21/2023 10:30:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](80) NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Meta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[MetaView]    Script Date: 3/21/2023 10:30:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

                CREATE VIEW [dbo].[MetaView] AS
                SELECT Id, Nombre, FechaCreacion, 
                (dbo.GetTotalTareas(Id)) AS TotalTareas,
                (dbo.GetTotalTareasCompletadas(Id)) AS TareasCompletadas,
                (dbo.GetTareasCompletionPercentage(Id)) AS PorcentajeCumplimiento
                FROM [dbo].[Meta]
            
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/21/2023 10:30:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarea]    Script Date: 3/21/2023 10:30:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarea](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](80) NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[EsImportante] [bit] NOT NULL,
	[Estado] [nvarchar](100) NOT NULL,
	[MetaId] [int] NOT NULL,
 CONSTRAINT [PK_Tarea] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230311165532_InitialCreate', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230311182626_CreateFunctions', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230311185108_AddMetaView', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230321042845_EnableCascadeDelete', N'7.0.3')
GO
SET IDENTITY_INSERT [dbo].[Meta] ON 

INSERT [dbo].[Meta] ([Id], [Nombre], [FechaCreacion]) VALUES (1, N'Meta 1', CAST(N'2023-03-21T10:27:48.8072713' AS DateTime2))
INSERT [dbo].[Meta] ([Id], [Nombre], [FechaCreacion]) VALUES (2, N'Meta 2', CAST(N'2023-03-21T10:27:48.8092519' AS DateTime2))
INSERT [dbo].[Meta] ([Id], [Nombre], [FechaCreacion]) VALUES (3, N'Meta 3', CAST(N'2023-03-21T10:27:48.8092691' AS DateTime2))
INSERT [dbo].[Meta] ([Id], [Nombre], [FechaCreacion]) VALUES (4, N'Meta 4', CAST(N'2023-03-21T10:27:48.8092733' AS DateTime2))
INSERT [dbo].[Meta] ([Id], [Nombre], [FechaCreacion]) VALUES (5, N'Meta 5', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Meta] OFF
GO
SET IDENTITY_INSERT [dbo].[Tarea] ON 

INSERT [dbo].[Tarea] ([Id], [Nombre], [FechaCreacion], [EsImportante], [Estado], [MetaId]) VALUES (1, N'Tarea 1', CAST(N'2023-03-21T10:27:48.8090672' AS DateTime2), 0, N'Completada', 1)
INSERT [dbo].[Tarea] ([Id], [Nombre], [FechaCreacion], [EsImportante], [Estado], [MetaId]) VALUES (2, N'Tarea 2', CAST(N'2023-03-21T10:27:48.8091829' AS DateTime2), 1, N'Completada', 1)
INSERT [dbo].[Tarea] ([Id], [Nombre], [FechaCreacion], [EsImportante], [Estado], [MetaId]) VALUES (3, N'Tarea 3', CAST(N'2023-03-21T10:27:48.8092454' AS DateTime2), 1, N'Abierta', 1)
INSERT [dbo].[Tarea] ([Id], [Nombre], [FechaCreacion], [EsImportante], [Estado], [MetaId]) VALUES (4, N'Tarea 4', CAST(N'2023-03-21T10:27:48.8092464' AS DateTime2), 0, N'Abierta', 1)
INSERT [dbo].[Tarea] ([Id], [Nombre], [FechaCreacion], [EsImportante], [Estado], [MetaId]) VALUES (5, N'Tarea 1', CAST(N'2023-03-21T10:27:48.8092524' AS DateTime2), 0, N'Abierta', 2)
INSERT [dbo].[Tarea] ([Id], [Nombre], [FechaCreacion], [EsImportante], [Estado], [MetaId]) VALUES (6, N'Tarea 2', CAST(N'2023-03-21T10:27:48.8092661' AS DateTime2), 1, N'Abierta', 2)
INSERT [dbo].[Tarea] ([Id], [Nombre], [FechaCreacion], [EsImportante], [Estado], [MetaId]) VALUES (7, N'Tarea 3', CAST(N'2023-03-21T10:27:48.8092681' AS DateTime2), 0, N'Abierta', 2)
INSERT [dbo].[Tarea] ([Id], [Nombre], [FechaCreacion], [EsImportante], [Estado], [MetaId]) VALUES (8, N'Tarea 1', CAST(N'2023-03-21T10:27:48.8092694' AS DateTime2), 0, N'Abierta', 3)
INSERT [dbo].[Tarea] ([Id], [Nombre], [FechaCreacion], [EsImportante], [Estado], [MetaId]) VALUES (9, N'Tarea 2', CAST(N'2023-03-21T10:27:48.8092717' AS DateTime2), 0, N'Abierta', 3)
INSERT [dbo].[Tarea] ([Id], [Nombre], [FechaCreacion], [EsImportante], [Estado], [MetaId]) VALUES (10, N'Tarea 3', CAST(N'2023-03-21T10:27:48.8092726' AS DateTime2), 0, N'Completada', 3)
INSERT [dbo].[Tarea] ([Id], [Nombre], [FechaCreacion], [EsImportante], [Estado], [MetaId]) VALUES (11, N'Tarea 1', CAST(N'2023-03-21T10:27:48.8092737' AS DateTime2), 1, N'Completada', 5)
INSERT [dbo].[Tarea] ([Id], [Nombre], [FechaCreacion], [EsImportante], [Estado], [MetaId]) VALUES (12, N'Tarea 1', CAST(N'2023-03-21T10:27:48.8092743' AS DateTime2), 0, N'Completada', 5)
SET IDENTITY_INSERT [dbo].[Tarea] OFF
GO
ALTER TABLE [dbo].[Tarea] ADD  DEFAULT (CONVERT([bit],(0))) FOR [EsImportante]
GO
ALTER TABLE [dbo].[Tarea] ADD  DEFAULT (N'Abierta') FOR [Estado]
GO
ALTER TABLE [dbo].[Tarea]  WITH CHECK ADD  CONSTRAINT [FK_Tarea_Meta_MetaId] FOREIGN KEY([MetaId])
REFERENCES [dbo].[Meta] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tarea] CHECK CONSTRAINT [FK_Tarea_Meta_MetaId]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de la meta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Meta', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación de la meta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Meta', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Metas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Meta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de la tarea' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tarea', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación de la tarea' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tarea', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicador de importancia de una tarea' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tarea', @level2type=N'COLUMN',@level2name=N'EsImportante'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado de completado de la tarea' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tarea', @level2type=N'COLUMN',@level2name=N'Estado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Tareas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tarea'
GO
