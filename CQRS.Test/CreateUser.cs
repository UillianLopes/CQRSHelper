using CQRSHelper.Core.Interfaces;
using System;

namespace CQRSHelper.Test
{
    public class CreateUser : ICommand
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Weigth { get; set; }
        public DateTime BirthDate { get; set; }

        public CreateAddress CreateAddress { get; set; }
    }
}
