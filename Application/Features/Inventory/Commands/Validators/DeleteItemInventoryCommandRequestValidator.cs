using Application.Common.Validators;
using Application.Features.Inventory.Commands.Request;
using Application.Features.Item.Commands.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.Commands.Validators
{
    /// <summary>
    /// Class to validate this request
    /// </summary>
    public class DeleteItemInventoryCommandRequestValidator : AbstractValidator<DeleteItemInventoryCommandRequest>
    {
        public DeleteItemInventoryCommandRequestValidator()
        {
            RuleFor(v => v.InventoryId).SetValidator(new BaseValidator());
            RuleFor(v => v.ItemName).NotEmpty();
        }
    }
}
