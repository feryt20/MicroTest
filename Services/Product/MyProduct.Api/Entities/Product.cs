using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyProduct.Api.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        [BsonElement("Name")]
        public required string Name { get; set; }

        public required string Category { get; set; }

        public required string Summary { get; set; }

        public required string Description { get; set; }

        public required string ImageFile { get; set; }

        public decimal Price { get; set; }
    }
}
