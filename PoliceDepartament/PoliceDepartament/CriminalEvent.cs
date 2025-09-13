using System;
using System.Collections.Generic;

namespace PoliceDepartament
{
    /// <summary>
    /// Клас CriminalEvent представляє собою подію злочину, 
    /// що містить інформацію про злочин, місце події та статус
    /// </summary>
    public class CriminalEvent
    {
        private int id; //унікальний ідентифікатор події злочину
        private string description; //опис події злочину
        private string eventPlace; //місце, де сталася подія злочину
        private string status; //статус події злочину 

        private Service service;
        public PoliceOfficer policeOfficer;
        public Client client;
        public TechnicalDevice technicalDevice;
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
        public string EventPlace
        {
            get
            {
                return eventPlace;
            }
            set
            {
                this.eventPlace = value;
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
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id"> ідентифікатор </param>
        /// <param name="description"> опис події </param>
        /// <param name="eventPlace"> місце події </param>
        /// <param name="officer">офіцер</param>
        /// <param name="client">клієнт</param>
        /// <param name="device">пристрій</param>
        public CriminalEvent(int id, string description, string eventPlace, PoliceOfficer officer, Client client, TechnicalDevice device)
        {
            Id = id;
            Description = description;
            EventPlace = eventPlace;
            Status = "Registered";
            service = new Service();
            this.policeOfficer = officer;
            this.client = client;
            this.technicalDevice = device;
            Console.WriteLine("Constructor with parameters was called.");
        }
        /// <summary>
        /// Конструктор без параметрів
        /// </summary>
        public CriminalEvent()
        {
            Id = 0;
            Description = "";
            EventPlace = "";
            Status = "Registered";
            service = new Service();
            Console.WriteLine("Empty constructor was called.");
        }
        /// <summary>
        /// Приватний конструктор
        /// </summary>
        /// <param name="privateParam">параметр для ід</param>
        private CriminalEvent(string privateParam)
        {
            Id = int.Parse(privateParam);
            Description = "Private init";
            Status = "Private";
            service = new Service();
            Console.WriteLine("Private constructor was called.");
        }
        /// <summary>
        /// Конструктор копії
        /// </summary>
        /// <param name="other">інший клас</param>
        public CriminalEvent(CriminalEvent other)
        {
            Id = other.Id;
            Description = other.Description;
            EventPlace = other.EventPlace;
            Status = other.Status;
            service = new Service();
            policeOfficer = other.policeOfficer;
            client = other.client;
            technicalDevice = other.technicalDevice;
            Console.WriteLine("Copy constructor was called.");
        }
        /// <summary>
        /// Конструктор, який викликає інший конструктор
        /// </summary>
        /// <param name="id"> ідентифікатор </param>
        /// <param name="officer">офіцер</param>
        /// <param name="client">клієнт</param>
        /// <param name="device">пристрій</param>
        public CriminalEvent(int id, PoliceOfficer officer, Client client, TechnicalDevice device)
            : this(id, "Default description", "Unknown place", officer, client, device)
        {
            Console.WriteLine("Constructor that calls other constructors.");
        }
        /// <summary>
        /// Статичний конструктор
        /// </summary>
        static CriminalEvent()
        {
            Console.WriteLine("Static constructor was called.");
        }
        /// <summary>
        /// Метод для збереження даних про подію злочину у файл
        /// </summary>
        public void SaveData()
        {
            service.FilePath = "criminalEvents.txt";
            service.WriteData($"{id};{description};{eventPlace};{status}");
            service.OutputData($"Event #{id} is saved.");
        }
    }
}
