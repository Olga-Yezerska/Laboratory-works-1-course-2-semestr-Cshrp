using System;
using System.Collections.Generic;

namespace PoliceDepartament
{
    /// <summary>
    /// Клас Client представляє клієнта поліції, 
    /// який може надсилати запити на обслуговування
    /// </summary>
    public class Client
    {
        private int id; //унікальний ідентифікатор клієнта
        private string name; //ім'я клієнта
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
        /// Конструктор без параметрів
        /// </summary>
        public Client()
        {
            service = new Service();
            id = 0;
            name = "";
            Console.WriteLine("Empty constructor was called.");
        }
        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">ід</param>
        /// <param name="name">ім'я</param>
        public Client(int id, string name)
        {
            service = new Service();
            Id = id;
            Name = name;
            Console.WriteLine("Constructor with parameters was called.");
        }
        /// <summary>
        /// СТатичний конструктор
        /// </summary>
        static Client()
        {
            Console.WriteLine("Static constructor was called.");
        }
        /// <summary>
        /// Приватний конструктор
        /// </summary>
        /// <param name="privateFlag">для виклику конструктора</param>
        private Client(bool privateFlag)
        {
            service = new Service();
            id = -1;
            name = "Private Client";
            Console.WriteLine("Private constructor was called.");
        }
        /// <summary>
        /// Конструктор для копіювання
        /// </summary>
        /// <param name="other">клас, який копіюється</param>
        public Client(Client other)
        {
            Id = other.Id;
            Name = other.Name;
            service = new Service();
            Console.WriteLine("Copy constructor was called.");
        }
        /// <summary>
        /// Конструктор, що викликає інші конструктори
        /// </summary>
        /// <param name="id">ід</param>
        public Client(int id) : this(id, "Default Name")
        {
            Console.WriteLine("Constructor that calls other constructors.");
        }
        /// <summary>
        /// Метод для надсилання запиту на обслуговування
        /// </summary>
        public void Apply()
        {
            service.OutputData("=== The Client is sending a request ===");

            Id = service.InputIntData("Enter the ID of Client:");
            Name = service.InputStringData("Enter the name of Client:");

            service.OutputData($"The request has been sent. Client: {Name} (ID: {Id})");
        }
    }
}
