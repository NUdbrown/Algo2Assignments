using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AlgoDataStructure;

namespace AlgoTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            //SingleLinkedList<int> list = new SingleLinkedList<int>();
            int index = 7;
            Console.WriteLine("The ADD Method and toString");

            //Add Method and toString
            list.Add(12);
            list.Add(20);
            list.Add(1);
            list.Add(0);
            list.Add(121);
            list.Add(420);
            list.Add(78);
            list.Add(90);
            list.Add(34);
            list.Add(4);
            Console.WriteLine(list.ToString());

            Console.WriteLine("\nThe COUNT Method");
            Console.WriteLine("The the count of this list is: " + list.Count());


            Console.WriteLine("\nThe INSERT Method");
            Console.WriteLine("I am inserting the number 51 at index: " + index);
            list.Insert(51, index);
            Console.WriteLine("New List: " + list.ToString());

            Console.WriteLine("\nThe Get Method");
            Console.WriteLine("What is at index " + index + ": " + list.Get(index));

            //Console.WriteLine("\nThe REMOVEAT Method");
            //Console.WriteLine("What is at index " + index + ": " + list.Get(index));
            //Console.WriteLine("I am removing the element at index " + index + ": " + list.RemoveAt(index));
            //Console.WriteLine("New List: " + list.ToString());

            //Console.WriteLine("\nThe COUNT Method");
            //Console.WriteLine("The the count of this list is: " + list.Count());

            Console.WriteLine("\nThe SEARCH Method");
            Console.WriteLine("Searching for 51: " + list.Search(51));

            //Console.WriteLine("\nThe REMOVE Method");
            //Console.WriteLine(list.Remove());
            //Console.WriteLine("New List: " + list.ToString());

            //Console.WriteLine("\nThe COUNT Method");
            //Console.WriteLine("The the count of this list is: " + list.Count());

            //Console.WriteLine("\nThe REMOVELAST Method");
            //Console.WriteLine(list.RemoveLast());
            //Console.WriteLine("New List: " + list.ToString());

            //Console.WriteLine("\nThe COUNT Method");
            //Console.WriteLine("The the count of this list is: " + list.Count());


            //Console.WriteLine("\nThe Get Method");
            //Console.WriteLine("What is at index  7: " + list.Get(7));

            Console.WriteLine("\nThe CLEAR Method");
            list.Clear();
            Console.WriteLine("New List: " + list.ToString());

        }
        //static void Main(string[] args)
        //{
        //    BinarySearchTree<int> bst = new BinarySearchTree<int>();

        //    bst.Add(24);
        //    bst.Add(10);
        //    bst.Add(1337);

        //    bst.Add(50);
        //    bst.Add(17);
        //    bst.Add(72);
        //    //bst.Add(12);
        //    //bst.Add(23);
        //    //bst.Add(54);

        //    //bst.Add(76);
        //    bst.Add(9);
        //    //bst.Add(14);
        //    //bst.Add(19);
        //    //bst.Add(67);

        //    //bst.Add(35);
        //    //bst.Add(80);
        //    //bst.Add(65);
        //    //bst.Add(24);
        //    //bst.Add(5);

        //    Console.WriteLine("Count:" + bst.Count());
        //    Console.WriteLine();
        //    //Console.WriteLine("contains: " + bst.Contains(20));
        //    //Console.WriteLine();
        //    //Console.WriteLine("contains: " + bst.Contains(0));
        //    //Console.WriteLine();
        //    Console.WriteLine("\nInorder:" + bst.Inorder());

        //    //Console.WriteLine();
        //    //Console.WriteLine("\nRemove: I'm removing 17 : " + bst.Remove(17));

        //    Console.WriteLine();
        //    Console.WriteLine("\nInorder:" + bst.Inorder());

        //    Console.WriteLine("\nRemove: I'm removing 24 : " + bst.Remove(24));

        //    //bst.Clear();

        //    Console.WriteLine("Count:" + bst.Count());
        //    Console.WriteLine();

        //    Console.WriteLine();
        //    Console.WriteLine("\nInorder:" + bst.Inorder());
        //    Console.WriteLine("\nPostorder:" + bst.Postorder());
        //    Console.WriteLine("\nPreorder:" + bst.Preorder());


        //    //Console.WriteLine();
        //    //Console.WriteLine("\nPreorder:" + bst.Preorder());

        //    //Console.WriteLine();
        //    //Console.WriteLine("\nPostorder:" + bst.Postorder());

        //    foreach (var item in bst.ToArray())
        //    {
        //        Console.WriteLine(item);
        //    }

        //    Console.ReadLine();



        //}
    }
}
