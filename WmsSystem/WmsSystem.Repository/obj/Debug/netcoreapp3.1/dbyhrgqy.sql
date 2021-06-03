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
GO

CREATE TABLE [Produtos] (
    [Id] int NOT NULL IDENTITY,
    [Referencia] nvarchar(max) NULL,
    [Nome] nvarchar(max) NULL,
    [PCusto] real NOT NULL,
    [PVenda] real NOT NULL,
    [Quantidade] real NOT NULL,
    [Estoque] int NOT NULL,
    [UndMedida] nvarchar(max) NULL,
    [Grupo] nvarchar(max) NULL,
    [DtAlteracao] datetime2 NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210531215440_Initial', N'5.0.6');
GO

COMMIT;
GO

