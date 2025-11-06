CREATE TABLE Poc.[dbo].[Acesso](
	[GuidUsuario]   	UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[HorarioAcesso] 	DATETIME NULL,
    CONSTRAINT FK_Acesso_Usuarios FOREIGN KEY (GuidUsuario)
    REFERENCES Poc.[dbo].Usuario(GuidUsuario)
) ON [PRIMARY]
