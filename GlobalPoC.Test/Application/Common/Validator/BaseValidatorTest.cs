using Application.Common.Validators;
using FluentAssertions;
using Xunit;

namespace GlobalPoC.Application.Inventory
{
    /// <summary>
    /// Unit test for BaseValidator class
    /// </summary>
	public class BaseValidatorTest
	{

		[Fact]
		public void ValidateMethod_WhenGuidIsEmpty_ShouldReturnFalse()
		{
			//Arrange
			var validator = new BaseValidator();

			//Act
			var v = validator.Validate(System.Guid.Empty);

			//Assert
			v.IsValid.Should().BeFalse();
		}

		[Fact]
		public void ValidateMethod_WhenGuidIsNotNull_ShouldReturnTrue()
		{
			//Arrange
			var validator = new BaseValidator();

			//Act
			var v = validator.Validate(System.Guid.NewGuid());

			//Assert
			v.IsValid.Should().BeTrue();
		}
	}
}
