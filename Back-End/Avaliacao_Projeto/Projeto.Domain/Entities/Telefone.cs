using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Entities
{
    public class Telefone 
    {
        public Telefone(int contato, Funcionario funcionario)
        {
            Contato = contato;
            Funcionario = funcionario;
        }

        public Funcionario Funcionario { get; private set; }

        public int Contato { get; private set; }
    }
}
