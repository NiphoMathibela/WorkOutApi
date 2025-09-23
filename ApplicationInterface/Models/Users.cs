using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Users
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public int Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonElement("Email")]
    public string Email { get; set; }
}