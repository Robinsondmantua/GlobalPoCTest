using Application.Common.Interfaces;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infraestructure.Repository
{
    public class CommandMemoryRepositoryItem : ICommandRepository<Domain.Entities.Item>
    
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContext _context;

        public CommandMemoryRepositoryItem(IUnitOfWork unitOfWork, IContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<Domain.Entities.Item> AddAsync(Domain.Entities.Item entity)
        {
            _context.Items.Add(entity);
            await _unitOfWork.Commit();
            return entity;
        }

        public async Task DeleteAsync(Domain.Entities.Item entity)
        {
            _context.Items.Remove(entity);
            await _unitOfWork.Commit();
        }

        public async Task UpdateAsync(Domain.Entities.Item entity)
        {
            var entityIndex = _context.Items.FindIndex(x=>x.Id == entity.Id);
            
            if (entityIndex >=0)
            {
                _context.Items[entityIndex] = entity;
                await _unitOfWork.Commit();
            }
        }
    }
}
