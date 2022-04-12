using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Item : EntityBase
    {
        public string Name { get; private set; }
        public ItemType? Type { get; private set; }
        public DateTime? ExpirationDate { get; private set; }

    }
}
