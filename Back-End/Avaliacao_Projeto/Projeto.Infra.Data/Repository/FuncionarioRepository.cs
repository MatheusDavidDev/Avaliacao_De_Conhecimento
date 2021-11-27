using Microsoft.EntityFrameworkCore;
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
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ProjetoContext _ctx;
        public FuncionarioRepository(ProjetoContext context)
        {
            _ctx = context;
        }
        public Funcionario BuscarPorDataCadastro(DateTime data)
        {
           return _ctx.Funcionarios.FirstOrDefault(x => x.DataCadastro == data);
        }

        public Funcionario BuscarPorNome(string nome)
        {
            return _ctx.Funcionarios.FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower());
        }

        public ICollection<Funcionario> Listar()
        {
            return _ctx.Funcionarios
                .AsNoTracking()
                .Include(x => x.Empresa)
                .Include(x => x.Telefones)
                .OrderBy(x => x.DataCadastro)
                .ToList();
        }
    }
}
