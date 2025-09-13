using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
internal class CatalogFaculties : IEnumerable, IEnumerator //стандартні інтерфейси для реалізації порівняння та ітерації
{
    private Faculty[] faculties; //масив факультетів
    private int currentIndex = -1; //індекс поточного факультету
    private Faculty[] sortedFaculties; //масив відсортованих факультетів
    /// <summary>
    /// Конструктор за замовчуванням
    /// </summary>
    public CatalogFaculties()
    {
        faculties = new Faculty[0]; //ініціалізація масиву факультетів
        sortedFaculties = new Faculty[0]; //ініціалізація масиву відсортованих факультетів
    }
    /// <summary>
    /// Конструктор з параметрами
    /// </summary>
    /// <param name="faculties"> масив факультетів </param>
    public CatalogFaculties(Faculty[] faculties)
    {
        this.faculties = faculties; //ініціалізація масиву факультетів
        this.sortedFaculties = new Faculty[faculties.Length]; //ініціалізація масиву відсортованих факультетів
        Array.Copy(faculties, sortedFaculties, faculties.Length); //копія масиву факультетів
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public Faculty[] Faculties
    {
        get
        {
            return faculties; //повернення масиву факультетів
        }
        set
        {
            faculties = value; //присвоєння масиву факультетів
            sortedFaculties = new Faculty[faculties.Length]; //ініціалізація масиву відсортованих факультетів
            Array.Copy(faculties, sortedFaculties, faculties.Length); //копія масиву факультетів
        }
    }
    /// <summary>
    /// Метод повернення нумератора для доступу до колекції
    /// </summary>
    /// <returns> нумератор </returns>
    public IEnumerator GetEnumerator()
    {
        return (IEnumerator)this;
    }
    /// <summary>
    /// Метод встановлення поточної позиції на початок
    /// </summary>
    public void Reset()
    {
        currentIndex = -1;
    }
    /// <summary>
    /// Метод для повернення поточної позиції
    /// </summary>
    public object Current
    {
        get 
        { 
            return faculties[currentIndex]; 
        }
    }
    /// <summary>
    /// Метод для переходу до наступного елемента
    /// </summary>
    /// <returns></returns>
    public bool MoveNext()
    {
        if (currentIndex < faculties.Length - 1)
        {
            currentIndex++;
            return true;
        }
        return false;
    }
    /// <summary>
    /// Метод для сортування факультетів за кількістю викладачів у зростаючому порядку
    /// </summary>
    /// <param name="service"> сервіс </param>
    public void SortByTeacherCount(Service service)
    {
        Array.Sort(faculties, TeacherCountComparer.SortTeacherAscending()); //сортування факультетів
        string data = "\n=== Faculties sorted by number of teachers ===\n";
        foreach (Faculty f in faculties)
        {
            data += $"Faculty: {f.FacultyName}, Teachers: {f.TeacherCount}, Departments: {f.DepartmentNumber}, Study Load: {f.StudyLoad}\n";
        }
        WriteToFile(service, data);
    }
    /// <summary>
    /// Метод для порівняння факультетів за кількістю кафедр та річним навантаженням
    /// </summary>
    /// <param name="service"> сервіс </param>
    /// <param name="faculty1"> перший факультет </param>
    /// <param name="faculty2"> другий факультет </param>
    public void CompareFaculties(Service service, Faculty faculty1, Faculty faculty2)
    {
        string data = "\n=== Faculties comparison ===\n";
        int result = CompareByDepartmentAndLoad(faculty1, faculty2); //порівняння факультетів
        if (result < 0)
        {
            data += $"{faculty1.FacultyName} has fewer departments or workload than {faculty2.FacultyName}\n";
        }
        else if (result > 0)
        {
            data += $"{faculty1.FacultyName} has more departments or workload than {faculty2.FacultyName}\n";
        }
        else
        {
            data += $"{faculty1.FacultyName} and {faculty2.FacultyName} have the same number of departments and workload\n";
        }
        WriteToFile(service, data);
    }
    /// <summary>
    /// Метод для порівняння факультетів за кількістю кафедр та річним навантаженням
    /// </summary>
    /// <param name="x"> перший факультет </param>
    /// <param name="y"> другий факультет </param>
    /// <returns> результат </returns>
    private int CompareByDepartmentAndLoad(Faculty x, Faculty y)
    {
        if (x.DepartmentNumber != y.DepartmentNumber)
        {
            return x.DepartmentNumber.CompareTo(y.DepartmentNumber);
        }
        return x.StudyLoad.CompareTo(y.StudyLoad);
    }
    /// <summary>
    /// Метод для запису даних у файл
    /// </summary>
    /// <param name="service"> сервіс </param>
    /// <param name="data"> інформація для запису </param>
    private void WriteToFile(Service service, string data)
    {
        string filePath = @"D:\Новая папка\C#\Lab4Ver4\faculty_comparison.txt";
        string existingData = "";
        service.PathToFile = filePath;
        if (File.Exists(filePath))
        {
            existingData = service.ReadFromFile();
        }
        service.Data = existingData + data;
        service.WriteData();
    }
}