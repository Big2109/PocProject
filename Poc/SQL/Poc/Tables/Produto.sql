USE Poc;
GO
CREATE TABLE [dbo].[Produto] (
    [GuidUsuario]  UNIQUEIDENTIFIER NULL,
    [GuidProduto]  UNIQUEIDENTIFIER NOT NULL,
    [Nome]         NVARCHAR (100)   NULL,
    [Descricao]    NVARCHAR (100)   NULL,
    [Icone]        VARCHAR (100)    NULL,
    [CorHex]       VARCHAR (100)    NULL,
    [CriadoEm]     DATETIME         NULL,
    [AtualizadoEm] DATETIME         NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED ([GuidProduto] ASC)
);