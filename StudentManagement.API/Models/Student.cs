using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentManagement.API.Models;

public class Student
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    public string Name { get; set; }
    [BsonElement("graduated")]
    public bool IsGraduate { get; set; }
    public string[] Courses { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
}