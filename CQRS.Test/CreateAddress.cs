using CQRS.Core.Interfaces;

namespace CQRS.Test
{
    public class CreateAddress : ICommand
    {
        public int Number { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
    }
}
