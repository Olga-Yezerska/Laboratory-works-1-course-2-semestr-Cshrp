using System;
using System.IO;

namespace Lab6
{
    /// <summary>
    /// Клас для сервісу, який відповідає за введення та виведення даних,
    /// </summary>
    public class Service
    {
        private string pathToFile; // шлях до файлу, який використовується для зберігання даних
        /// <summary>
        /// Конструктор
        /// </summary>
        public Service()
        {
            pathToFile = "";
        }
        /// <summary>
        /// Властивість
        /// </summary>
        public string PathToFile
        {
            get
            {
                return pathToFile;
            }
            set
            {
                this.pathToFile = value;
            }
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
        /// Метод виведення
        /// </summary>
        /// <param name="data"></param>
        /// <param name="clearConsole"></param>
        public void OutputData(string data, bool clearConsole = false)
        {
            if (clearConsole)
            {
                Console.Clear(); // Clear previous console output if requested
            }

            Console.WriteLine(data); // Add a prefix for better readability
        }
        /// <summary>
        /// Метод для читання даних з файлу
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReadData(string path)
        {
            StreamReader reader = new StreamReader(path);
            string result = reader.ReadToEnd();
            reader.Close();
            return result;
        }
        /// <summary>
        /// Метод для запису даних у файл
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public void WriteData(string path, string data)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(data);
            writer.Close();
        }
    }
}