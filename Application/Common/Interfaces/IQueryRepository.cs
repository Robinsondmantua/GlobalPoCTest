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
        IReadOnlyList<T> GetAllAsync();
        T GetByIdAsync(int id);
    }
}
