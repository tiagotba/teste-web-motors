using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using WebMotorsChallenger.Domain.Entities.Tables;
using WebMotorsChallenger.Domain.Repositories;
using WebMotorsChallenger.Infra.Connections;

namespace WebMotorsChallenger.Infra.Repositories
{
    public class AnuncioRepository : IAnuncioRepository
    {
        IConnectionFactory _connectionFactory;
        public AnuncioRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public void CreateOrUpdateAnucio(Anuncios anuncios)
        {

            var p = new DynamicParameters();

            p.Add("@MSG",
         SqlDbType.VarChar, 
             direction: ParameterDirection.Output);
            p.Add("@MARCA", anuncios.Marca);
            p.Add("@MODELO", anuncios.Modelo);
            p.Add("@ANO", anuncios.Ano);
            p.Add("@VERSAO", anuncios.Versao);
            p.Add("@KM", anuncios.Quilometragem);
            p.Add("@OBSERVACAO", anuncios.Observacao);
            p.Add("@ATIVO", true);



            if (anuncios.ID == 0)
            {
                p.Add("@ID", null);
            }
            else
            {
                p.Add("@ID", anuncios.ID);
            }

            using (var connection = _connectionFactory.GetConnection())
            {

                connection.Execute("LP_CHALEGER_CAD_ALT_ANUNCIOS", p, commandType: CommandType.StoredProcedure);
            }
        }

        public Anuncios GetAnucioByID(int codAnuncio)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                string query = "SELECT " +
                                " [ID]" +
                                ",[marca]" +
                                ",[modelo]" +
                                ",[ano]" +
                                ",[quilometragem]" +
                                ",[versao]" +
                                ",[observacao]" +
                            "FROM [Teste_WebMotors].[dbo].[tb_AnuncioWebmotors] WHERE [ID] = @codAnuncio ";
                return connection
              .Query<Anuncios>(query

                             , new
                             {
                                 codAnuncio

                             }
                             ).FirstOrDefault();
            }
        }

        public List<Anuncios> GetAnuncios(string marca, string modelo = "", string versao = "")
        {
            string query = "SELECT " +
                                " [ID]" +
                                ",[marca]" +
                                ",[modelo]" +
                                ",[ano]" +
                                ",[quilometragem]" +
                                ",[observacao]" +
                            "FROM [Teste_WebMotors].[dbo].[tb_AnuncioWebmotors] WHERE [ativo] = 1 AND [marca] = @marca";

            if (!string.IsNullOrEmpty(modelo) && !string.IsNullOrEmpty(versao))
            {
                query = "SELECT " +
                                " [ID]" +
                                ",[marca]" +
                                ",[modelo]" +
                                ",[versao]" +
                                ",[ano]" +
                                ",[quilometragem]" +
                                ",[observacao]" +
                                ",[ativo]" +
                            "FROM [Teste_WebMotors].[dbo].[tb_AnuncioWebmotors] WHERE [ativo] = 1 AND [marca] = @marca AND [modelo] = @modelo AND [versao] = @versao ";

            }

            if (!string.IsNullOrEmpty(modelo))
            {
                query = "SELECT " +
                                " [ID]" +
                                ",[marca]" +
                                ",[modelo]" +
                                ",[versao]" +
                                ",[ano]" +
                                ",[quilometragem]" +
                                ",[observacao]" +
                            "FROM [Teste_WebMotors].[dbo].[tb_AnuncioWebmotors] WHERE [ativo] = 1 AND [marca] = @marca AND [versao] = @versao ";
            }



            if (!string.IsNullOrEmpty(versao))
            {
                query = "SELECT " +
                                " [ID]" +
                                ",[marca]" +
                                ",[modelo]" +
                                ",[versao]" +
                                ",[ano]" +
                                ",[quilometragem]" +
                                ",[observacao]" +
                            "FROM [Teste_WebMotors].[dbo].[tb_AnuncioWebmotors] WHERE [ativo] = 1 AND [marca] = @marca AND [modelo] = @modelo ";
            }



            using (var connection = _connectionFactory.GetConnection())
            {
                return connection
               .Query<Anuncios>(query

                             , new
                             {
                                 marca,
                                 modelo,
                                 versao
                             }
                             ).ToList();
            }


        }

        public void RemoveAnuncio(int anuncioExclud)
        {
            var p = new DynamicParameters();

            p.Add("@MSG",
           SqlDbType.VarChar,
             direction: ParameterDirection.Output);
            p.Add("@MARCA", null);
            p.Add("@MODELO", null);
            p.Add("@VERSAO", null);
            p.Add("@ANO",null);
            p.Add("@KM", null);
            p.Add("@OBSERVACAO", null);
            p.Add("@ATIVO", false);

            p.Add("@ID", anuncioExclud);


            using (var connection = _connectionFactory.GetConnection())
            {

                connection.Execute("LP_CHALEGER_CAD_ALT_ANUNCIOS", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
