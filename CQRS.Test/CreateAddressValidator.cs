using CQRSHelper.Validators.Classes;
using CQRSHelper.Validators.Extensions;

namespace CQRSHelper.Test
{
    public class CreateAddressValidator : CommandValidator<CreateAddress>
    {
        public CreateAddressValidator()
        {
            Property(x => x.District)
                .HasMinLength(10, "O distrito pode ter no minimo 5 caracteres!")
                .HasMaxLength(10, "O distrito pode ter no máximo 10 caracteres!");
        }
    }
}
