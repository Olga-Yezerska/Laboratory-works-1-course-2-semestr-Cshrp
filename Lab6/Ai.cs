using System;
using System.Threading;
namespace Lab6
{
    /// <summary>
    /// Клас для штучного інтелекту
    /// </summary>
    public class Ai
    {
        private double memoryStorage; // обсяг пам'яті 
        private double difficultyLevel; // рівень складності
        private string studyParametrs; // параметри навчання
        private double studySpeed; // швидкість навчання

        //Асоціація
        private Service service;
        private Neurointerface neuroInterface;
        private MoodAnalysis moodAnalyzer;
        private Biointerface bioInterface;
        private CommunicationModel communication;
        private PowerSupply powerSupply;
        private Random random;
        private Message message; 
        private SecurityControl securityControl; 

        /// <summary>
        /// Властивість
        /// </summary>
        public double MemoryStorage
        {
            get
            {
                return memoryStorage;
            }
            set
            {
                this.memoryStorage = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public double DifficultyLevel
        {
            get
            {
                return difficultyLevel;
            }
            set
            {
                difficultyLevel = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string StudyParametrs
        {
            get
            {
                return studyParametrs;
            }
            set
            {
                this.studyParametrs = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public double StudySpeed
        {
            get
            {
                return studySpeed;
            }
            set
            {
                this.studySpeed = value;
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
        public Neurointerface NeuroInterface
        {
            get
            {
                return neuroInterface;
            }
            set
            {
                this.neuroInterface = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public Biointerface BioInterface
        {
            get
            {
                return bioInterface;
            }
            set
            {
                this.bioInterface = value;
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
        public MoodAnalysis MoodAnalyzer
        {
            get
            {
                return moodAnalyzer;
            }
            set
            {
                this.moodAnalyzer = value;
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
        public Message Message
        {
            get
            {
                return message;
            }
            set
            {
                this.message = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public SecurityControl SecurityControl
        {
            get
            {
                return securityControl;
            }
            set
            {
                this.securityControl = value;
            }
        }
        /// <summary>
        /// Конструктор без параметрів
        /// </summary>
        public Ai()
        {
            memoryStorage = 0.0;
            difficultyLevel = 0.0;
            studyParametrs = "";
            studySpeed = 0.0;
            random = new Random();
        }
        /// <summary>
        /// Метод для генерації прогнозів на основі даних нейроінтерфейсу, біоінтерфейсу та аналізу настрою
        /// </summary>
        /// <returns> прогноз </returns>
        public string GeneratePredictions()
        {
            string neuroData = neuroInterface.BrainSynchronization(); // синхронізація нейроінтерфейсу
            string bioData = bioInterface.ReadParameters(); //читання параметрів біоінтерфейсу
            string moodData = bioInterface.DataAnalysis();  //аналіз даних настрою
            service.OutputData("Interfaces: Neuro=" + neuroData + ", Bio=" + bioData + ", Mood=" + moodData);
            double predictionScore = random.NextDouble() * difficultyLevel * 100; //розрахунок прогнозу на основі складності та випадкового числа
            string prediction = "Predicted outcome: " + predictionScore.ToString("F2") + "% confidence";
            string encryptedPrediction = securityControl.EncryptData(prediction, 128);
            service.OutputData("Prediction: " + prediction);
            service.WriteData("ai_log.txt", "Prediction: " + prediction);
            return prediction;
        }
        /// <summary>
        /// Метод тренування штучного інтелекту на основі біоінтерфейсу
        /// </summary>
        public void Train()
        {
            string bioData = bioInterface.ReadParameters();
            service.OutputData("Training data: Bio = " + bioData);
            int epochs = random.Next(5, 20);
            double learningRate = random.NextDouble() * 0.1;
            studyParametrs = "epochs:" + epochs + ",rate:" + learningRate.ToString("F2");
            memoryStorage -= 1.0; 
            service.OutputData("Updated parameters: " + studyParametrs);
            UpdateModel();
            service.WriteData("ai_log.txt", "Trained: " + studyParametrs);
        }
        /// <summary>
        /// Метод для оновлення моделі штучного інтелекту
        /// </summary>
        public void UpdateModel()
        {
            difficultyLevel += 0.01;
            if (difficultyLevel > 1.0)
            {
                difficultyLevel = 1.0;
            }
            studySpeed += 10.0; 
            if (studySpeed > 1000.0)
            {
                studySpeed = 1000.0;
            }
            service.OutputData("Model updated: Complexity = " + difficultyLevel.ToString("F2") + ", Speed=" + studySpeed.ToString("F2"));
            service.WriteData("ai_log.txt", "Model updated: " + studyParametrs);
        }
        /// <summary>
        /// Метод для очищення пам'яті штучного інтелекту та скидання параметрів навчання
        /// </summary>
        public void MemoryCleaning()
        {
            memoryStorage = 50.0; 
            studyParametrs = "epochs:10,rate:0.01"; 
            service.OutputData("Memory cleared: Capacity=" + memoryStorage.ToString("F2") + " GB, Parameters=" + studyParametrs);
            service.WriteData("ai_log.txt", "Memory cleared");
        }
        /// <summary>
        /// Метод для отримання рекомендацій на основі контексту
        /// </summary>
        /// <param name="context"> контекст для рекомендацій</param>
        /// <returns> рекомендації </returns>
        public string GetRecommendation(string context)
        {
                string recommendation = "Recommendation for " + context;
                service.OutputData("Recommendation: " + recommendation);
                service.WriteData("ai_log.txt", "Recommendation: " + recommendation);
                return recommendation;          
        }
    }
}