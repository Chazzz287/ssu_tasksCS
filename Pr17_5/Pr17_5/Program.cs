using System;

/*
 Задание 5. Создать класс для работы с одномерным массивом целых чисел.
Разработать следующие члены класса:
1. Закрытое поле:
 int [] IntArray;
2. Конструкторы, позволяющие создать массив размерности n:
 со значением n по умолчанию;
 с заданным значением n;
 на основе существующего экземпляра класса (конструктор копирования).
3. Методы, позволяющие:
 вычислить сумму элементов массива;
 вычислить произведение элементов массива.
4. Перегрузить методы предка Object (ToString, GetHashCode, Equals, GetType).
5. Свойство:
 возвращающее размерность массива (доступное только для чтения);
 позволяющее домножить все элементы массива на скаляр (доступное только для
записи).
6. Индексатор, позволяющий по индексу обращаться к соответствующему элементу
массива.
7. Перегрузку:
 операции ++ (--): одновременно увеличивает (уменьшает) значение всех элементов
массива на 1;
 операции !: возвращает значение true, если элементы массива не упорядочены по
возрастанию, иначе false;
 операции бинарный *: домножить все элементы массива на скаляр;
 операции преобразования класса массив в одномерный массив (и наоборот).
Продемонстрировать работу класса.
 */

class IntArray
{
    // Закрытое поле
    private int[] intArray;

    // Конструктор по умолчанию
    public IntArray() : this(10) { } // массив из 10 элементов по умолчанию

    // Конструктор с заданной размерностью
    public IntArray(int n)
    {
        if (n <= 0) throw new ArgumentException("Размерность массива должна быть больше 0.");
        intArray = new int[n];
    }

    // Конструктор копирования
    public IntArray(IntArray existingArray)
    {
        if (existingArray == null) throw new ArgumentNullException(nameof(existingArray));
        intArray = (int[])existingArray.intArray.Clone();
    }

    // Метод для вычисления суммы элементов массива
    public int Sum()
    {
        int sum = 0;
        foreach (var item in intArray)
        {
            sum += item;
        }
        return sum;
    }

    // Метод для вычисления произведения элементов массива
    public int Product()
    {
        int product = 1;
        foreach (var item in intArray)
        {
            product *= item;
        }
        return product;
    }

    // Перегрузка метода ToString
    public override string ToString()
    {
        return string.Join(", ", intArray);
    }

    // Перегрузка метода GetHashCode
    public override int GetHashCode()
    {
        int hash = 17;
        foreach (var item in intArray)
        {
            hash = hash * 31 + item.GetHashCode();
        }
        return hash;
    }

    // Перегрузка метода Equals
    public override bool Equals(object obj)
    {
        if (obj is IntArray otherArray)
        {
            if (intArray.Length != otherArray.intArray.Length) return false;
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] != otherArray.intArray[i]) return false;
            }
            return true;
        }
        return false;
    }

    // Свойство: возвращающее размерность массива (только для чтения)
    public int Length => intArray.Length;

    // Свойство: домножение всех элементов массива на скаляр (только для записи)
    public int Scalar
    {
        set
        {
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] *= value;
            }
        }
    }

    // Индексатор для доступа к элементам массива
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= intArray.Length) throw new IndexOutOfRangeException();
            return intArray[index];
        }
        set
        {
            if (index < 0 || index >= intArray.Length) throw new IndexOutOfRangeException();
            intArray[index] = value;
        }
    }

    // Перегрузка операций ++ и --
    public static IntArray operator ++(IntArray array)
    {
        var newArray = new IntArray(array);
        for (int i = 0; i < newArray.intArray.Length; i++)
        {
            newArray.intArray[i]++;
        }
        return newArray;
    }

    public static IntArray operator --(IntArray array)
    {
        var newArray = new IntArray(array);
        for (int i = 0; i < newArray.intArray.Length; i++)
        {
            newArray.intArray[i]--;
        }
        return newArray;
    }

    // Перегрузка операции ! (проверка на неупорядоченность массива)
    public static bool operator !(IntArray array)
    {
        for (int i = 1; i < array.intArray.Length; i++)
        {
            if (array.intArray[i - 1] > array.intArray[i]) return true;
        }
        return false;
    }

    // Перегрузка бинарной операции * (домножение на скаляр)
    // [] * 2
    public static IntArray operator *(IntArray array, int scalar)
    {
        var newArray = new IntArray(array);
        for (int i = 0; i < newArray.intArray.Length; i++)
        {
            newArray.intArray[i] *= scalar;
        }
        return newArray;
    }

    // 2 * []
    public static IntArray operator *(int scalar, IntArray array)
    { 
        return array * scalar;
    }

    // Перегрузка явного преобразования IntArray -> int[]
    public static explicit operator int[](IntArray array)
    {
        return (int[])array.intArray.Clone();
    }

    // Перегрузка явного преобразования int[] -> IntArray
    public static explicit operator IntArray(int[] array)
    {
        var newArray = new IntArray(array.Length);
        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }
        return newArray;
    }

    // Пример использования
    static void Main(string[] args)
    {
        // Создание объектов
        IntArray array1 = new IntArray(5);
        for (int i = 0; i < array1.Length; i++)
        {
            array1[i] = i + 1;
        }

        IntArray array2 = new IntArray(array1);
        array2.Scalar = 3;

        //Создание списка
        List<IntArray> arrays = new List<IntArray> { array1, array2 };

        using (StreamWriter fileOut = new StreamWriter(@"C:\Users\Mari\source\repos\ssu_tasksCS\Pr17_5\Pr17_5\output.txt"))
        {
            //// Вывод объектов
            fileOut.WriteLine("Array1: " + array1);
            fileOut.WriteLine("Array2: " + array2);



            //// Сравнение объектов
            fileOut.WriteLine("Array1 equals Array2: " + array1.Equals(array2));
            fileOut.WriteLine("Array1 hash code: " + array1.GetHashCode());
            fileOut.WriteLine("Array2 hash code: " + array2.GetHashCode());

            //// Демонстрация работы перегрузки
            fileOut.WriteLine("Is Array1 unordered: " + (!array1));
            fileOut.WriteLine("Array1 * 2: " + (array1 * 2));
            fileOut.WriteLine("3 * Array1: " + (3 * array1));


            // демонстрация инкримента
            fileOut.WriteLine("array1: " + array1);

            var array3 = ++array1;

            array2[0] = 100;
            fileOut.WriteLine("array3: " + array3);
            //// Вывод всех объектов из списка
            fileOut.WriteLine("List of arrays:");
            foreach (var array in arrays)
            {
                fileOut.WriteLine(array);
            }
        }
        
    }
}
