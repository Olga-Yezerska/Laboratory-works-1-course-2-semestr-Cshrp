using System;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Клас для аналізу настрою людини
    /// </summary>
    public class MoodAnalysis
    {
        private float stressLevel; // рівень стресу (від 0 до 100)
        private string currentEmotion; // поточна емоція (спокійний, нейтральний, стресовий)
        private string[] moodHistory; // історія настрою (максимум 100 записів)
        private string moodTrend; // тренд настрою (погіршується, покращується, стабільний)
        private int historyCount; // лічильник записів в історії

        //Асоціації
        private Service service;
        private Biointerface biointerface;
        private Neurointerface neurointerface;
        private Ai ai;
        private VisualizationModule visualization;

        /// <summary>
        /// Властивість
        /// </summary>
        public float StressLevel
        {
            get
            {
                return stressLevel;
            }
            set
            {
                this.stressLevel = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string CurrentEmotion
        {
            get
            {
                return currentEmotion;
            }
            set
            {
                this.currentEmotion = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string[] MoodHistory
        {
            get
            {
                return moodHistory;
            }
            set
            {
                this.moodHistory = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string MoodTrend
        {
            get
            {
                return moodTrend;
            }
            set
            {
                this.moodTrend = value;
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
        /// Властивість
        /// </summary>
        public Neurointerface Neurointerface
        {
            get
            {
                return neurointerface;
            }
            set
            {
                this.neurointerface = value;
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
        public VisualizationModule Visualization
        {
            get
            {
                return visualization;
            }
            set
            {
                this.visualization = value;
            }
        }

        /// <summary>
        /// Конструктор без параметрів
        /// </summary>
        public MoodAnalysis()
        {
            stressLevel = 0.0f;
            currentEmotion = "";
            moodHistory = new string[100]; // Максимум 100 записів
            moodTrend = "";
            historyCount = 0;
        }
        /// <summary>
        /// Метод для визначення поточного настрою людини на основі біоінтерфейсу та нейроінтерфейсу
        /// </summary>
        /// <returns> поточну емоцію </returns>
        public string IdentifyCurrentEmotion()
        {
            string bioReport = biointerface.ReadParameters();
            string neuroReport = neurointerface.BrainSynchronization();
            float heartRate = 0f;
            float temperature = 0f;
            float signalStrength = neurointerface.SignalStrength;
            string[] bioLines = bioReport.Split('\n');
            for (int i = 0; i < bioLines.Length; i++)
            {
                if (bioLines[i].Contains("Heart Rate"))
                {
                    string[] parts = bioLines[i].Split(':');
                    if (parts.Length > 1)
                    {
                        string value = parts[1].Replace("bpm", "").Trim();
                        float.TryParse(value, out heartRate);
                    }
                }
                if (bioLines[i].Contains("Temperature"))
                {
                    string[] parts = bioLines[i].Split(':');
                    if (parts.Length > 1)
                    {
                        string value = parts[1].Replace("°C", "").Trim();
                        float.TryParse(value, out temperature);
                    }
                }
            }
            stressLevel = (heartRate > 100 || temperature > 37.0f) ? 80f : 20f;
            stressLevel = (signalStrength < 0.7f) ? stressLevel + 10f : stressLevel;
            if (stressLevel > 60f)
            {
                currentEmotion = "Stressed";
            }
            else if (stressLevel > 30f)
            {
                currentEmotion = "Neutral";
            }
            else
            {
                currentEmotion = "Calm";
            }
            if (historyCount < moodHistory.Length)
            {
                moodHistory[historyCount] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + currentEmotion;
                historyCount++;
            }
            service.OutputData("Emotion determined: " + currentEmotion + " (Stress: " + stressLevel + "%)");
            service.WriteData("mood_log.txt", "Emotion: " + currentEmotion + ", Stress: " + stressLevel + "%");
            return currentEmotion;
        }
        /// <summary>
        /// Метод для аналізу тренду настрою на основі історії
        /// </summary>
        /// <returns> тренд настрою </returns>
        public string MoodTrendAnalysis()
        {
            int stressCount = 0;
            int calmCount = 0;
            for (int i = 0; i < historyCount; i++)
            {
                if (moodHistory[i].Contains("Stressed"))
                {
                    stressCount++;
                }
                else if (moodHistory[i].Contains("Calm"))
                {
                    calmCount++;
                }
            }
            if (stressCount > calmCount && stressCount > historyCount / 2)
            {
                moodTrend = "Worsening";
            }
            else if (calmCount > stressCount && calmCount > historyCount / 2)
            {
                moodTrend = "Improving";
            }
            else
            {
                moodTrend = "Stable";
            }
            service.OutputData("Mood trend analyzed: " + moodTrend);
            service.WriteData("mood_log.txt", "Mood trend: " + moodTrend);
            return moodTrend;
        }
        /// <summary>
        /// Метод для генерації рекомендацій на основі поточного настрою та рівня стресу
        /// </summary>
        public void RecomendationGeneration()
        {
            string recommendation = ai.GetRecommendation("Mood: " + currentEmotion + ", Stress: " + stressLevel + "%");
            string output = "Recommendation: " + recommendation;
            visualization.DisplayData(output);
            service.OutputData(output);
            service.WriteData("mood_log.txt", output);
        }
        /// <summary>
        /// Метод для адаптації інтерфейсу користувача на основі поточного настрою людини
        /// </summary>
        public void InterfaceAdaptation()
        {
            service.OutputData("Adapting interface to mood: " + currentEmotion);
            string action = "";
            if (currentEmotion == "Stressed")
            {
                action = "Switching to calming color scheme.";
            }
            else if (currentEmotion == "Calm")
            {
                action = "Maintaining standard interface.";
            }
            else
            {
                action = "Adjusting to neutral mode.";
            }

            service.OutputData(action);
        }
        /// <summary>
        /// Метод для надсилання сповіщення про емоційний стан людини та рівень стресу
        /// </summary>
        public void EmotionalStateNotification()
        {
            string notification = "Emotional state: " + currentEmotion + ", Stress: " + stressLevel + "%";
            visualization.DisplayData(notification);
            service.OutputData("Notification sent: " + notification);
            service.WriteData("mood_log.txt", notification);
        }
    }
}