using System;

namespace PoliceDepartament
{
    /// <summary>
    /// Клас PoliceCenter представляє поліцейський центр
    /// </summary>
    public class PoliceCenter
    {
        private int id; //унікальний ідентифікатор поліцейського центру
        private string name; // назва поліцейського центру
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
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
        /// <summary>
        /// Конструктор без параметрів
        /// </summary>
        public PoliceCenter()
        {
            id = 0;
            name = "";
            service = new Service();
            Console.WriteLine("Default constructor called.");
        }
        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">ід</param>
        /// <param name="name">ім'я</param>
        public PoliceCenter(int id, string name)
        {
            Id = id;
            Name = name;
            service = new Service();
            Console.WriteLine("Parameterized constructor called.");
        }
        /// <summary>
        /// Статичний конструктор
        /// </summary>
        static PoliceCenter()
        {
            Console.WriteLine("Static constructor called.");
        }
        /// <summary>
        /// Заркитий конструктор
        /// </summary>
        /// <param name="privateFlag">для виклику</param>
        private PoliceCenter(bool privateFlag)
        {
            id = -1;
            name = "Private Center";
            service = new Service();
            Console.WriteLine("Private constructor called.");
        }
        /// <summary>
        /// Конструктор копії
        /// </summary>
        /// <param name="other">оригінал</param>
        public PoliceCenter(PoliceCenter other)
        {
            Id = other.Id;
            Name = other.Name;
            service = new Service();
            Console.WriteLine("Copy constructor called.");
        }
        /// <summary>
        /// Конструктор, що викликає інші
        /// </summary>
        /// <param name="id">ід</param>
        public PoliceCenter(int id) : this(id, "Default Center")
        {
            Console.WriteLine("Constructor calling another constructor called.");
        }
        /// <summary>
        /// Метод для реєстрації клієнта
        /// </summary>
        public void RegisterClient()
        {
            service.OutputData("Client was registered");
        }
        /// <summary>
        /// Метод для реєстрації поліцейського
        /// </summary>
        public void SubmitRequest()
        {
            service.OutputData("Request was sent to the appropriate service");
        }
        /// <summary>
        /// Метод для відображення доступних послуг
        /// </summary>
        public void DisplayAvailableServices()
        {
            service.OutputData("Available services were displayed");
        }
        Service service = new Service();
        public Request request;
        public CrimeService crimeService;
        public TrafficService trafficService;
        public TouristSafety touristSafety;
        public LostAndFoundService lostAndFoundService;
    }
}
