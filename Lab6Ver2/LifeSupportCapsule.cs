using System;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Клас для капсули підтримки життєдіяльності
    /// </summary>
    public class LifeSupportCapsule
    {
        private float chargeLevel; // рівень заряду (від 0 до 100)
        private string[][] availableSubstances; // масив доступних речовин (назва, кількість)
        private string[] injectionHistory; // історія ін'єкцій (назва речовини, доза)

        // Асоціація
        private Service service;
        private Sensors sensors;
        private Ai ai;
        private PowerSupply powerSupply;

        /// <summary>
        /// Властивість
        /// </summary>
        public float ChargeLevel
        {
            get
            {
                return chargeLevel;
            }
            set
            {
                this.chargeLevel = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string[][] AvailableSubstances
        {
            get
            {
                return availableSubstances;
            }
            set
            {
                this.availableSubstances = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string[] InjectionHistory
        {
            get
            {
                return injectionHistory;
            }
            set
            {
                this.injectionHistory = value;
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
        public LifeSupportCapsule()
        {
            chargeLevel = 100.0f;
            availableSubstances = new string[][]
            {
                new string[] { "Adrenaline", "10" },
                new string[] { "Insulin", "15" },
                new string[] { "Sedative", "8" }
            };
            injectionHistory = new string[0];
        }
        /// <summary>
        /// Метод для перевірки наявності речовини
        /// </summary>
        /// <param name="substance"> ін'єкція на перевірку </param>
        /// <param name="requiredAmount"> її об'єм </param>
        /// <returns> відповідь про наявність </returns>
        public string SubstancePresenceChecking(string substance, float requiredAmount)
        {
            int index = -1;
            for (int i = 0; i < availableSubstances.Length; i++)
            {
                if (availableSubstances[i][0] == substance)
                {
                    index = i;
                    break;
                }
            }
            float availableAmount;
            if (!float.TryParse(availableSubstances[index][1], out availableAmount) || availableAmount < requiredAmount)
            {
                service.OutputData("Substance " + substance + " insufficient (required: " + requiredAmount + " ml, available: " + availableSubstances[index][1] + " ml).");
                return "Unavailable";
            }

            service.OutputData("Substance " + substance + " available: " + availableAmount + " ml.");
            return "Available";
        }
        /// <summary>
        /// Метод для ін'єкції речовини
        /// </summary>
        /// <param name="substance"> ін'єкція </param>
        /// <param name="dose"> її доза </param>
        /// <returns> результат </returns>
        public string InjectSubstance(string substance, float dose)
        {
            string availability = SubstancePresenceChecking(substance, dose);
            if (availability != "Available")
            {
                return availability;
            }
            if (!powerSupply.PowerLevelChecking())
            {
                service.OutputData("Cannot inject: Low power.");
                return "Unavailable";
            }
            sensors.ReadingData();
            if (sensors.HeartRate > 120 && substance == "Adrenaline")
            {
                service.OutputData("Injection cancelled: High heart rate.");
                return "Unavailable";
            }
            string aiRecommendation = ai.GetRecommendation("Inject " + dose + " ml of " + substance + " with heart rate " + sensors.HeartRate + " bpm?");
            if (aiRecommendation.Contains("Not recommended"))
            {
                service.OutputData("AI advises against injection: " + aiRecommendation);
                return "Unavailable";
            }
            service.OutputData("Injecting " + dose + " ml of " + substance + "...");
            int index = -1;
            for (int i = 0; i < availableSubstances.Length; i++)
            {
                if (availableSubstances[i][0] == substance)
                {
                    index = i;
                    break;
                }
            }
            float currentAmount = float.Parse(availableSubstances[index][1]);
            availableSubstances[index][1] = (currentAmount - dose).ToString();
            return "Available";
        }
        /// <summary>
        /// Метод для поповнення запасів речовин
        /// </summary>
        /// <param name="newSupplies"> нова ін'єкція </param>
        public void ReplenishSupplies(string[][] newSupplies)
        {
            for (int i = 0; i < newSupplies.Length; i++)
            {
                string substance = newSupplies[i][0];
                float amount;
                if (!float.TryParse(newSupplies[i][1], out amount))
                {
                    service.OutputData("Invalid amount for " + substance + ".");
                    continue;
                }
                bool found = false;
                for (int j = 0; j < availableSubstances.Length; j++)
                {
                    if (availableSubstances[j][0] == substance)
                    {
                        float currentAmount = float.Parse(availableSubstances[j][1]);
                        availableSubstances[j][1] = (currentAmount + amount).ToString();
                        service.OutputData("Refilled " + substance + ": +" + amount + " ml, total " + availableSubstances[j][1] + " ml.");
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    string[][] newList = new string[availableSubstances.Length + 1][];
                    for (int k = 0; k < availableSubstances.Length; k++)
                    {
                        newList[k] = availableSubstances[k];
                    }
                    newList[availableSubstances.Length] = new string[] { substance, amount.ToString() };
                    availableSubstances = newList;
                    service.OutputData("Added new substance " + substance + ": " + amount + " ml.");
                }
            }
        }
        /// <summary>
        /// Метод для оновлення списку речовин
        /// </summary>
        /// <param name="updatedSupplies"> оновлений список </param>
        public void UpdateList(string[][] updatedSupplies)
        {
            int validCount = 0;
            for (int i = 0; i < updatedSupplies.Length; i++)
            {
                float amount;
                if (float.TryParse(updatedSupplies[i][1], out amount))
                {
                    validCount++;
                }
            }
            string[][] newList = new string[validCount][];
            int index = 0;
            for (int i = 0; i < updatedSupplies.Length; i++)
            {
                float amount;
                if (float.TryParse(updatedSupplies[i][1], out amount))
                {
                    newList[index] = updatedSupplies[i];
                    index++;
                }
            }
            availableSubstances = newList;
            service.OutputData("Substance list updated.");
            string logEntry = "Updated substance list: ";
            for (int i = 0; i < newList.Length; i++)
            {
                logEntry += newList[i][0] + ": " + newList[i][1] + " ml";
                if (i < newList.Length - 1) logEntry += ", ";
            }
            service.WriteData("capsule_log.txt", logEntry);
        }
    }
}