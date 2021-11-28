using Projeto.Domain.Queries.PessoaJuridica;
using Projeto.Domain.Repository;
using Projeto.Shared.Handler.Contracts;
using Projeto.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                        Telefones = x.Telefones,
                        DataCadastro = x.DataCadastro,
                        Empresa = x.Empresa.NomeFantasia,
                    };
                }

            );

            return new GenericQueryResult(true, "Funcionarios pessoas juridicas  encontrados", retornoPessoasJuridicas);
        }
    }
}
