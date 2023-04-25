using cs_lab9;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

internal class Program
{
    //Метод для нахождения значения функции
    public static double f(double x)
    {
        Random rand = new Random();
        int a = rand.Next(-50, 50);
        if (x < 0)
        {
            if (x == a)
                throw new MyDBZException("Нельзя делить на ноль", x, a);
            else
                return x + Math.Pow(Math.Sin(1 / (x - a) + 4), 2);
        }
        else
        {
            if (x == a || x == -a)
                throw new MyDBZException("Нельзя делить на ноль", x, a);
            else if (Math.Abs(x) > Math.Abs(a))
                throw new MyArgumentException("Подкоренное множество не может быть отрицательным", x, a);
            else
                return a * x / Math.Sqrt(a * a - x * x);
        }
    }

    static void Main(string[] args)
    {
        //Task 1
        try
        {
            Random rand = new Random();
            double[] elements = new double[10];
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = rand.Next(-50, 50);
                Console.WriteLine($"x = {elements[i]}\tf(x) = {f(elements[i])}");
            }
        }
        catch (MyDBZException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine($"x = a = {ex.Argument}");
        }
        catch (MyArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine($"Неправильные значения аргумента и переменной: x = {ex.Argument}\ta = {ex.Value}");
        }

        //Task 3
        Console.WriteLine("Введите два целых числа:");
        Console.Write("k1 = ");
        int k1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("k2 = ");
        int k2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество элементов массива: ");
        int n = Convert.ToInt32(Console.ReadLine());
        double[] x = new double[n];
        try
        {
            RandArray(x, 0, k1 - 1);
            InpArray(x, k1, k2);
            RandArray(x, k2 + 1, n - 1);
        }
        catch (MyIOORException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine($"Неправильное значение k2 = {ex.Index}");
        }
        catch (FirstBiggerSecondException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine($"k1 = {ex.FirstI} > k2 = {ex.SecondI}");
        }
        OutArray(x);
        double[] y = new double[n];
        Console.WriteLine("\nЭлементы массива y: ");
        for (int i = 0; i < n; i++)
        {
            try
            {
                y[i] = f(x[i]);
                Console.Write(y[i] + " ");
            }
            catch (MyDBZException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"x = a = {ex.Argument}");
            }
            catch (MyArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Неправильные значения аргумента и переменной: x = {ex.Argument}\ta = {ex.Value}");
            }
        }
        int count = 0;
        Console.WriteLine("\nТочки, попавшие в заштрихованную область:");
        for (int i = 0; i < n; i++)
        {
            if (y[i] >= -4 && y[i] <= 4 && x[i] >= -4 && x[i] <= 0 || y[i] <= 4 - x[i] && x[i] >= 0 && y[i] >= 0)
            {
                Console.WriteLine($"({x[i]}, {f(x[i])})");
                count++;
            }
        }
        Console.WriteLine($"Количество данных точек: {count}");
    }

    //Методы для заполнения массива
    public static void InpArray(double[] arr, int k1, int k2)
    {
        if (k2 >= arr.Length)
            throw new MyIOORException("Значение индекса вышло за пределы допустимых значений", k2);
        else if (k2 < k1)
            throw new FirstBiggerSecondException("Индекс первого элемента должен быть меньше второго", k1, k2);
        Console.WriteLine("Введите элементы массива:");
        for (int i = k1; i <= k2; i++)
        {
            arr[i] = Convert.ToDouble(Console.ReadLine());
        }
    }

    public static void RandArray(double[] arr, int k1, int k2)
    {
        if (k2 >= arr.Length)
            throw new MyIOORException("Значение индекса вышло за пределы допустимых значений", k2);
        else if (k2 < k1)
            throw new FirstBiggerSecondException("Индекс первого элемента должен быть меньше второго", k1, k2);
        Random rand = new Random();
        for (int i = k1; i <= k2; i++)
        {
            arr[i] = rand.Next(-50, 50);
        }
    }

    //Метод для вывода массива
    public static void OutArray(double[] arr)
    {
        Console.Write("\nЭлементы массива: ");
        foreach (double elem in arr)
        {
            Console.Write(elem + " ");
        }
    }
}