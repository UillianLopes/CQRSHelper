using System.Threading.Tasks;

namespace CQRSHelper.Core.Interfaces
{
    public interface ICommandHandlerAsync<TCommand> where TCommand : ICommand
    {
        Task<ICommandResponse> Handle(TCommand command);
    }
}
