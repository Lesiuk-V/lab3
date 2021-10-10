using System;

namespace lab3
{
    class Program
    {
        //Метод для перенемення елементів з однієї області в іншу для int
        static void ReplaseElements(int[,] arr, int n, int m) 
        {
            Console.WriteLine("\nПереписання елементів з однієї області в іншу");
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    int temp = arr[i, j];
                    arr[i, j] = arr[j, i];
                    arr[j, i] = temp;
                }
            }
        }
        //Метод для перенемення елементів з однієї області в іншу для char
        static void ReplaseElements(char[,] arr,int n, int m)
        {
            Console.WriteLine("\nПереписання елементів з однієї області в іншу");
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    char temp = arr[i, j];
                    arr[i, j] = arr[j, i];
                    arr[j, i] = temp;
                }
            }
        }
        //Метод для пошуку символів в масиві
        static bool SearchChar(char[,] arr,int n,int m)
        {
            Console.WriteLine("Введіть символ який потрібно знайти");
            char c = Convert.ToChar(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    if (c == arr[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        // метод для пошуку максимального та максимального значення
        static void SearchMinMax(int[,] arr,int n, int m)
        {
            int min = arr[0, 0];
            int max = arr[0, 0];
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] < min && arr[i, j] > 0)
                    {
                        min = arr[i, j];
                    }
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                    }
                }
            }

            Console.WriteLine($"min = {min}, max = {max}");
        }
        // метод для виводу масиву типу int 
        static void PrintArr(int[,] arr, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        // масив для виводу масиву типу char
        static void PrintArr(char[,] arr,int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        //Метод для пошуку парного числа
        static int GetOddNumber(Random random)
        {


            int number = random.Next(1, 9);
            while (number % 2 == 0)
            {
                number = random.Next(1, 9);
            }

            return number;
        }
        // метод для пошуку непарного числа
        static int GetEvenNumber(Random random)
        {
            int number = random.Next(1, 9);
            while (number % 2 != 0)
            {
                number = random.Next(1,9);
            }
            return number;
        }

        static void Transpon(int[,] arr, int n, int m)                   //Транспоновка матрицы интового типа данных
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int temp = arr[i, j];
                    arr[i, j] = arr[j, i];
                    arr[j, i] = temp;
                }
            }
        }
        static void Transpon(char[,] arr, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    char temp = arr[i, j];
                    arr[i, j] = arr[j, i];
                    arr[j, i] = temp;
                }
            }
        }

        // Метод в який виноситься switch який багато раз використовується для того щоб не дублювати код
        static void switchFun(int v, int[,] arr, char[,] charArr, int i, int j)

        {
            Random random = new();
            switch (v)
            {

                case 1:
                    arr[i, j] = random.Next(1, 9);
                    break;
                case 2:
                    arr[i, j] = GetEvenNumber(random);
                    break;
                case 3:
                    arr[i, j] = GetOddNumber(random);
                    break;
                case 4:
                    charArr[i, j] = (char)random.Next(0x0410, 0x44F);
                    break;
                case 5:
                    charArr[i, j] = (char)random.Next('A', 'Z' + 1);
                    break;

            }
        }

        static void WorckWithArr(int choice,int [,] arr,int n,int m)
        {
            switch (choice)
            {
                case 1:
                    SearchMinMax(arr, n, m);
                    PrintArr(arr, n, m);
                    break;
                case 2:
                    Console.WriteLine("Для цього масиво неможливо виконати пошук символу");
                    break;
                case 3:
                    Transpon(arr, n, m);
                    PrintArr(arr, n, m);
                    break;
                case 4:
                    ReplaseElements(arr, n, m);
                    PrintArr(arr, n, m);
                    break;
                default:
                    break;
            }
        }
        static void WorckWithArr(int choice, char[,] arr, int n, int m)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Для цього масиву неможливо виконати пошук min/max");
                    break;
                case 2:
                    SearchChar(arr, n, m);
                    PrintArr(arr, n, m);
                    break;
                case 3:
                    Transpon(arr, n, m);
                    PrintArr(arr, n, m);
                    break;
                case 4:
                    ReplaseElements(arr, n, m);
                    break;
                default:
                    break;
            }
        }
        static void PrintMenu()
        {
            Console.WriteLine("Що потрібно виконати?");
            Console.WriteLine("1. Знайти max / min.");
            Console.WriteLine("2. Пошук символу");
            Console.WriteLine("3. Транспонувати масив");
            Console.WriteLine("4. Переписати елементи з однiєї областi в iншу");
        }

        //Регіон в якому всі методи заповнюють різні області масивів
        #region filling arrays         
        static void Arr1(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == j || i > j)
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else
                        charArr[i, j] = '0';
                }
            }
            if (v == 1 || v == 2 || v == 3)
            {
                PrintArr(arr, n, m);
            }
            else
            {
                PrintArr(charArr, n, m);
            }
            PrintMenu();
            int choice= Convert.ToInt32(Console.ReadLine());
            if (v == 1 || v == 2 || v == 3)
            {
                WorckWithArr(choice, arr, n, m);
            }
            else
                WorckWithArr(choice, charArr, n, m);
        }

        static void Arr2(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == j || i < j)
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else charArr[i, j] = '0';
                }
            }
            if (v == 1 || v == 2 || v == 3)
            {
                PrintArr(arr, n, m);
            }
            else
            {
                PrintArr(charArr, n, m);
            }
            PrintMenu();

            int choice = Convert.ToInt32(Console.ReadLine());
            if (v == 1 || v == 2 || v == 3)
            {
                WorckWithArr(choice, arr, n, m);
            }
            else
                WorckWithArr(choice, charArr, n, m);
        }

        static void Arr3(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i + j == n - 1 || i + j <= n - 1)
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else charArr[i, j] = '0';
                }
            }
            if (v == 1 || v == 2 || v == 3)
            {
                PrintArr(arr, n, m);
            }
            else
            {
                PrintArr(charArr, n, m);
            }
            PrintMenu();

            int choice = Convert.ToInt32(Console.ReadLine());
            if (v == 1 || v == 2 || v == 3)
            {
                WorckWithArr(choice, arr, n, m);
            }
            else
                WorckWithArr(choice, charArr, n, m);
        }

        static void Arr4(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i + j == n - 1 || i + j >= n - 1)
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else charArr[i, j] = '0';
                }
            }
            if (v == 1 || v == 2 || v == 3)
            {
                PrintArr(arr, n, m);
            }
            else
            {
                PrintArr(charArr, n, m);
            }
            PrintMenu();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (v == 1 || v == 2 || v == 3)
            {
                WorckWithArr(choice, arr, n, m);
            }
            else
                WorckWithArr(choice, charArr, n, m);
        }

        static void Arr5(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j == n - 1 || i + j <= n - 1) && (i == j || i < j) || (i == j || i > j) && (i + j == n - 1 || i + j >= n - 1))
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else
                    {
                        charArr[i, j] = '0';
                    }
                }
            }
            if (v == 1 || v == 2 || v == 3)
            {
                PrintArr(arr, n, m);
            }
            else
            {
                PrintArr(charArr, n, m);
            }
            PrintMenu();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (v == 1 || v == 2 || v == 3)
            {
                WorckWithArr(choice, arr, n, m);
            }
            else
                WorckWithArr(choice, charArr, n, m);
        }

        static void Arr6(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i == j || i > j) && (i + j == n - 1 || i + j <= n - 1) || (i == j || i < j) && (i + j == n - 1 || i + j >= n - 1))
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else
                    {
                        charArr[i, j] = '0';
                    }
                }
            }
            if (v == 1 || v == 2 || v == 3)
            {
                PrintArr(arr, n, m);
            }
            else
            {
                PrintArr(charArr, n, m);
            }
            PrintMenu();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (v == 1 || v == 2 || v == 3)
            {
                WorckWithArr(choice, arr, n, m);
            }
            else
                WorckWithArr(choice, charArr, n, m);

        }

        static void Arr7(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j == n - 1 || i + j <= n - 1) && (i == j || i > j))
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else
                    {
                        charArr[i, j] = '0';
                    }
                }
            }
            if (v == 1 || v == 2 || v == 3)
            {
                PrintArr(arr, n, m);
            }
            else
            {
                PrintArr(charArr, n, m);
            }
            PrintMenu();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (v == 1 || v == 2 || v == 3)
            {
                WorckWithArr(choice, arr, n, m);
            }
            else
                WorckWithArr(choice, charArr, n, m);
        }

        static void Arr8(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i == j || i < j) && (i + j == n - 1 || i + j >= n - 1))
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else
                    {
                        charArr[i, j] = '0';
                    }
                }
            }
            if (v == 1 || v == 2 || v == 3)
            {
                PrintArr(arr, n, m);
            }
            else
            {
                PrintArr(charArr, n, m);
            }
            PrintMenu();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (v == 1 || v == 2 || v == 3)
            {
                WorckWithArr(choice, arr, n, m);
            }
            else
                WorckWithArr(choice, charArr, n, m);
        }

        static void Arr9(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i + j >= n - 1 && i + j >= n - 1 && i >= j && i >= j)
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else
                    {
                        charArr[i, j] = '0';
                    }
                }
            }
            if (v == 1 || v == 2 || v == 3)
            {
                PrintArr(arr, n, m);
            }
            else
            {
                PrintArr(charArr, n, m);
            }
            PrintMenu();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (v == 1 || v == 2 || v == 3)
            {
                WorckWithArr(choice, arr, n, m);
            }
            else
                WorckWithArr(choice, charArr, n, m);
        }

        static void Arr10(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i + j <= n - 1 && i + j <= n - 1 && i <= j && i <= j)
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else
                    {
                        charArr[i, j] = '0';
                    }
                }
            }
            if (v == 1 || v == 2 || v == 3)
            {
                PrintArr(arr, n, m);
            }
            else
            {
                PrintArr(charArr, n, m);
            }
            PrintMenu();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (v == 1 || v == 2 || v == 3)
            {
                WorckWithArr(choice, arr, n, m);
            }
            else
                WorckWithArr(choice, charArr, n, m);
        }

        static void Arr11(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i + j == n - 1 || i + j <= n - 1 || i == j || i > j)
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else
                    {
                        charArr[i, j] = '0';
                    }
                }
            }
            if (v == 1 || v == 2 || v == 3)
            {
                PrintArr(arr, n, m);
            }
            else
            {
                PrintArr(charArr, n, m);
            }
            PrintMenu();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (v == 1 || v == 2 || v == 3)
            {
                WorckWithArr(choice, arr, n, m);
            }
            else
                WorckWithArr(choice, charArr, n, m);
        }

        static void Arr12(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i + j == n - 1 || i + j >= n - 1 || i == j || i < j)
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else charArr[i, j] = '0';
                }
            }
            if (v == 1 || v == 2 || v == 3)
            {
                PrintArr(arr, n, m);
            }
            else
            {
                PrintArr(charArr, n, m);
            }
            PrintMenu();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (v == 1 || v == 2 || v == 3)
            {
                WorckWithArr(choice, arr, n, m);
            }
            else
                WorckWithArr(choice, charArr, n, m);
        }

        static void Arr13(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i + j == n - 1 || i + j <= n - 1 || i == j || i < j)
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else charArr[i, j] = '0';
                }
            }
            if (v == 1 || v == 2 || v == 3)
            {
                PrintArr(arr, n, m);
            }
            else
            {
                PrintArr(charArr, n, m);
            }
            PrintMenu();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (v == 1 || v == 2 || v == 3)
            {
                WorckWithArr(choice, arr, n, m);
            }
            else
                WorckWithArr(choice, charArr, n, m);
        }

        static void Arr14(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i + j == n - 1 || i + j >= n - 1 || i == j || i > j)
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else charArr[i, j] = '0';
                }
            }
            if (v == 1 || v == 2 || v == 3)
            {
                PrintArr(arr, n, m);
            }
            else
            {
                PrintArr(charArr, n, m);
            }
            PrintMenu();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (v == 1 || v == 2 || v == 3)
            {
                WorckWithArr(choice, arr, n, m);
            }
            else
                WorckWithArr(choice, charArr, n, m);
        }

        static int ChoiceFiil()
        {
            Console.WriteLine("Введiть вид заповнення матриці");
            Console.WriteLine("1.Псевдовипадковими числами");
            Console.WriteLine("2.Парними числами в дiапазонi вiд n до m");
            Console.WriteLine("3.Непарними числами в дiапазонi вiд n до m");
            Console.WriteLine("4.Будь-якими символами");
            Console.WriteLine("5.Будь-якими буквами англ. алфавiту");
            int fillArr = Convert.ToInt32(Console.ReadLine());
            return fillArr;
        }

        #endregion
        static void Main(string[] args)
        {
            int n, m, zavd;
            bool loop = true;
            Console.Write("Введіть розміри матриці: n=");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("m=");
            m = Convert.ToInt32(Console.ReadLine());
            while(loop)
            {
                Console.WriteLine("Введiть номер завдання(1-14) або 0 для виходу");
                zavd = Convert.ToInt32(Console.ReadLine());

                switch (zavd)
                {
                    case 0:
                        loop = false;
                        break;
                    case 1:
                        Arr1(ChoiceFiil(), n, m);
                        break;
                    case 2:
                        Arr2(ChoiceFiil(), n, m);
                        break;
                    case 3:
                        Arr3(ChoiceFiil(), n, m);
                        break;
                    case 4:
                        Arr4(ChoiceFiil(), n, m);
                        break;
                    case 5:
                        Arr5(ChoiceFiil(), n, m);
                        break;
                    case 6:
                        Arr6(ChoiceFiil(), n, m);
                        break;
                    case 7:
                        Arr7(ChoiceFiil(), n, m);
                        break;
                    case 8:
                        Arr8(ChoiceFiil(), n, m);
                        break;
                    case 9:
                        Arr9(ChoiceFiil(), n, m);
                        break;
                    case 10:
                        Arr10(ChoiceFiil(), n, m);
                        break;
                    case 11:
                        Arr11(ChoiceFiil(), n, m);
                        break;
                    case 12:
                        Arr12(ChoiceFiil(), n, m);
                        break;
                    case 13:
                        Arr13(ChoiceFiil(), n, m);
                        break;
                    case 14:
                        Arr14(ChoiceFiil(), n, m);
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
}
