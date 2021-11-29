using Projeto.Domain.Entities;
using System.Collections.Generic;


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
        /// Busca um funcionario pessoa Juridica por CNPJ
        /// </summary>
        /// <param name="cnpj"> CNPJ buscado </param>
        /// <returns> Dados do funcionario buscado</returns>
        PessoaJuridica BuscarCNPJ(string cnpj);

        /// <summary>
        /// Lista de funcionarios que são pessoas fisicas
        /// </summary>
        /// <returns> Retorna uma lista de funcionarios que são pessoas juridicas cadastrados </returns>
        ICollection<PessoaJuridica> Listar();
    }
}
