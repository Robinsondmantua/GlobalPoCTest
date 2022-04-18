using Application.Common.Validators;
using FluentAssertions;
using Xunit;

namespace RiaLink.UnitTest.Application.Validator
{
	public class BaseValidatorTest
	{

		[Fact]
		public void ValidateMethod_WhenGuidIsEmpty_ShouldReturnFalse()
		{
			//Arrange
			var validator = new BaseValidator();

			//Act
			var v = validator.Validate(new System.Guid());

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
