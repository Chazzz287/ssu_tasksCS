/*
 Для каждого столбца найти произведение элементов с номерами от k1 до k2 и записать
данные в новый массив.

k1 = 1  k2 = 2

3

0 1 2 
3 4 5
6 7 8

ans:
18 28 40
*/
void task_4_15()
{
    // здесь используется двумерный массив
    Console.Write("Enter numLenghtaArr: ");
    ushort numLenght = ushort.Parse(Console.ReadLine());

    int[,] multiarr = new int[numLenght, numLenght];
    int[] arr = new int[numLenght];

    Console.Write("Enter k1: ");
    int k1 = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter k2: ");
    int k2 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine(' ');

    for (int i = 0; i < numLenght; i++)
    {
        for (int j = 0; j < numLenght; j++)
        {
            multiarr[i, j] = Convert.ToInt32(Console.ReadLine());
            if (arr[j] == 0 && i == 0) arr[j] = 1;
            if (i >= k1 && i <= k2)
                arr[j] *= multiarr[i, j];
        }
    }

    Console.WriteLine(' ');
    Console.WriteLine("Answer:");
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i]);
        Console.Write(' ');
    }
}


/*
 Уплотнить массив, удалив из него все строки и столбцы, состоящие из одних нулей.  

4

0 1 2 0
0 0 0 0
0 3 0 0
0 0 0 0

3

0 1 2
0 3 0
0 0 0

1 2
3 0

*/
void task_6_15()
{
    Console.Write("Enter numLenghtaArr: ");
    int numLenght = int.Parse(Console.ReadLine());
    int numRowLenght = numLenght;

    int[][] toothArr = new int[numLenght][];

    for (int i = 0; i < numLenght; i++)
    {
        toothArr[i] = new int[numRowLenght];
        for (int j = 0; j < numRowLenght; j++)
        {
            toothArr[i][j] = int.Parse(Console.ReadLine());
        }
    }

    // Для одномерного массива
    void Delete(int[] array, int n, int k)
    {
        for(int i = k; i < n- 1; i++)
        {
            array[i] = array[i + 1];
        }
    }


    // Для ступенчатого массива
    void toothDelete(int[][] tArray, ref int n, int k)
    {
        for (int i = k; i < n - 1; i++)
        {
            tArray[i] = tArray[i + 1];
        }
        n--;
    }

    // Удаление всех нулевых рядов 
    int k = 0;
    while (k < numLenght)
    {
        if (toothArr[k].Sum() == 0)
        {
            toothDelete(toothArr, ref numLenght, k);
        }
        ++k;
    }

    // Удаление всех нулевых столбцов
    k = 0;
    while (k < numRowLenght)
    {
        int sum = 0;
        for (int i = 0; i < numLenght; i++)
        {
            sum += toothArr[i][k];
        }
        if (sum != 0) k++;
        else
        {
            for (int i = 0; i < numLenght; i++)
            {
                Delete(toothArr[i], numRowLenght, k);
            }
            numRowLenght--;
            k = 0;
        }
    }

    // Вывод
    Console.WriteLine();
    for(int i=0; i < numLenght; ++i)
    {
        for(int  j = 0; j < numRowLenght; ++j)
        {
            Console.Write($"{toothArr[i][j]} ");
        }
        Console.WriteLine();
    }
}

task_6_15();