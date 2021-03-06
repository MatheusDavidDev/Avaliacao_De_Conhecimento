using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Projeto.Domain.Entities
{
    public class PessoaJuridica : Fornecedor
    {
        public PessoaJuridica(string nome, Guid idEmpresa, DateTime dataCadastro, string cNPJ)
            :base(nome, dataCadastro, idEmpresa)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
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
