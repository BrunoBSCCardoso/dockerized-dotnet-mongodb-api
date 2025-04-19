
using MongoDB.Bson.Serialization.Attributes;

namespace DockerVolumesPersistency.Models
{
    public class Counters
    {
        [BsonId]
        public string Id { get; set; } = string.Empty;

        [BsonElement("count")]
        public int Count { get; set; }
    }
}
