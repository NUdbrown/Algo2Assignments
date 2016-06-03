using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect
{
    public class Network
    {
        public static void Main(string[] args)
        {
            Network network = new Network();
            Console.WriteLine("Please type in the location of the text file containing the network data: ");
            string filePath = Console.ReadLine();
            network.Run(filePath);

        }

        public void Run(string filePath)
        {
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
                }
            }

        }
    }
}
