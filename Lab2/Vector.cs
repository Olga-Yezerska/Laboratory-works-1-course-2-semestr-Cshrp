using System;
namespace Lab2
{
    /// <summary>
    /// Клас Вектор
    /// </summary>
    internal class Vector
    {
        private int numberOfElements; //кількість елементів
        private int[] array; //масив початковий
        /// <summary>
        /// Конструктор класу Вектор
        /// </summary>
        /// <param name="numberOfElements"> кількість елементів у масиві </param>
        public Vector(int numberOfElements)
        {
            this.numberOfElements = numberOfElements; //ініціалізація кількості елементів
            array = new int[numberOfElements]; //створення масиву
        }
        /// <summary>
        /// Генерація масиву
        /// </summary>
        public void Generation()
        {
            Random random = new Random(); //генератор випадкових чисел
            for (int i = 0; i < numberOfElements; i++)
            {
                array[i] = random.Next(-20, 21);
            }
        }
        /// <summary>
        /// Сортування масиву алгоритмом вставлення
        /// </summary>
        public void InsertionSort()
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }
        /// <summary>
        /// Пошук додатніх простих чисел алгоритмом Ератосфена
        /// </summary>
        /// <returns> масив простих чисел </returns>
        public int[] PrimeNumbers()
        {
            int count = 0; //кількість простих чисел
            int max = 0; //максимальне число
            for (int i = 0; i < numberOfElements; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            bool[] isPrime = new bool[max + 1]; //булевий масив простих чисел
            if (max >= 2)
            {
                for (int i = 2; i <= max; i++)
                {
                    isPrime[i] = true;
                }
                for (int p = 2; p * p <= max; p++)
                {
                    if (isPrime[p])
                    {
                        for (int i = p * p; i <= max; i += p)
                        {
                            isPrime[i] = false;
                        }
                    }
                }               
                for (int i = 0; i < numberOfElements; i++)
                {
                    if (array[i] > 1 && isPrime[array[i]])
                    {
                        count++;
                    }
                }
            }
            int[] prime = new int[count]; //створення масиву простих чисел
            int index = 0;
            for (int i = 0; i < numberOfElements; i++)
            {
                if (array[i] > 1 && isPrime[array[i]])
                {
                    prime[index++] = array[i];
                }
            }
            return prime;
        }
        /// <summary>
        /// Лінійний пошук максимального від'ємного та мінімального додатного елемента
        /// </summary>
        /// <returns> кортеж з мінімального та максимального значення </returns>
        public (int, int) LinearSearch()
        {
            int maxElement = int.MinValue; 
            int minElement = int.MaxValue;
            for (int i = 0; i < numberOfElements; i++)
            {
                if (array[i] < 0 && array[i] > maxElement)
                {
                    maxElement = array[i];
                }
                if (array[i] > 0 && array[i] < minElement)
                {
                    minElement = array[i];
                }
            }
            return (minElement, maxElement);
        }
        /// <summary>
        /// Отримання масиву
        /// </summary>
        /// <returns> масиву </returns>
        public int[] GetVector()
        {
            return array;
        }
    }
}