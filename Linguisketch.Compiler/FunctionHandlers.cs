using ImageMagick;

using Linguisketch.Parser;

namespace Linguisketch.Compiler
{
    public class FunctionHandlers
    {
        public static CommandResult HandleStrokeColorCommand(LSCommand command, IDrawables<ushort> drawables)
        {
            if (command.Args.Count < 1 ||
                command.Args.Count > 1)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "StrokeColor command expects 1 argument."
                };
            }
            string strokeColor = command.Args[0].Value;
            drawables = drawables.StrokeColor(new MagickColor(strokeColor));

            return new CommandResult() 
            { 
                Status = CommandStatus.Success
            };
        }
        public static CommandResult HandleFillColorCommand(LSCommand command, IDrawables<ushort> drawables)
        {
            if (command.Args.Count < 1 ||
                command.Args.Count > 1)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "FillColor command expects 1 argument."
                };
            }

            string fillColor = command.Args[0].Value;
            drawables = drawables.FillColor(new MagickColor(fillColor));

            return new CommandResult() 
            { 
                Status = CommandStatus.Success
            };
        }

        public static CommandResult HandleLineCommand(LSCommand command, IDrawables<ushort> drawables)
        {
            if (command.Args.Count < 4 ||
                command.Args.Count > 4)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Line command expects 4 arguments."
                };
            }

            double x1 = double.Parse(command.Args[0].Value);
            double y1 = double.Parse(command.Args[1].Value);
            double x2 = double.Parse(command.Args[2].Value);
            double y2 = double.Parse(command.Args[3].Value);

            drawables = drawables.Line(x1, y1, x2, y2);

            return new CommandResult() 
            { 
                Status = CommandStatus.Success
            };
        }
        public static CommandResult HandleFillCommand(LSCommand command, IDrawables<ushort> drawables)
        {
            if (command.Args.Count < 4 ||
                command.Args.Count > 4)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Fill command expects 4 arguments."
                };
            }

            double x1 = double.Parse(command.Args[0].Value);
            double y1 = double.Parse(command.Args[1].Value);
            double x2 = double.Parse(command.Args[2].Value);
            double y2 = double.Parse(command.Args[3].Value);

            drawables = drawables.Rectangle(x1, y1, x2, y2);

            return new CommandResult() 
            { 
                Status = CommandStatus.Success
            };
        }
    }
}
