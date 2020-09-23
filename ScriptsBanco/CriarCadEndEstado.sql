USE [EfinanceTeste]
GO

/****** Object:  Table [dbo].[Cad_End_Estado]    Script Date: 23/09/2020 11:30:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cad_End_Estado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Sigla] [varchar](2) NOT NULL,
	[DataInclusao] [datetime] NULL,
	[DataExclusao] [datetime] NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cad_End_Estado] ADD  CONSTRAINT [DF_Estado_DataInclusao]  DEFAULT (getdate()) FOR [DataInclusao]
GO

