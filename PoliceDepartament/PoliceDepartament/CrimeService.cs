using System;

namespace PoliceDepartament
{
    /// <summary>
    /// Клас CrimeService представляє службу, 
    /// яка обробляє кримінальні події, скарги та запити від клієнтів
    /// </summary>
    public class CrimeService
    {
        private int id; //унікальний ідентифікатор служби
        private string[] criminalEvents; //масив для зберігання кримінальних подій
        private int index; //індекс для додавання нових кримінальних подій
        private Service service;
        public CriminalEvent criminalEvent;
        public Complaint complaint;
        public Request request;
        public Client client;
        /// <summary>
        /// Властивість
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string[] CriminalEvents
        {
            get
            {
                return criminalEvents;
            }
            set
            {
                this.criminalEvents = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                this.index = value;
            }
        }
        /// <summary>
        /// Конструктор без параметрів
        /// </summary>
        /// <param name="capacity">розмір</param>
        public CrimeService()
        {
            criminalEvents = new string[100];
            index = 0;
            service = new Service();
            Console.WriteLine("Default constructor called.");
        }
        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="capacity">розмір</param>
        public CrimeService(int capacity)
        {
            criminalEvents = new string[capacity];
            index = 0;
            service = new Service();
            Console.WriteLine("Parameterized constructor called.");
        }
        /// <summary>
        /// Статичний конструктор
        /// </summary>
        static CrimeService()
        {
            Console.WriteLine("Static constructor called.");
        }
        /// <summary>
        /// Закритий конструктор
        /// </summary>
        /// <param name="privateFlag">для виклику</param>
        private CrimeService(bool privateFlag)
        {
            criminalEvents = new string[10];
            index = 0;
            service = new Service();
            Console.WriteLine("Private constructor called.");
        }
        /// <summary>
        /// Конструктор копії
        /// </summary>
        /// <param name="other">ооригінал</param>
        public CrimeService(CrimeService other)
        {
            criminalEvents = new string[other.criminalEvents.Length];
            Array.Copy(other.criminalEvents, criminalEvents, other.criminalEvents.Length);
            index = other.index;
            service = new Service();
            Console.WriteLine("Copy constructor called.");
        }
        /// <summary>
        /// Конструктор, який викликає інші
        /// </summary>
        /// <param name="capacity">обсяг</param>
        /// /// <param name="service">для виклику</param>
        public CrimeService(int capacity, Service service) : this(capacity)
        {
            Console.WriteLine("Constructor calling another constructor called.");
        }
        /// <summary>
        /// Метод для реєстрації кримінальної події
        /// </summary>
        public void RegisterCrime()
        {
            service.OutputData("=== Registering a crime ===");
            client = new Client();
            client.Id = service.InputIntData("Enter your client ID:");
            service.OutputData("Enter crime description:");
            string description = service.InputData();
            service.OutputData("Enter crime location:");
            string place = service.InputData();
            TechnicalDevice device = new TechnicalDevice { service = service };
            criminalEvent = new CriminalEvent(GetNewId(), description, place, null, client, device);
            criminalEvent.SaveData();
            service.OutputData($"Crime registered: {description} at {place}");
            device.FindActiveDevice();
        }
        /// <summary>
        /// Метод для реєстрації скарги клієнта
        /// </summary>
        public void RegisterComplaint()
        {
            service.OutputData("=== Registering a complaint ===");
            client = new Client();
            client.Id = service.InputIntData("Enter your client ID:");
            service.OutputData("Enter complaint description:");
            string description = service.InputData();
            complaint = new Complaint
            {
                Id = GetNewId(),
                Type = "criminal",
                Description = description,
                Status = "in processing",
                client = client,
            };
            complaint.SaveData();
            service.OutputData($"Complaint registered: {description}");
            TechnicalDevice device = new TechnicalDevice { service = service };
            device.FindActiveDevice();
        }
        /// <summary>
        /// Метод для реєстрації запиту на відвідування
        /// </summary>
        public void RegisterVisiting()
        {
            service.OutputData("=== Registering a visiting request ===");
            client = new Client();
            client.Id = service.InputIntData("Enter your client ID:");
            service.OutputData("Enter detainee ID:");
            string detaineeId = service.InputData();
            request = new Request
            {
                Id = GetNewId(),
                Type = "Visiting",
                Description = $"Visit detainee {detaineeId}",
                Status = "in processing",
                client = client,
            };
            request.SaveData();
            service.OutputData($"Visiting request for detainee #{detaineeId} registered");
        }
        /// <summary>
        /// Метод для оновлення статусу кримінальної події
        /// </summary>
        public void UpdateCriminalEventStatus()
        {
            service.OutputData("=== Updating crime event status ===");
            client = new Client();
            client.Id = service.InputIntData("Enter your client ID:");
            int eventId = service.InputIntData("Enter crime event ID:");
            service.OutputData("Enter new status:");
            string newStatus = service.InputData();
            service.OutputData($"Crime event #{eventId} status updated to: {newStatus}");
        }
        /// <summary>
        /// Метод для перевірки статусу скарги клієнта
        /// </summary>
        public void CheckComplaintStatus()
        {
            service.OutputData("=== Checking complaint status ===");
            client = new Client();
            client.Id = service.InputIntData("Enter your client ID:");
            int complaintId = service.InputIntData("Enter complaint ID:");
            service.OutputData($"Complaint #{complaintId} status: in processing");
        }
        /// <summary>
        /// Метод для обробки запиту клієнта до поліції
        /// </summary>
        public void ProcessRequest()
        {
            service.OutputData("=== Processing a request ===");
            service.OutputData("Enter the request (crime/complaint/visit/check):");
            string type = service.InputData();
            switch (type)
            {
                case "crime":
                    RegisterCrime();
                    break;
                case "complaint":
                    RegisterComplaint();
                    break;
                case "visit":
                    RegisterVisiting();
                    break;
                case "check":
                    CheckComplaintStatus();
                    break;
                default:
                    service.OutputData("Invalid request type. Please try again.");
                    break;
            }
        }
        /// <summary>
        /// Метод для отримання нового унікального ідентифікатора
        /// </summary>
        /// <returns></returns>
        private int GetNewId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }
    }
}
