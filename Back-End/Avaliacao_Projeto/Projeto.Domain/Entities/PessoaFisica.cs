using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Entities
{
    public class PessoaFisica : Funcionario
    {
        public PessoaFisica(string nome, Guid idEmpresa, DateTime dataCadastro, string rG, string cPF, DateTime dataNascimento)
            : base(nome, dataCadastro, idEmpresa)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(cPF, "CPF", "O CPF nao pode ser vazio")
                .IsNotEmpty(rG, "RG", "O RG nao pode ser vazio")
                .IsNotNull(dataNascimento, "DataNascimento", "A Data de nascimento nao pode ser vazia")

            );

            if (IsValid)
            {
                RG = rG;
                CPF = cPF;
                DataNascimento = dataNascimento;
            }

        }

        public string RG { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }


    }
}
