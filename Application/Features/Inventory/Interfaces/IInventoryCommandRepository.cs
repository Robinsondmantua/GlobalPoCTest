using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Interfaces;

namespace Application.Features.Inventory.Interfaces.Commands
{
    /// <summary>
    /// Interface to define the different methods to handle the inventory's commands
    /// </summary>
    public interface IInventoryCommandRepository: ICommandRepository<Domain.Aggregate.Inventory>
    {
    }
}
