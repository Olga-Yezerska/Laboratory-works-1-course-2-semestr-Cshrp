using System;
public class ITCompany : OrganizationalStructure
{

    public Service service = new Service(); //створення об'єкту класу Service
    //Department department = new Department(); //створення об'єкту класу Department

    /// <summary>
    /// Властивість для асоціації з факультетом
    /// </summary>
    public Department Department
    {
        get;
        set;
    }
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
    /// Додавання двох якостей
    /// </summary>
    /// <param name="obj1"> перший об'єкт </param>
    /// <param name="obj2"> другий об'єкт </param>
    /// <returns> результат додавання </returns>
    public static ITCompany operator +(ITCompany obj1, ITCompany obj2)
    {
        ITCompany company = new ITCompany()
        {
            structureName = obj1.structureName,
            activityDirection = obj1.activityDirection,
            partnerStructure = obj1.partnerStructure,
            processQuality = obj1.processQuality + obj2.processQuality
        }; //створення нового об'єкту
        return company; //повернення нового об'єкту
    }
    /// <summary>
    /// Віднімання якостей
    /// </summary>
    /// <param name="obj1"> перший об'єкт </param>
    /// <param name="obj2"> другий об'єкт </param>
    /// <returns> результат віднімання </returns>
    public static ITCompany operator -(ITCompany obj1, ITCompany obj2)
    {
        ITCompany company = new ITCompany()
        {
            structureName = obj1.structureName,
            activityDirection = obj1.activityDirection,
            partnerStructure = obj1.partnerStructure,
            processQuality = obj1.processQuality - obj2.processQuality
        }; //створення нового об'єкту
        return company; //повернення нового об'єкту
    }
    /// <summary>
    /// Інкремент якості
    /// </summary>
    /// <param name="v"> об'єкт, відносно якого інкрементуємо </param>
    /// <returns> результат інкрементування </returns>
    public static ITCompany operator ++(ITCompany v)
    {
        //створення нового об'єкту
        return new ITCompany
        {
            structureName = v.structureName,
            activityDirection = v.activityDirection,
            partnerStructure = v.partnerStructure,
            processQuality = v.processQuality + 1
        };
    }
    /// <summary>
    /// Декремент якості
    /// </summary>
    /// <param name="v"> об'єкт, відносно якого декрементуємо </param>
    /// <returns> результат декрементації </returns>
    public static ITCompany operator --(ITCompany v)
    {
        return new ITCompany
        {
            structureName = v.structureName,
            activityDirection = v.activityDirection,
            partnerStructure = v.partnerStructure,
            processQuality = v.processQuality - 1
        };
    }
    /// <summary>
    /// Конструктор з параметрами
    /// </summary>
    /// <param name="structureName">назва компанії</param>
    /// <param name="activityDirection">сфера діяльності</param>
    /// <param name="processQuality">якість підготовки</param>
    /// <param name="partnerStructure">партнерська структура</param>
    /// <param name="directions">напрямки підготовки</param>
    public ITCompany(string structureName, string activityDirection, double processQuality, string partnerStructure, string[] directions) : base(structureName, activityDirection, processQuality, partnerStructure, directions)
    {
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
        service.PathToFile = @"D:\Новая папка\C#\Lab5Ver3\setup_data.txt"; //шлях до файлу
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
        service.PathToFile = @"D:\Новая папка\C#\Lab5Ver3\partnership_request.txt";
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
            service.PathToFile = @"D:\Новая папка\C#\Lab5Ver3\partnership_response.txt";
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
        service.PathToFile = @"D:\Новая папка\C#\Lab5Ver3\recommendations.txt";
        service.WriteData();
    }
    /// <summary>
    /// Переписаний метод зміни назви структури
    /// </summary>
    /// <param name="newName"> нова назва </param>
    /// <param name="service"> сервіс для запису </param>
    public override void ChangeName(string newName, Service service)
    {
        string oldName = structureName;
        structureName = newName;
        UpdateData(service, action: "Name Change", details: $"Old: {oldName}\nNew: {newName}"); //запис до файлу
        this.service.PrintData($"Company name changed from {oldName} to {newName}\n"); //виведення зміни назви
    }
    /// <summary>
    /// Переписаний метод зміни якості процесу
    /// </summary>
    /// <param name="newQuality"> нова якість </param>
    public override void ChangeQuality(Service service, double newQuality)
    {
        double oldQuality = processQuality;
        processQuality = newQuality;
        this.service.PrintData($"Quality changed from {oldQuality:0.0} to {newQuality:0.0}\n"); //виведення зміни якості
        UpdateData(service, action: "Quality Update", details: $"Old value: {oldQuality:0.0}\nNew value: {newQuality:0.0}\nChange: {(newQuality - oldQuality):+0.0;-0.0;0}"); //запис до файлу
    }
    /// <summary>
    /// Переписаний метод підтвердження партнерських відносин
    /// </summary>
    /// <param name="service"> сервіс </param>
    public override void ConfirmPartnership(Service service)
    {
        string partnershipActPath = @"D:\Новая папка\C#\Lab5Ver3\partnership_act.txt";
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
        this.service.PrintData(message); //виведення статусу
        UpdateData(service, action: "Partnership Verification", details: $"Status: {message}"); //запис до файлу
    }
    /// <summary>
    /// Переписаний метод зміни партнерських відносин
    /// </summary>
    /// <param name="service"> сервіс </param>
    /// <param name="newPartner"> новий партнер </param>
    public override void ChangePartnership(Service service, string newPartner)
    {
        string oldPartner = partnerStructure;
        partnerStructure = newPartner;
        this.service.PrintData($"Partner changed from {oldPartner} to {newPartner}\n"); //виведення зміни партнера
        UpdateData(service, action: "Partnership Change", details: $"New partner: {newPartner}"); //запис до файлу
    }
    /// <summary>
    /// Переписаний метод оновлення даних
    /// </summary>
    /// <param name="service"> сервіс </param>
    /// <param name="action"> дія, яка відбувалась </param>
    /// <param name="details"> деталі змін </param>
    public override void UpdateData(Service service, string action, string details = "")
    {
        string filePath = $@"D:\Новая папка\C#\Lab5Ver3\update_{structureName}.txt"; //шлях до файлу
        string logEntry = $"\n=== {structureName} Update ===\n";
        logEntry += $"Action: {action}\n";
        logEntry += $"Details:\n{details}\n";
        string existingData = "";
        this.service.PathToFile = filePath;
        if (File.Exists(filePath)) //перевірка наявності файлу
        {
            existingData = this.service.ReadFromFile(); //зчитування даних з файлу
        }
        string updatedData = existingData + logEntry; //формування нових даних
        this.service.Data = updatedData; //запис нових даних
        this.service.WriteData();
        this.service.PrintData($"Data updated in {filePath}\n"); //виведення зміни даних
    }
    /// <summary>
    /// Метод отримання даних для створення кафедри
    /// </summary>
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
    /// <summary>
    /// Метод створення кафедри
    /// </summary>
    /// <param name="department"></param>
    /// <param name="facultyName"></param>
    public void CreateDepartment(Department department, string facultyName)
    {
        service.Data = $"=== New department details ===\n";
        service.Data += $"Department Name: {department.DepartmentName}\n" + $"Specialization: {department.Specialization}\n" + $"Department Head: {department.DepartmentHead}\n" + $"Number of Teachers: {department.NumberOfTeachers}\n" + $"Partner faculty: {facultyName}\n";
        service.Data += $"Created by {structureName}.";
        service.PathToFile = @"D:\Новая папка\C#\Lab5Ver3\department.txt";
        service.WriteData();
    }
}