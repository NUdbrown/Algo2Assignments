using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            string[] names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };

            Console.WriteLine(p.WhoIsNext(names, 7230702951));
            Console.ReadLine();

        }

        public string WhoIsNext(string[] names, long n)
        {
            Queue<string> namesAsQueue = new Queue<string>(names);
            string temp = null;
            for (long i = 1; i <= n; i++)
            {
                if (i == n)
                    return namesAsQueue.Dequeue();
                temp = namesAsQueue.Dequeue();
                namesAsQueue.Enqueue(temp);
                namesAsQueue.Enqueue(temp); 
            }

            return null;
        }
    }
}
