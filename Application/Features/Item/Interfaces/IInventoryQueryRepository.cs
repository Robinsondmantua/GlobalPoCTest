﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;

namespace Application.Features.Item.Interfaces.Queries
{
    /// Interface to define the different methods to handle the inventory's queries
    public interface IInventoryQueryRepository: IQueryRepository<Domain.Entities.Item>
    {
    }
}