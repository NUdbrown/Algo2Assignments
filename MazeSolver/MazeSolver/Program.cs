using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    /// <summary>
    ///     read a text file called maze.txt that has the adjacency list of an undirected graph.
    ///     first line of the list contains the names of all the nodes.
    ///     second line contains two nodes, indicating the start and end of the maze (in that order).
    ///     Each additional line contains a node in the graph followed by each node to which it is adjacent.
    ///     the nodes are comma-separated.
    ///     may contain multiple mazes, each separated by a blank line.
    ///     possible for: dead ends & have loops.
    /// </summary>
    internal class Program
    {
        public static void Main(string[] args)
        {
            //read in the file from args

            var list = new List<string>();
            var fileStream = new FileStream(args[0], FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                
                while (fileStream.CanRead)
                {

                    line = streamReader.ReadLine();
                    list.Add(line);
                    if (line == String.Empty)
                    {
                        list.Remove(list[list.Count - 1]);
                    }
                }
            }

            var lines = list.ToArray();
            
            SolveMaze(lines);
        }

        //read & get & save list of nodes ... split based off comma
        //read & get & save the beginning and end of maze ... split based off comma

        /*create dictionary based off of what a given node is connected to
        by reading the next lines until a blank new line is detected.
        */

        /**
        1. start at the starting node
        2. compare it to the connections of the next node.
        3. if same then current val go to next value
        4. add new value if not the same
        5. print list 
        **/
        public static string SolveMaze(string[] lines)
        {
            var keepTrack = SeparationOfConnections(lines);
            string[] beginend = lines[1].Split(',');
            var start = beginend.ElementAt(0);
            var end = beginend.ElementAt(1);
            var output = new List<string>();
            bool foundPath = false;

            while (!foundPath)
            {
                output.Add(start);
                for (int i = 0; i <= keepTrack.Count - 1; i++)
                {
                    
                }
            }

            return PrintOut(output) + end;
        }

        private static string PrintOut(List<string> outputs)
        {
            return outputs.Aggregate("", (current, item) => current + item);
        }

        //separates the connections
        private static Dictionary<string, List<string>> SeparationOfConnections(string[] lines)
        {
            var keepTrack = new Dictionary<string, List<string>>();
            string[] keys = lines[0].Split(',');
            string[] connections = new string[] { };

            for (var i = 2; i < lines.Length; i++)
            {
                //take a first letter because its the key, save the other letters
                connections = lines[i].Split(',');

                var letterToRemove = connections.ElementAt(0);
                Console.WriteLine("\nLetter Removed: " + letterToRemove);

                connections = connections.Where(val => val != letterToRemove).ToArray();

                foreach (var command in connections)
                {
                    Console.WriteLine(command);
                }
            }

            //add those letters to their matching key
            for (int j = 0; j <= keys.Length - 1; j++)
            {
                keepTrack.Add(keys.ElementAt(j), connections.ToList());
            }

            Console.ReadLine();
            //return the connections
            return keepTrack;
        }
    }
}
