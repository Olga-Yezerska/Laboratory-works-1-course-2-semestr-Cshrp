using System;
public class Faculty : OrganizationalStructure
{
    private string facultyDean; //декан факультету
    private int departmentNumber; //кількість кафедр
    private int studyLoad; //річне навчальне навантаження
    private int[] departmentLoad; //навчальне навантаження кафедр
    private double score; //оцінка пропозиції

    Service service = new Service(); //створення об'єкту класу Service

    /// <summary>
    /// Конструктор за замовченням
    /// </summary>
    public Faculty() : base()
    {
        structureName = "";
        facultyDean = "";
        departmentNumber = 0;
        studyLoad = 0;
        directions = new string[0];
        partnerStructure = "";
        processQuality = 0;
        departmentLoad = new int[0];
        score = 0;
    }
    /// <summary>
    /// Конструктор з параметрами
    /// </summary>
    /// <param name="structureName">назва факультету</param>
    /// <param name="activityDirection">напрям діяльності</param>
    /// <param name="processQuality"> якість процесу</param>
    /// <param name="partnerStructure">партнерська структура</param>
    /// <param name="directions">напрямки підготовки</param>
    /// <param name="facultyDean">декан факультету</param>
    /// <param name="departmentNumber">кількість кафедр</param>
    /// <param name="studyLoad">річне навчальне навантаження</param>
    /// <param name="departmentLoad">навчальне навантаження кафедр</param>
    /// <param name="score">оцінка пропозиції</param>
    public Faculty(string structureName, string activityDirection, double processQuality, string partnerStructure, string[] directions, string facultyDean, int departmentNumber, int studyLoad, int[] departmentLoad, double score) : base(structureName, activityDirection, processQuality, partnerStructure, directions)
    {
        this.facultyDean = facultyDean;
        this.departmentNumber = departmentNumber;
        this.studyLoad = studyLoad;
        this.departmentLoad = new int[0];
        this.score = score;
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string FacultyName
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
    public string FacultyDean
    {
        get
        {
            return facultyDean;
        }
        set
        {
            facultyDean = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public int DepartmentNumber
    {
        get
        {
            return departmentNumber;
        }
        set
        {
            departmentNumber = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public int StudyLoad
    {
        get
        {
            return studyLoad;
        }
        set
        {
            studyLoad = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string[] EducationAreas
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
    /// Властивість
    /// </summary>
    public string PartnerCompany
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
    public double EducationQuality
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
    public int[] DepartmentLoad
    {
        get
        {
            return departmentLoad;
        }
        set
        {
            departmentLoad = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public double Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
    /// <summary>
    /// Метод оцінки пропозиції
    /// </summary>
    public void EvaluateOffer()
    {
        service.PathToFile = @"D:\Новая папка\C#\Lab4Ver3\partnership_request.txt"; //шлях до файлу 
        string setupData = service.ReadFromFile().ToLower(); //зчитування даних з файлу
        string[] keywords = { "cyber security", "technologies", "department", "preparation", "great", "intership", "threats", "create", "new" }; //ключові слова для оцінки пропозиції
        foreach (string keyword in keywords)
        {
            if (setupData.Contains(keyword))
            {
                score += 0.2; //додавання балів за ключові слова
            }
        }
    }
    /// <summary>
    /// Метод підготовки відповіді на пропозицію
    /// </summary>
    /// <param name="companyName"> назва компанії </param>
    /// <param name="activityField"> сфера діяльності компанії </param>
    /// <param name="directions"> масив напрямів підготовки, які хоче організувати компанія </param>
    public void PrepareResponse(string companyName, string activityField, string[] directions)
    {
        if (score >= 1) //якщо оцінка більше 1 - тобто компанія відповідає нормам факультету
        {
            //формування угоди про партнерство
            service.Data = $"=== Agreement on Partnership === \n";
            service.Data += $"This agreement is made between {structureName} Faculty, represented by the Dean {facultyDean}, and {companyName}, a company operating in the field of {activityField}.\n";
            service.Data += $"The parties agree to collaborate on the creation of a new academic department focused on {directions[0]}, aiming to enhance student training and career readiness in this critical field.\n";
            service.Data += $"{structureName} Faculty will provide academic infrastructure and administrative support.\r\n{companyName} will offer expert involvement, curriculum input, and potential funding or technical assistance.\r\n\r\nThis agreement takes effect upon signing and is valid for an initial term of [e.g., 3 years], with possible extension by mutual consent.";
            service.Data += $"Signed: \n{facultyDean}, {structureName}";
        }
        else //якщо компанія не відповідає нормам факультету
        {
            //формування відмови
            service.Data = $"=== Response to Partnership Proposal === \n";
            service.Data += $"Dear {companyName},\n";
            service.Data += $"After careful consideration, we regret to inform you that we are currently unable to proceed with the proposed collaboration. \nAt this time, our faculty is focusing on existing academic priorities and does not have the necessary resources to support the creation of a new department.\n";
            service.Data += $"We appreciate your interest in partnering with us and encourage you to reach out in the future as our priorities may evolve.\n";
            service.Data += $"Best regards,\n";
            service.Data += $"{facultyDean}, Dean of {structureName} Faculty";
        }
        service.PathToFile = @"D:\Новая папка\C#\Lab4Ver3\partnership_response.txt";
        service.WriteData();
    }
    /// <summary>
    /// Метод визначення напрямів 
    /// </summary>
    public void DefineDirections()
    {
        service.PrintData("Enter number of directions: ");
        int count = Convert.ToInt32(service.ReadData()); //кількість напрямів підготовки
        directions = new string[count]; //ініціалізація масиву напрямів підготовки
        for (int i = 0; i < count; i++)
        {
            service.PrintData($"Enter direction {i + 1}: ");
            directions[i] = service.ReadData(); //заповнення масиву напрямів підготовки
        }
    }
    /// <summary>
    /// Метод запису напрямів підготовки до файлу
    /// </summary>
    public void ApproveDirections()
    {
        service.Data = $"=== Approved education areas for {structureName} === \n" + "Directions of preparation: \n"; //формування заголовка
        for (int i = 0; i < directions.Length; i++) //перебір масиву напрямів
        {
            service.Data += directions[i] + "\n"; //додавання напрямів до файлу
        }
        service.Data += $"Approved by dean {facultyDean}.";
        service.PathToFile = @"D:\Новая папка\C#\Lab4Ver3\approved_areas.txt";
        service.WriteData();
    }
    /// <summary>
    /// Метод визначення річного навантаження
    /// </summary>
    public void DefineStudyLoad()
    {
        service.PrintData("Enter annual study load: "); //річне навчальне навантаження
        studyLoad = Convert.ToInt32(service.ReadData());
    }
    /// <summary>
    /// Метод розподілу навантаження серез кафедр
    /// </summary>
    public void DistributeStudyLoad()
    {
        departmentLoad = new int[departmentNumber]; //ініціалізація масиву навантаження кафедр
        int baseLoad = studyLoad / departmentNumber; //базове навантаження
        int remainingLoad = studyLoad % departmentNumber; //залишок навантаження
        for (int i = 0; i < departmentNumber; i++)
        {
            departmentLoad[i] = baseLoad; //призначення базового навантаження
            if (remainingLoad > 0) //якщо залишок навантаження більше 0 
            {
                departmentLoad[i]++; //додавання залишку до навантаження кафедри
                remainingLoad--; //зменшення залишку
            }
        }
    }
    /// <summary>
    /// Метод запису навантаження кафедр до файлу
    /// </summary>
    public void ApproveStudyLoad()
    {
        service.Data = $"=== Approved study load for {departmentNumber} departments for {structureName} === \n"; //формування заголовка
        for (int i = 0; i < directions.Length; i++) //перебір масиву напрямів
        {
            service.Data += $"Direction {i + 1}: {directions[i]}\n"; //додавання напрямів до файлу
        }
        service.Data += $"Approved by dean {facultyDean}.";
        service.PathToFile = @"D:\Новая папка\C#\Lab4Ver3\approved_study_load.txt";
        service.WriteData();
    }
    /// <summary>
    /// Метод отримання даних про якість освіти
    /// </summary>
    /// <returns> кортеж отриманих значень </returns>
    public (double disciplineQuality, double teacherQualification, double provisionQuality, double studentMotivation) RecieveQualityData()
    {
        service.PrintData("Enter level of discipline quality: "); //оцінка предметів
        double disciplineQuality = Convert.ToDouble(service.ReadData());
        service.PrintData("Enter level of teacher qualification: "); //оцінка викладацького складу
        double teacherQualification = Convert.ToDouble(service.ReadData());
        service.PrintData("Enter level of provision quality: "); //оцінка забезпечення
        double provisionQuality = Convert.ToDouble(service.ReadData());
        service.PrintData("Enter level of student motivation: "); //оцінка мотивації студентів
        double studentMotivation = Convert.ToDouble(service.ReadData());
        return (disciplineQuality, teacherQualification, provisionQuality, studentMotivation); //повернення кортежу
    }
    /// <summary>
    /// Метод порівняння отриманих результатів із нормою
    /// </summary>
    /// <param name="disciplineQuality"> оцінка предметів </param>
    /// <param name="teacherQualification"> оцінка викладацького складу </param>
    /// <param name="provisionQuality"> оцінка забезпечення </param>
    /// <param name="studentMotivation"> оцінка мотивації студентів </param>
    /// <returns> відповідь щодо якості підготовки </returns>
    public string CompareResults(double disciplineQuality, double teacherQualification, double provisionQuality, double studentMotivation)
    {
        // визначення норм для оцінки якості підготовки
        double normDiscipline = 75.0;
        double normTeacherQualification = 70.0;
        double normProvisionQuality = 70.0;
        double normStudentMotivation = 65.0;
        if (disciplineQuality < normDiscipline * 0.5 || teacherQualification < normTeacherQualification * 0.5 || provisionQuality < normProvisionQuality * 0.5 || studentMotivation < normStudentMotivation * 0.5) //якщо оцінка менше 50% від норми
        {
            return "Has critical issues";
        }
        else if (disciplineQuality < normDiscipline || teacherQualification < normTeacherQualification || provisionQuality < normProvisionQuality || studentMotivation < normStudentMotivation) //якщо оцінка менше норми
        {
            return "Has major issues";
        }
        return "Has minor issues";
    }
    /// <summary>
    /// Метод формулювання висновку
    /// </summary>
    /// <param name="conclusion"> висновок у залежності від отриманого аналізу </param>
    /// <param name="disciplineQuality"> оцінка предметів </param>
    /// <param name="teacherQualification"> оцінка викладацького складу </param>
    /// <param name="provisionQuality"> оцінка забезпечення </param>
    /// <param name="studentMotivation"> оцінка мотивації студентів </param>
    public void FormulateConclusion(string conclusion, double disciplineQuality, double teacherQualification, double provisionQuality, double studentMotivation)
    {
        service.Data = $"=== Conclusion on the quality of education at {structureName} === \n" + $"Discipline quality: {disciplineQuality}\n" + $"Teacher qualification: {teacherQualification}\n"; //формування заголовка
        service.Data += $"Provision quality: {provisionQuality}\n" + $"Student motivation: {studentMotivation}\n" + $"Conclusion: {conclusion}\n" + $"Approved by dean {facultyDean}."; //формування висновку
        service.PathToFile = @"D:\Новая папка\C#\Lab4Ver3\quality_conclusion.txt";
        service.WriteData();
    }
    /// <summary>
    /// Метод зміни назви факультету
    /// </summary>
    /// <param name="newName"> нова назва </param>
    public override void ChangeName(string newName)
    {
        base.ChangeName(newName); //виклик методу базового класу
        service.PrintData($"Faculty name updated to: {newName}\n");
    }
}