// 15. Вывести на экран все слова-палиндромы, содержащиеся в сообщении. 
/*
 aboba bob barabara, bere bere

 aboba bob
 */
char[] div = {' ', '.', ',', ';', ':', '!', '?', '\"', '(', ')', '[', ']', '{', '}' };
string[] arrStr = Console.ReadLine().Split(div);

foreach (string str in arrStr)
{
    string strReverse = new string(str.ToCharArray().Reverse().ToArray());
    if (str.CompareTo(strReverse) == 0) Console.WriteLine(str);
}