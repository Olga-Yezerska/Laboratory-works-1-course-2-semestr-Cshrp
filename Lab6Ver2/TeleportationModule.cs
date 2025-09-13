using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Клас для модуля телепортації
    /// </summary>
    public class TeleportationModule
    {
        private double chargeLevel; // рівень заряду (від 0 до 100%)
        private double maxDistance; // максимальна відстань телепортації (в км) 
        private double riskLevel; // рівень ризику (від 0 до 1)
        private string[] routeHistory; // історія маршрутів (масив рядків)
        private int historyCount; // лічильник записів в історії

        //Асоціації
        private Service service;
        private SecurityControl security;
        private Sensors sensors;
        private PowerSupply powerSupply;
        private Random random;
        private Message message;

        /// <summary>
        /// Властивість
        /// </summary>
        public double ChargeLevel
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
        public double MaxDistance
        {
            get
            {
                return maxDistance;
            }
            set
            {
                this.maxDistance = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public double RiskLevel
        {
            get
            {
                return riskLevel;
            }
            set
            {
                this.riskLevel = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string[] RouteHistory
        {
            get
            {
                return routeHistory;
            }
            set
            {
                this.routeHistory = value;
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
        public SecurityControl Security
        {
            get
            {
                return security;
            }
            set
            {
                this.security = value;
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
        /// Конструктор
        /// </summary>
        public TeleportationModule()
        {
            chargeLevel = 0.0;
            maxDistance = 0.0;
            riskLevel = 0.0;
            routeHistory = new string[10];
            historyCount = 0;
            random = new Random();
        }
        /// <summary>
        /// Метод для розрахунку маршруту телепортації
        /// </summary>
        /// <param name="startPoint"> початкова точка </param>
        /// <param name="endPoint"> кінцева точка </param>
        /// <returns> розрахунок маршруту </returns>
        public string RouteCalculation(string startPoint, string endPoint)
        {
            double distance = random.NextDouble() * maxDistance;
            if (distance > maxDistance)
            {
                service.OutputData("Route too long: " + distance + " km exceeds max distance " + maxDistance + " km.");
                return "Error: Exceeds max distance";
            }
            if (historyCount < routeHistory.Length)
            {
                string routeEntry = "From:" + startPoint + "|To:" + endPoint + "|" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                                   "|Distance:" + distance.ToString("F2") + "|Risk:" + riskLevel.ToString("F2");
                routeHistory[historyCount] = routeEntry;
                historyCount++;
                service.WriteData("teleportation_log.txt", "Route: " + routeEntry);
            }
            else
            {
                service.OutputData("Route history full. Cannot store new route.");
            }
            string route = "Route from " + startPoint + " to " + endPoint + ": " + distance.ToString("F2") + " km";
            service.OutputData("Calculated: " + route);
            return route;
        }
        /// <summary>
        /// Метод для перевірки безпеки маршруту телепортації
        /// </summary>
        /// <returns> відповідь про безпеку </returns>
        public bool SecurityChecking()
        {
            security.ThreatsAnalysis();
            int threatLevel = security.ThreatLevel;
            riskLevel = threatLevel / 100.0;
            service.OutputData("Security check: Threat level=" + threatLevel + ", Risk level=" + riskLevel.ToString("F2"));
            bool isSafe = riskLevel < 0.5;
            service.OutputData("Route safety: " + (isSafe ? "Safe" : "Unsafe")); //якщо ризик менше 0.5, то маршрут безпечний
            service.WriteData("teleportation_log.txt", "Safety check: Risk=" + riskLevel.ToString("F2") + ", Safe=" + isSafe);
            Thread.Sleep(2);
            return isSafe;
        }
        /// <summary>
        /// Метод для ініціалізації телепортації з перевіркою безпеки та рівня заряду
        /// </summary>
        /// <param name="startPoint"> початкова точка </param>
        /// <param name="endPoint"> кінцева точка </param>
        /// <param name="route"> маршрут телепортації </param>
        public void TeleportationInitialization(string startPoint, string endPoint, string route)
        {
            if (!SecurityChecking())
            {
                service.OutputData("Teleportation aborted: Route is unsafe.");
                return;
            }
            double requiredCharge = random.NextDouble() * 20.0 + 10.0; // 10–30%
            if (chargeLevel < requiredCharge)
            {
                service.OutputData("Teleportation aborted: Insufficient charge. Required: " + requiredCharge.ToString("F2") + "%, Available: " + chargeLevel.ToString("F2") + "%");
                return;
            }
            if (route.StartsWith("Error"))
            {
                service.OutputData("Teleportation aborted: " + route);
                return;
            }

            chargeLevel -= requiredCharge;
            service.OutputData("Teleportation from " + startPoint + " to " + endPoint + " completed. Charge remaining: " + chargeLevel.ToString("F2") + "%");
            service.WriteData("teleportation_log.txt", "Teleport: " + startPoint + " -> " + endPoint + ", Charge used: " + requiredCharge.ToString("F2") + "%");
        }
        /// <summary>
        /// Метод   для скасування телепортації
        /// </summary>
        public void CancelTeleportation()
        {
            if (historyCount > 0)
            {
                string lastRoute = routeHistory[historyCount - 1];
                routeHistory[historyCount - 1] = null;
                historyCount--;
                service.OutputData("Teleportation cancelled: " + lastRoute);
                service.WriteData("teleportation_log.txt", "Cancelled: " + lastRoute);
            }
            else
            {
                service.OutputData("No route to cancel.");
            }
        }
    }
}