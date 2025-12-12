USE Poc;
GO
CREATE TABLE [dbo].[Acesso] (
    [GuidUsuario]   UNIQUEIDENTIFIER NOT NULL,
    [HorarioAcesso] DATETIME         NULL,
    [Ativo]         BIT              NULL,
    PRIMARY KEY CLUSTERED ([GuidUsuario] ASC),
    CONSTRAINT [FK_Acesso_Usuarios] FOREIGN KEY ([GuidUsuario]) REFERENCES [dbo].[Usuario] ([GuidUsuario])
);