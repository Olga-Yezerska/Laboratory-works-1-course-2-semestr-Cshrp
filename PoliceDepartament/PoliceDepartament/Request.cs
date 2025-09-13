using System;

namespace PoliceDepartament
{
    /// <summary>
    /// Клас Request представляє запит клієнта до поліції
    /// </summary>
    public class Request
    {
        private int id; //унікальний ідентифікатор запиту
        private string type; //тип запиту
        private string description; //опис запиту
        private string status; //статус запиту
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
        public Request()
        {
            id = 0;
            type = "";
            status = "";
            description = "";
            service = new Service();
            Console.WriteLine("Default constructor called.");
        }
        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">ід</param>
        /// <param name="type">тип</param>
        /// <param name="description">опис</param>
        /// <param name="status">статус</param>
        public Request(int id, string type, string description, string status)
        {
            Id = id;
            Type = type;
            Description = description;
            Status = status;
            service = new Service();
            Console.WriteLine("Parameterized constructor called.");
        }
        /// <summary>
        /// Статичний конструктор
        /// </summary>
        static Request()
        {
            Console.WriteLine("Static constructor called.");
        }
        /// <summary>
        /// Закритий конструктор
        /// </summary>
        /// <param name="privateFlag">для виклику</param>
        private Request(bool privateFlag)
        {
            id = -1;
            type = "Private Request";
            description = "Private description";
            status = "inactive";
            service = new Service();
            Console.WriteLine("Private constructor called.");
        }
        /// <summary>
        /// Конструктор копії
        /// </summary>
        /// <param name="other">оригінал</param>
        public Request(Request other)
        {
            Id = other.Id;
            Type = other.Type;
            Description = other.Description;
            Status = other.Status;
            service = new Service();
            Console.WriteLine("Copy constructor called.");
        }
        /// <summary>
        /// Конструктор для виклику інших
        /// </summary>
        /// <param name="id">ід</param>
        public Request(int id) : this(id, "Default Type", "Default Description", "pending")
        {
            Console.WriteLine("Constructor calling another constructor called.");
        }
        /// <summary>
        /// Метод для створення запиту
        /// </summary>
        public void SaveData()
        {
            service.FilePath = "requests.txt";
            service.WriteData($"{Id};{Type};{Description};{Status}");
            service.OutputData($"Request #{Id} is saved.");
        }
    }
}
