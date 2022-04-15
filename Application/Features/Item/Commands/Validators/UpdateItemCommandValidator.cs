using Application.Common.Validators;
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
    public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommandRequest>
    {
        public UpdateItemCommandValidator()
        {
            RuleFor(v => v.RequestParams.Id).SetValidator(new BaseValidator());

            RuleFor(v => v.RequestParams.Name)
            .NotEmpty();
        }
    }
}
