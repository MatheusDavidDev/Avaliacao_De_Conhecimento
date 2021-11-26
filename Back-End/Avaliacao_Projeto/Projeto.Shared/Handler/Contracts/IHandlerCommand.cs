using Projeto.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Shared.Handler.Contracts
{
    public interface IHandlerCommand <T> where T : ICommand
    {
        ICommandResult Handler(T command);
   
    }
}
