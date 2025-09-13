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
            Console.WriteLine("Default constructor called.");
        }
        /// <summary>
        /// КОнструктор з параметрами
        /// </summary>
        /// <param name="pathToFile">шлях до фалйу</param>
        public Service(string pathToFile)
        {
            filePath = pathToFile;
            Console.WriteLine("Parameterized constructor called.");
        }
        /// <summary>
        /// Статичний конструктор
        /// </summary>
        static Service()
        {
            Console.WriteLine("Static constructor called.");
        }
        /// <summary>
        /// Закритий конструктор
        /// </summary>
        /// <param name="privateFlag">для виклику</param>
        private Service(bool privateFlag)
        {
            filePath = "private.txt";
            Console.WriteLine("Private constructor called.");
        }
        /// <summary>
        /// Конструктор копії
        /// </summary>
        /// <param name="other">оригінал</param>
        public Service(Service other)
        {
            filePath = other.filePath;
            Console.WriteLine("Copy constructor called.");
        }

        /// <summary>
        /// Конструктор який викликає інші конструктори
        /// </summary>
        /// <param name="i">для виклику</param>
        public Service(int i) : this("")
        {
            Console.WriteLine("Constructor calling another constructor called.");
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
