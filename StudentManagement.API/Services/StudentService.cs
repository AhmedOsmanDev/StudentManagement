using System.Collections.Generic;
using MongoDB.Driver;
using StudentManagement.API.Models;
using StudentManagement.API.Settings;

namespace StudentManagement.API.Services;

public class StudentService : IStudentService
{
    private readonly IMongoCollection<Student> _students;
    
    public StudentService(IStudentDbSetting setting, IMongoClient client)
    {
        _students = client.GetDatabase(setting.DatabaseName)
            .GetCollection<Student>(setting.CollectionName);
    }

    public List<Student> Get()
    {
        return _students.Find(student => true).ToList();
    }
    
    public Student Get(string id)
    {
        return _students.Find(student => student.Id == id).FirstOrDefault();
    }
    
    public string Add(Student student)
    {
        try
        {
            _students.InsertOne(student);
            return student.Id;
        }
        catch
        {
            return null;
        }
    }
    
    public bool Update(string id, Student student)
    {
        return _students.ReplaceOne(student => student.Id == id, student).IsAcknowledged;
    }
    
    public bool Delete(string id)
    {
        return _students.DeleteOne(student => student.Id == id).IsAcknowledged;
    }
}