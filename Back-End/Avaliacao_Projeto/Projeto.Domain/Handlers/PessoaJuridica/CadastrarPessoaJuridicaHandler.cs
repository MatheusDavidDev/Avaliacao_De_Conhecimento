using Flunt.Notifications;
using Projeto.Domain.Commands.PessoaJuridica;
using Projeto.Domain.Repository;
using Projeto.Shared.Commands;
using Projeto.Shared.Handler.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    "Informe corretamente os dados do funcionario juridico",
                    command.Notifications
                );
            }

            // Verifica se o usuario existe
            var userExistente = _userJuridicoRepositorio.BuscarCNPJ(command.CNPJ);
            if (userExistente != null)
                return new GenericCommandResult(false, "Funcionario já cadastrado no sistema", null);

            Entities.PessoaJuridica funcionario = new Entities.PessoaJuridica
                (
                    command.Nome,
                    command.IdEmpresa,
                    command.DataCadastro = DateTime.Now,
                    command.CNPJ
                );
            if (!funcionario.IsValid)
                return new GenericCommandResult(false, "Dados de funcionario invalidos", funcionario.Notifications);

            _userJuridicoRepositorio.Cadastrar(funcionario);


            return new GenericCommandResult(true, "Funcionario cadastrado com sucesso!", "Objeto");
        }
    }
}
