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
            bst.Add(60);
            bst.Add(20);
            bst.Add(75);
            bst.Add(15);
            bst.Add(30);
            bst.Add(17);

            bst.Add(70);
            bst.Add(90);
            bst.Add(10);
            bst.Add(25);
            bst.Add(40);

            bst.Add(35);
            bst.Add(80);
            bst.Add(65);
            bst.Add(24);
            bst.Add(5);

            Console.WriteLine("Count:" + bst.Count());
            Console.WriteLine();
            //Console.WriteLine("contains: " + bst.Contains(20));
            //Console.WriteLine();
            //Console.WriteLine("contains: " + bst.Contains(0));
            Console.WriteLine();
            Console.WriteLine("\nInorder:" + bst.Inorder());

            Console.WriteLine();
            Console.WriteLine("\nRemove: I'm removing 90 : " + bst.Remove(90));

            Console.WriteLine();
            Console.WriteLine("\nInorder:" + bst.Inorder());

            bst.Clear();

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

            //foreach (var item in bst.ToArray())
            //{
            //    Console.WriteLine(item);
            //}

            Console.ReadLine();



        }
    }
}
