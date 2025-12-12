CREATE TABLE [dbo].[Acesso] (
    [GuidAcesso]    UNIQUEIDENTIFIER NOT NULL,
    [GuidUsuario]   UNIQUEIDENTIFIER NULL,
    [HorarioAcesso] DATETIME         NULL,
    CONSTRAINT [PK_Acesso] PRIMARY KEY CLUSTERED ([GuidAcesso] ASC),
    CONSTRAINT [FK_Acesso_Usuarios] FOREIGN KEY ([GuidUsuario]) REFERENCES [dbo].[Usuario] ([GuidUsuario])
);
