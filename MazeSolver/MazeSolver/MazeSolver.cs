using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
                        //_graph.DictionarySetUp(lines);
                        mazeNumber++;
                        List<Graph.Node<string>> resultList = SolveMaze(_graph.DictionarySetUp(lines), lines);
                        Console.WriteLine(PrintOut(mazeNumber, resultList));                     
                        list.Clear();
                        if (streamReader.EndOfStream)
                        {
                            fileStream.Close();
                        }
                    }
                }
            }
        }


        public List<Graph.Node<string>> SolveMaze(Dictionary<Graph.Node<string>, Graph.Node<string>[]> nodesAndConnections, string [] lines)
        {
            //figure out how to save the path
            
            Graph.Node<string> current = null;
            int count = 0;
            Queue<Graph.Node<string>> theQueue = new Queue<Graph.Node<string>>();
            var paths = new List<List<Graph.Node<string>>>();

            current = nodesAndConnections.Keys.FirstOrDefault(k => k.Data == lines[1].Split(',')[0]);              
            current.Visited = (++ count);
            theQueue.Enqueue(current);

            while(theQueue.Count > 0)
            {
                var path = new List<Graph.Node<string>>();

                if (!path.Contains(current))
                {
                    path.Add(current);
                }

                var currentInQueue = nodesAndConnections[current];
                foreach (var element in currentInQueue)
                {
                    if (element.Visited == 0)
                    {
                        element.Visited = ++ count;
                        theQueue.Enqueue(element);
                        if (!path.Contains(element))
                        {
                            if (element.Data != lines[1].Split(',')[1])
                            {
                                path.Add(element);
                            }
                            else
                            {
                                path.Add(element);
                                paths.Add(path);
                                break;
                            }                            
                        }
                    }
                }
                theQueue.Dequeue();
            }

            int min = paths.Select(m => m.Count).Min();

            List<Graph.Node<string>> theRightPath = paths.Where(p => p.Count == min).FirstOrDefault();

            return theRightPath;
        }

        private string PrintOut(int mazeNum, List<Graph.Node<string>> theRightPath)
        {
            string outputs = null;
            string printThis = "Maze " + mazeNum + " Solution: ";
            if (theRightPath != null)
            {
                outputs = theRightPath.Aggregate<Graph.Node<string>, string>(null,
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
