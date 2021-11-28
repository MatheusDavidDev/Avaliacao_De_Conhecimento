using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Handlers.Funcionario;
using Projeto.Domain.Queries.Funcionario;
using Projeto.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Api.Controllers
{
    [Route("v1/funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        [HttpGet]
        public GenericQueryResult GetAll([FromServices] ListarFuncionarioHandler handle)
        {
            // Criamos uma interface nova da query
            ListarFuncionarioQuery query = new ListarFuncionarioQuery();

            // Fazemos o comparativo para mostar somente os ativos para o usuario comum

            return (GenericQueryResult)handle.Handler(query);
        }
    }
}
