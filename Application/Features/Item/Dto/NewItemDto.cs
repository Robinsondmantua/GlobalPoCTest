using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.Dtos
{
    /// <summary>
    /// Dto to transfer information between layers
    /// </summary>
    public class NewItemDto
    {
        public string Name { get; set; }
        public ItemType? Type { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
