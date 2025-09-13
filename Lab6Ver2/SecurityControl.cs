using System;

namespace Lab6
{
    /// <summary>
    /// Клас для контролю безпеки
    /// </summary>
    public class SecurityControl
    {
        private int threatLevel; // рівень загрози (від 0 до 100)
        private string threatAssessment; // оцінка загрози (висока, середня, низька)
        private bool securityMode; // режим безпеки (активний/неактивний)
        private string currentLocation; // поточне місцезнаходження
        private string[] threatsHistory; // історія загроз (максимум 10 записів)
        private int historyCount; // лічильник записів в історії

        //Асоціації
        private Service service;
        private Ai ai;
        private Sensors sensors;
        private TeleportationModule teleportation;
        private CommunicationModel communication;
        private PowerSupply powerSupply;

        /// <summary>
        /// Властивість
        /// </summary>
        public int ThreatLevel
        {
            get
            {
                return threatLevel;
            }
            set
            {
                this.threatLevel = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string ThreatAssessment
        {
            get
            {
                return threatAssessment;
            }
            set
            {
                this.threatAssessment = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public bool SecurityMode
        {
            get
            {
                return securityMode;
            }
            set
            {
                this.securityMode = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string CurrentLocation
        {
            get
            {
                return currentLocation;
            }
            set
            {
                this.currentLocation = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>

        public string[] ThreatsHistory
        {
            get
            {
                return threatsHistory;
            }
            set
            {
                this.threatsHistory = value;
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
        public Sensors Sensors
        {
            get
            {
                return sensors;
            }
            set
            {
                this.sensors = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public TeleportationModule Teleportation
        {
            get
            {
                return teleportation;
            }
            set
            {
                this.teleportation = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public CommunicationModel Communication
        {
            get
            {
                return communication;
            }
            set
            {
                this.communication = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public PowerSupply PowerSupply
        {
            get
            {
                return powerSupply;
            }
            set
            {
                this.powerSupply = value;
            }
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        public SecurityControl()
        {
            threatLevel = 0;
            threatAssessment = "";
            securityMode = false;
            currentLocation = "";
            threatsHistory = new string[10];
            historyCount = 0;
        }
        /// <summary>
        /// Метод для аналізу загроз
        /// </summary>
        public void ThreatsAnalysis()
        {
            service.OutputData("Sensor data: HeartRate=" + sensors.HeartRate);
            threatLevel = sensors.HeartRate > 100 ? 50 : 25;
            if (historyCount < threatsHistory.Length)
            {
                threatsHistory[historyCount] = "Threat analyzed at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": Level=" + threatLevel;
                historyCount++;
            }
            if (threatLevel > 70)
            {
                threatAssessment = "High";
            }
            else if (threatLevel > 40)
            {
                threatAssessment = "Medium";
            }
            else
            {
                threatAssessment = "Low";
            }
            string aiRecommendation = ai.GetRecommendation("Threat level: " + threatLevel);
            service.WriteData("security_log.txt", "Threat: " + threatAssessment + ", Level: " + threatLevel);
        }
        /// <summary>
        /// Метод для сповіщення про небезпеку
        /// </summary>
        public void DangerAlert()
        {
            if (threatLevel > 40)
            {
                string message = "Danger detected! Threat level: " + threatLevel + ", Location: " + currentLocation;
                string encryptedMessage = EncryptData(message, 128);
                communication.SendData(encryptedMessage);
                service.OutputData("Notified: " + message);
                service.WriteData("security_log.txt", "Notified: " + message);
            }
            else
            {
                service.OutputData("No significant threat to notify.");
            }
        }
        /// <summary>
        /// Метод для активації режиму безпеки
        /// </summary>
        public void SecurityActivation()
        {
            securityMode = true;
            service.OutputData("Protection activated: GuardMode=" + securityMode);
            service.WriteData("security_log.txt", "Protection activated: " + securityMode);
        }
        /// <summary>
        /// Метод для деактивації режиму безпеки
        /// </summary>
        public void ModeUpdate()
        {
            if (threatLevel > 70)
            {
                securityMode = true;
            }
            else if (threatLevel > 40)
            {
                securityMode = true;
            }
            else
            {
                securityMode = false;
            }
            service.OutputData("Guard mode updated: " + securityMode);
            service.WriteData("security_log.txt", "Guard mode: " + securityMode);
        }
        /// <summary>
        /// Метод для шифрування даних
        /// </summary>
        /// <param name="data"> інформація на шифрування </param>
        /// <param name="encryptionLevel"> рівень шифрування </param>
        /// <returns> зашифровані дані </returns>
        public string EncryptData(string data, int encryptionLevel)
        {
            if (encryptionLevel < 128)
            {
                service.OutputData("Encryption level too low: " + encryptionLevel + " bits.");
                return "Error: Low encryption level";
            }
            string encrypted = "ENC[" + encryptionLevel + "]:" + data;
            service.OutputData("Encrypting data with " + encryptionLevel + "-bit level.");
            return encrypted;
        }
        /// <summary>
        /// Метод для дешифрування даних
        /// </summary>
        /// <param name="data"> інфромація на розшифровку </param>
        /// <param name="encryptionLevel"> півень шифрування </param>
        /// <returns> розшифрована інформація </returns>
        public string DecryptData(string data, int encryptionLevel)
        {
            if (data.StartsWith("ENC[" + encryptionLevel + "]:"))
            {
                string decrypted = data.Substring(data.IndexOf(":") + 1);
                service.OutputData("Decrypting data with " + encryptionLevel + "-bit level.");
                return decrypted;
            }
            service.OutputData("Invalid encrypted data format.");
            return "Error: Invalid format";
        }
    }
}