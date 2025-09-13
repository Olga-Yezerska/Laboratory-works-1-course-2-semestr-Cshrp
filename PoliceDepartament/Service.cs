using System;
using System.IO;

namespace PoliceDepartament
{
    /// <summary>
    /// Клас Service представляє сервіс для взаємодії з даними
    /// </summary>
    public class Service
    {
        private string filePath; //шлях до файлу для зберігання даних
        /// <summary>
        /// Властивість
        /// </summary>
        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                this.filePath = value;
            }
        }
        /// <summary>
        /// Конструктор без параметрів
        /// </summary>
        public Service()
        {
            filePath = "";
        }
        public Service(string pathToFile)
        {
            filePath = pathToFile;
        }
        /// <summary>
        /// Метод виводить повідомлення на консоль
        /// </summary>
        /// <param name="message"></param>
        public void OutputData(string message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// Метод для введення даних з консолі
        /// </summary>
        /// <returns></returns>
        public string InputData()
        {
            return Console.ReadLine();
        }
        /// <summary>
        /// Метод для запису даних у файл
        /// </summary>
        /// <param name="data"></param>
        public void WriteData(string data)
        {
            StreamWriter writer = new StreamWriter(filePath);
            writer.WriteLine(data);
            writer.Close();
        }
        /// <summary>
        /// Метод для читання даних з файлу
        /// </summary>
        /// <returns></returns>
        public string ReadData()
        {
            StreamReader reader = new StreamReader(filePath);
            string result = reader.ReadToEnd();
            reader.Close();
            return result;
        }
        /// <summary>
        /// Метод для введення цілочисельних даних з консолі з повідомленням
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public int InputIntData(string message)
        {
            OutputData(message);
            return Convert.ToInt32(Console.ReadLine());
        }
        /// <summary>
        /// Метод для введення рядкових даних з консолі з повідомленням
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string InputStringData(string message)
        {
            OutputData(message);
            return Console.ReadLine();
        }
    }
}
