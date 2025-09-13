using System;
public class OrganizationalStructure
{
    protected string structureName; //назва структури
    protected string activityDirection; //напрям діяльності
    protected double processQuality; //якість процесу
    protected string partnerStructure; //партнерська структура
    protected string[] directions; //напрямки підготовки

    Service service = new Service(); //створення об'єкту класу Service

    /// <summary>
    /// Конструктор за замовчуванням
    /// </summary>
    protected OrganizationalStructure()
    {
        structureName = "";
        activityDirection = "";
        processQuality = 0.0;
        partnerStructure = "";
        directions = new string[0];
    }
    /// <summary>
    /// Конструктор з параметрами
    /// </summary>
    /// <param name="structureName"> назва структури </param>
    /// <param name="activityDirection"> напрям діяльності </param>
    /// <param name="processQuality"> якість процесу </param>
    /// <param name="partnerStructure"> партнерська структура </param>
    /// <param name="directions"> напрями підготовки </param>
    protected OrganizationalStructure(string structureName, string activityDirection, double processQuality, string partnerStructure, string[] directions)
    {
        this.structureName = structureName;
        this.activityDirection = activityDirection;
        this.processQuality = processQuality;
        this.partnerStructure = partnerStructure;
        this.directions = directions;
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string StructureName
    {
        get
        {
            return structureName;
        }
        set
        {
            structureName = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string ActivityDirection
    {
        get
        {
            return activityDirection;
        }
        set
        {
            activityDirection = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public double ProcessQuality
    {
        get
        {
            return processQuality;
        }
        set
        {
            processQuality = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string PartnerStructure
    {
        get
        {
            return partnerStructure;
        }
        set
        {
            partnerStructure = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string[] Directions
    {
        get
        {
            return directions;
        }
        set
        {
            directions = value;
        }
    }
    /// <summary>
    /// Метод зміни назви структури
    /// </summary>
    /// <param name="newName"> нова назва </param>
    public void ChangeName(string newName)
    {
        string oldName = structureName; //збереження старої назви
        structureName = newName; //зміна назви
        UpdateData(action: "Name Change", details: $"Old: {oldName}\nNew: {newName}"); //запис до файлу
    }
    /// <summary>
    /// Метод зміни якості процесу
    /// </summary>
    /// <param name="newQuality"> нова якість </param>
    public void ChangeQuality(double newQuality)
    {
        double oldQuality = processQuality; //збереження старої якості
        processQuality = newQuality; //зміна якості
        UpdateData(action: "Quality Update", details: $"Old value: {oldQuality:0.0}\nNew value: {newQuality:0.0}\n" + $"Change: {(newQuality - oldQuality):+0.0;-0.0;0}"); //запис до файлу
    }
    /// <summary>
    /// Метод підтвердження партнерських відносин
    /// </summary>
    public void ConfirmPartnership()
    {
        string partnershipActPath = @"D:\Новая папка\C#\Lab4\partnership_act.txt"; //шлях до файлу
        bool isConfirmed = File.Exists(partnershipActPath); //перевірка наявності файлу
        string message = "";
        if (isConfirmed) //якщо файл існує
        {
            message = "Partnership is confirmed: file partnership_act.txt found.\n"; //зміна статусу
        }
        else
        {
            message = "Partnership is not confirmed: file partnership_act.txt not found.\n";
        }
        UpdateData(action: "Partnership Verification", details: $"Status: {message}"); //запис до файлу
    }
    /// <summary>
    /// Метод зміни партнерських відносин
    /// </summary>
    /// <param name="newPartner"> новий партнер </param>
    public void ChangePartnership(string newPartner)
    {
        string oldPartner = partnerStructure; //збереження старого партнера
        partnerStructure = newPartner; //зміна партнера
        UpdateData(action: "Partnership Change", details: $"New partner: {newPartner}"); //запис до файлу
    }
    /// <summary>
    /// Метод додавання напрямів підготовки
    /// </summary>
    /// <param name="direction"> новий напрям </param>
    public void AddDirection(string direction)
    {
        string[] updatedDirections = new string[directions.Length + 1]; //створення нового масиву
        Array.Copy(directions, updatedDirections, directions.Length); //копіювання старих напрямів
        updatedDirections[directions.Length] = direction; //додавання нового напряму
        directions = updatedDirections; //оновлення масиву напрямів
        UpdateData(action: "New Direction Added", details: $"- {direction}\nTotal directions: {directions.Length}"); //запис до файлу
    }
    /// <summary>
    /// Метод оновлення даних
    /// </summary>
    /// <param name="action"> дія, яка відбувалась</param>
    /// <param name="details"> деталі операції </param>
    public void UpdateData(string action, string details = "")
    {
        string filePath = $@"D:\Новая папка\C#\Lab4Ver4\update_{structureName}.txt"; //шлях до файлу
        string logEntry = $"\n=== {structureName} Update ===\n"; //формування заголовка
        logEntry += $"Action: {action}\n"; //додавання дії
        logEntry += $"Details:\n{details}\n"; //додавання деталей
        string existingData = "";
        service.PathToFile = filePath; //встановлення шляху до файлу
        if (File.Exists(filePath)) //якщо файл існує
        {
            existingData = service.ReadFromFile(); //зчитування існуючих даних
        }
        string updatedData = existingData + logEntry; //оновлення даних
        service.Data = updatedData;
        service.WriteData();
    }
}