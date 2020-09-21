using Domain.Commands.SharedCommands;
using Domain.Commands.Validations.Shared;
using System;

namespace Domain.Commands.Shared
{
    public class RemoveCategoriaCommand : CategoriaCommand
    {
        public RemoveCategoriaCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCategoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

