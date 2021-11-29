using Flunt.Notifications;
using Flunt.Validations;
using Projeto.Shared.Commands;
using System;

namespace Projeto.Domain.Commands.PessoaJuridica
{
    public class CadastrarPessoaJuridicaCommand : Notifiable<Notification>, ICommand
    {
        public CadastrarPessoaJuridicaCommand()
        {

        }

        public CadastrarPessoaJuridicaCommand(string nome, string cNPJ, Guid idEmpresa)
        {
            Nome = nome;
            CNPJ = cNPJ;
            IdEmpresa = idEmpresa;
        }

        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public Guid IdEmpresa { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(CNPJ, "CNPJ", "O CNPJ nao pode ser vazio")
                .IsNotEmpty(Nome, "Nome", "O Nome nao pode ser vazio")
                .IsNotNull(IdEmpresa, "IdEmpresa", "O Id da empresa nao pode ser vazio")
            );
        }
    }
}
