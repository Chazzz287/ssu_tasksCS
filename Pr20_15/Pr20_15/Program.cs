using System;
using System.IO;
/*
 Реализовать типизированный однонаправленный список с тремя точками доступ (head,
tail, temp) для хранения и обработки целых чисел. Для списка должны быть реализованы
базовые операции: инициализация списка, добавление элемента в «хвост» списка, извлечение
элемента из «головы» списка, просмотр элементов в списке, а также дополнительные
операции в соответствии поставленной задачей.
При решении задачи целые числа считываются из файла input.txt. Данные в файле
хранятся в неструктурированном виде. Количество чисел в файле не менее 50.
Результат выводится в файл output.txt в структурированном виде – вначале исходная
последовательность чисел через пробел, а затем с новой строки итоговая последовательность
чисел также через пробел.
При решении задачи дополнительные структуры данных не используются. Все
действия выполняются над текущем списком.

15. Удалить из списка элементы так, чтобы каждый элемент встречался только один раз.
 */

namespace Pr20_15
{
    internal class Program
    {
        static void Main()
        {
            IntList list = new IntList();

            // Чтение входного файла
            string[] allText = File.ReadAllLines("C:\\Users\\Mari\\source\\repos\\ssu_tasksCS\\Pr20_15\\Pr20_15\\input.txt");
            foreach (string line in allText)
            {
                string[] parts = line.Split(new char[] { ' ', '\t', ',', '.', ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    if (int.TryParse(part, out int number))
                    {
                        list.AddEnd(number);
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("C:\\Users\\Mari\\source\\repos\\ssu_tasksCS\\Pr20_15\\Pr20_15\\output.txt"))
            {
                // Исходная последовательность
                list.Show(writer);

                // Удаление повторов
                list.RemoveDuplicates();

                // Итоговая последовательность
                list.Show(writer);
            }

            Console.WriteLine("Результат записан в output.txt");
        }
        
    }
}
