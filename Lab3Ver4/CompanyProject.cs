using System;
using System.IO;
/// <summary>
/// Клас CompanyProject
/// </summary>

public static class CompanyProject
{
    static Service service = new Service(); //створення об'єкту класу Service

    /// <summary>
    /// Метод сортування масиву годин дисциплін за допомогою алгоритму сортування вставками
    /// </summary>
    /// <param name="disciplineHours"> масив годин </param>
    /// <param name="disciplines"> масив дисциплін </param>
    /// <param name="disciplineLecturers"> масив викладачів </param>
    public static void SortAndWriteDisciplineHours(int[] disciplineHours, string[] disciplines, string[] disciplineLecturers)
    {
        for (int i = 1; i < 40; i++)
        {
            int keyHour = disciplineHours[i]; 
            string keyDiscipline = disciplines[i];
            string keyLecturer = disciplineLecturers[i];
            int j = i - 1;
            while (j >= 0 && disciplineHours[j] > keyHour)
            {
                disciplineHours[j + 1] = disciplineHours[j]; //зсув більшого елементу
                disciplines[j + 1] = disciplines[j];
                disciplineLecturers[j + 1] = disciplineLecturers[j];
                j--; //зменшення індексу для перевірки попереднього
            }
            disciplineHours[j + 1] = keyHour; //вставка елемента на правильну позицію
            disciplines[j + 1] = keyDiscipline;
            disciplineLecturers[j + 1] = keyLecturer;
        }
    }
    /// <summary>
    /// Метод запису відсортованих дисциплін у файл
    /// </summary>
    /// <param name="disciplineHours"> масив годин </param>
    /// <param name="disciplines"> масив дисциплін </param>
    /// <param name="disciplineLecturers"> масив викладачів </param>
    public static void DisplaySortedDisciplines(int[] disciplineHours, string[] disciplines, string[] disciplineLecturers)
    {
        service.Data = "=== Sorted Disciplines by Hours ===\n";
        for (int i = 0; i < disciplineHours.Length; i++)
        {
            service.Data += $"Discipline: {disciplines[i]}, Hours: {disciplineHours[i]}, Lecturer: {disciplineLecturers[i]}\n";
        }
        service.PathToFile = @"D:\Новая папка\C#\Lab3Ver4\sorted_disciplines.txt";
        service.WriteData();
    }
}