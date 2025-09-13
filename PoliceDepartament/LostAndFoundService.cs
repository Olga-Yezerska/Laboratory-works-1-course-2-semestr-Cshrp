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
