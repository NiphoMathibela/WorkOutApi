using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class WeightGoal
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("userId")]
    public string UserId { get; set; } = null!;

    [BsonElement("targetWeight")]
    public float TargetWeight { get; set; }

    [BsonElement("currentWeight")] 
    public float CurrentWeight { get; set; }

    [BsonElement("targetDate")]
    public DateTime TargetDate { get; set; }
}