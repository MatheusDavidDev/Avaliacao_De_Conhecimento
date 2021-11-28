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
        public Telefone(string contato, Guid idFornecedor)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(contato, "Contato", "O Contato não pode ser vazio")
                .IsNotEmpty(idFornecedor, "IdFuncionario", "O Id Funcionario não pode ser vazio")

            );

            if (IsValid)
            {
                Contato = contato;
                this.idFornecedor = idFornecedor;
            }

            
        }

        public string Contato { get; private set; }

        // Composição
        public Guid idFornecedor { get; private set; }
        public Fornecedor Fornecedor { get; private set; }
    }
}
