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
        service.PathToFile = @"D:\Новая папка\C#\Lab3Ver4\setup_data.txt";
        service.WriteData();

        //Отримання напрямів підготовки
        service.PrintData("\n=== Directions of preparation ===\n");
        faculty.DefineDirections(); //виклик методу визначення напрямів підготовки

        //Отримання річного навантаження
        service.PrintData("\n=== Annual study load ===\n");
        faculty.DefineStudyLoad(); //виклик методу визначення річного навантаження
        faculty.DistributeStudyLoad(); //виклик методу розподілу навантаження
        faculty.ApproveStudyLoadAndDirections(); //виклик методу погодження навантаження

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

        //Друга версія програми
        service.PrintData("\n=== Second version ===\n");

        //Отримання даних про кафедру
        service.PrintData("\n=== Department details ===\n");
        company.GetDepartmentData(department); //виклик методу отримання даних про кафедру
        company.CreateDepartment(department, faculty.FacultyName); //виклик методу створення кафедри

        //Визначення викладачів кафедри
        service.PrintData("\n=== Department lecturers ===\n");
        department.AddLecturers(); //виклик методу визначення викладачів кафедри

        //Визначення дисциплін кафедри 
        department.StudyDisciplinesGeneration(); //виклик методу визначення дисциплін кафедри

        //Визначення годинного навантаження кафедри
        department.SetDisciplinesHours(); //виклик методу визначення годинного навантаження кафедри

        //Визначення викладачів до дисциплін кафедри
        department.AssignLecturersToDisciplines(); //виклик методу призначення викладачів на дисципліни кафедри

        //Визначення розподілу дисциплін кафедри на семестри
        string output = department.DisciplineDistribution();

        //Третя версія програми
        service.PrintData("\n=== Third version ===\n");
        service.PrintData("\n Department curriculum is written to the file! \n");

        //Визначення навчального плану кафедри
        department.CreateCurriculum(output, faculty.FacultyDean, department.DepartmentName, department.DepartmentHead); //виклик методу створення навчального плану кафедри

        //Четверта версія програми
        service.PrintData("\n=== Fourth version ===\n");
        service.PrintData("\n Sorted disciplines are written to the file! \n");

        //Визначення відсортованих дисциплін кафедри
        CompanyProject.SortAndWriteDisciplineHours(department.DisciplineHours, department.Disciplines, department.DisciplineLecturers); //виклик методу сортування дисциплін
        CompanyProject.DisplaySortedDisciplines(department.DisciplineHours, department.Disciplines, department.DisciplineLecturers); //виклик методу запису відсортованих дисциплін

        //Завершення програми
        service.PrintData("\nAll data is written to files!\n");
        service.PrintData("\n=== End of program ===\n");
    }
}