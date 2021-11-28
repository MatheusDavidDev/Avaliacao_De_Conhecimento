using Flunt.Notifications;
using Flunt.Validations;
using Projeto.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Entities
{
    public class Fornecedor : Base
    {

        public Fornecedor(string nome, DateTime dataCadastro, Guid idEmpresa)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(nome, "Nome", "O Nome nao pode ser vazio")
                .IsNotNull(idEmpresa, "IdEmpresa", "O Id da empresa nao pode ser vazio")
                
            );

            if (IsValid)
            {
                Nome = nome;
                DataCadastro = dataCadastro;
                IdEmpresa = idEmpresa;

            }

        }

        public string Nome { get; private set; }
        public DateTime DataCadastro { get; private set; }


        //Composição
        public Guid IdEmpresa  { get; private set; }
        public Empresa Empresa { get; private set; }

        public IReadOnlyCollection<Telefone> Telefones { get; private set; }


    }
}
