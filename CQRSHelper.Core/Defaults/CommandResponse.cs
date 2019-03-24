using CQRSHelper.Core.Interfaces;
using System.Collections.Generic;

namespace CQRSHelper.Core.Defaults
{
    public class CommandResponse : ICommandResponse
    {
        public CommandResponse()
        {
        }

        public bool Success { get; set; }
        public object Data { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
}
