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
