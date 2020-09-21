using Domain.Commands.Shared;

namespace Domain.Commands.Validations.Shared
{
    public class RegisterNewCategoriaCommandValidation : CategoriaValidation<RegisterNewCategoriaCommand>
    {
        public RegisterNewCategoriaCommandValidation()
        {
            ValidateDescricao();
        }
    }
}
