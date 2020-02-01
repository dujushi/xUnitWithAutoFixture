using System;
using System.Threading.Tasks;
using AutoFixture.xUnit2.AutoMoq;
using FluentAssertions;
using Xunit;
using xUnitWithAutoFixture.Business.Services;
using xUnitWithAutoFixture.Common.Models;

namespace xUnitWithAutoFixture.Business.UnitTests.Services
{
    public class ProductServiceTests
    {
        [Theory, AutoMockData]
        public void GetByIdAsync_WhenProductIdIsEmpty_ThrowsArgumentException(ProductService sut)
        {
            // arrange
            // act
            Func<Task<Product>> func = () => sut.GetByIdAsync(Guid.Empty);
            // assert
            func.Should().Throw<ArgumentException>()
                .WithMessage("Product ID cannot be empty. *")
                .And.ParamName.Should().Be("productId");
        }
    }
}
