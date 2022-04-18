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
    public class NewInventoryCommandRequestValidator : AbstractValidator<NewInventoryCommandRequest>
    {
        /// <summary>
        /// Class to validate this request
        /// </summary>

        public NewInventoryCommandRequestValidator()
        {
            RuleFor(v => v.Name)
            .NotEmpty();
        }
    }
}
