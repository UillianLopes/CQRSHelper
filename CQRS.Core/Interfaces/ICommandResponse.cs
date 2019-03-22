using System.Collections.Generic;

namespace CQRSHelper.Core.Interfaces
{
    public interface ICommandResponse
    {
        bool Success { get; set; }
        object Data { get; set; }
        IEnumerable<string> Messages { get; set; }
    }
}
