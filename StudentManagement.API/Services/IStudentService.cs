using System.Collections.Generic;
using StudentManagement.API.Models;

namespace StudentManagement.API.Services;

public interface IStudentService
{
    List<Student> Get();
    Student Get(string id);
    string Add(Student student);
    bool Update(string id, Student student);
    bool Delete(string id);
}