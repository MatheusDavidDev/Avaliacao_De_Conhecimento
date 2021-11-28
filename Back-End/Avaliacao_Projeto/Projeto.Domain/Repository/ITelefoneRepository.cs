using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Repository
{
    public interface ITelefoneRepository
    {
        /// <summary>
        /// Cadastra um telefone
        /// </summary>
        /// <param name="novoTelefone"> Objeto com os dados do novo telefone</param>
        void Cadastrar(Telefone novoTelefone);
    }
}
