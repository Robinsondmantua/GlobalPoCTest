using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    /// <summary>
    /// This interface defines methods for commands (Insert,Update and delete actions).
    /// </summary>
    public interface ICommandRepository<T> where T: class
    {
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
