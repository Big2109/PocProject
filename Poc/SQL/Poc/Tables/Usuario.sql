USE Poc;
GO
CREATE TABLE [dbo].[Usuario] (
    [GuidUsuario]   UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [Nome]          NVARCHAR (100)   NULL,
    [NomeUsuario]   NVARCHAR (100)   NULL,
    [Email]         NVARCHAR (100)   NULL,
    [Senha]         NVARCHAR (100)   NULL,
    [HorarioAcesso] DATETIME         NULL
);