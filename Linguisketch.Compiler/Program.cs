using Linguisketch.Parser;

namespace Linguisketch.Compiler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1) 
            {
                Console.WriteLine("Please pass the path to the script to compile as the first argument.");
                return;
            }

            string scriptPath = args[0];

            if(!File.Exists(scriptPath))
            {
                Console.WriteLine($"Failed to find script at path '{scriptPath}'.");
                return;
            }

            string script = File.ReadAllText(scriptPath);

            if(string.IsNullOrEmpty(script))
            {
                Console.WriteLine($"Failed to load script from path '{scriptPath}'.");
            }

            Console.WriteLine("Parsing script..");

            var tokens = LSParser.ParseScript(script);
            var commands = LSParser.ParseCommands(tokens);

            Console.WriteLine("Finished parsing.");

            foreach (var command in commands)
            {
                Console.WriteLine($"Command: {command.Command.Value}");
                Console.WriteLine($"Args: {string.Join(',', command.Args.Select(arg => arg.Value))}");
            }
        }
    }
}