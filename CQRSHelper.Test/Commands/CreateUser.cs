using CQRSHelper.Core.Interfaces;

namespace CQRSHelper.Test.Commands
{
    public class CreateUser : ICommand
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
    }
}
