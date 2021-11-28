using Projeto.Domain.Queries.Funcionario;
using Projeto.Domain.Repository;
using Projeto.Shared.Handler.Contracts;
using Projeto.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projeto.Domain.Queries.Funcionario.ListarFuncionarioQuery;

namespace Projeto.Domain.Handlers.Funcionario
{
    public class ListarFuncionarioHandler : IHandlerQuery<ListarFuncionarioQuery>
    {
        private readonly IFornecedorRepository _funcionarioRepositorio;

        public ListarFuncionarioHandler(IFornecedorRepository funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;

        }

        public IQueryResult Handler(ListarFuncionarioQuery query)
        {
            var funcionario = _funcionarioRepositorio.Listar();

            var retornoFuncionario = funcionario.Select(
                x =>
                {
                    return new ListarPessoaFisicaResult()
                    {
                        //Id = x.Id,
                        //Nome = x.Nome,
                        //DataNascimento = x.DataNascimento,
                        //RG = x.RG,
                        //CPF = x.CPF,
                        //Empresa = x.Empresa,
                        //Telefones = x.Telefones,
                        //DataCadastro = x.DataCadastro
                    };
                }

            );

            return new GenericQueryResult(true, "Funcionarios encontrados", funcionario);
        }
    }
}
