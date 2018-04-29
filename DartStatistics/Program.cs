using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DartStatistics
{
    

    class Program
    {
        private static int lineCountNetto  = 0;
        private static int lineCountBrutto = 0;
        private static int classCount = 0;
        
        static void Main(string[] args)
        {
            var currentDir = Directory.GetCurrentDirectory();

            Count(currentDir);
            Console.WriteLine("Total:");
            Console.WriteLine("LinesBrutto: " + lineCountBrutto + " - LinesNetto: " + lineCountNetto + " - Classes: " + classCount);


            Console.ReadLine();
        }

        static void Count(string path)
        {
            var fileNames = Directory.EnumerateFiles(path);
            foreach (var name in fileNames)
            {
                int _lineCountBrutto = 0;
                int _lineCountNetto = 0;
                int _classCount = 0;
                Console.WriteLine(name);

                var reader =  File.OpenText(name);

                var line = reader.ReadLine();
                while (line != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        lineCountBrutto++;
                    }
                    else
                    {
                        _lineCountBrutto++;
                        _lineCountNetto++;
                        if (line.Contains("class"))
                        {
                            _classCount++;
                        }
                    }
                    line = reader.ReadLine();
                }
                Console.WriteLine("LinesBrutto: " + _lineCountBrutto + " - LinesNetto: " + _lineCountNetto + " - Classes: " + _classCount);
                lineCountNetto += _lineCountNetto;
                lineCountBrutto += _lineCountBrutto;
                classCount += _classCount;
            }

            var dirNames = Directory.EnumerateDirectories(path);
            foreach (var name in dirNames)
            {
                Console.WriteLine("-" + name);
                Count(Path.Combine(path,name));
            }


            
        }
    }
}
