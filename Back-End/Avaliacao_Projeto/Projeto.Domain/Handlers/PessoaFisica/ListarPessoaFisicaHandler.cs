using Projeto.Domain.Queries.PessoaFisica;
using Projeto.Domain.Repository;
using Projeto.Shared.Handler.Contracts;
using Projeto.Shared.Queries;
using System.Linq;
using static Projeto.Domain.Queries.PessoaFisica.ListarPessoaFisicaQuery;

namespace Projeto.Domain.Handlers.PessoaFisica
{
    public class ListarPessoaFisicaHandler : IHandlerQuery<ListarPessoaFisicaQuery>
    {
        private readonly IPessoaFisicaRepository _userFisicoRepositorio;

        public ListarPessoaFisicaHandler(IPessoaFisicaRepository userFisicoRepositorio)
        {
            _userFisicoRepositorio = userFisicoRepositorio;

        }

        public IQueryResult Handler(ListarPessoaFisicaQuery query)
        {
            var funPessoasFisicas = _userFisicoRepositorio.Listar();

            var retornoPessoasFisicas = funPessoasFisicas.Select(
                x =>
                {
                    return new ListarPessoaFisicaResult()
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        DataNascimento = x.DataNascimento,
                        RG = x.RG,
                        CPF = x.CPF,
                        Empresa = x.Empresa.NomeFantasia,
                        DataCadastro = x.DataCadastro,
                        Telefones = x.Telefones
                        .Select(x => x.Contato)

                    };
                }

            );

            return new GenericQueryResult(true , "Fornecedor físicos encontrados", retornoPessoasFisicas);
        }
    }
}
