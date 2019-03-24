using System.Collections.Generic;

namespace CQRSHelper.Core.Interfaces
{
    public interface ICommandResponse
    {
        bool Success { get; set; }
        IEnumerable<string> Messages { get; set; }
    }
}
