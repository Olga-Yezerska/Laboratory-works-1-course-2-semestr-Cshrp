using System;
class SetOfDepartments
{
    private Department[] departments; // масив структур
    /// <summary>
    /// Конструктор за замовчуванням
    /// </summary>
    /// <param name="size"> розмір масиву </param>
    public SetOfDepartments(int size)
    {
        departments = new Department[size];
    }
    /// <summary>
    /// Доступ через індексатор
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Department this[int index]
    {
        get
        {
            return departments[index];
        }
        set
        {
            departments[index] = value;
        }
    }
}