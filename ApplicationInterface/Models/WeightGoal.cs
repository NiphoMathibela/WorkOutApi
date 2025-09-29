using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class WeightGoal
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("userId")]
    public string UserId { get; set; }

    [BsonElement("targetWeight")]
    public float TargetWeight { get; set; }

    [BsonElement("currentWeight")] 
    public float CurrentWeight { get; set; }

    [BsonElement("targetDate")]
    public DateTime TargetDate { get; set; }
}