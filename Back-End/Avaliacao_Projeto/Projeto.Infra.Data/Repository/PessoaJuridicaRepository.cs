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
    public class PessoaJuridicaRepository : IPessoaJuridicaRepository
    {
        private readonly ProjetoContext _ctx;

        public PessoaJuridicaRepository(ProjetoContext context)
        {
            _ctx = context;
        }

        public PessoaJuridica BuscarCNPJ(string cnpj)
        {
            return _ctx.Juridico.FirstOrDefault(x => x.CNPJ == cnpj);
        }

        public void Cadastrar(PessoaJuridica novoFuncionario)
        {
            _ctx.Juridico.Add(novoFuncionario);
            _ctx.SaveChanges();
        }

        public ICollection<PessoaJuridica> Listar()
        {
            return _ctx.Juridico
                .Include(x => x.Empresa)
                .Include(x => x.Telefones)
                .OrderBy(x => x.DataCadastro)
                .ToList();


        }
    }
}
