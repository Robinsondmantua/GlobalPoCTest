using Application.Common.Validators;
using Application.Features.Item.Queries.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.Commands.Validatiors
{
    /// <summary>
    /// Class to validate this request
    /// </summary>
    public class ItemSingleQueryValidator : AbstractValidator<ItemSingleQueryRequest>
    {
        public ItemSingleQueryValidator()
        {
            RuleFor(v => v.Id).SetValidator(new BaseValidator());
        }
    }
}
