using System;
public partial class Department
{
    /// <summary>
    /// Метод формування навчального плану
    /// </summary>
    /// <param name="output"> інформація про навчальний план </param>
    /// <param name="dean"> декан факультету </param>
    /// <param name="departmentName"> назва кафедри </param>
    /// <param name="departmentHead"> завідувач кафедри </param>
    public void CreateCurriculum(string output, string dean, string departmentName, string departmentHead)
    {
        service.Data = $"=== Curriculum for {departmentName}===\n";
        service.Data += "Faculty Load: 7200 hours\n";
        service.Data += output;
        service.Data += $"\nCurriculum Approved by\nDepartment Head: {departmentHead}\nFaculty Dean: {dean}";
        service.PathToFile = @"D:\Новая папка\C#\Lab3Ver3\curriculum.txt";
        service.WriteData();
    }
}