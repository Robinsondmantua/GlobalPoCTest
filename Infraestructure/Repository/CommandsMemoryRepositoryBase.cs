using Application.Common.Interfaces;
using Domain.Common;
using Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class CommandsMemoryRepositoryBase<T> : ICommandRepository<T> where T : EntityBase
    {

        public T Add(T entity)
        {
            Context<T>.entities.Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            Context<T>.entities.Remove(entity);
        }

        public void Update(T entity)
        {
            var entityIndex = Context<T>.entities.FindIndex(x=>x.Id == entity.Id);
            
            if (entityIndex >=0)
            {
                Context<T>.entities[entityIndex] = entity; 
            }
        }
    }
}
