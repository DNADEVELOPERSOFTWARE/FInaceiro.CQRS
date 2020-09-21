using Domain.Commands.SharedCommands;
using FluentValidation;
using System;

namespace Domain.Commands.Validations.Shared
{
    public abstract class CategoriaValidation<T> : AbstractValidator<T> where T : CategoriaCommand
    {
        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Por favor preencha o campo da descrição")
                .Length(2, 150).WithMessage("A descrição precisa ter no entre 2 e 150 caracteres");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}