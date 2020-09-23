USE [EfinanceTeste]
GO

/****** Object:  StoredProcedure [dbo].[PROC_CLI_LISTAGEM_V1]    Script Date: 23/09/2020 11:31:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PROC_CLI_LISTAGEM_V1]
AS
	SELECT cli.id,
		   case when cli.NomeSocial is not null then cli.NomeSocial + ' - ' + cli.Nome
				else cli.Nome
		   end as NomeApresentacao,
		   cli.DataNascimento,
		   cli.CPF,
		   cli.RG,
		   cli.NumeroTelefone,
		   e.Endereco + ', ' +  CAST(cli.Numero as varchar) + ',' + e.Bairro + ',' + c.Nome as Endereco
	  FROM Cli_Cliente cli
	 INNER JOIN Cad_End_Endereco e on e.Id = cli.EnderecoId
	 inner join Cad_End_Cidade c on c.Id = cli.CidadeId
	 inner join Cad_End_Estado uf on uf.Id = cli.EstadoId
	 where cli.DataExclusao is null;
;
GO

