using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Service service = new Service(); //об'єкт сервісу для виводу даних
            service.OutputData("SmartWatch Simulation Started: ");

            //Інціалізація об'єктів для модулів SmartWatch

            Sensors sensors = new Sensors(); //об'єкт сенсорів
            sensors.Service = service;

            PowerSupply powerSupply = new PowerSupply(); //об'єкт джерела живлення
            powerSupply.PowerSupplyMode = "Normal";
            powerSupply.Service = service;

            Biointerface biointerface = new Biointerface(); // об'єкт біоінтерфейсу
            biointerface.Sensors = sensors;
            biointerface.Service = service;
            biointerface.Type = "Neural";
            biointerface.AccuracyLevel = 90.0f;
            biointerface.Activity = false;
            biointerface.CalibrationStatus = "Not calibrated";

            SecurityControl securityControl = new SecurityControl(); // об'єкт контролю безпеки
            securityControl.ThreatLevel = 0;
            securityControl.ThreatAssessment = "Low";
            securityControl.SecurityMode = false;
            securityControl.CurrentLocation = "SafeZone";
            securityControl.ThreatsHistory = new string[10];
            securityControl.Service = service;
            securityControl.Sensors = sensors;
            securityControl.PowerSupply = powerSupply;

            CommunicationModel communication = new CommunicationModel(); // об'єкт комунікаційної моделі
            communication.Service = service;
            communication.CommunicationType = "WiFi";
            communication.Bandwidth = 100.0f;
            communication.ConnectionStatus = true;
            communication.EncryptionLevel = 128;

            Neurointerface neurointerface = new Neurointerface(); // об'єкт нейроінтерфейсу
            neurointerface.Calibration = 0.8f;
            neurointerface.Sensitivity = 0.5f;
            neurointerface.Adaptibility = 0.5f;
            neurointerface.SignalStrength = 0.7f;
            neurointerface.Service = service;
            neurointerface.Sensors = sensors;
            neurointerface.PowerSupply = powerSupply;
            neurointerface.Biointerface = biointerface;

            VisualizationModule visualization = new VisualizationModule(); // об'єкт модуля візуалізації
            visualization.Service = service;
            visualization.PowerSupply = powerSupply;

            MoodAnalysis moodAnalysis = new MoodAnalysis(); // об'єкт аналізу настрою
            moodAnalysis.MoodHistory = new string[100];
            moodAnalysis.Service = service;
            moodAnalysis.Biointerface = biointerface;
            moodAnalysis.Neurointerface = neurointerface;
            moodAnalysis.Visualization = visualization;
            visualization.MoodAnalysis = moodAnalysis;

            Message message = new Message(); // об'єкт повідомлення
            message.MessageType = "Notification";
            message.Sender = "System";
            message.MessageTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            message.EmotionalTone = "Neutral";
            message.MessagePriority = 1;
            message.State = "Draft";
            message.MessageHistory = new string[100];
            message.Service = service;
            message.Communication = communication;
            message.PowerSupply = powerSupply;
            message.Visualization = visualization;
            message.MoodAnalysis = moodAnalysis;

            Ai ai = new Ai(); // об'єкт штучного інтелекту
            ai.MemoryStorage = 50.0;
            ai.DifficultyLevel = 0.5;
            ai.StudyParametrs = "epochs:10,rate:0.01";
            ai.StudySpeed = 500.0;
            ai.Service = service;
            ai.NeuroInterface = neurointerface;
            ai.BioInterface = biointerface;
            ai.PowerSupply = powerSupply;
            ai.MoodAnalyzer = moodAnalysis;
            ai.Message = message;
            ai.SecurityControl = securityControl;
            ai.Communication = communication;
            securityControl.Ai = ai;
            securityControl.Communication = communication;
            communication.Ai = ai;
            moodAnalysis.Ai = ai;

            TeleportationModule teleportation = new TeleportationModule(); // об'єкт модуля телепортації
            teleportation.ChargeLevel = 100.0;
            teleportation.MaxDistance = 10.0;
            teleportation.RiskLevel = 0.0;
            teleportation.RouteHistory = new string[100];
            teleportation.Service = service;
            teleportation.Sensors = sensors;
            teleportation.PowerSupply = powerSupply;
            teleportation.Security = securityControl;
            teleportation.Message = message;
            securityControl.Teleportation = teleportation;

            Calendar calendar = new Calendar(); // об'єкт календаря
            calendar.Events = new string[100];
            calendar.EventCount = 0;
            calendar.EventName = "";
            calendar.EventDateTime = DateTime.Now;
            calendar.EventPlace = "";
            calendar.EventPriority = 0;
            calendar.SynchronisationStatus = false;
            calendar.Service = service;
            calendar.Visualization = visualization;
            calendar.Ai = ai;
            calendar.Message = message;
            calendar.CommunicationModel = communication;
            visualization.Calendar = calendar;

            LifeSupportCapsule capsule = new LifeSupportCapsule(); // об'єкт капсули підтримки життєдіяльності
            capsule.ChargeLevel = 100.0f;
            capsule.Service = service;
            capsule.Ai = ai;
            capsule.Sensors = sensors;
            capsule.PowerSupply = powerSupply;

            SmartWatch smartWatch = new SmartWatch(ai, teleportation, capsule, calendar, service); // об'єкт смарт-годинника
            smartWatch.Id = 1;
            smartWatch.SerialNumber = "SW-2025-001";
            smartWatch.Model = "SmartWatch Pro";
            smartWatch.FirmwareVersion = "1.0.0";
            smartWatch.Service = new Service();

            //Сценарій 1: Запуск SmartWatch
            service.OutputData("\n=== Scenario 1: SmartWatch Startup ===");
            smartWatch.SwitchOn();
            Thread.Sleep(1000);
            smartWatch.Diagnostics();
            Thread.Sleep(500);
            smartWatch.PeriodicityPlanning();
            Thread.Sleep(500);

            //Сценарій 2: Biointerface і Neurointerface
            service.OutputData("\n=== Scenario 2: Bio and Neuro Interfaces ===");
            string report = biointerface.ReadParameters();
            service.OutputData(report);
            Thread.Sleep(1000);
            string newReport = neurointerface.BrainSynchronization();
            service.OutputData(newReport);
            Thread.Sleep(500);
            biointerface.DataAnalysis();
            Thread.Sleep(500);
            neurointerface.CommandExecution();

            // Сценарій 3: Mood Analysis
            service.OutputData("\n=== Scenario 3: Mood Analysis ===");
            moodAnalysis.IdentifyCurrentEmotion();
            Thread.Sleep(500);
            moodAnalysis.MoodTrendAnalysis();
            Thread.Sleep(500);
            moodAnalysis.RecomendationGeneration();
            Thread.Sleep(500);
            moodAnalysis.InterfaceAdaptation();
            Thread.Sleep(500);
            moodAnalysis.EmotionalStateNotification();
            Thread.Sleep(500);

            // Сценарій 4: AI
            service.OutputData("\n=== Scenario 4: AI Operations ===");
            ai.GeneratePredictions();
            Thread.Sleep(1000);
            ai.Train();
            Thread.Sleep(500);
            service.OutputData("Enter the context for recomendation: ");
            string context = service.InputData();
            ai.GetRecommendation(context);
            Thread.Sleep(500);
            ai.MemoryCleaning();
            Thread.Sleep(500);
            Thread.Sleep(500);

            // Сценарій 5: Security Control
            service.OutputData("\n=== Scenario 5: Security Control ===");
            securityControl.ThreatsAnalysis();
            Thread.Sleep(1000);
            securityControl.DangerAlert();
            Thread.Sleep(500);
            securityControl.SecurityActivation();
            Thread.Sleep(500);
            securityControl.ModeUpdate();
            Thread.Sleep(500);

            // Сценарій 6: Communication and Message
            service.OutputData("\n=== Scenario 6: Communication and Message ===");
            communication.ConnectionChecking();
            Thread.Sleep(500);
            communication.SetConnection();
            Thread.Sleep(500);
            service.OutputData("Enter message content: ");
            string content = service.InputData();
            service.OutputData("Enter message type (Text/Alert/Notification): ");
            string type = service.InputData();
            service.OutputData("Enter sender name: ");
            string sender = service.InputData();
            service.OutputData("Enter message priority (1-5): ");
            int priority = int.Parse(service.InputData());
            message.CreateMessage(content, type, sender, priority);
            Thread.Sleep(500);
            message.SendMessage("Test message");
            Thread.Sleep(500);
            message.GetMessage();

            // Сценарій 7: Calendar
            service.OutputData("\n=== Scenario 7: Calendar Event ===");
            service.OutputData("Enter event name: ");
            string name = service.InputData();
            service.OutputData("Enter event place: ");
            string place = service.InputData();
            service.OutputData("Enter event priority (1-5): ");
            int priorityInput = int.Parse(service.InputData());
            DateTime eventDate = new DateTime(2025, 6, 3);
            calendar.CreateEvent(name, eventDate, place, priority);
            Thread.Sleep(1000);
            calendar.EventReminding();
            Thread.Sleep(500);
            calendar.Synchronise();
            Thread.Sleep(500);
            service.OutputData("Enter event name to delete: ");
            string eventName = service.InputData();
            calendar.DeleteEvent(eventName);

            // Сценарій 8: Life Support Capsule
            service.OutputData("\n=== Scenario 8: Life Support Capsule ===");
            service.OutputData("Enter the substance: ");
            string substance = service.InputData();
            service.OutputData("Enter the dose: ");
            float dose = float.Parse(service.InputData());
            capsule.InjectSubstance(substance, dose);
            Thread.Sleep(1000);
            service.OutputData("Injection history: " + string.Join(", ", capsule.InjectionHistory));
            Thread.Sleep(500);
            service.OutputData("Enter new substance: ");
            string newSubstance = service.InputData();
            string[][] newSupplies = new string[][] { new string[] { newSubstance, "10" } };
            capsule.ReplenishSupplies(newSupplies);

            // Сценарій 9: Teleportation Module
            service.OutputData("\n=== Scenario 9: Teleportation Module ===");
            teleportation.SecurityChecking();
            Thread.Sleep(500);
            service.OutputData("Enter start point for teleportation: ");
            string startPoint = service.InputData();
            service.OutputData("Enter end point for teleportation: ");
            string endPoint = service.InputData();
            string route = teleportation.RouteCalculation(startPoint, endPoint);
            Thread.Sleep(1000);
            teleportation.TeleportationInitialization(startPoint, endPoint, route);
            Thread.Sleep(1000);
            teleportation.CancelTeleportation();
            Thread.Sleep(500);

            // Сценарій 10: Visualization Module
            service.OutputData("\n=== Scenario 10: Visualization Module ===");
            visualization.ChangeType("Hologram");
            Thread.Sleep(500);
            visualization.AdjustBrightness();
            Thread.Sleep(500);
            visualization.SwitchAdaptationMode();

            // Сценарій 11: Sensors
            service.OutputData("\n=== Scenario 11: Sensors ===");
            sensors.ReadingData();
            Thread.Sleep(500);
            sensors.SensorsCalibration();
            Thread.Sleep(500);
            sensors.DataFormating();

            // Сценарій 12: Power Supply
            service.OutputData("\n=== Scenario 12: Power Supply ===");
            powerSupply.PowerLevelChecking();
            Thread.Sleep(500);
            powerSupply.SwitchMode();
            Thread.Sleep(500);
            powerSupply.OptimisingEnergyConsumption();
            Thread.Sleep(500);
            powerSupply.SwitchOffModule();

            // Сценарій 13: SmartWatch Reset
            service.OutputData("\n=== Scenario 13: SmartWatch Reset ===");
            smartWatch.FirmwareUpdate();
            smartWatch.SwitchOff();
            Thread.Sleep(500);

            //Друга версія

            //Створення трьох екземплярів SmartWatch із різними моделями

            //Про версія SmartWatch
            ISmartWatch smartWatchPro = new SmartWatch(ai, teleportation, capsule, calendar, service);
            smartWatchPro.Id = 1;
            smartWatchPro.SerialNumber = "SW-2025-001";
            smartWatchPro.Model = "SmartWatch Pro";

            //Фітнес-годинник SmartWatch
            ISmartWatch fitnessWatch = new SmartWatch(ai, teleportation, capsule, calendar, service);
            fitnessWatch.Id = 2;
            fitnessWatch.SerialNumber = "FW-2025-002";
            fitnessWatch.Model = "Fitness Model";

            //Базовий SmartWatch
            ISmartWatch basicWatch = new SmartWatch(ai, teleportation, capsule, calendar, service);
            basicWatch.Id = 3;
            basicWatch.SerialNumber = "BW-2025-003";
            basicWatch.Model = "Basic Model";

            // Сценарій 1: Запуск різних моделей SmartWatch
            service.OutputData("\n=== Scenario 1: Startup of Different Watch Models ===");
            smartWatchPro.SwitchOn();
            Thread.Sleep(1000);
            fitnessWatch.SwitchOn();
            Thread.Sleep(1000);
            basicWatch.SwitchOn();
            Thread.Sleep(500);

            // Сценарій 2: Діагностика різних моделей
            service.OutputData("\n=== Scenario 2: Diagnostics of Different Watch Models ===");
            smartWatchPro.Diagnostics();
            Thread.Sleep(500);
            fitnessWatch.Diagnostics();
            Thread.Sleep(500);
            basicWatch.Diagnostics();
            Thread.Sleep(500);

            // Сценарій 3: Оновлення прошивки
            service.OutputData("\n=== Scenario 3: Firmware Update of Different Watch Models ===");
            smartWatchPro.FirmwareUpdate();
            Thread.Sleep(500);
            fitnessWatch.FirmwareUpdate();
            Thread.Sleep(500);
            basicWatch.FirmwareUpdate();
            Thread.Sleep(500);

            // Сценарій 4: Планування періодичної діагностики
            service.OutputData("\n=== Scenario 4: Periodicity Planning of Different Watch Models ===");
            smartWatchPro.PeriodicityPlanning();
            Thread.Sleep(500);
            fitnessWatch.PeriodicityPlanning();
            Thread.Sleep(500);
            basicWatch.PeriodicityPlanning();
            Thread.Sleep(500);

            // Сценарій 5: Вимкнення різних моделей
            service.OutputData("\n=== Scenario 5: Shutdown of Different Watch Models ===");
            smartWatchPro.SwitchOff();
            Thread.Sleep(500);
            fitnessWatch.SwitchOff();
            Thread.Sleep(500);
            basicWatch.SwitchOff();
            Thread.Sleep(500);

            service.OutputData("\nSmartWatch Simulation Completed.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}