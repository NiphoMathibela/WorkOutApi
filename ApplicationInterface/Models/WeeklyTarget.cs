using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

public class WeeklyTarget
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("userId")]
    public string UserId { get; set; } = null!;

    [BsonElement("targetWorkoutsPerWeek")]
    public int? TargetWorkoutsPerWeek { get; set; }


    [BsonElement("completedWorkoutsThisWeek")]
    public int? CompletedWorkoutsThisWeek { get; set; }
    [BsonElement("weekStartDate")]
    public DateTime WeekStartDate { get; set; }

    [BsonElement("weekEndDate")]
    public DateTime WeekEndDate { get; set; }
}