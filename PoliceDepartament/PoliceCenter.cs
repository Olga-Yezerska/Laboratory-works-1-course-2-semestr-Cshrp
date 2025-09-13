using System;

namespace PoliceDepartament
{
    /// <summary>
    /// Клас PoliceCenter представляє поліцейський центр
    /// </summary>
    public class PoliceCenter
    {
        private int id; //унікальний ідентифікатор поліцейського центру
        private string name; // назва поліцейського центру
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
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
        /// <summary>
        /// Конструктор без параметрів
        /// </summary>
        public PoliceCenter()
        {
            id = 0;
            name = "";
        }
        /// <summary>
        /// Метод для реєстрації клієнта
        /// </summary>
        public void RegisterClient()
        {
            service.OutputData("Client was registered");
        }
        /// <summary>
        /// Метод для реєстрації поліцейського
        /// </summary>
        public void SubmitRequest()
        {
            service.OutputData("Request was sent to the appropriate service");
        }
        /// <summary>
        /// Метод для відображення доступних послуг
        /// </summary>
        public void DisplayAvailableServices()
        {
            service.OutputData("Available services were displayed");
        }
        Service service = new Service();
        public Request request;
        public CrimeService crimeService;
        public TrafficService trafficService;
        public TouristSafety touristSafety;
        public LostAndFoundService lostAndFoundService;
    }
}
