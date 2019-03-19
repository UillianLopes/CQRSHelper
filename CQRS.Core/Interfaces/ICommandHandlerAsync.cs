using System.Threading.Tasks;

namespace CQRS.Core.Interfaces
{
    public interface ICommandHandlerAsync<TCommand, TCommandResponse> where TCommand : ICommand where TCommandResponse : ICommandResponse
    {
        Task<TCommandResponse> Handle(TCommand command);
    }
}
