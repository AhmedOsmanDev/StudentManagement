namespace StudentManagement.API.Settings;

public class StudentDbSetting : IStudentDbSetting
{
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }
}