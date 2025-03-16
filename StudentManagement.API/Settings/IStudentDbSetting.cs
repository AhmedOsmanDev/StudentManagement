namespace StudentManagement.API.Settings;

public interface IStudentDbSetting
{
    string DatabaseName { get; set; }
    string CollectionName { get; set; }
}