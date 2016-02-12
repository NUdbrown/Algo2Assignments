using System;
using System.IO;
using System.Linq;

namespace MazeSolver
{
    /// <summary>
    /// read a text file called maze.txt that has the adjacency list of an undirected graph.
    /// first line of the list contains the names of all the nodes.
    /// second line contains two nodes, indicating the start and end of the maze (in that order). 
    /// Each additional line contains a node in the graph followed by each node to which it is adjacent. 
    /// the nodes are comma-separated. 
    /// may contain multiple mazes, each separated by a blank line. 
    /// possible for: dead ends & have loops.
    /// </summary>
    class Program
    {
        public static void Main(string[] args)
        {
            //read in the file from args
            string line;
            var file = new StreamReader(args[0]);
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                
            }
            Console.ReadLine();
            file.Close();
            
            SolveMaze();
        }

        public static void SolveMaze()
        {
            //read & get & save list of nodes ... split based off comma
            //read & get & save the beginning and end of maze ... split based off comma

            /*create dictionary based off of what a given node is connected to
            by reading the next lines until a blank new line is detected.
            */




        }
    }
}
