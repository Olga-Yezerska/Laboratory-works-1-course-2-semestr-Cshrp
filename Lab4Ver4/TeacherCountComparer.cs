using System.Collections;
/// <summary>
/// Клас для порівняння факультетів за кількістю викладачів.
/// </summary>
internal class TeacherCountComparer : IComparer
{
    /// <summary>
    /// Метод для порівняння двох факультетів за кількістю викладачів.
    /// </summary>
    /// <param name="x"> перший об'єкт для порівняння </param>
    /// <param name="y"> другий об'єкт для порівняння</param>
    /// <returns> результат </returns>
    int IComparer.Compare(object x, object y)
    {
        Faculty f1 = (Faculty)x;
        Faculty f2 = (Faculty)y;
        if (f1.TeacherCount < f2.TeacherCount)
        {
            return -1;
        }
        if (f1.TeacherCount > f2.TeacherCount)
        {
            return 1;
        }
        return 0;
    }
    /// <summary>
    /// Метод для отримання об'єкта IComparer для сортування факультетів за кількістю викладачів у зростаючому порядку.
    /// </summary>
    /// <returns> новий об'єкт </returns>
    public static IComparer SortTeacherAscending()
    {
        return (IComparer)new TeacherCountComparer();
    }
}