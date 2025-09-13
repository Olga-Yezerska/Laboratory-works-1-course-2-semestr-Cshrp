using System;
namespace Lab2
{
    /// <summary>
    /// Клас Матриця
    /// </summary>
    internal class Matrix
    {
        private int row; //кількість рядків
        private int column; //кількість стовпців
        private int[,] matrixA; //матриця

        private int min; //мінімальне значення
        private int max; //максимальне значення
        //рядки - товари
        //стовпці - прибуток
        /// <summary>
        /// Конструктор класу матриця
        /// </summary>
        /// <param name="row"> рядки </param>
        /// <param name="column"> стовпці </param>
        /// <param name="min"> мінімальне значення </param>
        /// <param name="max"> максимальне значення </param>
        public Matrix(int row, int column, int min, int max)
        {
            this.row = row; //ініціалізація кількості рядків
            this.column = column; //ініціалізація кількості стовпців
            this.min = min; //ініціалізація мінімального значення
            this.max = max; //ініціалізація максимального значення
            matrixA = new int[row, column]; //ініціалізація матриці
        }
        /// <summary>
        /// Генерація матриці
        /// </summary>
        public void Generation()
        {           
            Random random = new Random(); //рандомайзер
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrixA[i, j] = random.Next(min, max + 1);
                }
            }
        }
        /// <summary>
        /// Обрахунок прибутку кожного товару
        /// </summary>
        /// <param name="totalProfit"> змінна для загального прибутку товарів </param>
        public void CalculateTotalProfit(out int[] totalProfit)
        {
            totalProfit = new int[row]; 
            for (int i = 0; i < row; i++)
            {
                int total = 0; 
                for (int j = 0; j < column; j++)
                {
                    total += matrixA[i, j];
                }
                totalProfit[i] = total;
            }
        }
        /// <summary>
        /// Обрахунок загального прибутку магазину
        /// </summary>
        /// <param name="totalProfit"> прибуток кожного товару </param>
        /// <returns> загальний прибуток магазину </returns>
        public int CalculateTotalStoreProfit(int[] totalProfit)
        {
            int totalStoreProfit = 0; 
            foreach (int profit in totalProfit)
            {
                totalStoreProfit += profit;
            }
            return totalStoreProfit;
        }
        /// <summary>
        /// Обрахунок індекса продукта з найбільшим прибутком
        /// </summary>
        /// <param name="totalProfit"> прибуток кожного товару </param>
        /// <returns> індекс продукта з найбільшим прибутком </returns>
        public int FindMaxProfitIndex(int[] totalProfit)
        {
            int maxProfit = int.MinValue; //максимальний прибуток
            int maxProfitIndex = -1; //індекс цього продукту
            for (int i = 0; i < totalProfit.Length; i++)
            {
                if (totalProfit[i] > maxProfit)
                {
                    maxProfit = totalProfit[i];
                    maxProfitIndex = i;
                }
            }
            return maxProfitIndex;
        }
        /// <summary>
        /// Отримання матриці
        /// </summary>
        /// <returns> матриця </returns>
        public int[,] GetMatrix()
        {
            return matrixA;
        }
    }
}