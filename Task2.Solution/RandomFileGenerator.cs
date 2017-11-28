using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Solution
{
    public abstract class RandomFileGenerator
    {
        public abstract string WorkingDirectory { get; }
        public abstract string FileExtension { get; }
        public abstract void GenerateFiles(int filesCount, int contentLength);
        protected abstract byte[] GenerateFileContent(int contentLength);
        protected abstract void WriteBytesToFile(string fileName, byte[] content);
    }
}
