using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Repository
{
    public interface IPessoaJuridicaRepository
    {
        /// <summary>
        /// Cadastra um novo funcionario do tipo Pessoa juridicas
        /// </summary>
        /// <param name="novoFuncionario"> Objeto que contem os dados do novo funcionario </param>
        void Cadastrar(PessoaJuridica novoFuncionario);

        /// <summary>
        /// Lista de funcionarios que são pessoas fisicas
        /// </summary>
        /// <returns> Retorna uma lista de funcionarios que são pessoas juridicas cadastrados </returns>
        ICollection<PessoaJuridica> Listar();
    }
}
