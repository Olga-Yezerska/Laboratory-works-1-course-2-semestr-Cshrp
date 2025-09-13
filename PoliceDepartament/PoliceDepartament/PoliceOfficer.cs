using System;

namespace PoliceDepartament
{
    /// <summary>
    /// Клас PoliceOfficer представляє поліцейського
    /// </summary>
    public class PoliceOfficer
    {
        private int id; //унікальний ідентифікатор поліцейського
        private string name; //ім'я поліцейського
        private string status; //статус поліцейського (активний, неактивний тощо)
        private Service service;
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
        public PoliceOfficer()
        {
            id = 0;
            name = "";
            status = "";
            service = new Service();
            Console.WriteLine("Default constructor called.");
        }
        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">ід</param>
        /// <param name="name">ім'я</param>
        /// <param name="status">статус</param>
        public PoliceOfficer(int id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
            service = new Service();
            Console.WriteLine("Parameterized constructor called.");
        }
        /// <summary>
        /// Статичний конструктор
        /// </summary>
        static PoliceOfficer()
        {
            Console.WriteLine("Static constructor called.");
        }
        /// <summary>
        /// Закритий конструктор
        /// </summary>
        /// <param name="privateFlag">для виклику</param>
        private PoliceOfficer(bool privateFlag)
        {
            id = -1;
            name = "Private Officer";
            status = "inactive";
            service = new Service();
            Console.WriteLine("Private constructor called.");
        }
        /// <summary>
        /// Конструктор копії
        /// </summary>
        /// <param name="other">оригінал</param>
        public PoliceOfficer(PoliceOfficer other)
        {
            Id = other.Id;
            Name = other.Name;
            Status = other.Status;
            service = new Service();
            Console.WriteLine("Copy constructor called.");
        }
        /// <summary>
        /// Конструктор, який викликає інші
        /// </summary>
        /// <param name="id">ід</param>
        public PoliceOfficer(int id) : this(id, "Default Name", "active")
        {
            Console.WriteLine("Constructor calling another constructor called.");
        }
        /// <summary>
        /// Метод для призначення поліцейського на подію
        /// </summary>
        public void AssignToEvent()
        {
            service.OutputData($"Officer {Name} has been appointed to the event.");
        }
        /// <summary>
        /// Метод для збереження даних про поліцейського
        /// </summary>
        public void SaveData()
        {
            service.OutputData($"Information about the police officer has been saved: {Name}, status: {Status}");
        }

    }
}
