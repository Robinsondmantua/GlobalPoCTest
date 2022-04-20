using Application.Features.Inventory.Commands.Request;
using Application.Features.Item.Commands.Validators;
using FluentAssertions;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GlobalPoC.Test.Application.Inventory.Validator
{
    public class DeleteItemInventoryCommandRequestValidatorTest
    {
		[Fact]
		public void ValidateMethod_WhenNameIsEmpty_ShouldReturnFalse()
		{
			//Arrange
			var _cut = new DeleteItemInventoryCommandRequestValidator();
			var requestToValidate = new DeleteItemInventoryCommandRequest(inventoryId: System.Guid.NewGuid(),String.Empty);

			//Act
			var v = _cut.TestValidate(requestToValidate);

			//Assert
			v.IsValid.Should().BeFalse();
		}
	}
}
