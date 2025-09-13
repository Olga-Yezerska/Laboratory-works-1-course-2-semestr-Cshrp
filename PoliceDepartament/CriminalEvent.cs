using System;

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
        public CriminalEvent(int id, string description, string eventPlace)
        {
            Id = id;
            Description = description;
            EventPlace = eventPlace;
            Status = "Registered";
            service = new Service();
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
