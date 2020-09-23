USE [EfinanceTeste]
GO

/****** Object:  Table [dbo].[Cad_End_Cidade]    Script Date: 23/09/2020 11:30:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cad_End_Cidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](max) NOT NULL,
	[EstadoId] [int] NOT NULL,
	[CodigoIBGE] [varchar](10) NULL,
	[DataInclusao] [datetime] NULL,
	[DataExclusao] [datetime] NULL,
 CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cad_End_Cidade] ADD  CONSTRAINT [DF_Cidade_DataInclusao]  DEFAULT (getdate()) FOR [DataInclusao]
GO

ALTER TABLE [dbo].[Cad_End_Cidade]  WITH CHECK ADD  CONSTRAINT [FK_Cad_End_Cidade_Estado] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Cad_End_Estado] ([Id])
GO

ALTER TABLE [dbo].[Cad_End_Cidade] CHECK CONSTRAINT [FK_Cad_End_Cidade_Estado]
GO

