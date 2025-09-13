using System;

namespace PoliceDepartament
{
    /// <summary>
    /// Клас PoliceOfficer представляє поліцейського
    /// </summary>
    public class PoliceOfficer
    {
        private int id; //унікальний ідентифікатор поліцейського
        private string name; //ім'я поліцейського
        private string status; //статус поліцейського (активний, неактивний тощо)
        private Service service;
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
        /// Властивість
        /// </summary>
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                this.status = value;
            }
        }
        /// <summary>
        /// Конструктор без параметрів
        /// </summary>
        public PoliceOfficer()
        {
            id = 0;
            name = "";
            status = "";
            service = new Service();
        }
        /// <summary>
        /// Метод для призначення поліцейського на подію
        /// </summary>
        public void AssignToEvent()
        {
            service.OutputData($"Officer {Name} has been appointed to the event.");
        }
        /// <summary>
        /// Метод для збереження даних про поліцейського
        /// </summary>
        public void SaveData()
        {
            service.OutputData($"Information about the police officer has been saved: {Name}, status: {Status}");
        }

    }
}
