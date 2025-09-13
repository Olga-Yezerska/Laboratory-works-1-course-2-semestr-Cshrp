using System;

namespace PoliceDepartament
{
    /// <summary>
    /// Клас TechnicalDevice представляє технічний пристрій
    /// </summary>
    public class TechnicalDevice
    {
        private int id; //унікальний ідентифікатор технічного пристрою
        private string type; //тип технічного пристрою
        private string status; //статус технічного пристрою (активний, неактивний тощо)
        public Service service;
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
        public TechnicalDevice()
        {
            id = 0;
            type = "";
            status = "active";
            service = new Service();
            Console.WriteLine("Default constructor called.");
        }
        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">ід</param>
        /// <param name="type">тип</param>
        /// <param name="status">статус</param>
        public TechnicalDevice(int id, string type, string status)
        {
            Id = id;
            Type = type;
            Status = status;
            service = new Service();
            Console.WriteLine("Parameterized constructor called.");
        }
        /// <summary>
        /// Статичний конструктор
        /// </summary>
        static TechnicalDevice()
        {
            Console.WriteLine("Static constructor called.");
        }
        /// <summary>
        /// Закритий конструктор
        /// </summary>
        /// <param name="privateFlag">для виклику закритого</param>
        private TechnicalDevice(bool privateFlag)
        {
            id = -1;
            type = "Private Device";
            status = "inactive";
            service = new Service();
            Console.WriteLine("Private constructor called.");
        }
        /// <summary>
        /// Конструктор для копіювання
        /// </summary>
        /// <param name="other">оригінал</param>
        public TechnicalDevice(TechnicalDevice other)
        {
            Id = other.Id;
            Type = other.Type;
            Status = other.Status;
            service = new Service();
            Console.WriteLine("Copy constructor called.");
        }
        /// <summary>
        /// Конструктор для виклику інших конструкторів
        /// </summary>
        /// <param name="id"></param>
        public TechnicalDevice(int id) : this(id, "Default Type", "active")
        {
            Console.WriteLine("Constructor calling another constructor called.");
        }
        /// <summary>
        /// Метод для реєстрації нового технічного пристрою
        /// </summary>
        public void RegisterDevice()
        {
            service.OutputData("=== Registering a new device ===");
            id = Math.Abs(Guid.NewGuid().GetHashCode());
            service.OutputData("Enter the type:");
            type = service.InputData();
            status = "active";
            service.FilePath = "technicalDevices.txt";
            service.WriteData($"{id};{type};{status}");
            service.OutputData($"Device #{id} is saved.");
        }
        /// <summary>
        /// Метод для запису події, пов'язаної з технічним пристроєм
        /// </summary>
        /// <param name="eventId"> ід події </param>
        public void RecordEvent(int eventId)
        {
            if (status == "active")
            {
                service.WriteData($"{id};{type};{status};{eventId}");
                service.OutputData($"Device {type} #{id} recorded #{eventId}");
            }
        }
        /// <summary>
        /// Метод для пошуку активного технічного пристрою
        /// </summary>
        public void FindActiveDevice()
        {
            service.FilePath = "technicalDevices.txt";
            string data = service.ReadData();
            if (string.IsNullOrEmpty(data))
            {
                service.OutputData("No devices found in the file.");
                return;
            }
            string[] lines = data.Split('\n');
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                string[] parts = line.Split(';');
                if (parts.Length >= 3 && parts[2] == "active")
                {
                    service.OutputData($"Active device found: ID {parts[0]}, Type {parts[1]}");
                    return;
                }
            }
            service.OutputData("No active devices found.");
        }
    }
}
