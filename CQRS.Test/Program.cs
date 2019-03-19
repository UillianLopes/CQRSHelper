using CQRSHelper.Core.Interfaces;
using CQRSHelper.Validators.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CQRSHelper.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = new CreateUser()
            {
                Name = "TESTE",
                Age = 200,
                CreateAddress = new CreateAddress()
                {
                    District = "ddddddddddddddddddddddddddd"
                }
            };

           var validations = GetValidator(command)
                .SelectMany(x => x.Validate(command));

            foreach (var item in validations)
            {
                Console.WriteLine(item);

            }

            Console.ReadLine();
          
        }

        public static IEnumerable<CommandValidator<TCommand>> GetValidator<TCommand>(TCommand command) where TCommand : ICommand
        {
            var assembly = Assembly.GetAssembly(typeof(CreateAddress));

            var typeValidators = assembly
                .GetTypes()
                .Where(x => x.BaseType == typeof(CommandValidator<TCommand>))
                .ToArray();

            foreach (var type in typeValidators)
            {
                yield return Activator.CreateInstance(type) as CommandValidator<TCommand>;
            }
        }
    }
}
