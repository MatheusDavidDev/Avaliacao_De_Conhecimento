using Flunt.Notifications;
using Projeto.Domain.Commands.Empresa;
using Projeto.Domain.Repository;
using Projeto.Shared.Commands;
using Projeto.Shared.Handler.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Handlers.Empresa
{
    public class CadastrarEmpresaHandler : Notifiable<Notification>, IHandlerCommand<CadastrarEmpresaCommand>
    {
        private readonly IEmpresaRepository _empresaRepositorio;

        public CadastrarEmpresaHandler(IEmpresaRepository empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;

        }

        public ICommandResult Handler(CadastrarEmpresaCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(
                    false,
                    "Informe corretamente os dados da empresa",
                    command.Notifications
                );
            }
                // Verifica se a emrpesa existe
            var empresaExistente = _empresaRepositorio.BuscarPorCNPJ(command.CNPJ);
            if (empresaExistente != null)
                return new GenericCommandResult(false, "Empresa já cadastrada no sistama ", null);

            Entities.Empresa empresa = new Entities.Empresa
                (
                   command.UF.ToUpper(),
                   command.NomeFantasia,
                   command.CNPJ
                );
            if (!empresa.IsValid)
               return new GenericCommandResult(false, "Dados da empresa inválidos", empresa.Notifications);

            _empresaRepositorio.Cadastrar(empresa);

            return new GenericCommandResult(true, "Empresa cadastrada com sucesso", "Objeto");

        }
    }
}
