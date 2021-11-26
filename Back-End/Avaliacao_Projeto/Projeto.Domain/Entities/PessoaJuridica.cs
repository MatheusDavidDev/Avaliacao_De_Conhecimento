using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Entities
{
    public class PessoaJuridica : Funcionario
    {
        public PessoaJuridica(string nome, Guid idEmpresa, string cNPJ)
            :base(nome, idEmpresa)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                //.IsNotEmpty(nome, "Nome", "O Nome nao pode ser vazio")
                //.IsNotNull(idEmpresa, "IdEmpresa", "O Id da empresa nao pode ser vazio")
                .IsNotEmpty(cNPJ, "CNPJ", "O CNPJ nao pode ser vazio")

            );

            if (IsValid)
            {
                CNPJ = cNPJ;

            }

        }

        public string CNPJ { get; private set; }
    }
}
