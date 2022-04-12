using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    /// <summary>
    /// This interface defines methods for queries.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueryRepository<T> where T: class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
