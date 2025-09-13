using System;
public class ITCompany : OrganizationalStructure
{

    Service service = new Service(); //створення об'єкту класу Service

    /// <summary>
    /// Конструктор за замовченням
    /// </summary>
    public ITCompany() : base()
    {
        structureName = "";
        activityDirection = "";
        partnerStructure = "";
        processQuality = 0.0;
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string CompanyName
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
    public string ActivityField
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
    public string PartnerFaculty
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
    public double TrainingQuality
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
    /// Метод пошуку факультету для партнерства 
    /// </summary>
    public void SearchFaculty()
    {
        service.PathToFile = @"D:\Новая папка\C#\Lab4Ver4\setup_data.txt"; //шлях до файлу
        string setupData = service.ReadFromFile(); //зчитування даних з файлу
        string[] lines = setupData.Split('\n'); //розділ файлу на рядки
        string facultyLine = null; // ініціалізація змінної для зберігання рядка
        foreach (string line in lines)
        {
            if (line.Contains("Faculty:")) //якщо рядок має "Faculty"
            {
                facultyLine = line;
                break;
            }
        }
        int startIndex = facultyLine.IndexOf("Faculty:") + 8; //визначення початкового індексу після закінчення "Faculty"
        int endIndex = facultyLine.IndexOf(",", startIndex); //визначення кінцевого як першу кому
        string result = "";
        for (int i = startIndex; i < endIndex; i++)
        {
            result += facultyLine[i]; //додавання по символу з проміжку від початкового до кінцевого індексу
        }
        partnerStructure = result.Trim(); //визначення значення факультету без проблів
    }
    /// <summary>
    /// Метод отримання деталей взаємодії
    /// </summary>
    /// <returns> кортеж отриманих деталей </returns>
    public (string interactionFormat, string[] directions, string benefits) RecieveInteractionDetails()
    {
        service.PrintData("\nSpecify interaction format: ");
        string interactionFormat = service.ReadData(); //надання формату взаємодії
        service.PrintData("Enter number of proposed directions: ");
        int dirCount = Convert.ToInt32(service.ReadData());
        string[] directions = new string[dirCount]; //надання кількості запропонованих напрямів
        for (int i = 0; i < dirCount; i++)
        {
            service.PrintData($"Enter direction {i + 1}: ");
            directions[i] = service.ReadData(); //надання самих напрямів
        }
        service.PrintData("Specify benefits of partnership: ");
        string benefits = service.ReadData(); //надання переваг підпису угоди
        return (interactionFormat, directions, benefits);
    }
    /// <summary>
    /// Метод створення запиту на співпрацю
    /// </summary>
    /// <param name="interactionFormat"> формат взаємодії</param>
    /// <param name="directions"> напрями </param>
    /// <param name="benefits"> переваги </param>
    public void CreateRequest(string interactionFormat, string[] directions, string benefits)
    {
        SearchFaculty(); //виклик методу пошуку факультету
        service.Data = $"Partnership Request\n" + $"Company: {structureName}\n" + $"Activity Field: {activityDirection}\n" + $"Target Faculty: {partnerStructure}\n" + $"Interaction Format: {interactionFormat}\n" + $"Proposed Directions: {string.Join(", ", directions)}\n" + $"Benefits: {benefits}"; //формування запиту
        service.PathToFile = @"D:\Новая папка\C#\Lab4Ver4\partnership_request.txt";
        service.WriteData();
    }
    /// <summary>
    /// Метод підпису угоди або отримання відмови
    /// </summary>
    /// <param name="score"> отримана оцінка від факультету </param>
    public void SignAgreement(double score)
    {
        if (score >= 1) //якщо оцінка більше 1 - факультет погодив співпрацю
        {
            service.PrintData("\nAgreement is signed!\n");
            service.PathToFile = @"D:\Новая папка\C#\Lab4Ver4\partnership_response.txt";
            service.RenameFile("partnership_act.txt"); //зміна назви файлу з "відповідь" на "акт про співпрацю"
        }
        else //інакше - факультет відмовив
        {
            service.PrintData("Agreement is not signed! Starting the program from the start.");
            Program.RestartProgram(); //перезапуск програми
        }
    }
    /// <summary>
    /// Метод отримання даних для оцінення якості підготовки студентів
    /// </summary>
    /// <returns> кортеж отриманих значень</returns>
    public (double fact, double minimum, double norm) DefineStandards()
    {
        service.PrintData("Enter actual work results: ");
        double fact = Convert.ToDouble(service.ReadData()); //введення фактичних результатів роботи
        service.PrintData("Enter the minimum permissible value of the indicator: ");
        double minimum = Convert.ToDouble(service.ReadData()); //введення базового рівня
        service.PrintData("Enter the planned level: ");
        double norm = Convert.ToDouble(service.ReadData()); //введення планового рівня
        return (fact, minimum, norm);
    }
    /// <summary>
    /// Метод розрахунку індексу якості підготовки
    /// </summary>
    /// <param name="fact"> фактині результати роботи </param>
    /// <param name="minimum"> базовий рівень </param>
    /// <param name="norm"> плановий рівень </param>
    public void CalculateIndex(double fact, double minimum, double norm)
    {
        if (norm == minimum) //уникнення ділення на нуль
        {
            service.PrintData("Error: Norm and Base cannot be equal.\n");
            processQuality = 0.0;
        }
        if (fact < minimum) //якщо нижче базового рівня – результат відсутній
        {
            processQuality = 0.0;
        }
        processQuality = ((fact - minimum) / (norm - minimum)) * 100; //обрахунок індексу якості підготовки за формулою
    }
    /// <summary>
    /// Метод надання рекомендацій на основі якості підготовки
    /// </summary>
    /// <param name="fact"> фактичні результати підготовки </param>
    /// <param name="minimum"> базовий рівень </param>
    /// <param name="norm"> плановий рівень </param>
    public void ProvideRecommendations(double fact, double minimum, double norm)
    {
        service.Data = $"=== Conclusion on the quality of education ===\n" + $"Actual work results: {fact}\n" + $"Minimum permissible value: {minimum}\n" + $"Planned level: {norm}\n"; //формування висновку
        if (processQuality < 50) //якщо нижче 50% - значна відсутність якості
        {
            service.Data += "Recommendation: Significant improvement needed.";
        }
        else if (processQuality < 75) //якщо нижче 75% - помірна відсутність якості
        {
            service.Data += "Recommendation: Moderate improvement needed.";
        }
        else //інакше - якість прийнятна
        {
            service.Data += "Recommendation: Quality is acceptable.";
        }
        service.PathToFile = @"D:\Новая папка\C#\Lab4Ver4\recommendations.txt";
        service.WriteData();
    }
}