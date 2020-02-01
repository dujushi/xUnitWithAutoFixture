using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using xUnitWithAutoFixture.Common.Models;

namespace xUnitWithAutoFixture.Common.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Product> GetByIdAsync(CancellationToken cancellationToken = default);
    }
}
