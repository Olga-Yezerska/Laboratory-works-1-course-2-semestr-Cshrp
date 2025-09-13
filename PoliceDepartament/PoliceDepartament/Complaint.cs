using System;
namespace PoliceDepartament
{
    /// <summary>
    /// Клас Complaint представляє скаргу клієнта поліції, 
    /// яка містить інформацію про тип, опис та статус скарги
    /// </summary>
    public class Complaint
    {
        private int id; //унікальний ідентифікатор скарги
        private string type; //тип скарги
        private string description;// опис скарги
        private string status; //статус скарги
        private Service service; 
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
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                this.type = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                this.description = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                this.status = value;
            }
        }
        /// <summary>
        /// Конструктор без параметрів
        /// </summary>
        public Complaint()
        {
            id = 0;
            type = "";
            description = "";
            status = "";
            service = new Service();
            Console.WriteLine("Empty constructor was called.");
        }
        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">ід</param>
        /// <param name="type">тип</param>
        /// <param name="description">опис</param>
        /// <param name="client">клас клієнта</param>
        public Complaint(int id, string type, string description, Client client)
        {
            Id = id;
            Type = type;
            Description = description;
            Status = "Pending";
            service = new Service();
            this.client = client;
            Console.WriteLine("Constructor with parameters was called.");
        }
        /// <summary>
        /// Статичний конструктор
        /// </summary>
        static Complaint()
        {
            Console.WriteLine("Static constructor was called.");
        }
        /// <summary>
        /// Закритий конструктор
        /// </summary>
        /// <param name="privateFlag">позначка</param>
        private Complaint(bool privateFlag)
        {
            id = -1;
            type = "Private Complaint";
            description = "Private description";
            status = "Private";
            service = new Service();
            Console.WriteLine("Private constructor was called.");
        }
        /// <summary>
        /// Конструктор для копії
        /// </summary>
        /// <param name="other">оригінал</param>
        public Complaint(Complaint other)
        {
            Id = other.Id;
            Type = other.Type;
            Description = other.Description;
            Status = other.Status;
            service = new Service();
            client = other.client;
            Console.WriteLine("Copy constructor was called.");
        }
        /// <summary>
        /// Конструктор, який викликає інший конструктор
        /// </summary>
        /// <param name="id">ід</param>
        /// <param name="client">клієнт</param>
        public Complaint(int id, Client client) : this(id, "General", "Default description", client)
        {
            Console.WriteLine("Constructor that calls other constructors.");
        }
        /// <summary>
        /// Метод для збереження даних про скаргу
        /// </summary>
        public void SaveData()
        {
            service.FilePath = "complaints.txt";
            service.OutputData($"The complaint has been saved:\nType: {Type}\nDescription: {Description}\nStatus: {Status}");
        }
    }
}
