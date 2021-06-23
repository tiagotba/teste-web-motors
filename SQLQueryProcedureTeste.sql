USE [Teste_WebMotors]
GO

/****** Object:  StoredProcedure [dbo].[LP_CHALEGER_CAD_ALT_ANUNCIOS]    Script Date: 22/06/2021 16:51:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









ALTER PROCEDURE [dbo].[LP_CHALEGER_CAD_ALT_ANUNCIOS] @MARCA VARCHAR(45),@MODELO VARCHAR(45),@VERSAO VARCHAR(45),@ANO INT,@KM INT,@OBSERVACAO TEXT,@ATIVO BIT,@ID INT,@MSG VARCHAR(1024) OUTPUT
AS BEGIN

SET @MSG=''

IF @ID IS NOT NULL AND @ATIVO = 0 
BEGIN

UPDATE [dbo].[tb_AnuncioWebmotors]
   SET [ativo] =@ATIVO
 WHERE ID = @ID

END
ELSE

IF @ID IS NOT NULL AND @ATIVO = 1
BEGIN

UPDATE [dbo].[tb_AnuncioWebmotors]
   SET [marca] = @MARCA
      ,[modelo] = @MODELO
      ,[versao] = @VERSAO
      ,[ano] = @ANO
      ,[quilometragem] = @KM
      ,[observacao] = @OBSERVACAO
      ,[ativo] =@ATIVO
 WHERE ID = @ID

 END
ELSE
BEGIN

INSERT INTO [dbo].[tb_AnuncioWebmotors]
           ([marca]
           ,[modelo]
           ,[versao]
           ,[ano]
           ,[quilometragem]
           ,[observacao]
           ,[ativo])
     VALUES
           (@MARCA
           ,@MODELO
           ,@VERSAO
           ,@ANO
           ,@KM
           ,@OBSERVACAO
           ,@ATIVO)
END



		   

		   END
GO


