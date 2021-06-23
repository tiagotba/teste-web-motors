using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using WebMotorsChallenger.Domain.Commands;
using WebMotorsChallenger.Domain.Commands.Anuncio;
using WebMotorsChallenger.Domain.Entities.Tables;
using WebMotorsChallenger.Domain.Repositories;

namespace WebMotorsChallenger.Domain.Handlers
{
    public class AnuncioHandler : Notifiable<Notification>
    {
        private readonly IAnuncioRepository _anuncioRepository;
        public AnuncioHandler(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }

        public ICommandResult Handle(CreateAnuncioCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, algo de errado está acontecendo :/ ", command.Notifications);

            // Busca registro do anuncio na base

            var anuncioDB = _anuncioRepository.GetAnuncios(command.marca, command.modelo, command.versao);

            if (anuncioDB.Count > 0) return new GenericCommandResult(false, "Ops, esse anuncio já se encontra registrado na base de dados ! :/ ", command);

            // gera o objeto do tipo entidade Anuncio

            var newAnuncio = new Anuncios(command.marca, command.modelo, command.versao, command.ano, command.km, command.observacao);

            // salva no banco
            _anuncioRepository.CreateOrUpdateAnucio(newAnuncio);

            //retorna o resultado
            return new GenericCommandResult(true, "Anuncio cadastrado com sucesso! :)", newAnuncio);

        }


        public ICommandResult Handle(UpdateAnuncioCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, algo de errado está acontecendo :/ ", command.Notifications);

            // Busca registro do anuncio na base

            var anuncioDB = _anuncioRepository.GetAnucioByID(command.codigo);

            if(anuncioDB == null) return new GenericCommandResult(false, "Ops, esse anuncio não se encontra registrado na base de dados ! :/ ", command);

            // altera o objeto anuncio
            anuncioDB.UpdateValues(command.marca, command.modelo, command.versao, command.ano, command.km, command.observacao);
            
            // salva no banco
            _anuncioRepository.CreateOrUpdateAnucio(anuncioDB);

            //retorna o resultado
            return new GenericCommandResult(true, "Anuncio alterado com sucesso! :)", anuncioDB);


        }

        public ICommandResult Handle(RemoveAnuncioCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, algo de errado está acontecendo :/ ", command.Notifications);

            // Busca registro do anuncio na base

            var anuncioDB = _anuncioRepository.GetAnucioByID(command.codigo);

            if (anuncioDB == null) return new GenericCommandResult(false, "Ops, esse anuncio não se encontra registrado na base de dados ! :/ ", command);

            // salva no banco
            _anuncioRepository.RemoveAnuncio(anuncioDB.ID);

            //retorna o resultado
            return new GenericCommandResult(true, "Anuncio removido com sucesso! :)", anuncioDB);


        }
    }
}
