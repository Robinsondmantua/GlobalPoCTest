﻿using Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common 
{
    public class EntityBase
    {
        protected int Id {get; set;}
        public ICollection<IDomainEvent>? Events { get; }
    }
}
