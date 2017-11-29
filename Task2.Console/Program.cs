using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Solution;

namespace Task2.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var charsGen = new RandomCharsFileGenerator();
            charsGen.GenerateFiles(2, 20);

            var bytesGen = new RandomBytesFileGenerator();
            bytesGen.GenerateFiles(3, 30);

            var txtFiles = Directory.GetFiles(charsGen.WorkingDirectory, "*.txt");
            foreach (var file in txtFiles)
            {
                System.Console.WriteLine("txt file length: " + new FileInfo(file).Length);
            }

            var bytesFiles = Directory.GetFiles(bytesGen.WorkingDirectory, "*.bytes");
            foreach (var file in bytesFiles)
            {
                System.Console.WriteLine("bytes file length: " + new FileInfo(file).Length);
            }

            System.Console.Read();
        }
    }
}
