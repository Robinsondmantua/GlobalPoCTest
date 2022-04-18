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
    /// Item's command repository 
    /// </summary>
    public class QueryMemoryRepositoryItem : IQueryRepository<Domain.Entities.Item>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContext _context;

        public QueryMemoryRepositoryItem(IUnitOfWork unitOfWork, IContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<IReadOnlyList<Domain.Entities.Item>> GetAllAsync()
        {
            return _context.Items;
        }

        public async Task<Domain.Entities.Item> GetByIdAsync(Guid id)
        {
            return _context.Items.FirstOrDefault(x => x.Id == id);
        }
    }
}
