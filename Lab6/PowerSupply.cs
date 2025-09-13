using System;
using System.Threading;

namespace Lab6
{
    /// <summary>
    /// Клас для джерела живлення
    /// </summary>
    public class PowerSupply
    {
        private float powerLevel; // рівень потужності (від 0 до 100)
        private string energySource; // джерело енергії (сонячна, електрична, ядерна)
        private string powerSupplyMode; // режим живлення (Normal, Eco)
        private float energyConsumptionRate; // рівень споживання енергії (від 0 до 1)

        //Асоціація
        private Service service;

        /// <summary>
        /// Властивість
        /// </summary>
        public float PowerLevel
        {
            get
            {
                return powerLevel;
            }
            set
            {
                this.powerLevel = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string EnergySource
        {
            get
            {
                return energySource;
            }
            set
            {
                this.energySource = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string PowerSupplyMode
        {
            get
            {
                return powerSupplyMode;
            }
            set
            {
                this.powerSupplyMode = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public float EnergyConsumptionRate
        {
            get
            {
                return energyConsumptionRate;
            }
            set
            {
                this.energyConsumptionRate = value;
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
        /// Консттруктор з параметром
        /// </summary>
        /// <param name="service"> сервіс </param>
        public PowerSupply(Service service)
        {
            powerLevel = 100;
            energySource = "";
            powerSupplyMode = "";
            energyConsumptionRate = 0;
            this.service = service;
        }
        /// <summary>
        /// Конструктор без параметрів 
        /// </summary>
        public PowerSupply()
        {
            powerLevel = 100;
            energySource = "";
            powerSupplyMode = "";
            energyConsumptionRate = 0;
        }
        /// <summary>
        /// Метод для перевірки рівня потужності
        /// </summary>
        /// <returns> результат перевріки заряду </returns>
        public bool PowerLevelChecking()
        {
            if(powerLevel < 10)
            {
                service.OutputData("Power level is low. Please charge the power supply.");
                return false;
            }
            else
            {
                service.OutputData("Power level is sufficient.");
                return true;
            }
        }
        /// <summary>
        /// Метод для заряджання джерела живлення
        /// </summary>
        public void Charging()
        {
            while(powerLevel != 100)
            {
                Thread.Sleep(3 * 60 * 1000);
                powerLevel += 1;
            }
            service.OutputData("Power supply is fully charged.");
        }
        /// <summary>
        /// Метод для розряджання джерела живлення
        /// </summary>
        public void Discharge()
        {
            while (powerLevel != 0)
            {
                Thread.Sleep(3 * 60 * 1000);
                powerLevel -= 1;
            }
            service.OutputData("Power supply is fully discharged.");
        }
        /// <summary>
        /// Метод для перемикання режиму живлення
        /// </summary>
        public void SwitchMode()
        {
            if (powerSupplyMode == "Normal")
            {
                powerSupplyMode = "Eco";
                energyConsumptionRate = 0.05f; 
                service.OutputData("Switched to Eco mode. Energy consumption reduced.");
            }
            else
            {
                service.OutputData("Error: Unknown power mode.");
            }
        }
        /// <summary>
        /// Метод для оптимізації споживання енергії
        /// </summary>
        public void OptimisingEnergyConsumption()
        {
            if (powerSupplyMode != "Eco")
            {
                service.OutputData("Optimization available only in Eco mode.");
                return;
            }

            service.OutputData("Optimizing energy consumption...");
            energyConsumptionRate = Math.Max(0.03f, energyConsumptionRate * 0.9f); 
            service.OutputData($"Energy consumption optimized to {energyConsumptionRate:F3}/min.");
        }
        /// <summary>
        /// Метод для вимкнення модуля живлення
        /// </summary>
        public void SwitchOffModule()
        {
            if (powerSupplyMode == "Eco")
            {
                    powerSupplyMode = "Normal";
                    energyConsumptionRate = 0.1f; 
                    service.OutputData("Eco mode disabled. Switched to Normal mode.");
            }
            else
            {
                    service.OutputData("Already in Normal mode.");
            }
        }       
    }
}