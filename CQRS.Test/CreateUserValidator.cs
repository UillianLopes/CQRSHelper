using CQRSHelper.Validators.Classes;
using CQRSHelper.Validators.Extensions;

namespace CQRSHelper.Test
{
    public class CreateUserValidator : CommandValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            Property(x => x.Name)
                .HasMaxLength(10, "O nome excede o tamanho maximo!")
                .IsNotNullOrEmpty("O nome não pode ser nulo!");

            Property(x => x.Age)
                .HasMaxValue(100, "A idade dever ser menor ou igual a 100!")
                .HasMinValue(1, "A idade deve ser maior ou igual que 1!");

            Property(x => x.CreateAddress)
                .HasValidator(new CreateAddressValidator());
        }
    }
}
