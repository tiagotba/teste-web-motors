using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using WebMotorsChallenger.Domain.Entities.Tables;

namespace WebMotorsChallenger.Domain.Commands.Anuncio
{
    public class UpdateAnuncioCommand : Contract<Anuncios>
    {
        public int codigo { get; set; }
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
                .IsGreaterThan(codigo, 0, "codigo", "codigo do anuncio deve ser maior que zero")
                );
        }
    }
}
