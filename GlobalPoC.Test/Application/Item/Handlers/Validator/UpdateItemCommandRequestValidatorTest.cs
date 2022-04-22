using Application.Features.Item.Commands.Request;
using Application.Features.Item.Commands.Validators;
using Application.Features.Item.Dtos;
using FluentAssertions;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GlobalPoC.Test.Application.Item
{
	public class UpdateItemCommandRequestValidatorTest
	{
		[Fact]
		public void ValidateMethod_WhenNameIsEmpty_ShouldReturnFalse()
		{
			//Arrange
			var _cut = new UpdateItemCommandValidator();
			var requestToValidate = new UpdateItemCommandRequest(new ItemDto { Id = Guid.NewGuid(), Name = String.Empty });

			//Act
			var v = _cut.TestValidate(requestToValidate);

			//Assert
			v.IsValid.Should().BeFalse();
		}
	}
}
