using System;
using System.Globalization;
using System.Threading;

namespace Lab6
{
    /// <summary>
    /// Клас для смарт-годинника
    /// </summary>
    public class SmartWatch : ISmartWatch
    {
        private int id; // унікальний ідентифікатор
        private string serialNumber; // серійний номер
        private string model; // модель смарт-годинника
        private bool powerStatus; // стан живлення (ввімкнено/вимкнено)
        private string firmwareVersion; //  версія прошивки
        private DateTime lastDiagnosisTime; // час останньої діагностики

        //Композиція
        private PowerSupply powerSupply;
        private Sensors sensors;
        private SecurityControl securityControl;
        private Biointerface biointerface;
        private Neurointerface neurointerface;
        private VisualizationModule visualizationModule;
        private CommunicationModel communicationModule;
        private MoodAnalysis moodAnalysis;
        private Message message;

        //Агрегaція
        private Ai ai;
        private TeleportationModule teleportationModule;
        private LifeSupportCapsule lifeSupportCapsule;
        private Calendar calendar;

        //Асоціація
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

        public string SerialNumber
        {
            get
            {
                return serialNumber;
            }
            set
            {
                this.serialNumber = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                this.model = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public bool PowerStatus
        {
            get
            {
                return powerStatus;
            }
            set
            {
                this.powerStatus = value;
                if (value)
                {
                    service.OutputData("SmartWatch is powered on.");
                }
                else
                {
                    service.OutputData("SmartWatch is powered off.");
                }
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string FirmwareVersion
        {
            get
            {
                return firmwareVersion;
            }
            set
            {
                this.firmwareVersion = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public DateTime LastDiagnosisTime
        {
            get
            {
                return lastDiagnosisTime;
            }
            set
            {
                this.lastDiagnosisTime = value;
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
        /// Конструктор без параметрів
        /// </summary>
        public SmartWatch()
        {
            id = 0;
            serialNumber = string.Empty;
            model = string.Empty;
            powerStatus = false;
            firmwareVersion = "1.0.0";
            lastDiagnosisTime = DateTime.Now;
        }
        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="ai"> модуль АІ </param>
        /// <param name="teleportationModule"> модуль телепорту </param>
        /// <param name="lifeSupportCapsule"> модуль капсули життя </param>
        /// <param name="calendar"> календар </param>
        /// <param name="service"> сервіс </param>
        public SmartWatch(Ai ai, TeleportationModule teleportationModule, LifeSupportCapsule lifeSupportCapsule, Calendar calendar, Service service)
        {
            powerSupply = new PowerSupply(service);
            sensors = new Sensors();
            securityControl = new SecurityControl();
            biointerface = new Biointerface();
            neurointerface = new Neurointerface();
            visualizationModule = new VisualizationModule();
            communicationModule = new CommunicationModel();
            moodAnalysis = new MoodAnalysis();
            message = new Message();
            this.teleportationModule = teleportationModule;
            this.ai = ai;
            this.lifeSupportCapsule = lifeSupportCapsule;
            this.calendar = calendar;
            this.Service = service;
            id = 0;
            serialNumber = string.Empty;
            model = string.Empty;
            powerStatus = false;
            firmwareVersion = "1.0.0";
            lastDiagnosisTime = DateTime.Now;
        }
        /// <summary>
        /// Метод для ввімкнення смарт-годинника
        /// </summary>
        public void SwitchOn()
        {
            service.OutputData("SmartWatch is starting up...");
            if (powerSupply.PowerLevelChecking())
            {
                powerStatus = true;
                service.OutputData("SmartWatch activated.");
            }
            else
            {
                service.OutputData("Low battery. Charge required.");
            }
        }
        /// <summary>
        /// Метод для вимкнення смарт-годинника
        /// </summary>
        public void SwitchOff()
        {
            service.OutputData("SmartWatch is shutting down...");
            PowerStatus = false;

        }
        /// <summary>
        /// Метод для діагностики смарт-годинника
        /// </summary>
        public void Diagnostics()
        {
            string report = $"Diagnostics Report:\n" + $"ID: {id}\n" + $"Serial Number: {serialNumber}\n" + $"Model: {model}\n" +
                $"Power Status: {(powerStatus ? "On" : "Off")}\n" + $"Firmware Version: {firmwareVersion}\n" + $"Last Diagnosis Time: {lastDiagnosisTime.ToString(CultureInfo.InvariantCulture)}\n";
            report += $"Power Level: {powerSupply.PowerLevel}\n" + $"Energy Source: {powerSupply.EnergySource}\n" + $"Power Supply Mode: {powerSupply.PowerSupplyMode}\n" +
                      $"Energy Consumption Rate: {powerSupply.EnergyConsumptionRate}\n";
            report += $"Teleportation Module Status: {teleportationModule.ChargeLevel}\n" + $"AI Status: {ai.DifficultyLevel}\n" +
                $"Security Control Status: {securityControl.SecurityMode}\n" + $"Life Support Capsule Status: {lifeSupportCapsule.ChargeLevel}\n" +
                $"Communication Module Status: {communicationModule.CommunicationType}\n" + $"Messages Count: {communicationModule.EncryptionLevel}\n";
            report += $"Biointerface Type: {biointerface.Type}\n" + $"Biointerface Accuracy Level: {biointerface.AccuracyLevel}\n" +
                $"Biointerface Activity: {biointerface.Activity}\n" + $"Biointerface Calibration Status: {biointerface.CalibrationStatus}\n";
            report += $"Sensors Temperature: {sensors.Temperature:F1}°C\n" + $"Sensors Heart Rate: {sensors.HeartRate:F0} bpm\n" +
                $"Sensors Cardiogram Data: {sensors.CardiogramData}\n" + $"Sensors Location Coordinates: [{string.Join(", ", sensors.LocationCoordinates)}]\n" +
                $"Sensors Glucose Level: {sensors.GlucoseLevel:F1} mmol/L\n" + $"Sensors Sensor Accuracy: {sensors.SensorAccuracy:F1}%\n";
            report += $"Neurointerface Type: {neurointerface.Calibration}\n" + $"Neurointerface Signal Strength: {neurointerface.SignalStrength:F2}\n" +
                $"Neurointerface Adaptibility: {neurointerface.Adaptibility:F2}\n" + $"Neurointerface Sensitivity: {neurointerface.Sensitivity:F2}\n" +
                $"Visualization Module Status: {visualizationModule.OutputType}\n" + $"Visualization Module Brightness: {visualizationModule.BrightnessLevel:F2}\n";
            report += $"Neurointerface Signal Quality: {neurointerface.SignalStrength}\n" + $"Neurointerface Adaptibility: {neurointerface.Adaptibility:F2}\n" +
                $"Neurointerface Sensitivity: {neurointerface.Sensitivity:F2}\n" + $"Neurointerface Calibration: {neurointerface.Calibration:F2}\n";
            service.OutputData(report);
        }
        /// <summary>
        /// Метод для оновлення прошивки смарт-годинника
        /// </summary>
        public void FirmwareUpdate()
        {
            string newVersion = GenerateNewVersion(firmwareVersion);
            if (newVersion != firmwareVersion)
            {
                firmwareVersion = newVersion;
                lastDiagnosisTime = DateTime.Now;
                service.OutputData($"Firmware updated to version {firmwareVersion}.");
            }
            else
            {
                service.OutputData("Firmware is already up to date.");
            }
        }
        /// <summary>
        /// Метод для генерації нової версії прошивки на основі поточної версії
        /// </summary>
        /// <param name="currentVersion"></param>
        /// <returns> нова версія прошивки </returns>
        public string GenerateNewVersion(string currentVersion)
        {
            string[] parts = currentVersion.Split('.');
            if (parts.Length != 3 || !int.TryParse(parts[1], out int minor))
            {
                return currentVersion;
            }
            minor++;
            return $"{parts[0]}.{minor}.{parts[2]}";
        }
        /// <summary>
        /// Метод для планування періодичної діагностики смарт-годинника
        /// </summary>
        public void PeriodicityPlanning()
        {
            if ((DateTime.Now - lastDiagnosisTime).TotalHours >= 24)
            {
                Diagnostics();
                service.OutputData("Diagnostics scheduled.");
            }
        }
    }
}