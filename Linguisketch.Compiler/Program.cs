using ImageMagick;

using Linguisketch.Parser;

namespace Linguisketch.Compiler
{
    internal class Program
    {
        private static Dictionary<string, Func<LSCommand, IDrawables<ushort>, CommandResult>> handlers = new()
        {
            { "fillcolor", FunctionHandlers.HandleFillColorCommand },
            { "strokecolor", FunctionHandlers.HandleStrokeColorCommand },
            { "line", FunctionHandlers.HandleLineCommand },
            { "fill", FunctionHandlers.HandleFillCommand }
        };

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

            Console.WriteLine("Compiling commands..");

            using var image = new MagickImage(new MagickColor("#ffffff"), 256, 256);
            var currentPoint = new PointD(0, 0);

            IDrawables<ushort> drawables = new Drawables();

            bool hasErrors = false;
            List<CommandResult> errors = new();

            foreach (var command in commands)
            {
                var cmd = command.Command.Value.ToLower();

                var result = handlers[cmd].Invoke(command, drawables);

                if (result.Status == CommandStatus.Failed)
                {
                    errors.Add(result);
                    hasErrors = true;
                }
            }

            if(hasErrors)
            {
                Console.WriteLine("Errors occured during the compilation process.");
                foreach(var error in errors)
                {
                    Console.WriteLine($"Line {error.ErrorLineNumber}: {error.ErrorMessage}");
                }
                return;
            }

            image.Draw(drawables);

            Console.WriteLine("Finished compiling.");

            var outputName = Path.GetRandomFileName();

            Console.WriteLine($"Saving output as: '{outputName}.png'.");

            image.Write($"{outputName}.png");
        }
    }
}