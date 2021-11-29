using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Commands;
using Projeto.Domain.Handlers;
using Projeto.Shared.Commands;


namespace Projeto.Api.Controllers
{
    [Route("v1/telefone")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        [HttpPost]
        public GenericCommandResult Create(CadastrarTelefoneCommand command, [FromServices] CadastrarTelefoneHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

    }
}
