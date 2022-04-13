using Application.Common.Interfaces;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class MemoryRepository<T> : ICommandRepository<T>, IQueryRepository<T>
        where T : EntityBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        protected List<T> entities = new List<T>();

        public MemoryRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            entities.Add(entity);
            await _unitOfWork.Commit(); 
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            entities.Remove(entity);
            await _unitOfWork.Commit();
        }

        public async Task UpdateAsync(T entity)
        {
            var entityIndex = entities.FindIndex(x=>x.Id == entity.Id);
            
            if (entityIndex >=0)
            {
                entities[entityIndex] = entity;
                await _unitOfWork.Commit();
            }
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return entities;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return entities.FirstOrDefault(x=>x.Id == id);
        }


    }
}
