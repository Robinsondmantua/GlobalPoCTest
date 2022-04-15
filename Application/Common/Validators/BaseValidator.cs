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
    /// Base validator for common request (A Guid, header information or something that identifies the request)
    /// </summary>
    public class BaseValidator : AbstractValidator<Guid>
    {
        public BaseValidator()
        {
            RuleFor(v => v)
            .NotEmpty();
        }
    }
}
