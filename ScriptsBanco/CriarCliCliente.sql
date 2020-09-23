USE [EfinanceTeste]
GO

/****** Object:  Table [dbo].[Cli_Cliente]    Script Date: 23/09/2020 11:31:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cli_Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[NomeSocial] [varchar](200) NULL,
	[RG] [varchar](20) NOT NULL,
	[CPF] [varchar](14) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[NumeroTelefone] [varchar](20) NOT NULL,
	[NumeroTelefone2] [varchar](20) NULL,
	[EnderecoId] [int] NOT NULL,
	[CidadeId] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[Numero] [int] NOT NULL,
	[Complemento] [varchar](50) NULL,
	[Observacao] [varchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[DataExclusao] [datetime] NULL,
 CONSTRAINT [PK_Cli_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cli_Cliente] ADD  CONSTRAINT [DF_Cli_Cliente_DataInclusao]  DEFAULT (getdate()) FOR [DataInclusao]
GO

ALTER TABLE [dbo].[Cli_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cli_Cliente_Cidade] FOREIGN KEY([CidadeId])
REFERENCES [dbo].[Cad_End_Cidade] ([Id])
GO

ALTER TABLE [dbo].[Cli_Cliente] CHECK CONSTRAINT [FK_Cli_Cliente_Cidade]
GO

ALTER TABLE [dbo].[Cli_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cli_Cliente_Endereco] FOREIGN KEY([EnderecoId])
REFERENCES [dbo].[Cad_End_Endereco] ([Id])
GO

ALTER TABLE [dbo].[Cli_Cliente] CHECK CONSTRAINT [FK_Cli_Cliente_Endereco]
GO

ALTER TABLE [dbo].[Cli_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cli_Cliente_Estado] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Cad_End_Estado] ([Id])
GO

ALTER TABLE [dbo].[Cli_Cliente] CHECK CONSTRAINT [FK_Cli_Cliente_Estado]
GO

