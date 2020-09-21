using NetDevPack.Messaging;
using System;

namespace Domain.Events.EventsHandlers.Shared
{
    public class CategoriaRemovedEvent : Event
    {
        public CategoriaRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
