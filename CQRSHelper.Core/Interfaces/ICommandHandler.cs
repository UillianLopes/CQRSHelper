namespace CQRSHelper.Core.Interfaces
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        ICommandResponse Handle(TCommand command);
    }
}
