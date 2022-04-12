using Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Test
{
    /// <summary>
    /// Unit test of PrefixBrandName domain class. 
    /// </summary>
    public class PrefixBrandNameTest
    {
        [SetUp]
        public void PrefixBrandName_ShouldReturnException_WhenNameIsUnsupported()
        {
            FluentActions.Invoking(() => PrefixBrandName.SetName("TESTNAME"))
                .Should().Throw<ArgumentException>();
        }
    }
}