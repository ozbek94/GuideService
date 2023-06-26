using MongoDB.Bson.Serialization.Attributes;

namespace GuideService.Domain.Entities
{
    public class Person : EntityBase
    {
        [BsonElement("firstname")]
        public string Firstname { get; set; }
        [BsonElement("lastname")]
        public string LastName { get; set; }
        [BsonElement("phoneNumbers")]
        public virtual List<PhoneNumber> PhoneNumbers { get; set; }
        [BsonElement("descriptions")]
        public string Description { get; set; }
    }
}
