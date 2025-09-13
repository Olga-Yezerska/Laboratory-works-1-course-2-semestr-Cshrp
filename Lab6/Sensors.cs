using System;

namespace Lab6
{
    /// <summary>
    /// Клас для сенсорів
    /// </summary>
    public class Sensors
    {
        private double temperature; // температура тіла (в градусах Цельсія)
        private double heartRate; // частота серцевих скорочень (удари на хвилину)
        private string cardiogramData; // дані кардіограми (рядок з інформацією про ритм)
        private double[] locationCoordinates; // координати місцезнаходження (широта, довгота, висота)
        private double glucoseLevel; // рівень глюкози в крові (в ммоль/л)
        private double sensorAccuracy; // точність сенсора (від 0 до 100%)

        //Асоціація
        Service service;
        Random random = new Random();

        /// <summary>
        /// Властивість
        /// </summary>
        public double Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                this.temperature = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public double HeartRate
        {
            get
            {
                return heartRate;
            }
            set
            {
                this.heartRate = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string CardiogramData
        {
            get
            {
                return cardiogramData;
            }
            set
            {
                this.cardiogramData = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public double[] LocationCoordinates
        {
            get
            {
                return locationCoordinates;
            }
            set
            {
                this.locationCoordinates = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public double GlucoseLevel
        {
            get
            {
                return glucoseLevel;
            }
            set
            {
                this.glucoseLevel = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public double SensorAccuracy
        {
            get
            {
                return sensorAccuracy;
            }
            set
            {
                this.sensorAccuracy = value;
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
        public Sensors()
        {
            temperature = 0.0;
            heartRate = 0.0;
            cardiogramData = string.Empty;
            locationCoordinates = new double[3];
            glucoseLevel = 0.0;
            sensorAccuracy = 0.0;
            random = new Random();
        }
        /// <summary>
        /// Метод для читання даних з сенсорів
        /// </summary>
        public void ReadingData()
        {
            temperature = 36.6 + random.NextDouble() * 0.5; 
            heartRate = 60 + random.NextDouble() * 40; 
            cardiogramData = "Normal rhythm";
            locationCoordinates = new double[] { 50.45, 30.52, 0 }; 
            glucoseLevel = 4.5 + random.NextDouble() * 1.5; 
            sensorAccuracy = 95.0;
            service.OutputData("Sensor data read successfully.");
        }
        /// <summary>
        /// Метод для калібрування сенсорів
        /// </summary>
        public void SensorsCalibration()
        {
            sensorAccuracy = Math.Min(100, sensorAccuracy + 10); 
            service.OutputData($"Sensors calibrated. Accuracy: {sensorAccuracy:F1}%.");
        }
        /// <summary>
        /// Метод для форматування даних сенсорів 
        /// </summary>
        public void DataFormating()
        {
            string formattedData = "{\n" +
                                      $"  \"temperature\": {temperature:F1},\n" +
                                      $"  \"heartRate\": {heartRate:F0},\n" +
                                      $"  \"cardiogram\": \"{cardiogramData}\",\n" +
                                      $"  \"location\": [{locationCoordinates[0]:F2}, {locationCoordinates[1]:F2}, {locationCoordinates[2]:F2}],\n" +
                                      $"  \"glucose\": {glucoseLevel:F1},\n" +
                                      $"  \"accuracy\": {sensorAccuracy:F1}\n" +
                                      "}";
            service.OutputData(formattedData);
            service.WriteData("sensors.txt", formattedData);
        }
    }
}