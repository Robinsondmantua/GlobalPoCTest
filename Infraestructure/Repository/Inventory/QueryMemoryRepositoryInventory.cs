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
    /// Inventory's query repository 
    /// </summary>
    public class QueryMemoryRepositoryInventory : IQueryRepository<Domain.Aggregate.Inventory>
    {
        private readonly IContext _context;

        public QueryMemoryRepositoryInventory(IContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Domain.Aggregate.Inventory>> GetAllAsync()
        {
            return _context.Inventories;
        }

        public async Task<Domain.Aggregate.Inventory> GetByIdAsync(Guid id)
        {
            return _context.Inventories.FirstOrDefault(x => x.Id == id);
        }
    }
}
