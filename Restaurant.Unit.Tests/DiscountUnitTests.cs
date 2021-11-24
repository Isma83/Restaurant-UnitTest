using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Restaurant.Unit.Tests
{
    public class DiscountUnitTests
    {
        private Discount _discount;

        private Mock<IClock> _clockMock;


        [SetUp]
        public void SetUp()
        {
            _clockMock = new Mock<IClock>();

            _discount = new Discount(_clockMock.Object);
        }

        [Test]
        public void CalculateTotalAfterDiscount_ShouldCalculateDiscount()
        {
            // Arrange
            var product = new Product
            {
                Code = 1001,
                Total = 100
            };

            _clockMock.Setup(clock => clock.GetDate(It.IsAny<int>())).Returns(new DateTime(2021, 2, 1));

            _clockMock.Setup(clock => clock.Now).Returns(new DateTime(2021, 2, 1));

            // Act
            var result = _discount.CalculateTotalAfterDiscount(product);

            // Assert
            result.Should().Be(90);
            _clockMock.Verify(clock => clock.Now, Times.Never);
        }

        [Test]
        public void CalculateTotalAfterDiscount_WhenIsSummer_ShouldCalculateWithSummerDiscount()
        {
            // Arrange
            var product = new Product
            {
                Code = 1001,
                Total = 0
            };

            // Act
            Action action = () => _discount.CalculateTotalAfterDiscount(product);

            // Assert
            action.Should().Throw<ArgumentException>();
        }
    }
}
