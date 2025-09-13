using System;
namespace Lab2
{
    internal class Program
    {
        /// <summary>
        /// Ідентифікація автора, варіанту, умови та лабораторної роботи
        /// </summary>
        static void Identification()
        {
            Console.WriteLine("Student Olha Yezerska, SE-12, lab 2, var 4");
            Console.WriteLine("Create a console application in C#. Add two custom classes to the created C# project: the Vector class and the Matrix class.");
            Console.WriteLine("Implement the methods specified in the task in the Vector and Matrix classes.");
            Console.WriteLine("In accordance with the SOLID principle of single responsibility for implementing data input and output methods, create a separate Service class.");
        }
        /// <summary>
        /// Основний метод
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Identification(); //ідентифікація автора та умови

            Service service = new Service(); //створення об'єкту класу Service
            //1. Клас Сервіс - вивести умови завдань
            service.Tasks(); //умови завдань 

            //2. Клас Сервіс - задати вимірність масива 
            int numberOfElements = service.InputArray(); //введення масиву
            Vector vector = new Vector(numberOfElements); //створення об'єкта класу Vector
            //1. Клас Вектор - згенерувати додатніми та від'ємними псевдовипадковими числами масив заданого розміру
            vector.Generation(); //генерація масиву
            //3. Клас Сервіс - вивести згенерований масив
            Console.Write("Generated array: ");
            service.DisplayArray(vector); //виведення масиву

            //2. Клас Вектор - відсортувати масив методом вставлення
            vector.InsertionSort(); //сортування масиву
            //3. Клас Сервіс - вивести масив
            Console.Write("Sorted array: ");
            service.DisplayArray(vector); //виведення відсортованого масиву

            //4. Клас Сервіс - вивести знайдені прості числа
            service.DisplayPrime(vector); //виведення простих чисел. Значення елементів, що друкуються, визначаються в методі
                                          //PrimeNumbers() через об'єкт Vector, що передається як параметр

            //5. Клас Сервіс - вивести знайдені мінімальний додатній та максимальний від'ємний елементи масиву
            service.DisplayMinAndMax(vector); //виведення мінімального та максимального значення. Значення елементів, що друкуються,
                                              //визначаються в методі LinearSearch() через об'єкт Vector, що передається як параметр

            //6. Клас Сервіс - задати вимірність матриці
            (int row, int column) = service.InputMatrix(); //введення розмірності матриці
            //7. Клас Сервіс - задати діапазон для генерації псевдовипадкових чисел матриці
            (int min, int max) = service.InputRangeMatrix(); //введення діапазону генерації
            Matrix matrix = new Matrix(row, column, min, max); //створення об'єкта класу Matrix
            //1. Клас Матриця - згенерувати матрицю псевдовипадковими числами заданого діапазону та  заднаної розмірності
            matrix.Generation(); //генерація матриці
            //8. Клас Сервіс - вивести згенеровану матрицю
            service.DisplayGeneratedMatrix(matrix); //виведення матриці

            //9. Клас Сервіс - вивести обрахований прибуток кожного товару
            service.DisplayTotalProfitProduct(matrix); //виведення прибутку кожного продукту. Значення, що друкуються, визначаються в
                                                       //методі CalculateTotalProfit() через об'єкт Matrix, що передається як параметр

            //10. Клас Сервіс - вивести обрахований загальний прибуток магазину
            service.DisplayTotalStoreProfit(matrix); //виведення загального прибутку. Значення, що друкується, визначається в
                                                     //методі CalculateTotalStoreProfit() через об'єкт Matrix, що передається як параметр

            //11. Клас Сервіс - вивести обрахований індекс товару з найбільшим прибутком
            service.DisplayHighestProfitIndex(matrix); //виведення індексу продукту з найбільшим прибутком. Значення, що друкується, визначається в
                                                       //методі FindMaxProfitIndex() через об'єкт Matrix, що передається як параметр
        }
    }
}