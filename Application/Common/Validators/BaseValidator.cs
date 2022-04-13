using Application.Common.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Validators
{
    /// <summary>
    /// Base validator for common request (An Id, header information or something like that)
    /// </summary>
    public class BaseValidator : AbstractValidator<IdentityRequestDto>
    {
        public BaseValidator()
        {
            RuleFor(v => v.Id)
            .NotEmpty();
        }
    }
}
