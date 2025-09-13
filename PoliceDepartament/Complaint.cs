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
