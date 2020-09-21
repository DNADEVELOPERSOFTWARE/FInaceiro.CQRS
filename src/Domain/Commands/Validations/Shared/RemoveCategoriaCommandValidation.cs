using Domain.Commands.Shared;

namespace Domain.Commands.Validations.Shared
{
    public class RemoveCategoriaCommandValidation : CategoriaValidation<RemoveCategoriaCommand>
    {
        public RemoveCategoriaCommandValidation()
        {
            ValidateId();
        }
    }
}
