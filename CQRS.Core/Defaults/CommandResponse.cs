using CQRSHelper.Core.Interfaces;

namespace CQRSHelper.Core.Defaults
{
    public class CommandResponse : ICommandResponse
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string[] Messages { get; set; }
    }
}
