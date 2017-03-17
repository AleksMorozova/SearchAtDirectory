using FileSystemSearch.ParserHelper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSearch
{
    class Program
    {
        public static string ResultFilePath { get; set; }
        public static string StartFolder { get; set; }
        static void Main(string[] args)
        {
            var options = new CommandLineArguments();
            ArgumentsValidator validator = new ArgumentsValidator();
            ValidationResult results = validator.Validate(options);

            if (results.IsValid)
            {
                CommandLine.Parser.Default.ParseArguments(args, options);
                ResultFilePath = options.ResultFile;
                StartFolder = options.StartFolder;
                Registration.Registrate(options.Type);
                var processor = new DirectoryProcessor(Registration.processor, Registration.fileWrapper);
                processor.Process(StartFolder);
                Console.WriteLine("End directory processing");
            }
            else
            {
                Console.WriteLine("Input correct parameters");
            }

            Console.ReadKey();
        }
    }
}
