using NetDevPack.Domain;
using System;

namespace Domain.Models.Shared.Categories
{
    public class Categoria : Entity, IAggregateRoot
    {
        public Categoria(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        //Contrutor vazio para o EF
        protected Categoria(){}

        public string Descricao { get; private set; }

        //public virtual SistemaFinanceiro SistemaFinanceiro { get; set; }
    }
}
