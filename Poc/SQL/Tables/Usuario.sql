CREATE TABLE Poc.[dbo].[Usuario](
	[GuidUsuario] [uniqueidentifier] NULL,
	[Nome] [nvarchar](100) NULL,
    [NomeUsuario] [nvarchar](100) NULL,
    [Email] [nvarchar](100) NULL,
	[Senha] [nvarchar](100) NULL,
	[HorarioAcesso] [datetime] NULL
) ON [PRIMARY]
