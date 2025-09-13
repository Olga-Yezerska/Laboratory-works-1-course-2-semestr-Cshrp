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
        ITCompany company = new ITCompany();  //створення об'єкту класу ITCompany
        Faculty faculty = new Faculty();  //створення об'єкту класу Faculty
        Department department = new Department();  //створення об'єкту класу Department

        department.Faculty = faculty;
        department.ITCompany = company;
        faculty.Department = department;
        company.Department = department;

        Identification(); //виклик методу ідентифікації

        //Отримання необхідних даних щодо компанії
        service.PrintData("=== IT-Company deatails ===\n");
        service.PrintData("Enter company name: ");
        company.CompanyName = service.ReadData();
        service.PrintData("Enter activity field: ");
        company.ActivityField = service.ReadData();

        //Отримання необідних даних щодо факультету
        service.PrintData("\n=== Faculty details ===\n");
        service.PrintData("Enter faculty name: ");
        faculty.FacultyName = service.ReadData();
        service.PrintData("Enter faculty dean: ");
        faculty.FacultyDean = service.ReadData();
        service.PrintData("Enter number of departments: ");
        faculty.DepartmentNumber = Convert.ToInt32(service.ReadData());

        //Запис даних до початкового файлу
        service.Data = $"IT Company: {company.CompanyName}, Field: {company.ActivityField}\n" + $"Faculty: {faculty.FacultyName}, Dean: {faculty.FacultyDean}, " + $"Departments: {faculty.DepartmentNumber}";
        service.PathToFile = @"D:\Новая папка\C#\Lab5\setup_data.txt";
        service.WriteData();

        //Отримання напрямів підготовки
        service.PrintData("\n=== Directions of preparation ===\n");
        faculty.DefineDirections(); //виклик методу визначення напрямів підготовки
        faculty.ApproveDirections(); //виклик методу погодження напрямів підготовки

        //Отримання річного навантаження
        service.PrintData("\n=== Annual study load ===\n");
        faculty.DefineStudyLoad(); //виклик методу визначення річного навантаження
        faculty.DistributeStudyLoad(); //виклик методу розподілу навантаження
        faculty.ApproveStudyLoad(); //виклик методу погодження навантаження

        // Надсилання запиту компанією факультету
        company.SearchFaculty(); // виклик методу пошуку факультету
        service.PrintData("\n=== Partnership Request ===");
        (string interactionFormat, string[] directions, string benefits) = company.RecieveInteractionDetails(); //отримання деталей взаємодії
        company.CreateRequest(interactionFormat, directions, benefits); //створення запиту на співпрацю

        //Отримання відповіді факультету
        faculty.EvaluateOffer(); //виклик методу оцінки пропозиції
        faculty.PrepareResponse(company.CompanyName, company.ActivityField, directions); //виклик методу підготовки відповіді

        //Підпис угоди або отримання відмови
        company.SignAgreement(faculty.Score); //виклик методу підпису угоди

        //Визначення стандартів для оцінки якості підготовки студентів
        service.PrintData("\n=== Quality standards ===\n");
        (double fact, double minimum, double norm) = company.DefineStandards(); //визначення стандартів для оцінки якості підготовки студентів)
        company.CalculateIndex(fact, minimum, norm); //виклик методу обрахунку індекса якості підготовки
        company.ProvideRecommendations(fact, minimum, norm); //виклик методу надання рекомендацій

        //Визначення показників якості підготовки для контролю якості освіти
        service.PrintData("\n=== Education Quality Control ===\n");
        (double disciplineQuality, double teacherQualification, double provisionQuality, double studentMotivation) = faculty.RecieveQualityData(); //визначення показників якості підготовки
        string conclusion = faculty.CompareResults(disciplineQuality, teacherQualification, provisionQuality, studentMotivation); //виклик методу оцінки якості підготовки
        faculty.FormulateConclusion(conclusion, disciplineQuality, teacherQualification, provisionQuality, studentMotivation); //виклик методу формулювання висновку

        //Отримання даних про кафедру
        service.PrintData("\n=== Department details ===\n");
        company.GetDepartmentData(); //виклик методу отримання даних про кафедру
        company.CreateDepartment(faculty.FacultyName); //виклик методу створення кафедри

        //Визначення викладачів кафедри
        service.PrintData("\n=== Department lecturers ===\n");
        department.AddLecturers(); //виклик методу визначення викладачів кафедри

        //Визначення дисциплін кафедри 
        department.StudyDisciplinesGeneration(); //виклик методу визначення дисциплін кафедри

        //Визначення годинного навантаження кафедри
        department.SetDisciplinesHours(40); //виклик методу визначення годинного навантаження кафедри

        //Визначення викладачів до дисциплін кафедри
        department.AssignLecturersToDisciplines(); //виклик методу призначення викладачів на дисципліни кафедри

        //Визначення розподілу дисциплін кафедри на семестри
        string output = department.DisciplineDistribution();

        //Визначення навчального плану кафедри
        department.CreateCurriculum(output); //виклик методу створення навчального плану кафедри

        //Методи для зміни компонентів компанії
        service.PrintData("\n===== IT-Company =====\n");

        service.PrintData("Enter new company name: ");
        string newCompanyName = service.ReadData(); //зчитування нової назви компанії
        company.ChangeName(newCompanyName, company.service); //виклик методу зміни назви компанії

        service.PrintData("Enter new company quality: ");
        double newCompanyQuality = Convert.ToDouble(service.ReadData()); //зчитування нової якості
        company.ChangeQuality(company.service, newCompanyQuality); //виклик методу зміни якості компанії

        company.ConfirmPartnership(company.service); //виклик методу підтвердження партнерських відносин

        service.PrintData("Enter new partner structure name: ");
        string newCompanyPartner = service.ReadData(); //зчитування нової назви партнерської структури
        company.ChangePartnership(company.service, newCompanyPartner); //виклик методу зміни партнерських відносин

        //Методи для зміни компонентів факультету
        service.PrintData("\n===== Faculty =====\n");

        service.PrintData("Enter new faculty name: ");
        string newFacultyName = service.ReadData(); //зчитування нової назви факультету
        faculty.ChangeName(newFacultyName, faculty.service); //виклик методу зміни назви факультету

        faculty.ConfirmPartnership(faculty.service); //виклик методу підтвердження партнерських відносин

        service.PrintData("Enter new partner structure name: ");
        string newPartner = service.ReadData(); //зчитування нової назви партнерської структури
        faculty.ChangePartnership(faculty.service, newPartner); //виклик методу зміни партнерських відносин

        service.PrintData("Enter new direction: ");
        string newDirection = service.ReadData(); //зчитування нового напряму підготовки
        faculty.AddDirection(newDirection, faculty.service); //виклик методу зміни напрямів підготовки

        //Завершення програми
        service.PrintData("\n=== End of program ===\n");
    }
}