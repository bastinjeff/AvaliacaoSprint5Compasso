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

CREATE TABLE [Estados] (
    [Id] Guid NOT NULL,
    [Nome] varchar(max) NOT NULL,
    CONSTRAINT [PK_Estados] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Cidades] (
    [Id] Guid NOT NULL,
    [Nome] varchar(max) NOT NULL,
    [EstadoId] Guid NOT NULL,
    CONSTRAINT [PK_Cidades] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cidades_Estados_EstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [Estados] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Clientes] (
    [Id] Guid NOT NULL,
    [Nome] varchar(max) NOT NULL,
    [DataDeNascimento] datetime NULL,
    [CidadeId] Guid NOT NULL,
    [CEP] varchar(20) NOT NULL,
    [Logradouro] varchar(max) NULL,
    [Bairro] varchar(20) NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Clientes_Cidades_CidadeId] FOREIGN KEY ([CidadeId]) REFERENCES [Cidades] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Cidades_EstadoId] ON [Cidades] ([EstadoId]);
GO

CREATE INDEX [IX_Clientes_CidadeId] ON [Clientes] ([CidadeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211012114125_Inicial', N'5.0.10');
GO

COMMIT;
GO

