using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Commands;
using Projeto.Domain.Handlers;
using Projeto.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
