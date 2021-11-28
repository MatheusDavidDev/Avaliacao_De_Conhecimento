using Projeto.Domain.Entities;
using Projeto.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Queries.Funcionario
{
    public class ListarFornecedorQuery : IQuery
    {
        public void validar()
        {
            
        }

        public class ListarPessoaFisicaResult
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string Empresa { get; set; }
            public DateTime DataCadastro { get; set; }
            public IEnumerable<Object> Telefones { get; set; }

        }
    }
}
