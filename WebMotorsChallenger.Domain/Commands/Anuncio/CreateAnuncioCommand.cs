using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using WebMotorsChallenger.Domain.Entities.Tables;

namespace WebMotorsChallenger.Domain.Commands.Anuncio
{
   public class CreateAnuncioCommand : Contract<Anuncios>
    {
        public string marca { get; set; }
        public string modelo { get; set; }
        public string versao { get; set; }
        public int ano { get; set; }
        public int km { get; set; }
        public string observacao { get; set; }

        public void Validate()
        {
            AddNotifications
                (
                new Contract<Anuncios>()
                .Requires()
                .IsNotNullOrEmpty(marca, "marca", "marca do veiculo é obrigatorio")
                .IsNotNullOrEmpty(modelo, "modelo", "modelo do veiculo é obrigatorio")
                .IsGreaterThan(ano, 0, "ano", "ano deve ser maior que zero")
                .IsGreaterThan(km, 0, "quilometragem", "km deve ser maior que zero")
                );
        }
    }
}
