using System;
public class Department
{
    private string departmentName; //назва кафедри
    public string specialization; //спеціалізація
    private string departmentHead; //завідувач кафедри
    private int numberOfTeachers; //кількість викладачів
    private string[] disciplines; //перелік дисциплін
    private string[] lecturers; //викладачі 
    private string[] lecturerSpecializations; //спеціалізації викладачів
    private int[] disciplineHours; // години для кожної дисципліни
    private string[] disciplineLecturers; //викладачі для кожної дисципліни

    Service service = new Service(); //створення об'єкту класу Service

    /// <summary>
    /// Конструктор за замовчуванням
    /// </summary>
    public Department() //конструктор за замовчуванням
    {
        departmentName = "";
        specialization = "";
        departmentHead = "";
        numberOfTeachers = 0;
        disciplines = new string[0];
        lecturers = new string[0];
        lecturerSpecializations = new string[0];
        disciplineHours = new int[0];
        disciplineLecturers = new string[0];
    }
    /// <summary>
    /// Конструктор з параметрами
    /// </summary>
    /// <param name="departmentName"> назва кафедри </param>
    /// <param name="specialization"> спеціалізація </param>
    /// <param name="departmentHead"> завідувач кафедри </param>
    /// <param name="numberOfTeachers"> кількість викладачів </param>
    /// <param name="disciplines"> перелік дисциплін </param>
    /// <param name="partnerFaculty"> партнерський факультет </param>
    /// <param name="lecturers"> викладачі </param>
    /// <param name="lecturerSpecializations"> спеціалізація викладачів </param>
    /// <param name="disciplineHours"> години дисциплін </param>
    /// <param name="disciplineLecturers"> викладачі дисциплін </param>
    public Department(string departmentName, string specialization, string departmentHead, int numberOfTeachers, string[] disciplines, string[] lecturers, string[] lecturerSpecializations, int[] disciplineHours, string[] disciplineLecturers)  //конструктор з параметрами
    {
        this.departmentName = departmentName;
        this.specialization = specialization;
        this.departmentHead = departmentHead;
        this.numberOfTeachers = numberOfTeachers;
        this.disciplines = disciplines;
        this.lecturers = lecturers;
        this.lecturerSpecializations = new string[lecturers.Length];
        this.disciplineHours = disciplineHours;
        this.disciplineLecturers = disciplineLecturers;
    }
    /// <summary>
    /// Конструктор копії
    /// </summary>
    /// <param name="other"></param>
    public Department(Department other)
    {
        departmentName = other.departmentName;
        specialization = other.specialization;
        departmentHead = other.departmentHead;
        numberOfTeachers = other.numberOfTeachers;
        disciplines = other.disciplines;
        lecturers = other.lecturers;
        lecturerSpecializations = other.lecturerSpecializations;
        disciplineHours = other.disciplineHours;
        disciplineLecturers = other.disciplineLecturers;
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string DepartmentName
    {
        get
        {
            return departmentName;
        }
        set
        {
            departmentName = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string Specialization
    {
        get
        {
            return specialization;
        }
        set
        {
            specialization = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string DepartmentHead
    {
        get
        {
            return departmentHead;
        }
        set
        {
            departmentHead = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public int NumberOfTeachers
    {
        get
        {
            return numberOfTeachers;
        }
        set
        {
            numberOfTeachers = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string[] Disciplines
    {
        get
        {
            return disciplines;
        }
        set
        {
            disciplines = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string[] Lecturers
    {
        get
        {
            return lecturers;
        }
        set
        {
            lecturers = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string[] LecturerSpecializations
    {
        get
        {
            return lecturerSpecializations;
        }
        set
        {
            lecturerSpecializations = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public int[] DisciplineHours
    {
        get
        {
            return disciplineHours;
        }
        set
        {
            disciplineHours = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string[] DisciplineLecturers
    {
        get
        {
            return disciplineLecturers;
        }
        set
        {
            disciplineLecturers = value;
        }
    }
    /// <summary>
    /// Метод визначення викладачів і їх спеціалізацій
    /// </summary>
    public void AddLecturers()
    {
        lecturers = new string[numberOfTeachers]; //масив викладачів
        lecturerSpecializations = new string[numberOfTeachers]; //масив спеціалізацій викладачів
        for (int i = 0; i < numberOfTeachers; i++)
        {
            service.PrintData($"Enter name of lecturer {i + 1}: ");
            lecturers[i] = service.ReadData();
            service.PrintData($"Enter specialization of lecturer {lecturers[i]}: ");
            lecturerSpecializations[i] = service.ReadData();
        }
    }
    /// <summary>
    /// Метод визначення дисциплін кафедри
    /// </summary>
    public void StudyDisciplinesGeneration()
    {
        Random random = new Random(); //генератор випадкових чисел
        int numberOfDisciplines = 40; //кількість дисциплін
        disciplines = new string[numberOfDisciplines]; //масив дисциплін
        disciplineHours = new int[numberOfDisciplines]; //масив годин дисциплін
        string[] possibleDisciplines = 
        {
            "Introduction to Cybersecurity", "Network Security", "Cryptography and Data Protection", "Operating Systems Security", "Ethical Hacking and Penetration Testing",
            "Cybercrime and Digital Forensics", "Security in Cloud Computing", "Web Application Security", "Cybersecurity Law and Ethics", "Secure Software Development", 
            "Security Risk Management", "Incident Response and Disaster Recovery", "Wireless and Mobile Security", "Internet of Things(IoT) Security", "Malware Analysis and Reverse Engineering", 
            "Artificial Intelligence in Cybersecurity", "Blockchain and Decentralized Security", "Biometric Authentication Systems", "Privacy and Data Governance", 
            "Security Operations Center(SOC) Management", "Cyber Threat Intelligence", "Advanced Cryptographic Protocols", "Digital Identity and Access Management", "Secure Network Architecture", 
            "Capstone Project in Cybersecurity"
         }; //перелік можливих дисциплін
        int[] disciplineCounts = new int[possibleDisciplines.Length]; //масив для підрахунку кількості дисциплін
        for (int i = 0; i < numberOfDisciplines; i++)
        {
            string selectedDiscipline; //вибрана дисципліна
            int selectedIndex; //індекс вибраної дисципліни
            //випадковий вибір дисципліни
            do
            {
                selectedIndex = random.Next(possibleDisciplines.Length); //випадковий індекс
                selectedDiscipline = possibleDisciplines[selectedIndex]; //вибрана дисципліна
            } while (disciplineCounts[selectedIndex] >= 2);
            disciplines[i] = selectedDiscipline; 
            disciplineCounts[selectedIndex]++;
        }
    }
    /// <summary>
    /// Метод визначення годин для дисциплін
    /// </summary>
    /// <param name="numberOfDisciplines"> кількість дисциплін </param>
    public void SetDisciplinesHours(int numberOfDisciplines)
    {
        Random random = new Random(); //генератор випадкових чисел
        int targetTotalHours = 7200; //цільова кількість годин
        int totalHours = 0; //загальна кількість годин
        for (int i = 0; i < numberOfDisciplines; i++) //генерація годин для дисциплін
        {
            disciplineHours[i] = random.Next(2, 7) * 30; //60–180 годин
            totalHours += disciplineHours[i]; //додавання годин до загальної кількості
        }
        //випадкове коригування годин для досягнення цільової кількості
        while (totalHours != targetTotalHours)
        {
            int index = random.Next(numberOfDisciplines); //випадковий індекс
            int currentHours = disciplineHours[index]; //поточна кількість годин
            //перевірка на досягнення цільової кількості годин
            if (totalHours > targetTotalHours && currentHours > 60)
            {
                disciplineHours[index] -= 30; //зменшення годин
                totalHours -= 30; //зменшення загальної кількості годин
            }
            else if (totalHours < targetTotalHours && currentHours < 180)
            {
                disciplineHours[index] += 30; //збільшення годин
                totalHours += 30; //збільшення загальної кількості годин
            }
        }
    }
    /// <summary>
    /// Метод визначення викладачів для дисциплін
    /// </summary>
    public void AssignLecturersToDisciplines()
    {
        Random random = new Random(); //генератор випадкових чисел
        disciplineLecturers = new string[disciplines.Length]; //масив викладачів для дисциплін
        string[] cybersecurityDisciplines = 
        { 
            "Introduction to Cybersecurity", "Cybercrime and Digital Forensics", "Ethical Hacking and Penetration Testing", "Capstone Project in Cybersecurity", 
            "Cybersecurity Law and Ethics", "Security Risk Management", "Web Application Security"
        }; //перелік дисциплін з кібербезпеки
        string[] networkingDisciplines = 
        {
            "Network Security", "Wireless and Mobile Security", "Secure Network Architecture"
        }; //перелік дисциплін з мережевої безпеки
        string[] cryptographyDisciplines = 
        { 
            "Cryptography and Data Protection", "Advanced Cryptographic Protocols", "Blockchain and Decentralized Security"
        }; //перелік дисциплін з криптографії
        string[] softwareDevelopmentDisciplines = 
        {
            "Secure Software Development", "Web Application Security"
        }; //перелік дисциплін з розробки програмного забезпечення
        string[] cloudComputingDisciplines = 
        {
            "Security in Cloud Computing", "Internet of Things(IoT) Security"
        }; //перелік дисциплін з хмарних обчислень
        string[] aiAndAnalyticsDisciplines = 
        {
            "Artificial Intelligence in Cybersecurity", "Malware Analysis and Reverse Engineering", "Cyber Threat Intelligence"
        }; //перелік дисциплін з штучного інтелекту та аналітики
        string[] operationsDisciplines = 
        {
            "Security Operations Center(SOC) Management", "Incident Response and Disaster Recovery", "Security Risk Management"
        }; //перелік дисциплін з операційної безпеки
        string[] identityAndPrivacyDisciplines = 
        {
            "Privacy and Data Governance", "Biometric Authentication Systems", "Digital Identity and Access Management"
        }; //перелік дисциплін з ідентифікації та конфіденційності
        //визначення спеціалізації для кожної дисципліни
        for (int i = 0; i < disciplines.Length; i++)
        {
            string discipline = disciplines[i]; //дисципліна
            string specializationNeeded = "Any";
            if (cybersecurityDisciplines.Contains(discipline))
            {
                specializationNeeded = "Cybersecurity";
            }
            if (networkingDisciplines.Contains(discipline))
            {
                specializationNeeded = "Networking";
            }
            if (cryptographyDisciplines.Contains(discipline))
            {
                specializationNeeded = "Cryptography";
            }
            if (softwareDevelopmentDisciplines.Contains(discipline))
            {
                specializationNeeded = "Software Development";
            }
            if (cloudComputingDisciplines.Contains(discipline))
            {
                specializationNeeded = "Cloud Computing";
            }
            if (aiAndAnalyticsDisciplines.Contains(discipline))
            {
                specializationNeeded = "AI and Analytics";
            }
            if (operationsDisciplines.Contains(discipline))
            {
                specializationNeeded = "Operations";
            }
            if (identityAndPrivacyDisciplines.Contains(discipline))
            {
                specializationNeeded = "Identity and Privacy";
            }
            int[] suitableLecturers = new int[lecturers.Length]; //масив для підрахунку кількості викладачів
            int suitableCount = 0; //лічильник підходящих викладачів
            //перевірка на відповідність спеціалізації викладачів
            for (int j = 0; j < lecturers.Length; j++)
            {
                if (specializationNeeded == "Any" || lecturerSpecializations[j] == specializationNeeded)
                {
                    suitableLecturers[suitableCount] = j;
                    suitableCount++;
                }
            }
            //випадковий вибір викладача з підходящої спеціалізації
            if (suitableCount > 0)
            {
                int selectedIndex = suitableLecturers[random.Next(suitableCount)]; //випадковий індекс
                disciplineLecturers[i] = lecturers[selectedIndex];
            }
            else
            {
                disciplineLecturers[i] = "No lecturer yet.";
            }
        }
    }
    /// <summary>
    /// Метод формування розподілу дисциплін
    /// </summary>
    /// <returns> дані для запису у файл </returns>
    public string DisciplineDistribution()
    {
        string output = "=== Discipline Distribution ===\n";
        int semesters = 8; //кількість семестрів
        int hoursPerSemester = 900; //годин на семестр
        int disciplinesPerSemester = disciplines.Length / semesters; //дисциплін на семестр
        int disciplineIndex = 0; //індекс дисципліни
        //розподіл дисциплін по семестрах
        for (int year = 1; year <= 4; year++)
        {
            output += $"\nYear {year}:\n";
            for (int semester = (year - 1) * 2 + 1; semester <= year * 2; semester++)
            {
                output += $"  Semester {semester}:\n";
                int semesterHours = 0;
                int disciplinesInThisSemester = disciplinesPerSemester; //кількість дисциплін в семестрі
                if (semester == semesters)
                {
                    disciplinesInThisSemester = disciplines.Length - disciplineIndex;
                }
                for (int i = 0; i < disciplinesInThisSemester && disciplineIndex < disciplines.Length; i++)
                {
                    output += $"    - {disciplines[disciplineIndex]}: {disciplineHours[disciplineIndex]} hours";
                    output += $", Lecturer: {disciplineLecturers[disciplineIndex]}\n";
                    semesterHours += disciplineHours[disciplineIndex];
                    disciplineIndex++;
                }
                output += $"    Total: {semesterHours} hours ({semesterHours / 30} credits)\n";
            }
        }
        return output;
    }
    /// <summary>
    /// Метод формування навчального плану
    /// </summary>
    /// <param name="output"> інформація про розподіл дисциплін </param>
    /// <param name="dean"> декан факультету </param>
    public void CreateCurriculum(string output, string dean)
    {
        service.Data = $"=== Curriculum for {departmentName}===\n";
        service.Data += "Faculty Load: 7200 hours\n";
        service.Data += output;
        service.Data += $"\nCurriculum Approved by\nDepartment Head: {departmentHead}\nFaculty Dean: {dean}";
        service.PathToFile = @"D:\Новая папка\C#\Lab3Ver2\curriculum.txt";
        service.WriteData();
    }
}