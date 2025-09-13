using System;
using System.Diagnostics; //для перезапуску програми
class Program
{
    /// <summary>
    /// Метод ідентифікації автора та умови
    /// </summary>
    public static void Identification()
    {
        Console.WriteLine("\nStudent Olha Yezerska, SE-12(4), lab 3, var 4, ver 1");
        Console.WriteLine("There is a model of public-private partnership, in which the participants of the model are an IT company and a department. ");
        Console.WriteLine("The IT company enters into a partnership with the faculty. The IT company creates a department. The faculty delegates the teaching load to the department. ");
        Console.WriteLine("The application of the SOLID principle of single responsibility requires the inclusion of the Service entity in the system for the implementation of operations not inherent to the participants of the educational environment.");
        Console.WriteLine("=======================================================================================================================");
    }
    /// <summary>
    /// Метод перезапуску програми
    /// </summary>
    public static void RestartProgram()
    {
        Process.Start(Process.GetCurrentProcess().MainModule.FileName); //перезапуск програми
        Environment.Exit(0);
    }
    static void Main(string[] args)
    {
        Service service = new Service();  //створення об'єкту класу Service
        Faculty facultyObj = new Faculty(); //створення об'єкту класу Faculty
        ITCompany companyObj = new ITCompany(); //створення об'єкту класу ITCompany

        IOrganizationalStructure faculty = facultyObj; //створення об'єкту через інтерфейс IOrganizationalStructure
        IOrganizationalStructure company = companyObj; //створення об'єкту через інтерфейс IOrganizationalStructure

        Identification(); //виклик методу ідентифікації

        //Отримання необхідних даних щодо компанії
        service.PrintData("=== IT-Company deatails ===\n");
        service.PrintData("Enter company name: ");
        company.StructureName = service.ReadData();
        service.PrintData("Enter activity field: ");
        company.ActivityDirection = service.ReadData();

        //Отримання необідних даних щодо факультету
        service.PrintData("\n=== Faculty details ===\n");
        service.PrintData("Enter faculty name: ");
        faculty.StructureName = service.ReadData();
        service.PrintData("Enter faculty dean: ");
        facultyObj.FacultyDean = service.ReadData();
        service.PrintData("Enter number of departments: ");
        facultyObj.DepartmentNumber = Convert.ToInt32(service.ReadData());

        //Запис даних до початкового файлу
        service.Data = $"IT Company: {companyObj.CompanyName}, Field: {companyObj.ActivityField}\n" + $"Faculty: {facultyObj.FacultyName}, Dean: {facultyObj.FacultyDean}, " + $"Departments: {facultyObj.DepartmentNumber}";
        service.PathToFile = @"D:\Новая папка\C#\Lab4Ver3\setup_data.txt";
        service.WriteData();

        //Отримання напрямів підготовки
        service.PrintData("\n=== Directions of preparation ===\n");
        facultyObj.DefineDirections(); //виклик методу визначення напрямів підготовки
        facultyObj.ApproveDirections(); //виклик методу погодження напрямів підготовки

        //Отримання річного навантаження
        service.PrintData("\n=== Annual study load ===\n");
        facultyObj.DefineStudyLoad(); //виклик методу визначення річного навантаження
        facultyObj.DistributeStudyLoad(); //виклик методу розподілу навантаження
        facultyObj.ApproveStudyLoad(); //виклик методу погодження навантаження

        // Надсилання запиту компанією факультету
        companyObj.SearchFaculty(); // виклик методу пошуку факультету
        service.PrintData("\n=== Partnership Request ===");
        (string interactionFormat, string[] directions, string benefits) = companyObj.RecieveInteractionDetails(); //отримання деталей взаємодії
        companyObj.CreateRequest(interactionFormat, directions, benefits); //створення запиту на співпрацю

        //Отримання відповіді факультету
        facultyObj.EvaluateOffer(); //виклик методу оцінки пропозиції
        facultyObj.PrepareResponse(companyObj.CompanyName, companyObj.ActivityField, directions); //виклик методу підготовки відповіді

        //Підпис угоди або отримання відмови
        companyObj.SignAgreement(facultyObj.Score); //виклик методу підпису угоди

        //Визначення стандартів для оцінки якості підготовки студентів
        service.PrintData("\n=== Quality standards ===\n");
        (double fact, double minimum, double norm) = companyObj.DefineStandards(); //визначення стандартів для оцінки якості підготовки студентів)
        companyObj.CalculateIndex(fact, minimum, norm); //виклик методу обрахунку індекса якості підготовки
        companyObj.ProvideRecommendations(fact, minimum, norm); //виклик методу надання рекомендацій

        //Визначення показників якості підготовки для контролю якості освіти
        service.PrintData("\n=== Education Quality Control ===\n");
        (double disciplineQuality, double teacherQualification, double provisionQuality, double studentMotivation) = facultyObj.RecieveQualityData(); //визначення показників якості підготовки
        string conclusion = facultyObj.CompareResults(disciplineQuality, teacherQualification, provisionQuality, studentMotivation); //виклик методу оцінки якості підготовки
        facultyObj.FormulateConclusion(conclusion, disciplineQuality, teacherQualification, provisionQuality, studentMotivation); //виклик методу формулювання висновку

        //Початок завдань четвертої лабораторної роботи
        service.PrintData("\n=== Fourth Lab ===\n");

        //Методи для компанії
        service.PrintData("\n===== IT-Company =====\n");

        service.PrintData("Enter new company name: ");
        string newCompanyName = service.ReadData(); //виклик методу зміни назви компанії
        company.ChangeName(newCompanyName); //виклик методу зміни назви компанії

        service.PrintData("Enter new company quality: ");
        double newCompanyQuality = Convert.ToDouble(service.ReadData());
        company.ChangeQuality(newCompanyQuality); //виклик методу зміни якості компанії

        company.ConfirmPartnership(); //виклик методу підтвердження партнерських відносин

        service.PrintData("Enter new partner structure name: ");
        string newCompanyPartner = service.ReadData();
        company.ChangePartnership(newCompanyPartner); //виклик методу зміни партнерських відносин

        //Методи для факультету
        service.PrintData("\n===== Faculty =====\n");

        service.PrintData("Enter new faculty name: ");
        string newFacultyName = service.ReadData();
        faculty.ChangeName(newFacultyName); //виклик методу зміни назви факультету

        faculty.ConfirmPartnership(); //виклик методу підтвердження партнерських відносин

        service.PrintData("Enter new partner structure name: ");
        string newPartner = service.ReadData();
        faculty.ChangePartnership(newPartner); //виклик методу зміни партнерських відносин

        service.PrintData("Enter new direction: ");
        string newDirection = service.ReadData();
        faculty.AddDirection(newDirection); //виклик методу зміни напрямів підготовки

        service.PrintData("\n===== Second Version =====\n");
        //OrganizationalStructure structure = new OrganizationalStructure(newCompanyName, newCompanyQuality, newCompanyPartner, newDirection); //створення об'єкту класу OrganizationalStructure

        //Завершення програми
        service.PrintData("\n=== End of program ===\n");
    }
}