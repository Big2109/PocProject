USE Poc;
GO
CREATE TABLE [dbo].[Usuario] (
    [GuidUsuario]   UNIQUEIDENTIFIER NOT NULL,
    [Nome]          NVARCHAR (100)   NULL,
    [NomeUsuario]   NVARCHAR (100)   NULL,
    [Email]         NVARCHAR (100)   NULL,
    [Senha]         NVARCHAR (100)   NULL,
    [CriadoEm]      DATETIME         NULL,
    [HorarioAcesso] DATETIME         NULL,
    PRIMARY KEY CLUSTERED ([GuidUsuario] ASC)
);
