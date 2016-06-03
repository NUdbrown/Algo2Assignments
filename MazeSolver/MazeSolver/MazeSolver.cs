using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class MazeSolver
    {
        private readonly Graph<string> _graph = new Graph<string>();
        private List<List<Graph<string>.Node<string>>> collection = new List<List<Graph<string>.Node<string>>>();

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
            int mazeNumber = 0;
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                var list = new List<string>();
                while (fileStream.CanRead)
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
                        _graph.DictionaryCreation(lines);
                        _graph.SetConnections(lines);
                        // PrintTheDictionary();
                        mazeNumber++;
                        Console.WriteLine(PrintOut(mazeNumber, SolveMaze(lines)));
                        Console.WriteLine();
                        list.Clear();
                        if (streamReader.EndOfStream)
                        {
                            fileStream.Close();
                        }
                    }
                }
            }
        }

        public void PrintTheDictionary()
        {
            foreach (var value in _graph.Dictionary.Values)
            {
                Console.WriteLine("Value: " + value.Data);
                foreach (var connections in value.ConnectedNodes)
                {
                    Console.WriteLine("Connection: " + connections.Data);
                }
            }
        }

        public List<Graph<string>.Node<string>> SolveMaze(string[] lines)
        {
            //Queue<Graph<string>.Node<string>> theQueue = new Queue<Graph<string>.Node<string>>();
            var paths = new List<List<Graph<string>.Node<string>>>();
            var path = new List<Graph<string>.Node<string>>();
            //figure out how to save the path

            Graph<string>.Node<string> current = null;
            //int count = 0;
            var endNode = _graph.Dictionary[lines[1].Split(',')[1]];
            current = _graph.Dictionary[lines[1].Split(',')[0]];
            path.Add(current);

            foreach (var connectedNode in current.ConnectedNodes)
            {
                    path.Add(connectedNode);
                    paths.Add(RecursiveMethod(path, endNode));  
            }

            if (paths.ElementAt(0) == null)
            {
                return null;
            }
            else
            {
                int min = paths.Select(m => m.Count).Min();

                List<Graph<string>.Node<string>> theRightPath = paths.Where(p => p.Count == min).FirstOrDefault();

                return theRightPath;
            }

        }

        public List<Graph<string>.Node<string>> RecursiveMethod(List<Graph<string>.Node<string>> path, Graph<string>.Node<string> endNode)
        {
            if (path.ElementAt(path.Count - 1) != endNode)
            {
                foreach (var current in path.ElementAt(path.Count - 1).ConnectedNodes)
                {
                    if (!path.Contains(current))
                    {
                        if (current != endNode)
                        {
                            if (current.ConnectedNodes.Contains(endNode))
                            {
                                path.Add(current);
                                //Make a copy of the list for the next recursive call
                                var newlist = path.ToList();
                                //Save the path returned from the recursion
                                var childpath = RecursiveMethod(newlist, endNode);
                                //If childPath is not null, save it to the collection of paths (which you still need)
                                //Find the shortest path and return it.
                                if (childpath != null)
                                {
                                    collection.Add(childpath);
                                    if (collection.Count > 0)
                                    {
                                        int min = collection.Select(m => m.Count).Min();
                                        return collection.FirstOrDefault(p => p.Count == min);
                                    }
                                }

                            }    
                        }
                        else
                        {
                            path.Add(current);
                            return path;
                        }
                    }

                }

            }
            return null;
        }

        private string PrintOut(int mazeNum, List<Graph<string>.Node<string>> theRightPath)
        {
            string outputs = null;
            string printThis = "Maze " + mazeNum + " Solution: ";
            if (theRightPath != null)
            {
                outputs = theRightPath.Aggregate<Graph<string>.Node<string>, string>(null,
                    (current, node) => current + node.Data);

            }
            else
            {
                outputs = "No Solution";
            }
            return printThis + outputs;
        }


    }
}
