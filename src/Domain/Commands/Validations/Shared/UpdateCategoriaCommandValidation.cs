using Domain.Commands.Shared;

namespace Domain.Commands.Validations.Shared
{
    public class UpdateCategoriaCommandValidation : CategoriaValidation<UpdateCategoriaCommand>
    {
        public UpdateCategoriaCommandValidation()
        {
            ValidateId();
            ValidateDescricao();
        }
    }
}
