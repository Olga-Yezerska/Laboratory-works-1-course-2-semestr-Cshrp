using System;

namespace PoliceDepartament
{
    /// <summary>
    /// Клас TrafficService представляє послуги, пов'язані з дорожнім рухом, 
    /// такі як скасування штрафів, надання інформації та реєстрація технічних характеристик
    /// </summary>
    public class TrafficService
    {
        private int id; //унікальний ідентифікатор послуги
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
        /// Конструктор без параметрів
        /// </summary>
        public TrafficService()
        {
            id = 0;
        }
        /// <summary>
        /// Метод для скасування штрафу за порушення правил дорожнього руху
        /// </summary>
        public void WriteOffTrafficFine()
        {
            service.OutputData("Traffic fine cancelled");
        }
        /// <summary>
        /// Метод для скасування штрафу за паркування
        /// </summary>
        public void WriteOffParkingTicket()
        {
            service.OutputData("The parking fine was written off");
        }
        /// <summary>
        /// Метод для надання інформації про технічні характеристики транспортних засобів
        /// </summary>
        public void ProvideInformation()
        {
            service.OutputData("Help provided");
        }
        /// <summary>
        /// Метод для надання статусу технічних характеристик транспортних засобів
        /// </summary>
        public void ProvideStatus()
        {
            service.OutputData("The status of technical specifications has been granted");
        }
        /// <summary>
        /// Метод для реєстрації технічних характеристик транспортних засобів
        /// </summary>
        public void Register()
        {
            service.OutputData("The technical specifications were registered");
        }
        /// <summary>
        /// Метод для обробки запиту на обслуговування
        /// </summary>
        public void ProcessRequest()
        {
            service.OutputData("Request was processed");
        }
        Service service = new Service();
    }
}
