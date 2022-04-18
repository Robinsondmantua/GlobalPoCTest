using Application.Common.Validators;
using Application.Features.Inventory.Queries.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Queries.Validators
{
    /// <summary>
    /// Class to validate the request information regarding with items expired in an related inventory.
    /// </summary>
    public class InventoryItemsExpiredQueryValidator : AbstractValidator<InventoryItemExpiredQueryRequest>
    {
        public InventoryItemsExpiredQueryValidator()
        {
            RuleFor(v => v.Id).SetValidator(new BaseValidator());
        }
    }
}
