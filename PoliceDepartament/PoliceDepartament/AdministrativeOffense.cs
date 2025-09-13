using System;
using System.Collections.Generic;

namespace PoliceDepartament
{
    /// <summary>
    /// Клас AdministrativeOffense представляє адміністративне правопорушення, 
    /// яке містить інформацію про тип штрафу, суму штрафу та статус штрафу
    /// </summary>
    public class AdministrativeOffense
    {
        private int id; //унікальний ідентифікатор адміністративного правопорушення    
        private string fineType; //тип штрафу
        private double fineAmount; //сума штрафу
        private string fineStatus; //статус штрафу
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
        public string FineType
        {
            get
            {
                return fineType;
            }
            set
            {
                this.fineType = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public double FineAmount
        {
            get
            {
                return fineAmount;
            }
            set
            {
                this.fineAmount = value;
            }
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string FineStatus
        {
            get
            {
                return fineStatus;
            }
            set
            {
                this.fineStatus = value;
            }
        }
        /// <summary>
        /// Конструктор без параметрів
        /// </summary>
        public AdministrativeOffense()
        {
            id = 0;
            fineType = "";
            fineAmount = 0;
            fineStatus = "";
            Console.WriteLine("Empty constructor was called.");
        }
        /// <summary>
        /// Конструктор з параметрами
        /// </summary>
        /// <param name="id">ід</param>
        /// <param name="fineType">тип штрафу</param>
        /// <param name="fineAmount">кількість штрафу</param>
        public AdministrativeOffense(int id, string fineType, double fineAmount)
        {
            Id = id;
            FineType = fineType;
            FineAmount = fineAmount;
            FineStatus = "Pending";
            service = new Service();
            Console.WriteLine("Constructor with parameters was called.");
        }
        /// <summary>
        /// Статичний конструктор
        /// </summary>
        static AdministrativeOffense()
        {
            Console.WriteLine("Static constructor was called.");
        }
        /// <summary>
        /// Закритий конструктор
        /// </summary>
        /// <param name="privateAmount">кількість штрафу</param>
        private AdministrativeOffense(double privateAmount)
        {
            id = -1;
            fineType = "Private Fine";
            FineAmount = privateAmount;
            FineStatus = "Private";
            service = new Service();
            Console.WriteLine("Private constructor was called.");
        }
        /// <summary>
        /// Конструктор копії
        /// </summary>
        /// <param name="other">оригінал</param>
        public AdministrativeOffense(AdministrativeOffense other)
        {
            Id = other.Id;
            FineType = other.FineType;
            FineAmount = other.FineAmount;
            FineStatus = other.FineStatus;
            service = new Service();
            Console.WriteLine("Copy constructor was called.");
        }
        /// <summary>
        /// Конструктор, що викликає інші конструктори
        /// </summary>
        /// <param name="id"></param>
        public AdministrativeOffense(int id)
            : this(id, "Traffic", 100.0)
        {
            Console.WriteLine("Constructor that calls other constructors.");
        }
        /// <summary>
        /// Метод збереження даних про штрафи
        /// </summary>
        public void SaveFineData()
        {
            service.OutputData("Saved data on fines");
        }
        Service service = new Service();
    }
}
