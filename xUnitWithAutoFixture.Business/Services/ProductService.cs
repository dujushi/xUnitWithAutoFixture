using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using xUnitWithAutoFixture.Common.Models;
using xUnitWithAutoFixture.Common.Repositories;
using xUnitWithAutoFixture.Common.Services;

namespace xUnitWithAutoFixture.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _productRepository;

        public ProductService(IMemoryCache memoryCache, IProductRepository productRepository)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var cacheKey = $"{nameof(ProductService)}-{nameof(GetAllAsync)}";

            if (_memoryCache.TryGetValue(cacheKey, out IList<Product> products))
            {
                return products;
            }

            products = (await _productRepository.GetAllAsync(cancellationToken)).ToList();
            if (products.Any())
            {
                _memoryCache.Set(cacheKey, products);
            }

            return products;
        }

        public async Task<Product> GetByIdAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            if (productId == Guid.Empty)
            {
                throw new ArgumentException("Product ID cannot be empty.", nameof(productId));
            }

            var cacheKey = $"{nameof(ProductService)}-{nameof(GetByIdAsync)}-{productId}";

            if (_memoryCache.TryGetValue(cacheKey, out Product product))
            {
                return product;
            }

            product = await _productRepository.GetByIdAsync(productId, cancellationToken);
            if (product != null)
            {
                _memoryCache.Set(cacheKey, product);
            }

            return product;
        }
    }
}
