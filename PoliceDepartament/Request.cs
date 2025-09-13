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
