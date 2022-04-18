using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    /// <summary>
    /// This interface define the method to notify an event.
    /// </summary>
   
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
        Task Rollback();
    }
}
