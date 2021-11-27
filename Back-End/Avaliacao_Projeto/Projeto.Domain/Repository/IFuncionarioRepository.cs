using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Repository
{
    public interface IFuncionarioRepository
    {
        /// <summary>
        /// Lista de funcionarios
        /// </summary>
        /// <returns> Retorna uma lista de funcionarios cadastrados </returns>
        ICollection<Funcionario> Listar();

        /// <summary>
        /// Busca um funcionario pelo nome
        /// </summary>
        /// <param name="nome"> Nome do usuario buscado </param>
        /// <returns> Retorna os dados do usuario encontrado </returns>
        Funcionario BuscarPorNome(string nome);

        /// <summary>
        /// Busca um funcionario pela data de cadastro
        /// </summary>
        /// <param name="data"> Data de </param>
        /// <returns></returns>
        Funcionario BuscarPorDataCadastro(DateTime data);
    }
}
