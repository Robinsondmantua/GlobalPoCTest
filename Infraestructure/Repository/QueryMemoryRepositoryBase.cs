using Application.Common.Interfaces;
using Domain.Common;
using Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class QueryMemoryRepositoryBase<T> : IQueryRepository<T> where T : EntityBase
    {
        public IReadOnlyList<T> GetAllAsync()
        {
            return Context<T>.entities;
        }

        public T GetByIdAsync(int id)
        {
            return Context<T>.entities.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
