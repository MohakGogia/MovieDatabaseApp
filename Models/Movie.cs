using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Movie_Database_App.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("director")]
        public string Director { get; set; }

        [BsonElement("genre")]
        public string Genre { get; set; }

        [BsonElement("releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [BsonElement("reviews")]
        public List<Review> Reviews { get; set; }
    }
}
