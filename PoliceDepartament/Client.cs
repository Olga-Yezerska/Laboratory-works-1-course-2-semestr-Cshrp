using System;

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
