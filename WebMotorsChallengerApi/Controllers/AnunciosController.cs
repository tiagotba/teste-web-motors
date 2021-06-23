using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotorsChallenger.Domain.Commands;
using WebMotorsChallenger.Domain.Commands.Anuncio;
using WebMotorsChallenger.Domain.Handlers;
using WebMotorsChallenger.Domain.Repositories;

namespace WebMotorsChallengerApi.Controllers
{
    [Route("api/v{version:apiVersion}/anuncios")]
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AnunciosController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        [MapToApiVersion("1.0")]
        public JsonResult GetAnuncios([FromQuery] string marca, [FromQuery] string modelo, [FromQuery] string versao,
            [FromServices] IAnuncioRepository repository)
        {
            try
            {
                return Json(repository.GetAnuncios(marca, modelo, versao));
            }
            catch (Exception ex)
            {

                return new JsonResult(BadRequest()) { StatusCode = 400, Value = new GenericCommandResult(false, "ops! Algo de errado ocorreu, ", ex.Message) };
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        public JsonResult Update([FromBody] UpdateAnuncioCommand command,
           [FromServices] AnuncioHandler handler
           )
        {
            try
            {
                return Json((GenericCommandResult)handler.Handle(command));
            }
            catch (Exception ex)
            {
                return new JsonResult(BadRequest()) { StatusCode = 400, Value = new GenericCommandResult(false, "ops! Algo de errado ocorreu, ", ex.Message) };
            }

        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public JsonResult Save([FromBody] CreateAnuncioCommand command,
         [FromServices] AnuncioHandler handler
         )
        {
            try
            {
                return Json((GenericCommandResult)handler.Handle(command));
            }
            catch (Exception ex)
            {
                return new JsonResult(BadRequest()) { StatusCode = 400, Value = new GenericCommandResult(false, "ops! Algo de errado ocorreu, ", ex.Message) };
            }

        }

        [HttpDelete]
        [MapToApiVersion("1.0")]
        public JsonResult Remove([FromBody] RemoveAnuncioCommand command,
         [FromServices] AnuncioHandler handler
         )
        {
            try
            {
                return Json((GenericCommandResult)handler.Handle(command));
            }
            catch (Exception ex)
            {
                return new JsonResult(BadRequest()) { StatusCode = 400, Value = new GenericCommandResult(false, "ops! Algo de errado ocorreu, ", ex.Message) };
            }

        }
    }
}
