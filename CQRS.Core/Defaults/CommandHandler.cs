namespace CQRS.Core.Defaults
{
    public abstract class CommandHandler
    {
        public CommandResponse Success(object data, params string[] messages) => new CommandResponse() { Data = data, Messages = messages, Success = true };
        public CommandResponse Success(params string[] messages) => new CommandResponse() { Messages = messages, Success = true };
        public CommandResponse Failure(object data, params string[] messages) => new CommandResponse() { Data = data, Messages = messages, Success = false };
        public CommandResponse Failure(params string[] messages) => new CommandResponse() { Messages = messages, Success = false };

    }
}
