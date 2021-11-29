using Flunt.Notifications;
using Projeto.Domain.Commands.PessoaJuridica;
using Projeto.Domain.Repository;
using Projeto.Shared.Commands;
using Projeto.Shared.Handler.Contracts;
using System;

namespace Projeto.Domain.Handlers.PessoaJuridica
{
    public class CadastrarPessoaJuridicaHandler : Notifiable<Notification>, IHandlerCommand<CadastrarPessoaJuridicaCommand>
    {
        private readonly IPessoaJuridicaRepository _userJuridicoRepositorio;

        public CadastrarPessoaJuridicaHandler(IPessoaJuridicaRepository userJurudicoRepositorio)
        {
            _userJuridicoRepositorio = userJurudicoRepositorio;

        }

        public ICommandResult Handler(CadastrarPessoaJuridicaCommand command)
        {
            // Valida o command
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(
                    false,
                    "Informe corretamente os dados do fornecedor jurídico",
                    command.Notifications
                );
            }

            // Verifica se o usuario existe
            var userExistente = _userJuridicoRepositorio.BuscarCNPJ(command.CNPJ);
            if (userExistente != null)
                return new GenericCommandResult(false, "Fornecedor jurídico já cadastrado no sistema", null);

            Entities.PessoaJuridica funcionario = new Entities.PessoaJuridica
                (
                    command.Nome,
                    command.IdEmpresa,
                    DateTime.Now,
                    command.CNPJ
                );
            if (!funcionario.IsValid)
                return new GenericCommandResult(false, "Dados do fornecedor inválidos", funcionario.Notifications);

            _userJuridicoRepositorio.Cadastrar(funcionario);


            return new GenericCommandResult(true, "Fornecedor jurídico cadastrado com sucesso!", "Objeto");
        }
    }
}
