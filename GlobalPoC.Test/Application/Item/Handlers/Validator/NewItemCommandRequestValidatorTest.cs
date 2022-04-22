using Application.Features.Inventory.Commands.Request;
using Application.Features.Item.Commands.Request;
using Application.Features.Item.Commands.Validators;
using Application.Features.Item.Dtos;
using FluentAssertions;
using FluentValidation.TestHelper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GlobalPoC.Test.Application.Item
{
    public class NewItemCommandRequestValidatorTest
	{
		[Fact]
		public void ValidateMethod_WhenNameIsEmpty_ShouldReturnFalse()
		{
			//Arrange
			var _cut = new NewItemCommandValidator();
			var requestToValidate = new NewItemCommandRequest(new NewItemDto { Name = String.Empty });

			//Act
			var v = _cut.TestValidate(requestToValidate);

			//Assert
			v.IsValid.Should().BeFalse();
		}

		[Fact]
		public void ValidateMethod_WhenExpirationDateLessThanToday_ShouldReturnFalse()
		{
			//Arrange
			var _cut = new NewItemCommandValidator();
			var requestToValidate = new NewItemCommandRequest(new NewItemDto { Name = It.IsAny<string>(), ExpirationDate = DateTime.UtcNow.AddDays(-1)});

			//Act
			var v = _cut.TestValidate(requestToValidate);

			//Assert
			v.IsValid.Should().BeFalse();
		}
	}
}
