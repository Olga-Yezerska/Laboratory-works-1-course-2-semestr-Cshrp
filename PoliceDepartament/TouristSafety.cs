using System;

namespace PoliceDepartament
{
    /// <summary>
    /// Клас TouristSafety представляє собою систему безпеки для туристів,
    /// </summary>
    public class TouristSafety
    {
        private int id; //унікальний ідентифікатор системи безпеки для туристів
        private Service service;
        public Complaint complaint;
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
        public TouristSafety()
        {
            id = 0;
            service = new Service();
        }
        /// <summary>
        /// Метод для надання інформації про безпеку та правила
        /// </summary>
        public void ProvideInformation()
        {
            service.OutputData("Information about local safety and regulations has been provided.");
        }
        /// <summary>
        /// Метод для надання консультацій туристам
        /// </summary>
        public void ProvideAdvice()
        {
            service.OutputData("Consultation has been provided to the tourist.");
        }
        /// <summary>
        /// Метод для реєстрації скарги туриста
        /// </summary>
        public void RegisterComplaint()
        {
            service.OutputData("Complaint has been registered in the system.");
        }
        /// <summary>
        /// Метод для аналізу зони безпеки та рекомендацій поліції
        /// </summary>
        public void AnalyzeZone()
        {
            service.OutputData("Analyzed the zone. Police officer recommended");
        }
        /// <summary>
        /// Метод для призначення поліцейського для забезпечення безпеки туристів
        /// </summary>
        public void AppointSecurity()
        {
            service.OutputData("Police officer has been assigned to the incident.");
        }
        /// <summary>
        /// Метод для обробки запиту на обслуговування туристів
        /// </summary>
        public void ProcessRequest()
        {
            service.OutputData("Request has been registered in the system");
        }
    }
}
