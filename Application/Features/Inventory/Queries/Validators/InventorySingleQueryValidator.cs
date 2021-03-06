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
    /// Class to validate the request information when searching an inventory
    /// </summary>

    public class InventorySingleQueryValidator : AbstractValidator<InventorySingleQueryRequest>
    {
        public InventorySingleQueryValidator()
        {
            RuleFor(v => v.Id).SetValidator(new BaseValidator());
        }
    }
}
