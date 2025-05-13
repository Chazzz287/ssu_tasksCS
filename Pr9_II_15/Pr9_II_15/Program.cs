/*
 15. Дан файл, компонентами которого являются числа. Число компонент файла делится на
два. Создать новый файл, в который будет записываться наименьшее из каждой пары
чисел первого файла. 

example:
4 5 
9  6

4 6 
*/

using (StreamReader fileIn = new StreamReader("C:\\Users\\Mari\\source\\repos\\ssu_tasksCS\\Pr9_II_15\\Pr9_II_15\\input.txt"))
{
    using (StreamWriter fileOut = new StreamWriter("C:\\Users\\Mari\\source\\repos\\ssu_tasksCS\\Pr9_II_15\\Pr9_II_15\\output.txt", false))
    {
        string[] line;
        //читаем построчно до тех пор, пока поток fileIn не пуст
        while (fileIn.Peek() != -1)
        {
            line = fileIn.ReadLine().Split();
            if (line[0].CompareTo(line[1]) < 0) fileOut.Write($"{line[0]}\n");
            else fileOut.Write($"{line[1]}\n");
        }
    }
}