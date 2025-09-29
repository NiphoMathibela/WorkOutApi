using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

public class WorkoutLogs
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("userId")]
    public string UserId { get; set; }

    [BsonElement("workoutId")]
    public int WorkoutId { get; set; }

    [BsonElement("date")]
    public DateTime Date { get; set; }

}