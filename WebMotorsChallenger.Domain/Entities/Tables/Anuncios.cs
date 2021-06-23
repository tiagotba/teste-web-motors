using System;
using System.Collections.Generic;
using System.Text;

namespace WebMotorsChallenger.Domain.Entities.Tables
{
  public class Anuncios
    {
        public Anuncios()
        {

        }

        public Anuncios(string marca,string modelo,string versao,int ano,int km,string observacao)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Versao = versao;
            this.Quilometragem = km;
            this.Ano = ano;
            this.Observacao = observacao;
        }

        public int ID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }
        public bool Ativo { get; set; } = true;

        public void UpdateValues(string marca, string modelo,string versao, int ano,int quilometragem,string observacao)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Versao = versao;
            this.Ano = ano;
            this.Quilometragem = quilometragem;
            this.Observacao = observacao;
        }
    }
}
