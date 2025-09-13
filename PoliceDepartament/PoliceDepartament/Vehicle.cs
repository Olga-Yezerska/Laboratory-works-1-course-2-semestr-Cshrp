using System;
using System.Collections.Generic;

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
            service = new Service();
            Console.WriteLine("Empty constructor was called.");
        }
        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">ід</param>
        /// <param name="model">модель</param>
        /// <param name="ownerId">ід власника</param>
        public Vehicle(int id, string model, int ownerId)
        {
            Id = id;
            Model = model;
            OwnerId = ownerId;
            Status = "Registered";
            service = new Service();
            Console.WriteLine("Constructor with parameters was called.");
        }
        /// <summary>
        /// Статичний конструктор
        /// </summary>
        static Vehicle()
        {
            Console.WriteLine("Static constructor was called.");
        }
        /// <summary>
        /// Закритий конструктор
        /// </summary>
        /// <param name="privateModel">модель</param>
        private Vehicle(string privateModel)
        {
            id = -1;
            Model = privateModel;
            ownerId = 0;
            Status = "Private";
            service = new Service();
            Console.WriteLine("Private constructor was called.");
        }
        /// <summary>
        /// Конструктор для копіювання
        /// </summary>
        /// <param name="other">оригінал</param>
        public Vehicle(Vehicle other)
        {
            Id = other.Id;
            Model = other.Model;
            OwnerId = other.OwnerId;
            Status = other.Status;
            service = new Service();
            Console.WriteLine("Copy constructor was called.");
        }
        /// <summary>
        /// КОнструктор, який викликає інші
        /// </summary>
        /// <param name="id">ід</param>
        public Vehicle(int id)
            : this(id, "Default Model", 0)
        {
            Console.WriteLine("Constructor that calls other constructors.");
        }
        /// <summary>
        /// Метода для збереження даних транспортного засобу
        /// </summary>
        public void SaveTSData()
        {
            service.OutputData("Vehicle data was saved");
        }
        Service service;
    }
}
