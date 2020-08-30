using System.Threading.Tasks;
using Saas_Product_Import.Models;

namespace Saas_Product_Import.Repository
{
    public abstract class BaseRepository : IBaseRepository
    {
        public abstract Task<bool> Create(Product product);
    }
}
