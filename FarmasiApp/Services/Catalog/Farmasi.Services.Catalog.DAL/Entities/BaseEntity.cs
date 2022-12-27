using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Farmasi.Services.Catalog.DAL.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
