using System;

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
