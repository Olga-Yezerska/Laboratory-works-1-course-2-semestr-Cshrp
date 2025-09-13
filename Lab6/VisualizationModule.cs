using System;

namespace Lab6
{
    /// <summary>
    /// Клас для модуля візуалізації, 
    /// який відповідає за відображення даних та налаштування параметрів візуалізації.
    /// </summary>
    public class VisualizationModule
    {
        private string outputType; //тип виводу даних (текст, графік, голограма)
        private float outputQuality; //якість виводу даних (від 0 до 100)
        private string adaptationMode; //режим адаптації (день, ніч, настрій) 
        private float brightnessLevel; //рівень яскравості (від 0 до 100)

        //Асоціації
        private Service service;
        private MoodAnalysis moodAnalysis;
        private Calendar calendar;
        private Message messages;
        private PowerSupply powerSupply;
        private Random random;

        /// <summary>
        /// Властивість
        /// </summary>
        public string OutputType
        {
            get
            {
                return outputType;
            }
            set
            {
                this.outputType = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public float OutputQuality
        {
            get
            {
                return outputQuality;
            }
            set
            {
                this.outputQuality = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string AdaptationMode
        {
            get
            {
                return adaptationMode;
            }
            set
            {
                this.adaptationMode = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public float BrightnessLevel
        {
            get
            {
                return brightnessLevel;
            }
            set
            {
                this.brightnessLevel = value;
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
        public MoodAnalysis MoodAnalysis
        {
            get
            {
                return moodAnalysis;
            }
            set
            {
                this.moodAnalysis = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public Calendar Calendar
        {
            get
            {
                return calendar;
            }
            set
            {
                this.calendar = value;
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
        /// Конструктор за замовчуванням
        /// </summary>
        public VisualizationModule()
        {
            outputType = "";
            outputQuality = 0.0f;
            adaptationMode = "";
            brightnessLevel = 0.0f;
            random = new Random();
        }
        /// <summary>
        /// Метод для налаштування яскравості виводу даних на основі рівня навколишнього освітлення
        /// </summary>
        public void AdjustBrightness()
        {
            float ambientLight = (float)(random.NextDouble() * 100); 
            service.OutputData("Ambient light level: " + ambientLight + "%");
            brightnessLevel = ambientLight > 50f ? 75f : 25f;
            service.OutputData("Brightness adjusted to: " + brightnessLevel + "%");
            service.WriteData("visualization_log.txt", "Brightness: " + brightnessLevel + "%");
        }
        /// <summary>
        /// Метод для відображення даних у візуалізації
        /// </summary>
        /// <param name="data"> дані на виведення </param>
        public void DisplayData(string data)
        {
            string displayMessage = "Displaying [" + outputType + "]: " + data;
            service.OutputData(displayMessage);
            service.WriteData("visualization_log.txt", displayMessage);
        }
        /// <summary>
        /// Метод для зміни типу виводу даних та якості візуалізації
        /// </summary>
        /// <param name="newType"> новий тип </param>
        public void ChangeType(string newType)
        {
            string[] validTypes = new string[] { "Text", "Graph", "Hologram" };
            bool isValid = false;
            for (int i = 0; i < validTypes.Length; i++)
            {
                if (validTypes[i] == newType)
                {
                    isValid = true;
                    break;
                }
            }
            if (!isValid)
            {
                service.OutputData("Invalid output type: " + newType);
                return;
            }
            outputType = newType;
            outputQuality = newType == "Hologram" ? 90f : 80f;
            service.OutputData("Output type changed to: " + outputType + ", Quality: " + outputQuality + "%");
            service.WriteData("visualization_log.txt", "Output type: " + outputType + ", Quality: " + outputQuality + "%");
        }
        /// <summary>
        /// метод для перемикання режиму адаптації візуалізації на основі часу доби та емоційного стану користувача
        /// </summary>
        public void SwitchAdaptationMode()
        {
            string timeOfDay = DateTime.Now.Hour < 6 || DateTime.Now.Hour > 18 ? "Night" : "Day";
            string emotion = moodAnalysis.IdentifyCurrentEmotion();
            if (emotion == "Stressed")
            {
                adaptationMode = "MoodBased";
                brightnessLevel = 30f;
            }
            else if (timeOfDay == "Night")
            {
                adaptationMode = "Night";
                brightnessLevel = 20f;
            }
            else
            {
                adaptationMode = "Day";
                brightnessLevel = 60f;
            }
            service.OutputData("Adaptation mode switched to: " + adaptationMode + ", Brightness: " + brightnessLevel + "%");
            service.WriteData("visualization_log.txt", "Adaptation mode: " + adaptationMode + ", Brightness: " + brightnessLevel + "%");
        }
    }
}