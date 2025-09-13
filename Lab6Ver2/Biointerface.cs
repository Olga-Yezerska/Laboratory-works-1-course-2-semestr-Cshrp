using System;
using System.Threading;

namespace Lab6
{
    /// <summary>
    /// Клас для біоінтерфейсу
    /// </summary>
    public class Biointerface
    {
        private string type; // тип біоінтерфейсу
        private float accuracyLevel; // рівень точності (від 0 до 100)
        private bool activity; // активність біоінтерфейсу (активний/неактивний) 
        private string calibrationStatus; // статус калібрування (калібрований/некалібрований)

        //Асоціації
        private Service service;
        private Sensors sensors;
        private PowerSupply powerSupply;
        private MoodAnalysis moodAnalysis;

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
        public float AccuracyLevel
        {
            get
            {
                return accuracyLevel;
            }
            set
            {
                this.accuracyLevel = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public bool Activity
        {
            get
            {
                return activity;
            }
            set
            {
                this.activity = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string CalibrationStatus
        {
            get
            {
                return calibrationStatus;
            }
            set
            {
                this.calibrationStatus = value;
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
        /// Конструктор 
        /// </summary>
        public Biointerface()
        {
            type = "";
            accuracyLevel = 0.0f;
            activity = false;
            calibrationStatus = "";
        }
        /// <summary>
        /// Метод для зчитування параметрів біоінтерфейсу
        /// </summary>
        /// <returns> звіт </returns>
        public string ReadParameters()
        {
            sensors.ReadingData();
            activity = true;
            calibrationStatus = "Calibrated";
            accuracyLevel = (float)sensors.SensorAccuracy; //рівень точності від 0 до 100
            string report = $"Biointerface Parameters:\n" + $"Heart Rate: {sensors.HeartRate:F0} bpm\n" + $"Temperature: {sensors.Temperature:F1}°C\n" +
                           $"Glucose: {sensors.GlucoseLevel:F1} mmol/L\n" + $"Accuracy: {accuracyLevel:F1}%\n";
            service.WriteData("biointerface.txt", report);
            return report;
        }
        /// <summary>
        /// Метод для аналізу даних біоінтерфейсу
        /// </summary>
        /// <returns> висновок </returns>
        public string DataAnalysis()
        {
            if (!activity)
            {
                service.OutputData("Biointerface is inactive. Please read parameters.");
                return "Inactive";
            }
            string conclusion = sensors.HeartRate > 100 ? "High heart rate detected. Rest recommended." : //якщо серцебиття більше 100
                               sensors.GlucoseLevel > 6.0 ? "Elevated glucose. Consult a doctor." : //якщо рівень глюкози більше 6.0
                               sensors.Temperature > 37.0 ? "Elevated temperature. Monitor health." : //якщо температура більше 37.0
                               "All parameters normal.";
            service.OutputData($"Biointerface Analysis: {conclusion}");
            service.WriteData($"biointerface.txt", "Analysis: {conclusion}");
            return conclusion;
        }
        /// <summary>
        /// Метод для калібрування біоінтерфейсу
        /// </summary>
        public void Stimulation()
        {
            if (calibrationStatus != "Calibrated" || !activity)
            {
                service.OutputData("Cannot stimulate: Not calibrated or inactive.");
                return;
            }
            service.OutputData("Applying stimulation to stabilize parameters...");
            sensors.HeartRate = Math.Max(60, sensors.HeartRate - 5); //зменшуємо серцебиття на 5
            service.OutputData("Stimulation complete. Heart rate adjusted.");
        }

    }
}