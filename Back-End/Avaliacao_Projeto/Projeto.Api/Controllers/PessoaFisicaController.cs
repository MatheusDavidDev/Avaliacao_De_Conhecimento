using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Entities;
using Projeto.Domain.Handlers.PessoaFisica;
using Projeto.Domain.Queries.PessoaFisica;
using Projeto.Shared.Commands;
using Projeto.Shared.Queries;


namespace Projeto.Api.Controllers
{
    [Route("v1/Fisico")]
    [ApiController]
    public class PessoaFisicaController : ControllerBase
    {
        [HttpPost]
        public GenericCommandResult Create(CadastrarPessoaFisicaCommand command, [FromServices] CadastrarPessoaFisicaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [HttpGet]
        public GenericQueryResult GetAll([FromServices] ListarPessoaFisicaHandler handle)
        {
            // Criamos uma interface nova da query
            ListarPessoaFisicaQuery query = new ListarPessoaFisicaQuery();

            // Fazemos o comparativo para mostar somente os ativos para o usuario comum

            return (GenericQueryResult)handle.Handler(query);
        }
    }
}
