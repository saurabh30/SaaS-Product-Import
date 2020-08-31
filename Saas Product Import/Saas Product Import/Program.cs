using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Saas_Product_Import.Repository;
using Saas_Product_Import.Repository.SQL;
using Saas_Product_Import.Sources;

namespace Saas_Product_Import
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Wrong Input");
            }
            try
            {
                var sourceType = args[0];
                var filePath = args[1];
                /*Change only concrete implementaion to switch to mongo.*/
                var serviceCollection = new ServiceCollection().AddScoped<IBaseRepository, SQLRepository>();
                var serviceProvider = serviceCollection.BuildServiceProvider();
                var repository = serviceProvider.GetService<IBaseRepository>();

                ImportProduct.Start(sourceType, filePath, repository).Wait();
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine($"ArgumentException Error: {aex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.ReadKey();

        }
    }

    public static class ImportProduct
    {
        public static async Task Start(string sourceType, string path, IBaseRepository repository)
        {
            var source = SourceFactory.GetSource(sourceType);
            await source.Import(path, repository);
        }
    }
}
