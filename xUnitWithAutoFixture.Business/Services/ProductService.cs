using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using xUnitWithAutoFixture.Common.Models;
using xUnitWithAutoFixture.Common.Repositories;
using xUnitWithAutoFixture.Common.Services;

namespace xUnitWithAutoFixture.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
