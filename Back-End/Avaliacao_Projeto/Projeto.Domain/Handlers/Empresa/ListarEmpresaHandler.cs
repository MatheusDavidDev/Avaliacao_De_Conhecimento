using Projeto.Domain.Queries.Empresa;
using Projeto.Domain.Repository;
using Projeto.Shared.Handler.Contracts;
using Projeto.Shared.Queries;
using System.Linq;
using static Projeto.Domain.Queries.Empresa.ListarEmpresaQuery;

namespace Projeto.Domain.Handlers.Empresa
{
    public class ListarEmpresaHandler : IHandlerQuery<ListarEmpresaQuery>
    {
        private readonly IEmpresaRepository _empresaRepositorio;

        public ListarEmpresaHandler(IEmpresaRepository empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;

        }

        public IQueryResult Handler(ListarEmpresaQuery query)
        {
            var empresas = _empresaRepositorio.Listar();

            var retornoEmpresas = empresas.Select(
                x =>
                {
                    return new ListarEmpresaResult()
                    {
                        Id = x.Id,
                        UF = x.UF,
                        NomeFantasia = x.NomeFantasia,
                        CNPJ = x.CNPJ
                    };
                }
            );

            return new GenericQueryResult(true, "Empresas encontradas", retornoEmpresas);
        }
    }
}
