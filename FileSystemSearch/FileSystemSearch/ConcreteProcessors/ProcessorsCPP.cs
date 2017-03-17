using FileSystemSearch.FileWrapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSearch.ConcreteProcessors
{
    public class ProcessorsCPP : IProcess
    {
        public void ProcessFile(string path, IFileWrapper fileWrapper)
        {
            if (Path.GetExtension(path) == ".cpp")
                fileWrapper.WriteToFile(path, Program.ResultFilePath);
        }
    }
}
