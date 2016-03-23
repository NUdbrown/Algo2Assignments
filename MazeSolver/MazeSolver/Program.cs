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

            var fileStream = new FileStream(args[0], FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {

                var list = new List<string>();
                while (!streamReader.EndOfStream)
                {
                    var line = "";
                    line = streamReader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        list.Add(line);
                    }
                    else
                    {
                        var lines = list.ToArray();
                        SolveMaze(lines);
                        list = new List<string>();
                    }




                }
            }


            //SeparationOfConnections(lines);

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
            string[] beginend = lines[0].Split(',');
            var start = beginend.ElementAt(0);
            var end = beginend.ElementAt(1);
            var output = new List<string>();
            //bool foundPath = false;
            output.Add(start);

            //while (!foundPath)
            //{
            //get the first value in the keys list, check if its a key and add it to the output
            //keep checking the values until you've reached the end 

            for (int i = 0; i <= keepTrack.Keys.Count - 1; i++)
            {
                string[] valueToGet;
                string key = keepTrack.Keys.ElementAt(i);
                keepTrack.TryGetValue(key, out valueToGet);
                int whichValue = 0;

                if (valueToGet != null)
                {
                    if ((valueToGet.Length == 1 && !output.Contains(valueToGet.ElementAt(whichValue))))
                    {
                        output.Add(valueToGet.ElementAt(whichValue));
                        Console.WriteLine("I just added: " + valueToGet.ElementAt(whichValue));
                    }
                    else if (!output.Contains(valueToGet.ElementAt(whichValue)) && !output.Contains(end))
                    {

                    }
                }

                return PrintOut(output);


            }



            // }

            return PrintOut(output) + end;
        }

        private static string PrintOut(List<string> outputs)
        {
            return outputs.Aggregate("", (current, item) => current + item);
        }

        //separates the connections
        private static Dictionary<string, string[]> SeparationOfConnections(string[] lines)
        {
            var keepTrack = new Dictionary<string, string[]>();
            string[] keys = lines[0].Split(',');

            for (var i = 2; i < lines.Length; i++)
            {
                //take a first letter because its the key, save the other letters
                string [] connections = lines[i].Split(',');

                var letterToRemove = connections.ElementAt(0);
                Console.WriteLine("\nLetter Removed: " + letterToRemove);

                connections = connections.Where(val => val != letterToRemove).ToArray();

                foreach (var command in connections)
                {
                    Console.WriteLine(command);
                }

               keepTrack.Add(keys[i-2], connections);
                
            }
            //add those letters to their matching key

           // PrintKeepTrack(keepTrack);

            return keepTrack;
        }

        //private static void PrintKeepTrack(Dictionary<string, string[]> keyPair)
        //{
        //    string items = "";
        //    foreach (var pair in keyPair)
        //    {
        //        Console.WriteLine("Key: " + pair.Key + " Values:" + pair.Value);
        //    }
        //}
    }
}
