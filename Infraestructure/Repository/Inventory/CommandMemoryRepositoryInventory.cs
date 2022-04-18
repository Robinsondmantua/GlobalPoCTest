using Application.Common.Interfaces;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infraestructure.Repository
{
    /// <summary>
    /// Inventory's command repository 
    /// </summary>
    public class CommandMemoryRepositoryInventory : ICommandRepository<Domain.Aggregate.Inventory>
    
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContext _context;

        public CommandMemoryRepositoryInventory(IUnitOfWork unitOfWork, IContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<Domain.Aggregate.Inventory> AddAsync(Domain.Aggregate.Inventory entity)
        {
            _context.Inventories.Add(entity);
            await _unitOfWork.Commit();
            return entity;
        }

        public async Task DeleteAsync(Domain.Aggregate.Inventory entity)
        {
            _context.Inventories.Remove(entity);
            await _unitOfWork.Commit();
        }

        public async Task UpdateAsync(Domain.Aggregate.Inventory entity)
        {
            var entityIndex = _context.Inventories.FindIndex(x=>x.Id == entity.Id);
            
            if (entityIndex >=0)
            {
                _context.Inventories[entityIndex] = entity;
                await _unitOfWork.Commit();
            }
        }
    }
}
