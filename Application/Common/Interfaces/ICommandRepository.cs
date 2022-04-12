using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    /// <summary>
    /// This interface defines methods for commands.
    /// </summary>
    public interface ICommandRepository<T> where T: class
    {
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
