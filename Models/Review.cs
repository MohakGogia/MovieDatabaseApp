using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Movie_Database_App.Models
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("reviewerName")]
        public string ReviewerName { get; set; }

        [BsonElement("comment")]
        public string Comment { get; set; }

        [BsonElement("rating")]
        public int Rating { get; set; }
    }
}
