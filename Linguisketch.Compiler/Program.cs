using ImageMagick;
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

            Console.WriteLine("Drawing image..");

            using var image = new MagickImage(new MagickColor("#ffffff"), 256, 256);
            var currentPoint = new PointD(0, 0);

            IDrawables<ushort> drawables = new Drawables();

            bool hasErrors = false;

            foreach(var command in commands)
            {
                switch(command.Command.Value.ToLower())
                {
                    case "fillcolor":
                        if(command.Args.Count < 1 ||
                            command.Args.Count > 1)
                        {
                            Console.WriteLine($"There was an error on line: {command.Command.LineNumber}");
                            Console.WriteLine("FillColor expects 1 argument.");
                            hasErrors = true;
                            break;
                        }
                        string fillColor = command.Args[0].Value;
                        drawables = drawables.FillColor(new MagickColor(fillColor));
                        break;

                    case "strokecolor":
                        if (command.Args.Count < 1 ||
                            command.Args.Count > 1)
                        {
                            Console.WriteLine($"There was an error on line: {command.Command.LineNumber}");
                            Console.WriteLine("StrokeColor expects 1 argument.");
                            hasErrors = true;
                            break;
                        }
                        string strokeColor = command.Args[0].Value;
                        drawables = drawables.StrokeColor(new MagickColor(strokeColor));
                        break;

                    case "line":
                        if (command.Args.Count < 2 ||
                            command.Args.Count > 2)
                        {
                            Console.WriteLine($"There was an error on line: {command.Command.LineNumber}");
                            Console.WriteLine("Line expects 2 arguments.");
                            hasErrors = true;
                            break;
                        }
                        double x = double.Parse(command.Args[0].Value);
                        double y = double.Parse(command.Args[1].Value);

                        drawables = drawables.Line(currentPoint.X, currentPoint.Y, x, y);
                        currentPoint = new PointD(x, y);
                        break;

                    case "fill":
                        if (command.Args.Count < 4 || 
                            command.Args.Count > 4)
                        {
                            Console.WriteLine($"There was an error on line: {command.Command.LineNumber}");
                            Console.WriteLine("Fill expects 4 argument.");
                            hasErrors = true;
                            break;
                        }
                        double x1 = double.Parse(command.Args[0].Value);
                        double y1 = double.Parse(command.Args[1].Value);
                        double x2 = double.Parse(command.Args[2].Value);
                        double y2 = double.Parse(command.Args[3].Value);

                        drawables = drawables.Rectangle(x1, y1, x2, y2);
                        break;
                }
            }

            if(hasErrors)
            {
                Console.WriteLine("Failed compile.");
                return;
            }

            image.Draw(drawables);

            Console.WriteLine("Finished drawing.");

            var outputName = Path.GetRandomFileName();

            Console.WriteLine($"Saving output as: '{outputName}.png'.");

            image.Write($"{outputName}.png");
        }
    }
}