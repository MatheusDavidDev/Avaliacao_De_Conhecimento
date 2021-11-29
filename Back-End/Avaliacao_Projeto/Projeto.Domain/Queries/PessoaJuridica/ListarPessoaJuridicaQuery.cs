using Projeto.Shared.Queries;
using System;
using System.Collections.Generic;

namespace Projeto.Domain.Queries.PessoaJuridica
{
    public class ListarPessoaJuridicaQuery : IQuery
    {
        public void validar()
        {
            
        }

        public class ListarPessoaJuridicaResult
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string Empresa { get; set; }
            public DateTime DataCadastro { get; set; }
            public string CNPJ { get; set; }
            public IEnumerable<Object> Telefones { get; set; }


        }
    }
}
