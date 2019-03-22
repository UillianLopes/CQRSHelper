using System;
using System.Collections.Generic;

namespace CQRSHelper.Mediator.Classes
{
    public class CommandMediatorOptions
    {
        public ICollection<Type> ValidatorsTypes { get; set; }
        public ICollection<Type> HandlerTypes { get; set; }

    }
}
