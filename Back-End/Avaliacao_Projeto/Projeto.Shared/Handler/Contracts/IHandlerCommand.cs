using Projeto.Shared.Commands;

namespace Projeto.Shared.Handler.Contracts
{
    public interface IHandlerCommand <T> where T : ICommand
    {
        ICommandResult Handler(T command);
   
    }
}
