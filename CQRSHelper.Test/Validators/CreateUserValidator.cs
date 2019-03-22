using CQRSHelper.Test.Commands;
using CQRSHelper.Validators.Classes;
using CQRSHelper.Validators.Extensions;

namespace CQRSHelper.Test.Validators
{
    public class CreateUserValidator : CommandValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            Property(x => x.Name)
                .HasMaxLength(10, "O nome pode ter no maximo 10 caracteres!")
                .IsNotNull("O nome do usuário não pode ser nulo");

            Property(x => x.Age)
                .HasMinValue(1, "A idade do usuário deve ser maior ou igual a 1");
        }
    }
}
