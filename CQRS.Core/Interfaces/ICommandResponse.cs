namespace CQRSHelper.Core.Interfaces
{
    public interface ICommandResponse
    {
        bool Success { get; set; }
        object Data { get; set; }
        string[] Messages { get; set; }
    }
}
