using System;
namespace PoliceDepartament
{
    /// <summary>
    /// Клас LostAndFoundService представляє службу "Знайдено та втрачено"
    /// </summary>
    public class LostAndFoundService
    {
        private int id; //унікальний ідентифікатор служби "Знайдено та втрачено"
        private Service service;
        public Request request;
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
        public LostAndFoundService()
        {
            id = 0;
            service = new Service();
            Console.WriteLine("Default constructor called.");
        }
        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">ід</param>
        public LostAndFoundService(int id)
        {
            Id = id;
            service = new Service();
            Console.WriteLine("Parameterized constructor called.");
        }
        /// <summary>
        /// Статичний конструктор
        /// </summary>
        static LostAndFoundService()
        {
            Console.WriteLine("Static constructor called.");
        }
        /// <summary>
        /// Закритий конструктор
        /// </summary>
        /// <param name="privateFlag">для виклику</param>
        private LostAndFoundService(bool privateFlag)
        {
            id = -1;
            service = new Service();
            Console.WriteLine("Private constructor called.");
        }
        /// <summary>
        /// Конструктор копії
        /// </summary>
        /// <param name="other">оригінал</param>
        public LostAndFoundService(LostAndFoundService other)
        {
            Id = other.Id;
            service = new Service();
            Console.WriteLine("Copy constructor called.");
        }
        /// <summary>
        /// Конструктор для виклику інших
        /// </summary>
        /// <param name="service">для виклику</param>
        public LostAndFoundService(Service service) : this(0)
        {
            Console.WriteLine("Constructor calling another constructor called.");
        }
        /// <summary>
        /// Метод для реєстрації знайденого предмета
        /// </summary>
        public void RegisterItem()
        {
            string item = service.InputStringData("Enter the descriprion of the found item:");
            service.OutputData($"Lost item has been registered: {item}");
        }
        /// <summary>
        /// Метод для реєстрації втрати предмета
        /// </summary>
        public void ProcessRequest()
        {
            service.OutputData("The request about the found item has been processed.");
        }

    }
}
