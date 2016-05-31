using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class MazeSolver
    {
        private readonly Graph _graph = new Graph();

        public static void Main(string[] args)
        {
            //read in the file from args
            MazeSolver ms = new MazeSolver();

            Console.WriteLine("Please type in the location of a file that has the adjacency list of an undirected graph: ");
            string filePath = Console.ReadLine();

            ms.ReadMazeFile(filePath);

        }

        public void ReadMazeFile(string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
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
                        //SolveMaze(lines);
                        list = new List<string>();
                        _graph.DictionarySetUp(lines);
                    }
                }
            }
        }


        public string SolveMaze(Dictionary<Graph.Node<string>, Graph.Node<string>[]> dictionary)
        {
            //figure out how to save the path
            var nodesAndConnections = dictionary;
            




            return null;
        }

        private static string PrintOut(List<string> outputs)
        {
            return outputs.Aggregate("", (current, item) => current + item);
        }

        //getting the keys
      
        
    }
}
