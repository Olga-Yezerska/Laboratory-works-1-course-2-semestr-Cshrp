using System;
namespace Lab2
{
    /// <summary>
    /// Клас Сервіс
    /// </summary>
    internal class Service
    {
        /// <summary>
        /// Введення даних масиву
        /// </summary>
        public int InputArray()
        {
            int numberOfElements = GetValidInput("Enter the number of elements in the array: ", 1, 20);                     
            return numberOfElements;
        }
        /// <summary>
        /// Введення розмірності матриці
        /// </summary>
        /// <returns> кортеж з рядків і стовпців </returns>
        public (int, int) InputMatrix()
        {
            int row = GetValidInput("Enter the number of rows in the matrix: ", 1, 20);
            int column = GetValidInput("Enter the number of columns in the matrix: ", 1, 20);
            return (row, column);
        }
        /// <summary>
        /// Введення діапазону генерації
        /// </summary>
        /// <returns> кортеж з мінімального та максимального значень </returns>
        public (int min, int max) InputRangeMatrix()
        {
            int min = GetValidInput("Enter the minimum value: ", 1, 100);
            int max = GetValidInput("Enter the maximum value: ", 1, 100);
            return (min, max);
        }
        /// <summary>
        /// Виведення масиву
        /// </summary>
        /// <param name="vector"> об'єкт класу Вектор </param>
        public void DisplayArray(Vector vector)
        {
            int[] array = vector.GetVector();
            foreach (int num in array)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Виведення простих чисел з масиву
        /// </summary>
        /// <param name="vector"> об'єкт класу Вектор </param>
        public void DisplayPrime(Vector vector)
        {
            int[] prime = vector.PrimeNumbers();
            if (prime.Length == 0)
            {
                Console.WriteLine("There are no prime numbers in the array.");
            }
            else
            {
                Console.Write("Prime elements: ");
                foreach (int num in prime)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Виведення максимального від'ємного та мінімального додатнього елементів
        /// </summary>
        /// <param name="vector"> об'єкт класу Вектор </param>
        public void DisplayMinAndMax(Vector vector)
        {
            (int minElement, int maxElement) = vector.LinearSearch();
            if (minElement == int.MaxValue)
            {
                Console.WriteLine("There are no positive elements in the array.");
            }
            else
            {
                Console.WriteLine($"Min element: {minElement}");
            }
            if (maxElement == int.MinValue)
            {
                Console.WriteLine("There are no negative elements in the array.");
            }
            else
            {
                Console.WriteLine($"Max element: {maxElement}");
            }
            
        }
        /// <summary>
        /// Виведення матриці
        /// </summary>
        /// <param name="matrix"> об'єкт класу Матриця </param>
        public void DisplayGeneratedMatrix(Matrix matrix)
        {
            Console.WriteLine("Generated Matrix: ");
            int[,] matrixA = matrix.GetMatrix();
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    Console.Write(matrixA[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Виведення прибутку кожного товару
        /// </summary>
        /// <param name="matrix"> об'єкт класу Матриця </param>
        public void DisplayTotalProfitProduct(Matrix matrix)
        {
            matrix.CalculateTotalProfit(out int[] totalProfit);
            Console.WriteLine("Total profit from each project: ");
            for (int i = 0; i < totalProfit.Length; i++)
            {
                Console.WriteLine($"Product {i + 1}: {totalProfit[i]}");
            }
        }
        /// <summary>
        /// Виведення загального прибутку магазину
        /// </summary>
        /// <param name="matrix"> об'єкт класув Матриця </param>
        public void DisplayTotalStoreProfit(Matrix matrix)
        {
            matrix.CalculateTotalProfit(out int[] totalProfit);
            int totalStoreProfit = matrix.CalculateTotalStoreProfit(totalProfit);
            Console.WriteLine($"Total profit of the store from all products: {totalStoreProfit}");
        }
        /// <summary>
        /// Вмведення індекса продукта з найбільшим прибутком
        /// </summary>
        /// <param name="matrix"> об'єкт класу Матриця </param>
        public void DisplayHighestProfitIndex(Matrix matrix)
        {
            matrix.CalculateTotalProfit(out int[] totalProfit);
            int maxProfitIndex = matrix.FindMaxProfitIndex(totalProfit);
            Console.WriteLine($"Product with the highest profit: Product {maxProfitIndex + 1}");
        }
        /// <summary>
        /// Виведення умов завдань
        /// </summary>
        public void Tasks()
        {
            Console.WriteLine("==========================================================================================");
            Console.WriteLine("1. Generate positive and negative values of elements of a one-dimensional array.");
            Console.WriteLine("2. Sort the generated array in ascending order of its element values using the innsertion algorithm.");
            Console.WriteLine("3. Determine prime numbers among the positive elements of the array, using the Eratosthenes algorithm.");
            Console.WriteLine("4. Find the largest among the negative and smallest among the positive elements, using the linear search algorithm.");
            Console.WriteLine("5. Generate matrix elements, specifying its dimension and range of values from the console.");
            Console.WriteLine("6. Determine the total profit from each product, the total profit of the store from the sale of all products for all months, the index of the product that brings the greatest profit.");
            Console.WriteLine("7. Output to the console the array generated in the Vector class, the array after sorting, the found prime numbers among the positive elements of the array, the largest among the negative and the smallest among the positive elements of the array and their indices.");
            Console.WriteLine("8. Output to the console the matrix generated in the Matrix class, the store's total profit from each product, the store's total profit from the sale of all products for all months, the index of the product that brings the greatest profit.");
            Console.WriteLine("==========================================================================================");
        }
        /// <summary>
        /// Перевірка валідності введення
        /// </summary>
        /// <param name="message"> повідомлення, яке виводиться користувачу </param>
        /// <param name="min"> мінімальне допустиме значення </param>
        /// <param name="max"> максимальне допустиме значення </param>
        /// <returns> введене коректне значення </returns>
        public int GetValidInput(string message, int min = int.MinValue, int max = int.MaxValue)
        {
            int input;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out input) || input < min || input > max)
            {
                Console.WriteLine("Invalid input! Try again.");
                Console.Write(message);
            }
            return input;
        }
    }
}