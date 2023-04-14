using MyProduct.Api.Entities;
using MongoDB.Driver;

namespace MyProduct.Api.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
