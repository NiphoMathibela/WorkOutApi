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
    public string Description { get; set; } = null!;

    [BsonElement("muscleGroup")]
    public string MuscleGroup { get; set; } = null!;

    [BsonElement("equipment")]
    public string Equipment { get; set; } = null!;

    [BsonElement("type")]
    public string Type { get; set; } = null!;

    [BsonElement("instructions")]
    public string Instructions { get; set; } = null!;

    [BsonElement("gifUrl")]
    public string GifUrl { get; set; } = null!;

    [BsonElement("secondaryMuscleGroup")]
    public string SecondaryMuscleGroup { get; set; } = null!;

    [BsonElement("bodyPart")]
    public string BodyPart { get; set; } = null!;

    [BsonElement("repetitions")]
    public int? Repetitions { get; set; }

    [BsonElement("weight")]
    public float? Weight { get; set; }
}