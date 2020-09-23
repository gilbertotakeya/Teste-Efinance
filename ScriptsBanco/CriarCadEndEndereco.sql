USE [EfinanceTeste]
GO

/****** Object:  Table [dbo].[Cad_End_Endereco]    Script Date: 23/09/2020 11:30:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cad_End_Endereco](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CidadeId] [int] NOT NULL,
	[EstadoId] [int] NULL,
	[Endereco] [varchar](max) NOT NULL,
	[Bairro] [varchar](max) NOT NULL,
	[CodigoIbge] [varchar](10) NOT NULL,
	[CEP] [varchar](8) NOT NULL,
	[DataInclusao] [datetime] NOT NULL,
	[DataExclusao] [datetime] NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cad_End_Endereco] ADD  CONSTRAINT [DF_Endereco_DataInclusao]  DEFAULT (getdate()) FOR [DataInclusao]
GO

ALTER TABLE [dbo].[Cad_End_Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Cad_End_Endereco_Cidade] FOREIGN KEY([CidadeId])
REFERENCES [dbo].[Cad_End_Cidade] ([Id])
GO

ALTER TABLE [dbo].[Cad_End_Endereco] CHECK CONSTRAINT [FK_Cad_End_Endereco_Cidade]
GO

ALTER TABLE [dbo].[Cad_End_Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Cad_End_Endereco_Estado] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Cad_End_Estado] ([Id])
GO

ALTER TABLE [dbo].[Cad_End_Endereco] CHECK CONSTRAINT [FK_Cad_End_Endereco_Estado]
GO

