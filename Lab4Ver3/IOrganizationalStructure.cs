using System;
/// <summary>
/// Інтерфейс для організаційної структури
/// </summary>
public interface IOrganizationalStructure
{
    /// <summary>
    /// Властивість
    /// </summary>
    string StructureName
    {
        get;
        set;
    }
    /// <summary>
    /// Властивість
    /// </summary>
    string ActivityDirection
    {
        get;
        set;
    }
    /// <summary>
    /// Властивість
    /// </summary>
    double ProcessQuality
    {
        get;
        set;
    }
    /// <summary>
    /// Властивість
    /// </summary>
    string PartnerStructure
    {
        get;
        set;
    }
    /// <summary>
    /// Властивість
    /// </summary>
    string[] Directions
    {
        get;
        set;
    }
    void ChangeName(string newName); //метод зміни назви структури
    void ChangeQuality(double newQuality); //метод зміни якості процесу
    void ConfirmPartnership(); //метод підтвердження партнерства
    void ChangePartnership(string newPartner); //метод зміни партнерства
    void AddDirection(string newDirection); //метод зміни напрямків підготовки
    void UpdateData(string action, string details = ""); //метод зміни даних
}