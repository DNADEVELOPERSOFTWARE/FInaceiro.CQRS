using Domain.Models.Shared.Categories;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.SharedInterfaces.SharedValidations
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<Categoria> GetById(Guid id);
        Task<Categoria> GetByName(string descricao);
        Task<IEnumerable<Categoria>> GetAll();

        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Remove(Categoria categoria);
    }
}
