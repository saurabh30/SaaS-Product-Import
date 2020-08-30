using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Saas_Product_Import.Models;

namespace Saas_Product_Import.Repository.SQL
{
    public class SQLRepository : BaseRepository, ISQLRepository
    {
        public override Task<bool> Create(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
