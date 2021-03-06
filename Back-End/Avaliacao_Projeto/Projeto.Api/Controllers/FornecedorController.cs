using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Handlers.Funcionario;
using Projeto.Domain.Queries.Funcionario;
using Projeto.Shared.Queries;

namespace Projeto.Api.Controllers
{
    [Route("v1/Fornecedor")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        [HttpGet]
        public GenericQueryResult GetAll([FromServices] ListarFornecedorHandler handle)
        {
            // Criamos uma interface nova da query
            ListarFornecedorQuery query = new ListarFornecedorQuery();

            // Fazemos o comparativo para mostar somente os ativos para o usuario comum

            return (GenericQueryResult)handle.Handler(query);
        }
    }
}
