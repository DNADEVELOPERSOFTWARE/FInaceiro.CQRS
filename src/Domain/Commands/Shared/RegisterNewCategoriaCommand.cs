using Domain.Commands.SharedCommands;
using Domain.Commands.Validations.Shared;

namespace Domain.Commands.Shared
{
    public class RegisterNewCategoriaCommand : CategoriaCommand
    {

        public RegisterNewCategoriaCommand(string descricao)
        {
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCategoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
