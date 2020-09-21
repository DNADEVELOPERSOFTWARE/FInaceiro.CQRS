using Domain.Commands.Shared;
using Domain.Events.EventsHandlers.Shared;
using Domain.Interfaces.SharedInterfaces.SharedValidations;
using Domain.Models.Shared.Categories;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.CommandHandlers
{
    public class CategoriaCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCategoriaCommand, ValidationResult>,
        IRequestHandler<UpdateCategoriaCommand, ValidationResult>,
        IRequestHandler<RemoveCategoriaCommand, ValidationResult>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        
        public CategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewCategoriaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var categoria = new Categoria(Guid.NewGuid(), message.Descricao);

            if (await _categoriaRepository.GetByName(categoria.Descricao) != null)
            {
                AddError("Esta categoria já existe no sistema.");
                return ValidationResult;
            }

            categoria.AddDomainEvent(new CategoriaRegisteredEvent(categoria.Id, categoria.Descricao));

            _categoriaRepository.Add(categoria);

            return await Commit(_categoriaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateCategoriaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var categoria = new Categoria(message.Id, message.Descricao);
            var existingCategoria = await _categoriaRepository.GetByName(categoria.Descricao);

            if (existingCategoria != null && existingCategoria.Id != categoria.Id)
            {
                if (!existingCategoria.Equals(categoria))
                {
                    AddError("A Categoria já foi atualizada");
                    return ValidationResult;
                }
            }

            categoria.AddDomainEvent(new CategoriaUpdatedEvent(categoria.Id, categoria.Descricao));

            _categoriaRepository.Update(categoria);

            return await Commit(_categoriaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveCategoriaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var categoria = await _categoriaRepository.GetById(message.Id);

            if (categoria is null)
            {
                AddError("A categoria não exite.");
                return ValidationResult;
            }

            categoria.AddDomainEvent(new CategoriaRemovedEvent(message.Id));

            _categoriaRepository.Remove(categoria);

            return await Commit(_categoriaRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _categoriaRepository.Dispose();
        }
    }
}