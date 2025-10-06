using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;


public class Exercises
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("userId")]
    public string UserId { get; set; } = null!;

    [BsonElement("workoutId")]
    public string WorkoutId { get; set; } = null!;

    [BsonElement("name")]
    public string Name { get; set; } = null!;

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("muscleGroup")]
    public string? MuscleGroup { get; set; }

    [BsonElement("equipment")]
    public string? Equipment { get; set; }

    [BsonElement("type")]
    public string? Type { get; set; }

    [BsonElement("instructions")]
    public string? Instructions { get; set; }

    [BsonElement("gifUrl")]
    public string? GifUrl { get; set; }

    [BsonElement("secondaryMuscleGroup")]
    public string? SecondaryMuscleGroup { get; set; }

    [BsonElement("bodyPart")]
    public string? BodyPart { get; set; }

    [BsonElement("sets")]
    public int? Sets { get; set; }

    [BsonElement("repetitions")]
    public int? Repetitions { get; set; }

    [BsonElement("weight")]
    public float? Weight { get; set; }
}