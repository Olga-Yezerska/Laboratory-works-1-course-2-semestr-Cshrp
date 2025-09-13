using System;
using System.Threading;

namespace Lab6
{
    /// <summary>
    /// Клас для нейроінтерфейсу
    /// </summary>
    public class Neurointerface
    {
        private float calibration; // рівень калібрування (від 0 до 1)
        private float sensitivity; // чутливість (від 0 до 1)
        private float adaptibility; // адаптивність (від 0 до 1)
        private float signalStrength; // сила сигналу (від 0 до 1)

        // Асоціації
        private Service service;
        private Sensors sensors;
        private PowerSupply powerSupply;
        private Biointerface biointerface;
        private Random random = new Random();

        /// <summary>
        /// Властивість
        /// </summary>
        public float Calibration
        {
            get
            {
                return calibration;
            }
            set
            {
                this.calibration = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public float Sensitivity
        {
            get
            {
                return sensitivity;
            }
            set
            {
                this.sensitivity = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public float Adaptibility
        {
            get
            {
                return adaptibility;
            }
            set
            {
                this.adaptibility = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public float SignalStrength
        {
            get
            {
                return signalStrength;
            }
            set
            {
                this.signalStrength = value;
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
        /// Властивість
        /// </summary>
        public Biointerface Biointerface
        {
            get
            {
                return biointerface;
            }
            set
            {
                this.biointerface = value;
            }
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        public Neurointerface()
        {
            calibration = 0.0f;
            sensitivity = 0.0f;
            adaptibility = 0.0f;
            signalStrength = 0.0f;
        }
        /// <summary>
        /// Метод для синхронізації нейроінтерфейсу з мозком людини
        /// </summary>
        /// <returns> звіт </returns>
        public string BrainSynchronization()
        {
            SignalCalibration();
            sensors.ReadingData();
            signalStrength = 0.7f + (float)random.NextDouble() * 0.2f;
            string report = $"Neurointerface Synchronization:\n" +
                               $"Calibration: {calibration:F2}\n" +
                               $"Sensitivity: {sensitivity:F2}\n" +
                               $"Adaptibility: {adaptibility:F2}\n" +
                               $"Signal Strength: {signalStrength:F2}\n" +
                               $"Heart Rate (neural indicator): {sensors.HeartRate:F0} bpm";
            service.WriteData("neurointerface.txt", report);
            return report;
        }
        /// <summary>
        /// Метод для калібрування нейроінтерфейсу
        /// </summary>
        public void SignalCalibration()
        {
            service.OutputData($"Current calibration: {calibration:F2}");
            if (calibration < 0.8f)
            {
                calibration = 0.8f + (float)random.NextDouble() * 0.15f; // 0.8–0.95
                service.OutputData($"Calibration updated to {calibration:F2}");
            }
            else
            {
                service.OutputData("Calibration is sufficient.");
            }
        }
        /// <summary>
        /// Метод для виконання команди через біоінтерфейс
        /// </summary>
        public void CommandExecution()
        {
            if (signalStrength < 0.7f)
            {
                service.OutputData("Cannot execute command: Weak signal strength.");
                return;
            }
            service.OutputData("Executing command via Biointerface...");
            biointerface.Stimulation(); 
            service.OutputData("Command executed successfully.");
        }
        /// <summary>
        /// Метод для оновлення моделі сигналу нейроінтерфейсу
        /// </summary>
        public void UpdateSignalModel()
        {
            sensors.ReadingData();
            signalStrength = 0.7f + (float)random.NextDouble() * 0.2f;
            adaptibility = Math.Min(1.0f, adaptibility + 0.1f); // Збільшуємо до 1.0
            service.OutputData($"Signal model updated. Adaptibility: {adaptibility:F2}");
        }       
    }
}