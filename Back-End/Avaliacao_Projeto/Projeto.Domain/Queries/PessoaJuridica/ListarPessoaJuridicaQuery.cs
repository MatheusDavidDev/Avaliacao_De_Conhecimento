using Projeto.Domain.Entities;
using Projeto.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public string CNPJ { get; set; }
            
            public IReadOnlyCollection<Telefone> Telefones { get; set; }
            public DateTime DataCadastro { get; set; }
            public string Empresa { get; set; }


        }
    }
}
