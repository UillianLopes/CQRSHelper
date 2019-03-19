using CQRSHelper.Core.Interfaces;

namespace CQRSHelper.Test
{
    public class CreateAddress : ICommand
    {
        public int Number { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
    }
}
