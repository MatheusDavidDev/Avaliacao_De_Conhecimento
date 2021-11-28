using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Commands.PessoaJuridica;
using Projeto.Domain.Handlers.PessoaJuridica;
using Projeto.Domain.Queries.PessoaJuridica;
using Projeto.Shared.Commands;
using Projeto.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Api.Controllers
{
    [Route("v1/funcionarioJuridico")]
    [ApiController]
    public class PessoaJuridicaController : ControllerBase
    {
        [HttpPost]
        public GenericCommandResult Create(CadastrarPessoaJuridicaCommand command, [FromServices] CadastrarPessoaJuridicaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [HttpGet]
        public GenericQueryResult GetAll([FromServices] ListarPessoaJuridicaHandler handle)
        {
            // Criamos uma interface nova da query
            ListarPessoaJuridicaQuery query = new ListarPessoaJuridicaQuery();

            // Fazemos o comparativo para mostar somente os ativos para o usuario comum

            return (GenericQueryResult)handle.Handler(query);
        }
    }
}
