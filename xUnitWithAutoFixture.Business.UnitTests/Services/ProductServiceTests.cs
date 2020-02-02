using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoFixture.xUnit2.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Xunit;
using xUnitWithAutoFixture.Business.Services;
using xUnitWithAutoFixture.Common.Models;
using xUnitWithAutoFixture.Common.Repositories;

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

        [Theory, AutoMockData]
        public async Task GetByIdAsync_WhenCacheExists_ShouldNotUseRepository(
            Guid anonymousProductId,
            Product anonymousProduct,
            [Frozen] IMemoryCache memoryCache,
            [Frozen] IProductRepository productRepository,
            ProductService sut)
        {
            // arrange
            // We cannot do this directly, because it is an extension method.
            //Mock.Get(memoryCache)
            //    .Setup(x => x.TryGetValue(It.IsAny<string>(), out anonymousProduct))
            //    .Returns(true);

            var product = (object)anonymousProduct;
            Mock.Get(memoryCache)
                .Setup(x => x.TryGetValue(It.IsAny<string>(), out product))
                .Returns(true);

            // act
            await sut.GetByIdAsync(anonymousProductId);

            // assert
            Mock.Get(productRepository)
                .Verify(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
