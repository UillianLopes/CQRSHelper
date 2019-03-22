using CQRSHelper.Core.Interfaces;
using System.Threading.Tasks;

namespace CQRSHelper.Mediator.Interfaces
{
    public interface ICommandMediator
    {
        ICommandResponse Send<TCommand>(TCommand command) where TCommand : ICommand;

        Task<ICommandResponse> SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
