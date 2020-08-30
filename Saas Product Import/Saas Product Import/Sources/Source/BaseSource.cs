using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Saas_Product_Import.Common;
using Saas_Product_Import.Models;
using Saas_Product_Import.Repository;

namespace Saas_Product_Import.Sources.Source
{
    public abstract class BaseSource : IBaseSource
    {
        public SourceType Source { get ; set ; }

        public IList<Product> Products { get; protected set; }

        public async Task Import(string path, IBaseRepository repository)
        {
            Console.WriteLine($"Importing Started");

            this.Products = await this.Map(path);
            await this.SaveData(repository);

            Console.WriteLine("Import completed");
        }

        protected virtual Task<StreamReader> GetFileFromSource(string path)
        {
            var reader = StreamReader.Null;
            return Task.FromResult(reader);
        }

        private Task SaveData(object dataService)
        {
            throw new NotImplementedException();
        }

        protected abstract Task<IList<Product>> Map(string path);
       
    }
}
