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
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ProjetoContext _ctx;
        public EmpresaRepository(ProjetoContext context)
        {
            _ctx = context;
        }

        public Empresa BuscarPorCNPJ(string cnpj)
        {
            return _ctx.Empresas.FirstOrDefault(x => x.CNPJ == cnpj);
        }

        public void Cadastrar(Empresa novaEmpresa)
        {
            _ctx.Empresas.Add(novaEmpresa);
            _ctx.SaveChanges();
        }

        public ICollection<Empresa> Listar()
        {
            return _ctx.Empresas.AsNoTracking().ToList();
        }
    }
}
