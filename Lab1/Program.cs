using System;
using System.Text; //для використання кодування UTF-8
namespace Lab1
{
    class Program
    {
        static char piSymbol = '\u03C0'; //символ пі
        static double x; //змінна обрахунку полінома
        static double a; //змінна для виразу другого завдання
        static double b; //змінна для виразу другого завдання
        static double time; //змінна для визначення часу доби
        static double grade; //змінна для введення оцінок
        static int choice; //змінна для вибору опції
        static double totalGrade = 0; //змінна для обрахунку суми оцінок
        static double worstGrade = double.MaxValue; //змінна для обрахунку найгіршої оцінки
        static double bestGrade = double.MinValue; //змінна для обрахунку найкращої оцінки
        /// <summary>
        /// Метод ідентифікації автора роботи, варіанту та умови
        /// </summary>
        static void Identification()
        {
            Console.OutputEncoding = Encoding.UTF8; //встановлення кодування UTF-8
            Console.WriteLine("Student Olha Yezerska, SE-12, lab 1, var 4");
            Console.WriteLine("Create a console application in C#.Enter input data from the keyboard.Output results to the console.\r\nUse methods of the Console and Convert classes in the process of inputting and outputting data. Implement the listed functions.\r\nThe selection of functions is available using the menu, by selecting the switch selection operator to call the necessary functions.");
            Console.WriteLine();
        }
        /// <summary>
        /// Метод виведення особистих даних
        /// </summary>
        static void Info()
        {
            Console.WriteLine("Personal data: ");
            Console.WriteLine("Last name: Yezerska");
            Console.WriteLine("First name: Olha");
            Console.WriteLine("Age: 18");
            Console.WriteLine("Group: SE-12");
            Console.WriteLine("Course: 1");
            Console.WriteLine("E-mail: olha.yezerska@knu.ua");
        }
        /// <summary>
        /// Метод перевірки введення коректних даних, модифікований ШІ
        /// </summary>
        /// <param name="message"> Повідомлення, яке виводиться для користувача про прохання введення</param> <param name="min"> Мінімальне значення, яке користувач може ввести </param> <param name="max"> Максимальне значення, яке користувач може ввести </param>
        /// <returns> Повертає коректне введене значення </returns>
        static double GetValidInput(string message, double min = double.MinValue, double max = double.MaxValue)
        {
            double value;
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.WriteLine("Invalid input. Try again.");
                Console.Write(message);
            }
            return value;
        }
        /// <summary>
        /// Метод обчислення значення полінома
        /// </summary>
        /// <returns> Повертає результат обрахунку полінома </returns>
        static double Polynomial()
        {
            double p = 3.5 * Math.Pow(x, 4) + 3 * Math.Pow(x, 3) + 10 * Math.Pow(x, 2) + 8.3;
            return p;
        }
        /// <summary>
        /// Метод обчислення значення виразу, відповідно до другого завдання
        /// </summary>
        /// <returns> Повертає результат обрахунку вираза </returns>
        static double Expression()
        {
            double result = 1 + Math.Abs((a + b) / (a - b)) + Math.Sqrt((a - 1) / (b + 1));
            return result;
        }
        /// <summary>
        /// Метод обчислення значення функції
        /// </summary>
        /// <returns> Повертає обраховане значення функції </returns>
        static double Function()
        {
            if (x > 0 && x < Math.PI)
            {
                return Math.Sin(x);
            }
            else if (x >= Math.PI && x <= 2 * Math.PI)
            {
                return Math.Cos(x);
            }
            else 
            {
                return 1;
            }
        }
        /// <summary>
        /// Метод визначення часу доби
        /// </summary>
        /// <returns> Повертає відповідь про частину доби </returns>
        static string DayTime()
        {
            if (time >= 6 && time < 12)
            {
                return "It`s morning";
            }
            else if (time >= 12 && time < 18)
            {
                return "It`s afternoon";
            }
            else if (time >= 18 && time < 24)
            {
                return "It`s evening";
            }
            else 
            {
                return "It`s night";
            }
        }
        /// <summary>
        /// Метод обрахування оцінок
        /// </summary>
        static void Grades()
        {
            totalGrade += grade;
            if (grade < worstGrade)
            {
                worstGrade = grade;
            }
            if (grade > bestGrade)
            {
                bestGrade = grade;
            }
        }
        /// <summary>
        /// Метод введення оцінок і обрахування суми, найгіршої та найкращої оцінки
        /// </summary>
        static void InputAndCalculateGrades()
        {
            totalGrade = 0;
            worstGrade = double.MaxValue;
            bestGrade = double.MinValue;
            for (int i = 1; i <= 10; i++)
            {
                grade = GetValidInput($"Enter grade for subject {i}: ", 0, 100);
                Grades();
            }
        }
        /// <summary>
        /// Метод перевірки введених значень для обрахнку виразу
        /// </summary>
        static void CheckForExpression()
        {
            if (a == b || b == -1 || ((a - 1) / (b + 1)) < 0)
            {
                Console.WriteLine("The expression is not defined.");
            }
            else
            {
                Console.WriteLine("The result of the expression is " + Expression());
            }
        }
        /// <summary>
        /// Метод виведення меню
        /// </summary>
        static void MenuDisplay()
        {
            Console.WriteLine("============================================= MENU =============================================");
            Console.WriteLine("1. Display your personal data to the console.\r\nCalculate the value of the polynomial p = 3,5 * x^4 + 3 * x^3 + 10 * x^2 + 8,3.\r\nDisplay the result to the console.");
            Console.WriteLine("2. Plot the value of the expression (x = 1 + | (a + b) / (a - b) | + √(a - 1) / (b + 1))\r\nDisplay the result to the console.");
            Console.WriteLine("3. Calculate the value of the function at point x: ");
            Console.WriteLine("       (sin(x), 0 < x < " + piSymbol);
            Console.WriteLine("f(x) = {cos(x), " + piSymbol + " <= x <= 2" + piSymbol);
            Console.WriteLine("       (1     , x = 0");
            Console.WriteLine("4. Display the day on the screen (morning, afternoon,..) depends on the unit of time (1,2,.24).");
            Console.WriteLine("5. Set the student's grades in 10 subjects from the console.\r\nCalculate the total score, the worst and best grade.");
            Console.WriteLine("6. Exit");
            Console.WriteLine("================================================================================================");
        }
        /// <summary>
        /// Метод меню для вибору опції
        /// </summary>
        static void Menu()
        {
            MenuDisplay();
            do
            {
                choice = Convert.ToInt32(GetValidInput("Enter your choice: "));
                switch(choice)
                {
                    case 1:
                        Info();
                        x = GetValidInput("Enter the x: ");
                        Console.WriteLine("Polynomial value p = " + Polynomial());
                        break;
                    case 2:
                        a = GetValidInput("Enter the a: ");
                        b = GetValidInput("Enter the b: ");
                        CheckForExpression();
                        break;
                    case 3:
                        x = GetValidInput("Enter the x: ", 0, 2 * Math.PI);
                        Console.WriteLine("The value of the function is " + Function());
                        break;
                    case 4:
                        time = GetValidInput("Enter the time: ", 0, 24);
                        Console.WriteLine(DayTime());
                        break;
                    case 5:
                        InputAndCalculateGrades();
                        Console.WriteLine($"Total Grade: {totalGrade}");
                        Console.WriteLine($"Worst Grade: {worstGrade}");
                        Console.WriteLine($"Best Grade: {bestGrade}");
                        break;
                    case 6:
                        Console.WriteLine("The program is completed!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 6);
        }
        /// <summary>
        /// Основний метод
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Identification();
            Menu();
        }
    }
}