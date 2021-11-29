using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Projeto.Domain.Repository
{
    public interface IFornecedorRepository
    {
        /// <summary>
        /// Lista de funcionarios
        /// </summary>
        /// <returns> Retorna uma lista de funcionarios cadastrados </returns>
        ICollection<Fornecedor> Listar();

        /// <summary>
        /// Busca um funcionario pelo nome
        /// </summary>
        /// <param name="nome"> Nome do usuario buscado </param>
        /// <returns> Retorna os dados do usuario encontrado </returns>
        Fornecedor BuscarPorNome(string nome);

        /// <summary>
        /// Busca um funcionario pela data de cadastro
        /// </summary>
        /// <param name="data"> Data de </param>
        /// <returns></returns>
        Fornecedor BuscarPorDataCadastro(DateTime data);
    }
}
