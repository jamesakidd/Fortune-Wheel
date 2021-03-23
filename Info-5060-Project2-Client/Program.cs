using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info_5060_Project2_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> intLL = new LinkedList<int>();

            intLL.AddLast(1);
            intLL.AddLast(2);
            intLL.AddLast(3);
            intLL.AddLast(4);
            intLL.AddLast(5);

            IEnumerator<int> e = intLL.GetEnumerator();
            for (int i = 0; i < 20; i++)
            {
                if (e.MoveNext())
                {
                    Console.WriteLine(e.Current);
                }
                else
                {
                    e.Reset();
                    e.MoveNext();
                    Console.WriteLine(e.Current);
                }
            }


            Console.ReadKey();
            e.Dispose();
        }
    }
}
