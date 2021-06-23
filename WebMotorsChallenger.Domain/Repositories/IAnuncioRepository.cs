using System;
using System.Collections.Generic;
using System.Text;
using WebMotorsChallenger.Domain.Entities.Tables;

namespace WebMotorsChallenger.Domain.Repositories
{
   public interface IAnuncioRepository
    {
        void CreateOrUpdateAnucio(Anuncios anuncios);
        void RemoveAnuncio(int anuncioExclud);
        List<Anuncios> GetAnuncios(string marca, string modelo = "", string versao = "");
        Anuncios GetAnucioByID(int codAnuncio);
    }
}
