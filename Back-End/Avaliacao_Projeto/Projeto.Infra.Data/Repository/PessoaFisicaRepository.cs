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
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        private readonly ProjetoContext _ctx;
        public PessoaFisicaRepository(ProjetoContext context)
        {
            _ctx = context;
        }

        public PessoaFisica BuscarCPF(string cpf)
        {
            return _ctx.Fisico.FirstOrDefault(x => x.CPF == cpf);
        }

        public void Cadastrar(PessoaFisica novoFuncionario)
        {
            _ctx.Fisico.Add(novoFuncionario);
            _ctx.SaveChanges();
        }

        public ICollection<PessoaFisica> Listar()
        {
            return _ctx.Fisico
                .AsNoTracking()
                .Include(x => x.Empresa)
                .Include(x => x.Telefones)
                .OrderBy(x => x.DataCadastro)
                .ToList();
        }
    }
}
