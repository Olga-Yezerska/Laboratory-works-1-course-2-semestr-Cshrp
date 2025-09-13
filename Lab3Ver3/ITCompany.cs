using System;
public class ITCompany
{
    private string companyName; //назва компанії
    private string activityField; //сфера діяльності
    private string partnerFaculty; //партнерський факультет
    private double trainingQuality; //якісь підготовки студентів

    Service service = new Service(); //створення об'єкту класу Service
    //Department department = new Department(); //створення об'єкту класу Department

    /// <summary>
    /// Конструктор за замовченням
    /// </summary>
    public ITCompany()
    {
        companyName = "";
        activityField = "";
        partnerFaculty = "";
        trainingQuality = 0.0;
    }
    /// <summary>
    /// Конструктор з параметрами
    /// </summary>
    /// <param name="companyName"> назва компанії </param>
    /// <param name="activityField"> сфера діяльності </param>
    /// <param name="partnerFaculty"> партнерський факультет </param>
    /// <param name="trainingQuality"> якість підготовки студентів </param>
    public ITCompany(string companyName, string activityField, string partnerFaculty, double trainingQuality)
    {
        this.companyName = companyName;
        this.activityField = activityField;
        this.partnerFaculty = partnerFaculty;
        this.trainingQuality = trainingQuality;
    }
    /// <summary>
    /// Конструктор копії
    /// </summary>
    /// <param name="other"></param>
    public ITCompany(ITCompany other)
    {
        companyName = other.companyName;
        activityField = other.activityField;
        partnerFaculty = other.partnerFaculty;
        trainingQuality = other.trainingQuality;
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string CompanyName
    {
        get
        {
            return companyName;
        }
        set
        {
            companyName = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string ActivityField
    {
        get
        {
            return activityField;
        }
        set
        {
            activityField = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string PartnerFaculty
    {
        get
        {
            return partnerFaculty;
        }
        set
        {
            partnerFaculty = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public double TrainingQuality
    {
        get
        {
            return trainingQuality;
        }
        set
        {
            trainingQuality = value;
        }
    }
    /// <summary>
    /// Метод пошуку факультету для партнерства 
    /// </summary>
    public void SearchFaculty()
    {
        service.PathToFile = @"D:\Новая папка\C#\Lab3Ver2\setup_data.txt";
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
        partnerFaculty = result.Trim(); //визначення значення факультету без проблів
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
        service.Data = $"=== Partnership Request === \n" + $"Company: {companyName}\n" + $"Activity Field: {activityField}\n" + $"Target Faculty: {partnerFaculty}\n" + $"Interaction Format: {interactionFormat}\n" + $"Proposed Directions: {string.Join(", ", directions)}\n" + $"Benefits: {benefits}"; //формування запиту
        service.PathToFile = @"D:\Новая папка\C#\Lab3Ver3\partnership_request.txt";
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
            service.PrintData("Agreement is signed!");
            service.PathToFile = @"D:\Новая папка\C#\Lab3Ver3\partnership_response.txt";
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
            trainingQuality = 0.0;
        }
        if (fact < minimum) //якщо нижче базового рівня – результат відсутній
        {
            trainingQuality = 0.0;
        }
        trainingQuality = ((fact - minimum) / (norm - minimum)) * 100; //обрахунок індексу якості підготовки за формулою
    }
    /// <summary>
    /// Метод надання рекомендацій на основі якості підготовки
    /// </summary>
    /// <param name="fact"> фактичні результати підготовки </param>
    /// <param name="minimum"> базовий рівень </param>
    /// <param name="norm"> плановий рівень </param>
    public void ProvideRecommendations(double fact, double minimum, double norm)
    {
        service.Data = $"=== Conclusion on the quality of education ===\n" + $"Actual work results: {fact}\n" + $"Minimum permissible value: {minimum}\n" + $"Planned level: {norm}\n";
        if (trainingQuality < 50)
        {
            service.Data += "Recommendation: Significant improvement needed.";
        }
        else if (trainingQuality < 75)
        {
            service.Data += "Recommendation: Moderate improvement needed.";
        }
        else
        {
            service.Data += "Recommendation: Quality is acceptable.";
        }
        service.PathToFile = @"D:\Новая папка\C#\Lab3Ver3\recommendations.txt";
        service.WriteData();
    }
    public void GetDepartmentData(Department department)
    {
        service.PrintData("Enter department name: ");
        department.DepartmentName = service.ReadData();
        service.PrintData("Enter specialization: ");
        department.Specialization = service.ReadData();
        service.PrintData("Enter department head: ");
        department.DepartmentHead = service.ReadData();
        service.PrintData("Enter number of teachers: ");
        department.NumberOfTeachers = Convert.ToInt32(service.ReadData());
    }
    public void CreateDepartment(Department department, string facultyName)
    {
        service.Data = $"=== New department details ===\n";
        service.Data += $"Department Name: {department.DepartmentName}\n" + $"Specialization: {department.Specialization}\n" + $"Department Head: {department.DepartmentHead}\n" + $"Number of Teachers: {department.NumberOfTeachers}\n" + $"Partner faculty: {facultyName}\n";
        service.Data += $"Created by {companyName}.";
        service.PathToFile = @"D:\Новая папка\C#\Lab3Ver3\department.txt";
        service.WriteData();
    }
}