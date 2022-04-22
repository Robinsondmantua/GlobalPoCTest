using Application.Features.Item.Commands.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.Commands.Validators
{
    public class NewItemCommandValidator : AbstractValidator<NewItemCommandRequest>
    {
        /// <summary>
        /// Class to validate this request
        /// </summary>

        public NewItemCommandValidator()
        {
            RuleFor(v => v.RequestParams.ExpirationDate)
            .Must(x => x >= DateTime.Today)
            .When(v => v.RequestParams.ExpirationDate.HasValue);

            RuleFor(v => v.RequestParams.Name)
            .NotEmpty();
        }
    }
}
