using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    /// <summary>
    /// Unit of work pattern to confirm operations related with the BB.DD repository. 
    /// </summary>
    public class MemoryUnitOfWork : IUnitOfWork 
    {
        private readonly IEventNotificationService _eventNotificationService;

        public MemoryUnitOfWork(IEventNotificationService eventNotificationService)
        {
            _eventNotificationService = eventNotificationService;
        }

        public async Task Commit()
        {
            //Commit 
            await _eventNotificationService.Notify();
        }
        public async Task Rollback()
        {
            //Rollback
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
