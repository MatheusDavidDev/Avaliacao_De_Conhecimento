using Flunt.Notifications;
using Projeto.Domain.Entities;
using Projeto.Domain.Repository;
using Projeto.Shared.Commands;
using Projeto.Shared.Handler.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Handlers.PessoaFisica
{
    public class CadastrarPessoaFisicaHandler : Notifiable<Notification>, IHandlerCommand<CadastrarPessoaFisicaCommand>
    {
        private readonly IPessoaFisicaRepository _userFisicoRepositorio;

        public CadastrarPessoaFisicaHandler(IPessoaFisicaRepository userFisicoRepositorio)
        {
            _userFisicoRepositorio = userFisicoRepositorio;

        }

        public ICommandResult Handler(CadastrarPessoaFisicaCommand command)
        {
            // Valida o command
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(
                    false,
                    "Informe corretamente os dados do funcionario fisico",
                    command.Notifications
                );
            }


            // Verifica se o usuario existe
            var userExistente = _userFisicoRepositorio.BuscarCPF(command.CPF);
            if (userExistente != null)
                return new GenericCommandResult(false, "Funcionario já cadastrado no sistema", null);



            Entities.PessoaFisica funcionario = new Entities.PessoaFisica
                (
                    command.Nome,
                    command.IdEmpresa,
                    command.DataCadastro = DateTime.Now,
                    command.RG,
                    command.CPF,
                    command.DataNascimento

                ); 
            if (!funcionario.IsValid)
                return new GenericCommandResult(false, "Dados de funcionario invalidos", funcionario.Notifications);

            _userFisicoRepositorio.Cadastrar(funcionario);


            return new GenericCommandResult(true, "Funcionario cadastrado com sucesso!", "Objeto");



        }
    }
}
