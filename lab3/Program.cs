using System;

namespace lab3
{
    class Program
    {
        //Метод для перенемення елементів з однієї області в іншу для int
        static void replaseElements(int[,] arr) 
        {
            Console.WriteLine("\nПереписання елементів з однієї області в іншу");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = i + 1; j < arr.GetLength(1); j++)
                {
                    int temp = arr[i, j];
                    arr[i, j] = arr[j, i];
                    arr[j, i] = temp;
                }
            }
        }
        //Метод для перенемення елементів з однієї області в іншу для char
        static void replaseElements(char[,] arr)
        {
            Console.WriteLine("\nПереписання елементів з однієї області в іншу");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = i + 1; j < arr.GetLength(1); j++)
                {
                    char temp = arr[i, j];
                    arr[i, j] = arr[j, i];
                    arr[j, i] = temp;
                }
            }
        }
        //Метод для пошуку символів в масиві
        static bool searchChar(char[,] arr)
        {
            Console.WriteLine("Введіть символ який потрібно знайти");
            char c = Convert.ToChar(Console.ReadLine());
            for (int i = 0; i < arr.GetLength(0); i++)
            {

                for (int j = 0; j < arr.GetLength(1); j++)
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
        static void searchMinMax(int[,] arr)
        {
            int min = arr[0, 0];
            int max = arr[0, 0];
            for (int i = 0; i < arr.GetLength(0); i++)
            {

                for (int j = 0; j < arr.GetLength(1); j++)
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
        static void printArr(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        // масив для виводу масиву типу char
        static void printArr(char[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        //Метод для пошуку парного числа
        static int getOddNumber(Random random)
        {


            int n = random.Next(1, 9);
            while (n % 2 == 0)
            {
                n = random.Next(1, 9);
            }

            return n;
        }
        // метод для пошуку непарного числа
        static int getEvenТumber(Random random)
        {
            int n = random.Next(1, 9);
            while (n % 2 != 0)
            {
                n = random.Next(1, 9);
            }
            return n;
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
                    arr[i, j] = getOddNumber(random);
                    break;
                case 3:
                    arr[i, j] = getEvenТumber(random);
                    break;
                case 4:
                    charArr[i, j] = (char)random.Next(0x0410, 0x44F);
                    break;
                case 5:
                    charArr[i, j] = (char)random.Next('A', 'Z' + 1);
                    break;

            }
        }

        //Метод для винесення switch який багато раз використовується
        static void lab3_2(int v, int[,] arr, char[,] charArr)
        {
            switch (v)
            {
                case 1:
                    Console.WriteLine("Початвовий масив");
                    printArr(arr);
                    searchMinMax(arr);
                    Console.WriteLine();
                    replaseElements(arr);
                    printArr(arr);
                    break;
                case 2:
                    Console.WriteLine("Початвовий масив");
                    printArr(arr);
                    searchMinMax(arr);
                    replaseElements(arr);
                    break;
                case 3:
                    Console.WriteLine("Початвовий масив");
                    printArr(arr);
                    searchMinMax(arr);
                    replaseElements(arr);
                    break;
                case 4:
                    Console.WriteLine("Початвовий масив");
                    printArr(charArr);
                    if (searchChar(charArr))
                        Console.WriteLine("Цей символ знаходиться в масиві");
                    else
                        Console.WriteLine("Такого символу немає в масиві");
                    replaseElements(charArr);
                    printArr(charArr);
                    break;
                case 5:
                    Console.WriteLine("Початвовий масив");
                    printArr(charArr);
                    if (searchChar(charArr))
                        Console.WriteLine("Цей символ знаходиться в масиві");
                    else
                        Console.WriteLine("Такого символу немає в масиві");

                    replaseElements(charArr);
                    printArr(charArr);
                    break;
            }
        }


        #region filling arrays Регіон в якому всі методи заповнюють різні області масивів
        static void lab3_1_1(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
                printArr(arr);
            }
            else
                printArr(charArr);
        }

        static void lab3_2_1(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i == j || i > j)
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else
                        charArr[i, j] = '0';
                }
            }
            lab3_2(v, arr, charArr);
        }

        static void lab3_1_2(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i == j || i < j)
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else charArr[i, j] = '0';
                }
            }
            if (v == 1 || v == 2|| v==3)
            {
                printArr(arr);
            }
            else
                printArr(charArr);
        }

        static void lab3_1_3(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i + j == n - 1 || i + j <= n - 1)
                    {
                        switchFun(v, arr, charArr, i, j);
                    }
                    else charArr[i, j] = '0';
                }
            }
            if (v == 1 || v == 2|| v==3)
            {
                printArr(arr);
            }
            else
                printArr(charArr);
        }

        static void lab3_1_4(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
                printArr(arr);
            }
            else
                printArr(charArr);
        }

        static void lab3_1_5(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
                printArr(arr);
            }
            else
                printArr(charArr);
        }

        static void lab3_1_6(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
                printArr(arr);
            }
            else
                printArr(charArr);

        }

        static void lab3_1_7(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
                printArr(arr);
            }
            else
                printArr(charArr);
        }

        static void lab3_1_8(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
                printArr(arr);
            }
            else
                printArr(charArr);
        }

        static void lab3_1_9(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
                printArr(arr);
            }
            else
                printArr(charArr);
        }

        static void lab3_1_10(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
                printArr(arr);
            }
            else
                printArr(charArr);
        }

        static void lab3_1_11(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
                printArr(arr);
            }
            else
                printArr(charArr);
        }

        static void lab3_1_12(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
                printArr(arr);
            }
            else
                printArr(charArr);
        }

        static void lab3_1_13(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
                printArr(arr);
            }
            else
                printArr(charArr);
        }

        static void lab3_1_14(int v, int n, int m)
        {
            int[,] arr = new int[n, m];
            char[,] charArr = new char[n, m];
            Random random = new();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
                printArr(arr);
            }
            else
                printArr(charArr);


        }

        #endregion
        static void Main(string[] args)
        {
            int n, m;
            Console.Write("Введіть розмірність матриці n = ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("m = ");
            m = Convert.ToInt32(Console.ReadLine());
            //1 масив
            Console.WriteLine("\t1 масив");
            Console.WriteLine("Заповнення області масиву псевдовипадковими числами");
            lab3_1_1(1, n, m);
            Console.WriteLine("\nЗаповнення області масиву непарними числами");
            lab3_1_1(2, n, m);
            Console.WriteLine("\nЗаповнення області масиву парними числами");
            lab3_1_1(3, n, m);
            Console.WriteLine("\nЗаповнення будь яким символом");
            lab3_1_1(4, n, m);
            Console.WriteLine("\nЗаповнення буквами англійського алфавіту");
            lab3_1_1(5, n, m);
            //2 масив
            Console.WriteLine("\n\t2 масив");
            Console.WriteLine("Заповнення області масиву псевдовипадковими числами");
            lab3_1_2(1, n, m);
            Console.WriteLine("\nЗаповнення області масиву непарними числами");
            lab3_1_2(2, n, m);
            Console.WriteLine("\nЗаповнення області масиву парними числами");
            lab3_1_2(3, n, m);
            Console.WriteLine("\nЗаповнення будь яким символом");
            lab3_1_2(4, n, m);
            Console.WriteLine("\nЗаповнення буквами англійського алфавіту");
            lab3_1_2(5, n, m);
            //3 масив
            Console.WriteLine("\n\n\t3 масив");
            Console.WriteLine("Заповнення області масиву псевдовипадковими числами");
            lab3_1_3(1, n, m);
            Console.WriteLine("\nЗаповнення області масиву непарними числами");
            lab3_1_3(2, n, m);
            Console.WriteLine("\nЗаповнення області масиву парними числами");
            lab3_1_3(3, n, m);
            Console.WriteLine("\nЗаповнення будь яким символом");
            lab3_1_3(4, n, m);
            Console.WriteLine("\nЗаповнення буквами англійського алфавіту");
            lab3_1_3(5, n, m);
            //4 масив
            Console.WriteLine("\n\t4 масив");
            Console.WriteLine("Заповнення області масиву псевдовипадковими числами");
            lab3_1_4(1, n, m);
            Console.WriteLine("\nЗаповнення області масиву непарними числами");
            lab3_1_4(2, n, m);
            Console.WriteLine("\nЗаповнення області масиву парними числами");
            lab3_1_4(3, n, m);
            Console.WriteLine("\nЗаповнення будь яким символом");
            lab3_1_4(4, n, m);
            Console.WriteLine("\nЗаповнення буквами англійського алфавіту");
            lab3_1_4(5, n, m);
            //5 масив
            Console.WriteLine("\n\t5 масив\n");
            Console.WriteLine("Заповнення області масиву псевдовипадковими числами");
            lab3_1_5(1, n, m);
            Console.WriteLine("\nЗаповнення області масиву непарними числами");
            lab3_1_5(2, n, m);
            Console.WriteLine("\nЗаповнення області масиву парними числами");
            lab3_1_5(3, n, m);
            Console.WriteLine("\nЗаповнення будь яким символом");
            lab3_1_5(4, n, m);
            Console.WriteLine("\nЗаповнення буквами англійського алфавіту");
            lab3_1_5(5, n, m);
            //6 масив
            Console.WriteLine("\n\t6 масив\n");
            Console.WriteLine("Заповнення області масиву псевдовипадковими числами");
            lab3_1_6(1, n, m);
            Console.WriteLine("\nЗаповнення області масиву непарними числами");
            lab3_1_6(2, n, m);
            Console.WriteLine("\nЗаповнення області масиву парними числами");
            lab3_1_6(3, n, m);
            Console.WriteLine("\nЗаповнення будь яким символом");
            lab3_1_6(4, n, m);
            Console.WriteLine("\nЗаповнення буквами англійського алфавіту");
            lab3_1_6(5, n, m);
            //7 масив
            Console.WriteLine("\n\t7 масив\n");
            Console.WriteLine("Заповнення області масиву псевдовипадковими числами");
            lab3_1_7(1, n, m);
            Console.WriteLine("\nЗаповнення області масиву непарними числами");
            lab3_1_7(2, n, m);
            Console.WriteLine("\nЗаповнення області масиву парними числами");
            lab3_1_7(3, n, m);
            Console.WriteLine("\nЗаповнення будь яким символом");
            lab3_1_7(4, n, m);
            Console.WriteLine("\nЗаповнення буквами англійського алфавіту");
            lab3_1_7(5, n, m);
            //8 масив
            Console.WriteLine("\n\t8 масив\n");
            Console.WriteLine("Заповнення області масиву псевдовипадковими числами");
            lab3_1_8(1, n, m);
            Console.WriteLine("\nЗаповнення області масиву непарними числами");
            lab3_1_8(2, n, m);
            Console.WriteLine("\nЗаповнення області масиву парними числами");
            lab3_1_8(3, n, m);
            Console.WriteLine("\nЗаповнення будь яким символом");
            lab3_1_8(4, n, m);
            Console.WriteLine("\nЗаповнення буквами англійського алфавіту");
            lab3_1_8(5, n, m);
            //9 масив
            Console.WriteLine("\n\t9 масив\n");
            Console.WriteLine("Заповнення області масиву псевдовипадковими числами");
            lab3_1_9(1, n, m);
            Console.WriteLine("\nЗаповнення області масиву непарними числами");
            lab3_1_9(2, n, m);
            Console.WriteLine("\nЗаповнення області масиву парними числами");
            lab3_1_9(3, n, m);
            Console.WriteLine("\nЗаповнення будь яким символом");
            lab3_1_9(4, n, m);
            Console.WriteLine("\nЗаповнення буквами англійського алфавіту");
            lab3_1_9(5, n, m);
            //10 масив
            Console.WriteLine("\n\t10 масив\n");
            Console.WriteLine("Заповнення області масиву псевдовипадковими числами");
            lab3_1_10(1, n, m);
            Console.WriteLine("\nЗаповнення області масиву непарними числами");
            lab3_1_10(2, n, m);
            Console.WriteLine("\nЗаповнення області масиву парними числами");
            lab3_1_10(3, n, m);
            Console.WriteLine("\nЗаповнення будь яким символом");
            lab3_1_10(4, n, m);
            Console.WriteLine("\nЗаповнення буквами англійського алфавіту");
            lab3_1_10(5, n, m);
            //11 масив
            Console.WriteLine("\n\t11 масив\n");
            Console.WriteLine("Заповнення області масиву псевдовипадковими числами");
            lab3_1_11(1, n, m);
            Console.WriteLine("\nЗаповнення області масиву непарними числами");
            lab3_1_11(2, n, m);
            Console.WriteLine("\nЗаповнення області масиву парними числами");
            lab3_1_11(3, n, m);
            Console.WriteLine("\nЗаповнення будь яким символом");
            lab3_1_11(4, n, m);
            Console.WriteLine("\nЗаповнення буквами англійського алфавіту");
            lab3_1_11(5, n, m);
            //12 масив
            Console.WriteLine("\n\t12 масив\n");
            Console.WriteLine("Заповнення області масиву псевдовипадковими числами");
            lab3_1_12(1, n, m);
            Console.WriteLine("\nЗаповнення області масиву непарними числами");
            lab3_1_12(2, n, m);
            Console.WriteLine("\nЗаповнення області масиву парними числами");
            lab3_1_12(3, n, m);
            Console.WriteLine("\nЗаповнення будь яким символом");
            lab3_1_12(4, n, m);
            Console.WriteLine("\nЗаповнення буквами англійського алфавіту");
            lab3_1_12(5, n, m);
            //13 масив
            Console.WriteLine("\n\t13 масив\n");
            Console.WriteLine("Заповнення області масиву псевдовипадковими числами");
            lab3_1_13(1, n, m);
            Console.WriteLine("\nЗаповнення області масиву непарними числами");
            lab3_1_13(2, n, m);
            Console.WriteLine("\nЗаповнення області масиву парними числами");
            lab3_1_13(3, n, m);
            Console.WriteLine("\nЗаповнення будь яким символом");
            lab3_1_13(4, n, m);
            Console.WriteLine("\nЗаповнення буквами англійського алфавіту");
            lab3_1_13(5, n, m);
            //14 масив
            Console.WriteLine("\n\t14 масив\n");
            Console.WriteLine("Заповнення області масиву псевдовипадковими числами");
            lab3_1_14(1, n, m);
            Console.WriteLine("\nЗаповнення області масиву непарними числами");
            lab3_1_14(2, n, m);
            Console.WriteLine("\nЗаповнення області масиву парними числами");
            lab3_1_14(3, n, m);
            Console.WriteLine("\nЗаповнення будь яким символом");
            lab3_1_14(4, n, m);
            Console.WriteLine("\nЗаповнення буквами англійського алфавіту");
            lab3_1_14(5, n, m);
            Console.WriteLine("\n\tЗавдання 2 для 1 масиву\n");
            lab3_2_1(1, n, m);
            lab3_2_1(4, n, m);
        }
    }
}
