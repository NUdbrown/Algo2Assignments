using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDataStructure;

namespace AlgoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);

            bst.Add(50);
            bst.Add(17);
            bst.Add(72);
            //bst.Add(12);
            //bst.Add(23);
            //bst.Add(54);

            //bst.Add(76);
            bst.Add(9);
            //bst.Add(14);
            //bst.Add(19);
            //bst.Add(67);

            //bst.Add(35);
            //bst.Add(80);
            //bst.Add(65);
            //bst.Add(24);
            //bst.Add(5);

            Console.WriteLine("Count:" + bst.Count());
            Console.WriteLine();
            //Console.WriteLine("contains: " + bst.Contains(20));
            //Console.WriteLine();
            //Console.WriteLine("contains: " + bst.Contains(0));
            //Console.WriteLine();
            Console.WriteLine("\nInorder:" + bst.Inorder());

            //Console.WriteLine();
            //Console.WriteLine("\nRemove: I'm removing 17 : " + bst.Remove(17));

            Console.WriteLine();
            Console.WriteLine("\nInorder:" + bst.Inorder());

            Console.WriteLine("\nRemove: I'm removing 24 : " + bst.Remove(24));

            //bst.Clear();

            Console.WriteLine("Count:" + bst.Count());
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("\nInorder:" + bst.Inorder());
            Console.WriteLine("\nPostorder:" + bst.Postorder());
            Console.WriteLine("\nPreorder:" + bst.Preorder());


            //Console.WriteLine();
            //Console.WriteLine("\nPreorder:" + bst.Preorder());

            //Console.WriteLine();
            //Console.WriteLine("\nPostorder:" + bst.Postorder());

            foreach (var item in bst.ToArray())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();



        }
    }
}
