using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private static int charCount = 0;


        static void Main(string[] args)
        {
            var currentDir = Directory.GetCurrentDirectory();

            Count(currentDir);
            Console.WriteLine("Total:");
            Console.WriteLine("LinesBrutto: " + lineCountBrutto + " - LinesNetto: " + lineCountNetto + " - Code chars: " + charCount + " - Classes: " + classCount);


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
                int _charCount = 0;
                Console.WriteLine(name);


                var reader =  File.OpenText(name);

                var line = reader.ReadLine();
                var lineCharCount = 0;
                while (line != null)
                {
                    lineCharCount = CountValidChars(line);
                    if (lineCharCount == 0)
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
                    _charCount += lineCharCount;
                }
                Console.WriteLine("LinesBrutto: " + _lineCountBrutto + " - LinesNetto: " + _lineCountNetto + " - Code chars: " + _charCount + " - Classes: " + _classCount);
                lineCountNetto += _lineCountNetto;
                lineCountBrutto += _lineCountBrutto;
                classCount += _classCount;
                charCount += _charCount;
            }

            var dirNames = Directory.EnumerateDirectories(path);
            foreach (var name in dirNames)
            {
                Console.WriteLine("-" + name);
                Count(Path.Combine(path,name));
            }


            
        }

        static int CountValidChars(string s)
        {
            int count=0;
            for (var index = 0; index < s.Length; index++)
            {
                char c = s[index];
                char next = index + 1 < s.Length - 1 ? s[index + 1] : ' ';

                if (c == '/' && next == '/') // found comment
                {
                    return count;
                }
                if (!char.IsWhiteSpace(c))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
