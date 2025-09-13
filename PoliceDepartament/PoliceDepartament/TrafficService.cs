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
            service = new Service();
            Console.WriteLine("Empty constructor was called.");
        }
        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">ід</param>
        public TrafficService(int id)
        {
            Id = id;
            service = new Service();
            Console.WriteLine("Constructor with parameters was called.");
        }
        /// <summary>
        /// Статичний конструктор
        /// </summary>
        static TrafficService()
        {
            Console.WriteLine("Static constructor was called.");
        }
        /// <summary>
        /// Закритий конструктор
        /// </summary>
        /// <param name="privateFlag">флаг</param>
        private TrafficService(bool privateFlag)
        {
            id = -1;
            service = new Service();
            Console.WriteLine("Private constructor was called.");
        }
        /// <summary>
        /// Конструктор для копіювання
        /// </summary>
        /// <param name="other">оригінал</param>
        public TrafficService(TrafficService other)
        {
            Id = other.Id;
            service = new Service();
            Console.WriteLine("Copy constructor was called.");
        }
        /// <summary>
        /// Конструктор, який викликає інші
        /// </summary>
        /// <param name="id">ід</param>
        /// <param name="service">сервіс для виклику цього конструктора</param>
        public TrafficService(int id, Service service) : this(id)
        {
            Console.WriteLine("Constructor that calls other constructors.");
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
        Service service;
    }
}
