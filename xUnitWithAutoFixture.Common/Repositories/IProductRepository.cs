using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using xUnitWithAutoFixture.Common.Models;

namespace xUnitWithAutoFixture.Common.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Product> GetByIdAsync(Guid productId, CancellationToken cancellationToken = default);
    }
}
