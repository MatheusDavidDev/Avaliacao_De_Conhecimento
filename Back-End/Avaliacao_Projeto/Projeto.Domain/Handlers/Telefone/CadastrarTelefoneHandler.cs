using Flunt.Notifications;
using Projeto.Domain.Commands;
using Projeto.Domain.Repository;
using Projeto.Shared.Commands;
using Projeto.Shared.Handler.Contracts;

namespace Projeto.Domain.Handlers
{
    public class CadastrarTelefoneHandler : Notifiable<Notification>, IHandlerCommand<CadastrarTelefoneCommand>
    {
        private readonly ITelefoneRepository _telefoneRepositorio;

        public CadastrarTelefoneHandler(ITelefoneRepository telefoneRepositorio)
        {
            _telefoneRepositorio = telefoneRepositorio;

        }
        public ICommandResult Handler(CadastrarTelefoneCommand command)
        {
            // Valida o command
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(
                    false,
                    "Informe corretamente os dados do telefone",
                    command.Notifications
                );
            }

            Entities.Telefone telefone = new Entities.Telefone
                (
                    command.Contato,
                    command.idFornecedor
                );

            if (!telefone.IsValid)
                return new GenericCommandResult(false, "Dados de funcionario invalidos", telefone.Notifications);

            _telefoneRepositorio.Cadastrar(telefone);


            return new GenericCommandResult(true, "Telefone cadastrado com sucesso!", "Objeto");
        }
    }
}
