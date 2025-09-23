using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;


public class Exercises
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public int Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("muscleGroup")]
    public string MuscleGroup { get; set; }

    [BsonElement("equipment")]
    public string Equipment { get; set; }

    [BsonElement("type")]                               
    public string Type { get; set; }
    
    [BsonElement("instructions")]
    public string Instructions { get; set; }

    [BsonElement("gifUrl")]
    public string GifUrl { get; set; }

    [BsonElement("secondaryMuscleGroup")]
    public string SecondaryMuscleGroup { get; set; }

    [BsonElement("bodyPart")]
    public string BodyPart { get; set; }
}