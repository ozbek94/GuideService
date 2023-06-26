using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GuideService.Domain.Entities
{
    public class PhoneNumber : EntityBase
    {
        [BsonElement("GSM")]
        public string GSM { get; set; }
    }
}
