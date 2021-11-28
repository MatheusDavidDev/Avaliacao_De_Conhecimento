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
        public CadastrarTelefoneCommand(string contato, Guid idFornecedor)
        {
            Contato = contato;
            this.idFornecedor = idFornecedor;
        }

        public string Contato { get; set; }
        public Guid idFornecedor { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Contato, "Contato", "O Contato não pode ser vazio")
                .IsNotEmpty(idFornecedor, "IdFuncionario", "O Id Funcionario não pode ser vazio")
            );
        }
    }
}
