using Flunt.Notifications;
using Flunt.Validations;
using Projeto.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Entities
{
    public class CadastrarPessoaFisicaCommand : Notifiable<Notification>, ICommand
    {
        public CadastrarPessoaFisicaCommand()
        {

        }

        public CadastrarPessoaFisicaCommand(string nome, Guid idEmpresa, string rG, string cPF, DateTime dataNascimento)
        {
            Nome = nome;
            IdEmpresa = idEmpresa;
            RG = rG;
            CPF = cPF;
            DataNascimento = dataNascimento;
        }

        public string Nome { get; set; }
        public Guid IdEmpresa { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }



        public void Validar()
        {
            if ((Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(DataNascimento.ToString("yyyy"))) < 18)
                AddNotification("DataNacimento", "O Funcionario não pode ser menor de 18 anos");
            Console.WriteLine((Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(DataNascimento.ToString("yyyy"))));

            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Nome, "Nome", "O Nome nao pode ser vazio")
                .IsNotNull(IdEmpresa, "IdEmpresa", "O Id da empresa nao pode ser vazio")
                .IsNotEmpty(CPF, "CPF", "O CPF nao pode ser vazio")
                .IsNotEmpty(RG, "RG", "O RG nao pode ser vazio")
                
            );
        }
    }
}
