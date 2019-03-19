namespace CQRSHelper.Core.Interfaces
{
    public interface ICommandHandler<TCommand, TCommandResponse> where TCommand : ICommand where TCommandResponse : ICommandResponse
    {
        TCommandResponse Handle(TCommand command);
    }
}
