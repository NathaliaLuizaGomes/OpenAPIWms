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

BEGIN TRANSACTION;
GO

ALTER TABLE [Produtos] ADD [CategoriasIdCategoria] int NULL;
GO

ALTER TABLE [Produtos] ADD [Desativado] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

ALTER TABLE [Produtos] ADD [IdCategoria] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [Categoria] (
    [IdCategoria] int NOT NULL IDENTITY,
    [NomeCategoria] nvarchar(max) NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY ([IdCategoria])
);
GO

CREATE INDEX [IX_Produtos_CategoriasIdCategoria] ON [Produtos] ([CategoriasIdCategoria]);
GO

ALTER TABLE [Produtos] ADD CONSTRAINT [FK_Produtos_Categoria_CategoriasIdCategoria] FOREIGN KEY ([CategoriasIdCategoria]) REFERENCES [Categoria] ([IdCategoria]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210602004115_TabelaCategoriaEProdutos', N'5.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Compras] (
    [Seq] int NOT NULL IDENTITY,
    [IdCompra] int NOT NULL,
    [IdMercadoria] int NOT NULL,
    [QtdEntrada] int NOT NULL,
    [DataEntrada] datetime2 NOT NULL,
    CONSTRAINT [PK_Compras] PRIMARY KEY ([Seq])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210602040936_TabelaComprasECampoCategoria', N'5.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Categoria] ADD [PercDesconto] real NOT NULL DEFAULT CAST(0 AS real);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210602043333_CampoDescCategoria', N'5.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categoria]') AND [c].[name] = N'PercDesconto');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Categoria] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Categoria] DROP COLUMN [PercDesconto];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210602051017_RemoverCamposCategorias', N'5.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Categoria] ADD [Desconto] real NOT NULL DEFAULT CAST(0 AS real);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210602051715_Desconto', N'5.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Vendas] (
    [Seq] int NOT NULL IDENTITY,
    [IdVenda] int NOT NULL,
    [IdMercadoria] int NOT NULL,
    [QtdSaida] int NOT NULL,
    [DataSaida] datetime2 NOT NULL,
    CONSTRAINT [PK_Vendas] PRIMARY KEY ([Seq])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210602183022_TabelaVenda', N'5.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Categoria] ADD [Acrestimo] real NOT NULL DEFAULT CAST(0 AS real);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210603173441_Acrescimo', N'5.0.6');
GO

COMMIT;
GO

