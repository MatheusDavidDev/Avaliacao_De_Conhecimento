using Flunt.Notifications;
using Flunt.Validations;
using Projeto.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Commands
{
    public class CadastrarTelefoneCommand : Notifiable<Notification>, ICommand
    {
        public CadastrarTelefoneCommand()
        {

        }
        public CadastrarTelefoneCommand(string contato, Guid idFuncionario)
        {
            Contato = contato;
            this.idFuncionario = idFuncionario;
        }

        public string Contato { get; set; }
        public Guid idFuncionario { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Contato, "Contato", "O Contato não pode ser vazio")
                .IsNotEmpty(idFuncionario, "IdFuncionario", "O Id Funcionario não pode ser vazio")
            );
        }
    }
}
