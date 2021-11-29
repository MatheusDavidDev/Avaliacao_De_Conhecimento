using Projeto.Domain.Entities;
using System.Collections.Generic;

namespace Projeto.Domain.Repository
{
    public interface IEmpresaRepository
    {
        /// <summary>
        /// Cadastra uma nova empresa
        /// </summary>
        /// <param name="novaEmpresa"> Objeto com os dados da nova empresa </param>
        void Cadastrar(Empresa novaEmpresa);

        /// <summary>
        /// Busca empresa por CNPJ
        /// </summary>
        /// <param name="cnpj"> CNPJ Buscado </param>
        /// <returns> Dados da empresa buscada </returns>
        Empresa BuscarPorCNPJ(string cnpj);

        /// <summary>
        /// Lista de empresas
        /// </summary>
        /// <returns> Retorna a lista de empresas cadastradas </returns>
        ICollection<Empresa> Listar();

    }
}
