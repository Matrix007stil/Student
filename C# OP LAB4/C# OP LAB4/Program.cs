// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;
class Program
{
    static int[] vstavki(int[] array)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 1; i < array.Length; i++)
        {
            int k = i - 1;
            int current = array[i];
            while ((k >= 0) && (current < array[k]))
            {

                array[k + 1] = array[k];
                k--;
            }
            array[k + 1] = current;
        }
        stopwatch.Stop();
        Console.WriteLine($"Сортировка Вставками заняла: {stopwatch.Elapsed}\n");

        return array;
    }
    static int[] ArrayCopy(int[] array)
    {
        int[] copped = arrInitialisation(array.Length);
        for (int i = 0; i < array.Length; i++) { copped[i] = array[i]; }
        return copped;
    }
    static int[] shell(int[] arr)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int N = arr.Length;
        for (int d = N / 2; d != 0; d /= 2)
        {
            for (int start = 0; start < d; start++)
            {
                for (int i = start + d; i < N; i += d)
                {
                    int k = i - d;
                    int current = arr[i];
                    while ((k >= 0) && (current < arr[k]))
                    {
                        arr[k + d] = arr[k];
                        k -= d;

                    }
                    arr[k + d] = current;
                }

            }
        }
        stopwatch.Stop();
        Console.WriteLine($"Сортировка Шелла заняла: : {stopwatch.Elapsed}");
        return arr;
    }
    static int[] RandomArray(int[] a, int n)
    {
        Random rnd = new Random();
        int N = a.Length;
        for (int i = 0; i < N; i++)
            a[i] = rnd.Next(1, n);
        return a;
    }
    static void printArr(int[] numbers)
    {
        int N = numbers.Length;
        if (N <= 10)
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
        else
        {
            Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10");
        }
        Console.Write("\n");
    }

    static double parse(string num, int choise)
    {
        double ans = 0;
        while ((!double.TryParse(num, out ans)))
        {
            Console.Write("Ошибка, введите число: ");
            num = Console.ReadLine();
        }

        return ans;
    }
    static double function(double A, double B)
    {
        double f1 = Math.Pow(Math.Sin(A), 2) + Math.Pow(Math.Cos(B), 3);
        double f2 = Math.Pow(Math.Sin(A), 3) - Math.Pow(Math.Cos(B), 2);
        return Math.Round(Math.Sqrt(f1 / f2), 2);

    }
    static void Divine(double res)
    {
        bool flag = true;
        int k = 3;
        Console.WriteLine("Введите предполагаемый ответ(округлив до 2х знаков после запятой):");
        double supposeAns = Math.Round(parse(Console.ReadLine(), -1), 2);
        while ((k != 1) && (flag = true))
        {
            if (res == supposeAns)
            {
                Console.WriteLine("Ответ верный!!!\n");
                flag = false;
            }
            else
            {
                Console.WriteLine($"Неверный ответ! Осталось {k - 1} попыток\nВведите предполагаемый ответ(округлив до 2х знаков после запятой):");
                supposeAns = Math.Round(parse(Console.ReadLine(), -1), 2);
            }
            k--;
        }
        if (flag = true)
        {
            Console.WriteLine($"Правильный ответ: {res}");
        }
    }
    static void Author(string name)
    {
        Console.WriteLine($"Работу делал {name}");
        Console.ReadKey();
    }
    static void tryDivine()
    {
        double res;
        do
        {
            Console.Write("Введите значение переменной a:");
            double a = parse(Console.ReadLine(), -1);
            Console.Write("Введите значение переменной b:");
            double b = parse(Console.ReadLine(), -1);
            res = function(a, b);
            if (Double.IsNaN(res)) Console.WriteLine("Вы вышли за область определения функции");
        }
        while (Double.IsNaN(res));
        Divine(res);
        Console.ReadKey();
    }
    static bool exit()
    {
        Console.WriteLine("Вы точно хотите выйти?(д/н)");
        string mess = Console.ReadLine().ToLower();
        if (mess == "д") return true;
        else if (mess == "н") return false;
        else
        {
            while (true)
            {
                Console.WriteLine("Введите д/н");
                mess = Console.ReadLine().ToLower();
                if (mess == "д") return true;
                else if (mess == "н") return false;
            }

        }

    }
    static int arrParse(string ans)
    {
        int N;
        Console.WriteLine("Введите длину массива");
        ans = Console.ReadLine();

        while (!int.TryParse(ans, out N))
        {
            Console.WriteLine("Ошибка! Введите чило: ");
            ans = Console.ReadLine();
        }
        if (N <= 0)
        {
            Console.WriteLine("Ошибка! Неверная длина массива: ");
            Console.WriteLine("Введите длину массива");
            ans = Console.ReadLine();

            while (!int.TryParse(ans, out N))
            {
                Console.WriteLine("Ошибка! Введите чило: ");
                ans = Console.ReadLine();
            }

        }
        return N;
    }
    static int[] arrInitialisation(int N)
    {
        int[] arr = new int[N];
        RandomArray(arr, N);
        return arr;
    }

    static void arrSort()
    {
        int N = arrParse("FUN");
        int[] array = arrInitialisation(N);
        int[] copy = ArrayCopy(array);
        printArr(copy);
        printArr(shell(array));
        printArr(vstavki(copy));
        Console.ReadKey();
    }
    //static int[,] placeInitialization();
    static void printMultiArr(int[,] arr)
    {
        string s1 = "ABC123";
        
        int N1 = arr.GetLength(0);
        int N2 = arr.GetLength(1);
        Console.WriteLine("  ABC");
        for (int i = 0; i < N1; i++)
        {
            Console.Write($"{s1[3+i]} ");
            for (int j = 0; j < N2; j++)
            {
                Console.Write(arr[i, j]);
            }
            Console.WriteLine();
        }      

    }
    static bool check(string s1, string s2, int choise)
    {
        if (choise == 1)
        {
            for (int i = 0; i < s2.Length; i++)
            {
                if (s1 == s2[i].ToString())
                    return true;
            }
        }
        else if (choise == 2) 
        {
            for (int i = 0; i < s2.Length-1; i++)
            {
                if (s1 == s2[i].ToString() + s2[i+1].ToString())
                    return true;
            }
        }

            return false;
    }
    
    static string getXY(ref string s2)
    {
        string num = "123";
        string letter = "ABC";
        string XY;
        bool flag = true;
        do
        {
            Console.WriteLine("Введите позицию элемента");
            XY = Console.ReadLine();
            if ((XY.Length == 2) && check(XY[0].ToString(), letter, 1) && check(XY[1].ToString(), num, 1))
            {
                if (!check(XY, s2, 2))
                {
                    s2 += XY;
                    flag = false;
                }
                else { Console.WriteLine("Исправляй"); }
            }
        }
        while (flag);
        return XY;
    }
    static double getNum(ref string s1)
    {
        while (true)
        {
            Console.WriteLine("Введите число от 1-9 ");
            string sNum = Console.ReadLine();
            int num;
            while (!int.TryParse(sNum, out num))
            {
                Console.WriteLine("Ошибка введите число!");
                sNum = Console.ReadLine();
            }
            if ((num >= 1) && (num <= 9) && (!check(sNum, s1, 1)))
            {
                s1 += sNum;
                return num; 
            }
            else Console.Write("Ошибка! ");
        }
    }
    static bool checkHor(int[,] arr)
    {
        int N1 = arr.GetLength(0);
        int N2 = arr.GetLength(1);
        for (int i = 0; i< N1; i++)
        {
            int sum = 0;
            for (int j = 0; j< N2; j++)
            {
                sum += arr[i, j];
            }
            if (sum != 15) return false;
            
        }
        return true;
    }
    static bool checkVert(int[,] arr)
    {
        int N1 = arr.GetLength(0);
        int N2 = arr.GetLength(1);
        for (int i = 0; i < N1; i++)
        {
            int sum = 0;
            for (int j = 0; j < N2; j++)
            {
                sum += arr[j, i];
            }
            if (sum != 15) return false;
            
        }
        return true;
    }
    static void boubleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length;i++)
        {
            for (int j = 0; j < arr.Length - i-1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }    
    }
    static int[] func(int[] arr)
    {
        int[] num = new int[arr.Length];
        for (int i = 0;i < num.Length;i++)
        {
            num[i]= arr[i];
        }
        Array.Sort(num);
        int unique = 1;
        for (int i = 0;i<num.Length-1;i++)
        {
            if (num[i] != num[i+1])
            {
                unique++;
            }
        }
        int[] ans = new int[unique];
        ans[0] = num[0];
        int idx = 1;
        
        for (int j = 1; j < num.Length - 1; j++)
        {
            if (num[j] != num[j + 1])
            {
                ans[idx] = num[j+1];
                idx++;
            }
        }
        
        return ans;
    }
    static bool checkDiag(int[,] arr)
    {
        int sum1 = arr[0,0] + arr[1,1] + arr[2,2];
        int sum2 = arr[0, 2] + arr[1, 1] + arr[2, 0];
        if ((sum1 == 15) && (sum2 == 15)) return true;
        else return false;
        
    }
    static int[] input(ref string s1, ref string s2)
    {
        string position = getXY(ref s2);
        int posX = 0, posY = 0;
        int[,] alph = {{65, 1}, {66, 2}, {67, 3}};
        for (int i = 0; i < 3; i++)
        {
            if ((int)position[0] == alph[i,0]) posX = alph[i, 1];
        }
        posY = position[1] - '0';
        //Console.WriteLine($"{posX}, {posY}");
        int[] num = { posX, posY, (int)getNum(ref s1) };

        return num;
    }
    static bool checkWin(int[,] arr)
    {
        if (checkHor(arr) && (checkVert(arr)) && checkDiag(arr))
        {
            return true;
        }
        else return false;
    }
    static void changeMatrix(int[] num, int[,] arr)
    {
        int posX, posY, number;
        posY = num[0] - 1;
        posX = num[1] - 1;
        number = num[2];
        arr[posX, posY] = number;
    }
    static int[,] matrixInit(int N1, int N2)
    {
        int[,] arr = new int[N1,N2];

        return arr; 
    }
    static void game()
    {
        /* Magic
         {8, 1, 6},
         {3, 5, 7},
         {4, 9, 2}
         */

        string s1 = "";
        string s2 = "";
        bool flag = false;
        int[,] arr = matrixInit(3, 3);
        while (s1.Length < 9)
        {
            Console.Clear();
            printMultiArr(arr);
            int[] num = input(ref s1, ref s2);
            changeMatrix(num, arr);
            flag = checkWin(arr); 
        }
        Console.Clear();
        printMultiArr(arr);
        if (flag)
        {
            Console.WriteLine("Ты победил!");
        }
        else Console.WriteLine("Ничего, получится в следующий раз");
    }
    static void Main(string[] args)
    {
        int[] num = { 1, 1, 1, 2, 3, 3, 5, 5, 4 };
        bool flag = true;
        while (flag)
        {
            Console.Clear();
            Console.WriteLine("Меню выбора действий:\n1)Отгадай ответ\n2)Об авторе\n3)Сортировка массива\n4)Магический квдрат\n5)Выход");
            double ChoiceInt = parse(Console.ReadLine(), -1);

            switch (ChoiceInt)
            {
                case 1:
                    tryDivine();
                    break;
                case 2:
                    Author("Меркурьев Алексей");
                    printArr(func(num));
                    Console.ReadKey();
                    break;
                case 3:
                    arrSort();
                    break;
                case 4:
                    game();
                    Console.ReadKey();
                    break;
                case 5:
                    if (exit() == true) flag = false;
                    break;
                default:
                    Console.WriteLine("Ошибка! Введите число (1, 2, 3): ");
                    Console.ReadKey();
                    break;


            }
        }
    }
}
