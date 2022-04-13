using Application.Common.Interfaces;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class QueriesMemoryRepository<T> : IQueryRepository<T>
        where T : EntityBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContext _context;

        public QueriesMemoryRepository(IUnitOfWork unitOfWork, IContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return _context.entities;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return entities.FirstOrDefault(x=>x.Id == id);
        }


    }
}
