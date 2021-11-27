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
    public class Telefone : Base
    {
        public Telefone(string contato, Guid idFuncionario)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(contato, "Contato", "O Contato não pode ser vazio")
                .IsNotEmpty(idFuncionario, "IdFuncionario", "O Id Funcionario não pode ser vazio")

            );

            if (IsValid)
            {
                Contato = contato;
                this.idFuncionario = idFuncionario;
            }

            
        }

        public string Contato { get; private set; }

        // Composição
        public Guid idFuncionario { get; private set; }
        public Funcionario Funcionario { get; private set; }
    }
}
