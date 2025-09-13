using System;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Клас для моделі комунікації
    /// </summary>
    public class CommunicationModel
    {
        private string communicationType; // тип комунікації (наприклад, Wi-Fi, Bluetooth, Ethernet)
        private float bandwidth; // пропускна здатність (в Мбіт/с)
        private bool connectionStatus; // статус з'єднання (підключено/не підключено)
        private int encryptionLevel; // рівень шифрування (в бітах, наприклад, 128, 256)

        // Асоціація
        private Service service;
        private Message messages; 
        private Ai ai;
        private SecurityControl security;
        private PowerSupply powerSupply;

        /// <summary>
        /// Властивість
        /// </summary>
        public string CommunicationType
        {
            get
            {
                return communicationType;
            }
            set
            {
                this.communicationType = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public float Bandwidth
        {
            get
            {
                return bandwidth;
            }
            set
            {
                this.bandwidth = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public bool ConnectionStatus
        {
            get
            {
                return connectionStatus;
            }
            set
            {
                this.connectionStatus = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public int EncryptionLevel
        {
            get
            {
                return encryptionLevel;
            }
            set
            {
                this.encryptionLevel = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public Service Service
        {
            get
            {
                return service;
            }
            set
            {
                this.service = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public Ai Ai
        {
            get
            {
                return ai;
            }
            set
            {
                this.ai = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public SecurityControl Security
        {
            get
            {
                return security;
            }
            set
            {
                this.security = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public Message Messages
        {
            get
            {
                return messages;
            }
            set
            {
                this.messages = value;
            }
        }
        /// <summary>
        /// Конструктор 
        /// </summary>
        public CommunicationModel()
        {
            communicationType = "";
            bandwidth = 0.0f;
            connectionStatus = false;
            encryptionLevel = 0;
        }
        /// <summary>
        /// Метод для перевірки статусу з'єднання
        /// </summary>
        /// <returns> результат підключення </returns>
        public string ConnectionChecking()
        {
            string result;
            if (connectionStatus == true)
            {
                result = "Connected";
            }
            else
            {
                result = "Disconnected";
            }
            return result;
        }
        /// <summary>
        /// Метод для встановлення з'єднання
        /// </summary>
        public void SetConnection()
        {
            string status = ConnectionChecking();
            if (status.Contains("Error"))
            {
                return;
            }
            if (status == "Disconnected")
            {
                connectionStatus = true;
                bandwidth = 100f;
                service.OutputData("Connection established: " + communicationType);
                string aiRecommendation = ai.GetRecommendation("Establish connection: " + communicationType);
                service.OutputData("AI: " + aiRecommendation);
            }
            else
            {
                service.OutputData("Connection already active.");
            }

            service.WriteData("communication_log.txt", "Connection set: " + connectionStatus);
        }
        /// <summary>
        /// Метод для відключення з'єднання
        /// </summary>
        /// <param name="data"> інформація </param>
        public void SendData(string data)
        {
            string status = ConnectionChecking();
            if (status != "Connected")
            {
                service.OutputData("Cannot send data: No connection.");
                return;
            }
            service.OutputData("Data sent: " + data);
            service.WriteData("communication_log.txt", "Sent: " + data);
        }
        /// <summary>
        /// Метод для отримання даних 
        /// </summary>
        /// <returns> отримана інформація</returns>
        public string GetData()
        {
            string status = ConnectionChecking();
            if (status != "Connected")
            {
                service.OutputData("Cannot get data: No connection.");
                return "Error: No connection";
            }
            string rawData = "Sample data from server"; // Imitation
            service.OutputData("Data received: " + rawData);
            service.WriteData("communication_log.txt", "Received: " + rawData);
            return rawData;
        }
        /// <summary>
        /// Метод для шифрування даних перед відправкою
        /// </summary>
        /// <param name="data"> інформація на зашифровку </param>
        public void EncryptionData(string data)
        {
            if (encryptionLevel < 128)
            {
                service.OutputData("Encryption level too low: " + encryptionLevel + " bits.");
                return;
            }
            string encryptedData = security.EncryptData(data, encryptionLevel);
            service.OutputData("Data encrypted: " + encryptedData);
            service.WriteData("communication_log.txt", "Encrypted: " + encryptedData);
        }
    }
}