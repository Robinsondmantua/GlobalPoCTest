using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Application.Common.Exceptions
{
	/// <summary>
	/// Exception uses when request data is not valid. Fills a dictionary with the errors.
	/// </summary>
	public class ValidationException : Exception
	{
		public ValidationException()
			: base("One or more validation failures have occurred.")
		{
			Errors = new Dictionary<string, string[]>();
		}

		public ValidationException(IEnumerable<ValidationFailure> failures)
			: this()
		{
			Errors = failures
				.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
				.ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
			Source = $"Error : {Errors?.FirstOrDefault().Key} - is not valid.";
		}

		public IDictionary<string, string[]> Errors { get; }
	}
}