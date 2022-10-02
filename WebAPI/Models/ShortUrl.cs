using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Web_API.Models
{
    public class ShortUrl
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Hash")]
        public string Hash { get; set; }
        [BsonElement("OriginalUrl")]
        public string OriginalUrl { get; set; }
    }
}
