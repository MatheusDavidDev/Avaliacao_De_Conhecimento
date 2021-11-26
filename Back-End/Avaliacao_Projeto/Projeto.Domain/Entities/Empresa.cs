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
    public class Empresa : Base
    {
        public Empresa(string uF, string nomeFantasia, string cNPJ)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(uF, "UF", "UF não pode ser vazio")
                    .IsNotEmpty(nomeFantasia, "NomeFantasia", "O nome fantasia não pode ser vazio")
                    .IsLowerThan(cNPJ, 15, "cnpj", "CNPJ invalido, por favor digite o correto")
                );

            if (IsValid)
            {
                UF = uF;
                NomeFantasia = nomeFantasia;
                CNPJ = cNPJ;
            }

            UF = uF;
            NomeFantasia = nomeFantasia;
            CNPJ = cNPJ;
        }

        public string UF { get; private set; }
        public string NomeFantasia { get; private set; }
        public string CNPJ { get; private set; }

    }
}
