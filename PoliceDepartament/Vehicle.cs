using System;

namespace PoliceDepartament
{
    /// <summary>
    /// Клас Vehicle представляє транспортний засіб
    /// </summary>
    public class Vehicle
    {
        private int id; //унікальний ідентифікатор транспортного засобу
        private string model; //модель транспортного засобу
        private int ownerId; //унікальний ідентифікатор власника транспортного засобу
        private string status; //статус транспортного засобу
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
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                this.model = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public int OwnerId
        {
            get
            {
                return ownerId;
            }
            set
            {
                this.ownerId = value;
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
        public Vehicle()
        {
            id = 0;
            model = "";
            ownerId = 0;
            status = "";
        }
        /// <summary>
        /// Метода для збереження даних транспортного засобу
        /// </summary>
        public void SaveTSData()
        {
            service.OutputData("Vehicle data was saved");
        }
        Service service = new Service();
    }
}
