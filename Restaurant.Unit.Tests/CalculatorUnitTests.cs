using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace Restaurant.Unit.Tests
{
    class CalculatorUnitTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [TestCase(0, 1000, 1000)]
        [TestCase(-1, -1, -2)]
        [TestCase(0, 0, 0)]
        [TestCase(10000, 10000, 20000)]
        public void Sum_ShouldReturnExpectedValue(int value1, int value2, int expectedResult)
        {
            // Arrange

            // Act
            var result = _calculator.Sum(value1, value2);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        public void Multiply_ShouldReturnExpectedValue()
        {
            // Arrange

            // Act
            var result = _calculator.Multiply(2, 2);

            // Assert
            result.Should().Be(4);
        }

        [Test]
        public void Multiply_ShouldReturnExpectedValue_2and0()
        {
            // Arrange

            // Act
            var result = _calculator.Multiply(2, 0);

            // Assert
            result.Should().Be(0);
        }
    }
}
