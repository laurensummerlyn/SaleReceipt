using System;
using System.IO;

namespace Directories
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter directory path");
            string pat = Console.ReadLine();

            foreach (string path in args)
            {
                if (File.Exists(path))
                {
                    ProcessFile(path);
                }
                else if (Directory.Exists(path))
                {
                    ProcessDirectory(path);
                }
                else
                {
                    Console.WriteLine($"{path} is not a valid file or directory.");
                }
            }

            DirectoryInfo di = new DirectoryInfo(pat);
            foreach (var fi in di.GetFiles())
            {
                Console.WriteLine(fi.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Search pattern *2* returns :\n");
            foreach (var fi in di.GetFiles("*2*"))
            {
                Console.WriteLine(fi.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Search pattern test?.txt returns :\n");
            foreach (var fi in di.GetFiles("test?.txt"))
            {
                Console.WriteLine(fi.Name);
            }

            Console.WriteLine();

            Console.WriteLine("Search pattern AllDirectories returns:\n");
            foreach (var fi in di.GetFiles("*", SearchOption.AllDirectories))
            {
                Console.WriteLine(fi.Name);
            }

        }

        private static void ProcessDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);
        }

        private static void ProcessFile(string path)
        {
            Console.WriteLine($"Processed file '{path}");
        }
    }
    
}
