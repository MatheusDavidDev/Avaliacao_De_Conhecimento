using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Commands.Empresa;
using Projeto.Domain.Handlers.Empresa;
using Projeto.Domain.Queries.Empresa;
using Projeto.Shared.Commands;
using Projeto.Shared.Queries;


namespace Projeto.Api.Controllers
{
    [Route("v1/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        [HttpPost]
        public GenericCommandResult Create(CadastrarEmpresaCommand command, [FromServices] CadastrarEmpresaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [HttpGet]
        public GenericQueryResult GetAll([FromServices] ListarEmpresaHandler handle)
        {
            // Criamos uma interface nova da query
            ListarEmpresaQuery query = new ListarEmpresaQuery();

            // Fazemos o comparativo para mostar somente os ativos para o usuario comum

            return (GenericQueryResult)handle.Handler(query);
        }
    }
}
