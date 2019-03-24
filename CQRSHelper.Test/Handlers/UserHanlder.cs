using CQRSHelper.Core.Defaults;
using CQRSHelper.Core.Interfaces;
using CQRSHelper.Test.Commands;
using System.Threading.Tasks;

namespace CQRSHelper.Test.Handlers
{
    public class UserHanlder : CommandHandler, ICommandHandlerAsync<CreateUser>
    {
        public async Task<ICommandResponse> Handle(CreateUser command)
        {
            return Success("Deu certo!");
        }
    }
}
