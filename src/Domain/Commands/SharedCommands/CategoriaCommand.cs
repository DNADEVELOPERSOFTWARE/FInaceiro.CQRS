using NetDevPack.Messaging;
using System;

namespace Domain.Commands.SharedCommands
{
    public abstract class CategoriaCommand :Command
    {
        public Guid Id { get; protected set; }

        public string Descricao { get; protected set; }

       
    }
}
