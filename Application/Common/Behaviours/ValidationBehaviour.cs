using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Behaviours
{
	/// <summary>
	/// Mediatr pipeline to validate all incoming parameters using fluentvalidation. When the validation fails
	/// an exception is throwing
	/// </summary>
	/// <typeparam name="TRequest"></typeparam> Request
	/// <typeparam name="TResponse"></typeparam> Response
	public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			if (_validators.Any())
			{
				var context = new ValidationContext<TRequest>(request);

				var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
				var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

				if (failures.Count != 0)
				{
					throw new Application.Common.Exceptions.ValidationException(failures);
				}
			}
			return await next();
		}
	}
}
