using Catalog.API.Entities;
using MongoDB.Driver;
using System.Threading.Tasks.Sources;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client  = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSetting:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSetting:CollectionName"));
        }

        public IMongoCollection<Product> Products { get; }
    }
}
