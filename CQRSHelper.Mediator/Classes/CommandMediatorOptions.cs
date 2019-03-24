using System;
using System.Collections.Generic;

namespace CQRSHelper.Mediator.Classes
{
    public class CommandMediatorOptions
    {
        internal ICollection<Type> ValidatorsTypes { get; set; }
        internal ICollection<Type> HandlerTypes { get; set; }
    }
}
