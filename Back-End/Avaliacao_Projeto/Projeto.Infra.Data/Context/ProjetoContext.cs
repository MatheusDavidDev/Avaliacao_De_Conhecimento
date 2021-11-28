using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Data.Context
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext(DbContextOptions<ProjetoContext> options) : base(options)
        {

        }

        //Tabelas
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<PessoaFisica> Fisico { get; set; }
        public DbSet<PessoaJuridica> Juridico { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            #region Mapeamento da tabela Empresas
            //ID
            modelBuilder.Entity<Empresa>().Property(x => x.Id);

            // UF
            modelBuilder.Entity<Empresa>().Property(x => x.UF).HasColumnType("varchar(40)");

            //NOME FANTASIA
            modelBuilder.Entity<Empresa>().Property(x => x.NomeFantasia).HasColumnType("varchar(200)");

            //CNPJ
            modelBuilder.Entity<Empresa>().Property(x => x.CNPJ).HasColumnType("varchar(200)");

            #endregion

            #region Mapeamento da tabela Fornecedores
            //ID
            modelBuilder.Entity<Fornecedor>().Property(x => x.Id);

            // Foreign key Empresa
            modelBuilder.Entity<Fornecedor>().HasOne(p => p.Empresa).WithMany(x => x.Fornecedores).HasForeignKey(x => x.IdEmpresa);

            //NOME 
            modelBuilder.Entity<Fornecedor>().Property(x => x.Nome).HasColumnType("varchar(200)");

            //Data de cadastro
            modelBuilder.Entity<Fornecedor>().Property(x => x.DataCadastro).HasColumnType("DateTime");
            #endregion

            #region Mapeamento da tabela Pessoa Fisica
            //ID
            //modelBuilder.Entity<PessoaFisica>().Property(x => x.Id);

            //CPF
            modelBuilder.Entity<PessoaFisica>().Property(x => x.CPF).HasColumnType("varchar(20)");
            modelBuilder.Entity<PessoaFisica>().HasIndex(x => x.CPF).IsUnique();

            //RG
            modelBuilder.Entity<PessoaFisica>().Property(x => x.RG).HasColumnType("varchar(20)");
            modelBuilder.Entity<PessoaFisica>().HasIndex(x => x.RG).IsUnique();

            //DATA NASCIMENTO
            modelBuilder.Entity<PessoaFisica>().Property(x => x.DataNascimento).HasColumnType("Date");

            #endregion

            #region Mapeamento da tapela Pessoa Juridica

            //ID
            //modelBuilder.Entity<PessoaJuridica>().Property(x => x.Id);

            //CNPJ
            modelBuilder.Entity<PessoaJuridica>().Property(x => x.CNPJ).HasColumnType("varchar(20)");
            modelBuilder.Entity<PessoaJuridica>().HasIndex(x => x.CNPJ).IsUnique();

            #endregion

            #region Mapeamento da tabela Telefones
            //ID
            modelBuilder.Entity<Telefone>().HasOne(p => p.Fornecedor).WithMany(x => x.Telefones).HasForeignKey(x => x.idFornecedor);

            // Telefone
            modelBuilder.Entity<Telefone>().Property(x => x.Contato).HasColumnType("varchar(20)");
            #endregion
        }
    }
}
