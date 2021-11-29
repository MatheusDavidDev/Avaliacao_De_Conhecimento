using Projeto.Domain.Queries.PessoaJuridica;
using Projeto.Domain.Repository;
using Projeto.Shared.Handler.Contracts;
using Projeto.Shared.Queries;
using System.Linq;
using static Projeto.Domain.Queries.PessoaJuridica.ListarPessoaJuridicaQuery;

namespace Projeto.Domain.Handlers.PessoaJuridica
{
    public class ListarPessoaJuridicaHandler : IHandlerQuery<ListarPessoaJuridicaQuery>
    {
        private readonly IPessoaJuridicaRepository _userJuridicoRepositorio;

        public ListarPessoaJuridicaHandler(IPessoaJuridicaRepository userJurudicoRepositorio)
        {
            _userJuridicoRepositorio = userJurudicoRepositorio;

        }

        public IQueryResult Handler(ListarPessoaJuridicaQuery query)
        {
            var funPessoasJuridicas = _userJuridicoRepositorio.Listar();

            var retornoPessoasJuridicas = funPessoasJuridicas.Select(
                x =>
                {
                    return new ListarPessoaJuridicaResult()
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        CNPJ = x.CNPJ,
                        Empresa = x.Empresa.NomeFantasia,
                        DataCadastro = x.DataCadastro,
                        Telefones = x.Telefones.Select(x => x.Contato)
                    };
                }

            );

            return new GenericQueryResult(true, "Fornecedores jurídicos encontrados", retornoPessoasJuridicas);
        }
    }
}
