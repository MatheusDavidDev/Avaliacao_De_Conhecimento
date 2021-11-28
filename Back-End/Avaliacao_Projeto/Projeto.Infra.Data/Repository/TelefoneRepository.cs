using Projeto.Domain.Entities;
using Projeto.Domain.Repository;
using Projeto.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Data.Repository
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly ProjetoContext _ctx;

        public TelefoneRepository(ProjetoContext context)
        {
            _ctx = context;
        }

        public void Cadastrar(Telefone novoTelefone)
        {
            _ctx.Telefones.Add(novoTelefone);
            _ctx.SaveChanges();
        }
    }
}
