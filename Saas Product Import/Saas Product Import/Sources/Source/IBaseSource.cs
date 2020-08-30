using Saas_Product_Import.Common;
using Saas_Product_Import.Models;
using Saas_Product_Import.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saas_Product_Import.Sources.Source
{
    public interface IBaseSource
    {
        SourceType Source { get; set; }

        IList<Product> Products { get; }

        Task Import(string path, IBaseRepository repository); 
    }
}
