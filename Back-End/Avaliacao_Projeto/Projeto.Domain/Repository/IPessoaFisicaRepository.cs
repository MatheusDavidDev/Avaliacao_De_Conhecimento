using Projeto.Domain.Entities;
using System.Collections.Generic;


namespace Projeto.Domain.Repository
{
    public interface IPessoaFisicaRepository
    {

        /// <summary>
        /// Cadastra um novo funcionario do tipo Pessoa Fisica
        /// </summary>
        /// <param name="novoFuncionario"> Objeto que contem os dados do novo funcionario </param>
        void Cadastrar(PessoaFisica novoFuncionario);

        /// <summary>
        /// Lista de funcionarios que são pessoas fisicas
        /// </summary>
        /// <returns> Retorna uma lista de funcionarios que são pessoas fisicas cadastrados </returns>
        ICollection<PessoaFisica> Listar();

        /// <summary>
        /// Busca um funcionario pessoa fisica por CPF
        /// </summary>
        /// <param name="cpf"> cpf buscado </param>
        /// <returns> Dados do funcionario buscado</returns>
        PessoaFisica BuscarCPF(string cpf);

    }
}
