using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GuideService.Domain.Entities
{
    public class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    }
}
