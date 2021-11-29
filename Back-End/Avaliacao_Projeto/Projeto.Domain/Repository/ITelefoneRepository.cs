using Projeto.Domain.Entities;

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
