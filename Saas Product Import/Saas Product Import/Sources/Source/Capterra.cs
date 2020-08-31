using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Saas_Product_Import.Models;

namespace Saas_Product_Import.Sources.Source
{
    public class Capterra : BaseSource, ICapterra
    {
        public Capterra()
        {
            this.Source = Common.SourceType.YAML;
        }
        protected async override Task<IList<Product>> Map(string path)
        {
            var file = await this.GetFileFromSource(path);
            /*This to be replaced by actual data*/
            return  new List<Product>() { new Product { } };
        }
    }
}
