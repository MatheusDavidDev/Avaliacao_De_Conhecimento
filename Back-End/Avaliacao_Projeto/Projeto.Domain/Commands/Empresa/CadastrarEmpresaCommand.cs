using Flunt.Notifications;
using Flunt.Validations;
using Projeto.Shared.Commands;


namespace Projeto.Domain.Commands.Empresa
{
    public class CadastrarEmpresaCommand : Notifiable<Notification>, ICommand
    {
        public CadastrarEmpresaCommand()
        {

        }

        public CadastrarEmpresaCommand(string uF, string nomeFantasia, string cNPJ)
        {
            UF = uF;
            NomeFantasia = nomeFantasia;
            CNPJ = cNPJ;
        }

        public string UF { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }


        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(UF, "UF", "UF não pode ser vazio")
                    .IsNotEmpty(NomeFantasia, "NomeFantasia", "O nome fantasia não pode ser vazio")
                    .IsLowerThan(CNPJ, 15, "CNPJ", "CNPJ invalido, por favor digite o correto")
                );
        }
    }
}
