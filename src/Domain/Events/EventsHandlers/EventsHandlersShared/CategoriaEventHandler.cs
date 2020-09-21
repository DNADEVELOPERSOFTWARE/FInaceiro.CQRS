using Domain.Events.EventsHandlers.Shared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Events.EventsHandlers.EventsHandlersShaed
{
    public class CategoriaEventHandler :
        INotificationHandler<CategoriaRegisteredEvent>,
        INotificationHandler<CategoriaUpdatedEvent>,
        INotificationHandler<CategoriaRemovedEvent>
    {
        public Task Handle(CategoriaUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(CategoriaRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }


        public Task Handle(CategoriaRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}