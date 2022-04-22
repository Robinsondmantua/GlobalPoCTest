using Domain.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace GlobalPoC.Test.ValueObjects
{
    /// <summary>
    /// Unit test of PrefixBrandName domain class. 
    /// </summary>
    public class PrefixBrandNameTest
    {
        [Fact]
        public void PrefixBrandName_ShouldReturnException_WhenNameIsUnsupported()
        {
            FluentActions.Invoking(() => PrefixBrandName.SetName("TESTNAME"))
                .Should().Throw<ArgumentException>();
        }
    }
}