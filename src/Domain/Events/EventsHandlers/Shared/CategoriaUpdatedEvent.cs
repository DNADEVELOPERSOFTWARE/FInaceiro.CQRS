using NetDevPack.Messaging;
using System;

namespace Domain.Events.EventsHandlers.Shared
{
    public class CategoriaUpdatedEvent : Event
    {
        public CategoriaUpdatedEvent(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            AggregateId = id;
        }

        public Guid Id { get; set; }

        public string Descricao { get; private set; }
    }
}
