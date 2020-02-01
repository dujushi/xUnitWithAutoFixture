using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using xUnitWithAutoFixture.Common.Models;
using xUnitWithAutoFixture.Common.Services;

namespace xUnitWithAutoFixture.Business.Services
{
    public class ProductService : IProductService
    {
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
