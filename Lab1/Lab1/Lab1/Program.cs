
using System;
using System.Globalization;

// Главное меню программы
while (true)
{
    Console.WriteLine("\n========== ЛАБОРАТОРНАЯ РАБОТА №1 ==========");
    Console.WriteLine("Вариант 4");
    Console.WriteLine("1. Вычисление факториала");
    Console.WriteLine("2. Последовательность Фибоначчи");
    Console.WriteLine("3. Вычисление математической функции");
    Console.WriteLine("4. Сумма ряда Тейлора");
    Console.WriteLine("0. Выход");
    Console.Write("Выберите задание: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            {
                Console.Write("Введите целое число от 0 до 20: ");

                if (int.TryParse(Console.ReadLine(), out int n) &&
                    n >= 0 && n <= 20)
                {
                    long result = Factorial(n);
                    Console.WriteLine($"{n}! = {result}");
                }
                else
                {
                    Console.WriteLine("Ошибка! Нужно ввести целое число от 0 до 20.");
                }

                break;
            }

        case "2":
            {
                Console.Write("Введите номер последнего элемента (от 0 до 92): ");

                if (int.TryParse(Console.ReadLine(), out int n) &&
                    n >= 0 && n <= 92)
                {
                    Console.WriteLine("Последовательность Фибоначчи:");
                    Console.WriteLine(FibonacciSequence(n));
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите целое число от 0 до 92.");
                }

                break;
            }

        case "3":
            {
                Console.Write("Введите x (x >= 54): ");

                if (TryReadDouble(Console.ReadLine(), out double x))
                {
                    if (TryCalculateFunction(x, out double result, out string error))
                    {
                        Console.WriteLine($"Результат A = {result:F10}");
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка: {error}");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите корректное число.");
                }

                break;
            }

        case "4":
            {
                Console.Write("Введите x (-1 < x <= 1): ");

                if (TryReadDouble(Console.ReadLine(), out double x))
                {
                    if (x > -1 && x <= 1)
                    {
                        const double epsilon = 0.000001;

                        var result = CalculateTaylor(x, epsilon);
                        double libraryResult = Math.Log(1 + x);

                        Console.WriteLine("\nРезультаты вычисления:");
                        Console.WriteLine($"Сумма ряда Тейлора: {result.Sum:F10}");
                        Console.WriteLine($"Math.Log(1 + x):   {libraryResult:F10}");
                        Console.WriteLine($"Количество членов: {result.Terms}");
                        Console.WriteLine($"Точность epsilon:  {epsilon}");
                        Console.WriteLine($"Разница:           {Math.Abs(result.Sum - libraryResult):F10}");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! x должен находиться в диапазоне (-1; 1].");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите корректное число.");
                }

                break;
            }

        case "0":
            Console.WriteLine("Программа завершена.");
            return;

        default:
            Console.WriteLine("Такого пункта меню нет. Выберите от 0 до 4.");
            break;
    }
}

// Чтение вещественного числа с поддержкой точки и запятой
static bool TryReadDouble(string? input, out double value)
{
    return double.TryParse(
               input,
               NumberStyles.Float,
               CultureInfo.InvariantCulture,
               out value)
           ||
           double.TryParse(
               input,
               NumberStyles.Float,
               CultureInfo.CurrentCulture,
               out value);
}

// Задание 1. Вычисление факториала
static long Factorial(int n)
{
    long result = 1;

    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }

    return result;
}

// Задание 2. Формирование последовательности Фибоначчи
static string FibonacciSequence(int n)
{
    long first = 0;
    long second = 1;

    string sequence = "";

    for (int i = 0; i <= n; i++)
    {
        sequence += first;

        if (i < n)
        {
            sequence += ", ";
        }

        long next = first + second;
        first = second;
        second = next;
    }

    return sequence;
}

// Задание 3. Вычисление функции варианта 4
// A = sqrt(x - 54) + cos(x / 2) / sin(x^2) - ln(x)
static bool TryCalculateFunction(
    double x,
    out double result,
    out string error)
{
    result = 0;
    error = "";

    if (!double.IsFinite(x))
    {
        error = "Число должно быть конечным.";
        return false;
    }

    if (x < 54)
    {
        error = "Подкоренное выражение x - 54 должно быть неотрицательным.";
        return false;
    }

    double denominator = Math.Sin(x * x);

    if (Math.Abs(denominator) < 1e-12)
    {
        error = "Знаменатель sin(x^2) равен нулю или слишком близок к нулю.";
        return false;
    }

    result = Math.Sqrt(x - 54)
            + Math.Cos(x / 2) / denominator
            - Math.Log(x);

    return double.IsFinite(result);
}

// Задание 4. Вычисление суммы ряда Тейлора
// ln(1 + x) = x - x^2/2 + x^3/3 - x^4/4 + ...
static (double Sum, int Terms) CalculateTaylor(
    double x,
    double epsilon)
{
    double sum = 0;
    int n = 1;
    int terms = 0;

    while (true)
    {
        double term = Math.Pow(-1, n + 1) * Math.Pow(x, n) / n;

        if (Math.Abs(term) <= epsilon)
        {
            break;
        }

        sum += term;
        terms++;
        n++;
    }

    return (sum, terms);
}
