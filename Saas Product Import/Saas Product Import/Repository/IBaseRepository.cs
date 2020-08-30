using Saas_Product_Import.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saas_Product_Import.Repository
{
    public interface IBaseRepository
    {
        Task<bool> Create(Product product);
    }
}
