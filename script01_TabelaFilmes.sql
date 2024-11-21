IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [TB_FILMES] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [AnoLancamento] int NOT NULL,
    [Bilheteria] decimal(18,2) NOT NULL,
    [Duracao] time NOT NULL,
    [Classificacao] int NOT NULL,
    [Genero] int NOT NULL,
    CONSTRAINT [PK_TB_FILMES] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AnoLancamento', N'Bilheteria', N'Classificacao', N'Duracao', N'Genero', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_FILMES]'))
    SET IDENTITY_INSERT [TB_FILMES] ON;
INSERT INTO [TB_FILMES] ([Id], [AnoLancamento], [Bilheteria], [Classificacao], [Duracao], [Genero], [Nome])
VALUES (1, 2014, 774000000.0, 10, '02:49:00', 3, 'Interestelar'),
(2, 2013, 426074373.0, 16, '02:45:00', 0, 'Django Livre'),
(3, 2016, 340600000.0, 0, '02:08:00', 0, 'La La Land');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AnoLancamento', N'Bilheteria', N'Classificacao', N'Duracao', N'Genero', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_FILMES]'))
    SET IDENTITY_INSERT [TB_FILMES] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241121035738_InitialCreate', N'9.0.0');

COMMIT;
GO

