using Domain.Commands.SharedCommands;
using Domain.Commands.Validations.Shared;
using System;

namespace Domain.Commands.Shared
{
    public class UpdateCategoriaCommand : CategoriaCommand
    {
        public UpdateCategoriaCommand(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCategoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
