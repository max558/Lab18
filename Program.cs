using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_18
{
    /*
     * Дана строка, содержащая скобки трёх видов (круглые, квадратные и фигурные) и любые другие символы. 
     * Проверить, корректно ли в ней расставлены скобки. Например, в строке ([]{})[] скобки расставлены корректно, а в строке ([]] — нет. 
     * Указание: задача решается однократным проходом по символам заданной строки слева направо; 
     *      для каждой открывающей скобки в строке в стек помещается соответствующая закрывающая, 
     *      каждая закрывающая скобка в строке должна соответствовать скобке из вершины стека (при этом скобка из вершины стека снимается); 
     *      в конце прохода стек должен быть пуст.
     */
    class Program
    {
        static void Main(string[] args)
        {
            List<char> listChar = new List<char>();
            listChar = InPutData.EnterData("Введите строку содержащую ([]{})[]:");
            Stack<char> stCh = new Stack<char>();
            for (int i = 0; i < listChar.Count; i++)
            {
                switch (listChar[i])
                {
                    case '{':
                        stCh.Push('}');
                        break;
                    case '}':
                        if (stCh.Count > 0)
                        {
                            stCh.Pop();
                        }
                        break;
                    case '(':
                        stCh.Push(')');
                        break;
                    case ')':
                        if (stCh.Count > 0)
                        {
                            stCh.Pop();
                        }
                        break;
                    case '[':
                        stCh.Push(']');
                        break;
                    case ']':
                        if (stCh.Count > 0)
                        {
                            stCh.Pop();
                        }
                        break;
                    default:
                        break;
                }
                //Последняя итерация цикла, если есть стэк, то его внедряем в последовательность
                if ((stCh.Count > 0) && (i == listChar.Count - 1))
                {
                    listChar.AddRange(stCh);
                }
            }
            stCh.Clear();

            //Перевод результирующего списка в строку и ее вывод
            string strRes = "";
            for (int i = 0; i < listChar.Count; i++)
            {
                strRes += listChar[i].ToString();
            }
            Console.WriteLine();
            Console.WriteLine(strRes);
            Console.ReadKey();
        }
    }
    public static class InPutData
    {
        public static List<char> EnterData(string strIn)
        {
            List<char> listChar = new List<char>();
            string res = "";
            Console.WriteLine(strIn);
            res = Console.ReadLine();
            if (res.Length > 0)
            {
                foreach (var item in res)
                {
                    listChar.Add(item);
                }
            }

            return listChar;
        }
    }
}
