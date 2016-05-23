using AlgoDataStructures;
using System;
using System.Linq;
using System.Threading;

namespace AlgoTest
{
    class Program
    {
        //public static void Main(string[] args)
        //{
        //DoubleLinkedList<int> list = new DoubleLinkedList<int>();
        //SingleLinkedList<int> list = new SingleLinkedList<int>();
        //int index = 5;
        //Console.WriteLine("The ADD Method and toString");

        //Add Method and toString
        //list.Add(12);
        //list.Add(20);
        //list.Add(1);
        //list.Add(0);
        //list.Add(121);
        //list.Add(420);
        //list.Add(78);
        //list.Add(90);
        //list.Add(34);
        //list.Add(4);
        //Console.WriteLine(list.ToString());

        //Console.WriteLine("\nThe COUNT Method");
        //Console.WriteLine("The the count of this list is: " + list.Count);


        //Console.WriteLine("\nThe INSERT Method");
        //Console.WriteLine("I am inserting the number 22 at index: " + index);
        //list.Insert(22, index);
        //Console.WriteLine("New List: " + list.ToString());

        //Console.WriteLine("\nThe COUNT Method");
        //Console.WriteLine("The the count of this list is: " + list.Count);

        //Console.WriteLine("\nThe Get Method"); 
        //Console.WriteLine("What is at index " + index + ": " + list.Get(index));


        //Console.WriteLine("\nThe REMOVEAT Method");
        //Console.WriteLine("What is at index " + (list.Count - 1) + ": " + list.Get((list.Count - 1)));
        //Console.WriteLine("I am removing the element at index " + (list.Count - 1) + ": " + list.RemoveAt((list.Count - 1)));
        //Console.WriteLine("New List: " + list.ToString());

        //Console.WriteLine("\nThe COUNT Method");
        //Console.WriteLine("The the count of this list is: " + list.Count);

        //Console.WriteLine("\nThe INSERT Method");
        //Console.WriteLine("I am inserting the number 15 at index: " + );
        //list.Insert(15,(list.Count - 1));
        //Console.WriteLine("New List: " + list.ToString());

        //Console.WriteLine("\nThe COUNT Method");
        //Console.WriteLine("The the count of this list is: " + list.Count);

        //Console.WriteLine("\nThe SEARCH Method");
        //Console.WriteLine("Searching for 1: " + list.Search(1));

        //Console.WriteLine("\nThe REMOVE Method");
        //Console.WriteLine(list.Remove());
        //Console.WriteLine("New List: " + list.ToString());

        //Console.WriteLine("\nThe COUNT Method");
        //Console.WriteLine("The the count of this list is: " + list.Count);

        //Console.WriteLine("\nThe REMOVELAST Method");
        //Console.WriteLine(list.RemoveLast());
        //Console.WriteLine("New List: " + list.ToString());

        //Console.WriteLine("\nThe COUNT Method");
        //Console.WriteLine("The the count of this list is: " + list.Count);

        //Console.WriteLine("\nThe CLEAR Method");
        //list.Clear();
        //Console.WriteLine("New List: " + list.ToString());

        //    Console.WriteLine("\nThe REMOVEAT Method");
        //    Console.WriteLine("What is at index " + index + ": " + list.Get(index));
        //    //Console.WriteLine("I am removing the element at index " + index + ": " + list.RemoveAt(index));
        //    Console.WriteLine("New List: " + list.ToString());

        //    Console.WriteLine("\nThe COUNT Method");
        //    Console.WriteLine("The the count of this list is: " + list.Count);
        //}

        public static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);

            //bst.Add(50);
            //bst.Add(1472);
            //bst.Add(72);
            //bst.Add(1360);
            //bst.Add(1345);
            //bst.Add(54);

            //bst.Add(20);
            //bst.Add(9);
            //bst.Add(19);
            //bst.Add(14);
            //bst.Add(67);

            //bst.Add(35);
            //bst.Add(80);
            //bst.Add(65);
            //bst.Add(24);
            //bst.Add(5);

            Console.WriteLine("Count:" + bst.Count);
            //Console.WriteLine("\ncontains 24: " + bst.Contains(24));
           
            //Console.WriteLine("\ncontains 0: " + bst.Contains(0));
           
            //Console.WriteLine("\nInorder:" + bst.Inorder());

            //Console.WriteLine("\nRemove: I'm removing 17 : " + bst.Remove(17));
            Console.WriteLine("\nInorder:" + bst.Inorder());

            Console.WriteLine("\nRemove: I'm removing 24 : " + bst.Remove(24));

            //bst.Clear();

            Console.WriteLine("\nCount:" + bst.Count);         

            Console.WriteLine("\nInorder:" + bst.Inorder());
            //Console.WriteLine("\nPostorder:" + bst.Postorder());
            //Console.WriteLine("\nPreorder:" + bst.Preorder());


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
