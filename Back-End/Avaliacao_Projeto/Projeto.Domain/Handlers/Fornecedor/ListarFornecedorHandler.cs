using Projeto.Domain.Queries.Funcionario;
using Projeto.Domain.Repository;
using Projeto.Shared.Handler.Contracts;
using Projeto.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projeto.Domain.Queries.Funcionario.ListarFornecedorQuery;

namespace Projeto.Domain.Handlers.Funcionario
{
    public class ListarFornecedorHandler : IHandlerQuery<ListarFornecedorQuery>
    {
        private readonly IFornecedorRepository _funcionarioRepositorio;

        public ListarFornecedorHandler(IFornecedorRepository funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;

        }

        public IQueryResult Handler(ListarFornecedorQuery query)
        {
            var fornecedor = _funcionarioRepositorio.Listar();

            var retornoFornecedor = fornecedor.Select(
                x =>
                {
                    return new ListarPessoaFisicaResult()
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Empresa = x.Empresa.NomeFantasia,
                        DataCadastro = x.DataCadastro,
                        Telefones = x.Telefones.Select(x => x.Contato)
                    };
                }

            );

            return new GenericQueryResult(true, "Fornecedores encontrados", retornoFornecedor);
        }
    }
}
