using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using WebMotorsChallenger.Domain.Entities.Tables;

namespace WebMotorsChallenger.Domain.Commands.Anuncio
{
    public class RemoveAnuncioCommand : Contract<Anuncios>
    {

        public int codigo { get; set; }

        public void Validate()
        {
            AddNotifications
                (
                new Contract<Anuncios>()
                .Requires()
                .IsGreaterThan(codigo, 0, "codigo", "codigo do anuncio deve ser maior que zero")
                );
        }

    }
}
