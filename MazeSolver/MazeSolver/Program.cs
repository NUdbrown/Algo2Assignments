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
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            var lines = list.ToArray();

            var p = new Program();
            p.SolveMaze(lines);
        }

        //read & get & save list of nodes ... split based off comma
        //read & get & save the beginning and end of maze ... split based off comma

        /*create dictionary based off of what a given node is connected to
        by reading the next lines until a blank new line is detected.
        */


        public void SolveMaze(string[] lines)
        {
            var keepTrack = new Dictionary<string, List<string>>();
            string[] keys = lines[0].Split(',');
            string[] beginend = lines[1].Split(',');
            string[] commands;
            var connects = new List<string>();
            
            var start = beginend.ElementAt(0);
            var end = beginend.ElementAt(1);


            for (var i = 2; i < lines.Length; i++)
            {
                //take a first letter because its the key, save the other letters
                commands = lines[i].Split(',');
                var letterToRemove = commands.ElementAt(0);
                commands = commands.Where(val => val != letterToRemove).ToArray();
                connects.AddRange(commands);
  
                //add those letters to their matching key
                
                for (int j = 0; j <= keys.Length-1; j++)
                {
                    keepTrack.Add(keys.ElementAt(j), connects);
                }
                    //testing purposes
                    foreach (var reveal in keepTrack)
                    {
                        Console.WriteLine(reveal.Key + ": " + reveal.Value);
                    }
            }

            Console.Read();
            
        }
    }
}
