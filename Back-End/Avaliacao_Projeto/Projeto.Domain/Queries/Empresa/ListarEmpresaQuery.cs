using Projeto.Shared.Queries;
using System;


namespace Projeto.Domain.Queries.Empresa
{
    public class ListarEmpresaQuery : IQuery
    {
        public void validar()
        {
            
        }

        public class ListarEmpresaResult
        {
            public Guid Id { get; set; }
            public string UF { get; set; }
            public string NomeFantasia { get; set; }
            public string CNPJ { get; set; }
        }
    }
}
