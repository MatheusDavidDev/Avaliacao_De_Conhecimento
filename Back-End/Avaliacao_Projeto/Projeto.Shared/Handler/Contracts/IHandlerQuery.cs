using Projeto.Shared.Queries;

namespace Projeto.Shared.Handler.Contracts
{
    public interface IHandlerQuery<T> where T : IQuery
    {
        IQueryResult Handler(T query);
 
    }
}
