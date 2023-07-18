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

            var arg1 = command.Args[0].Value;
            if(arg1 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "StrokeColor argument 1 is null."
                };
            }

            drawables = drawables.StrokeColor(new MagickColor(arg1));

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

            var arg1 = command.Args[0].Value;
            if (arg1 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "FillColor argument 1 is null."
                };
            }

            drawables = drawables.FillColor(new MagickColor(arg1));

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

            var arg1 = command.Args[0].Value;
            var arg2 = command.Args[1].Value;
            var arg3 = command.Args[2].Value;
            var arg4 = command.Args[3].Value;

            if (arg1 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Line argument 1 is null."
                };
            }

            if (arg2 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Line argument 1 is null."
                };
            }

            if (arg3 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Line argument 1 is null."
                };
            }

            if (arg4 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Line argument 1 is null."
                };
            }

            if(!double.TryParse(arg1, out double x1))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Line argument 1 is not a valid number."
                };
            }

            if (!double.TryParse(arg2, out double y1))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Line argument 2 is not a valid number."
                };
            }

            if (!double.TryParse(arg3, out double x2))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Line argument 3 is not a valid number."
                };
            }

            if (!double.TryParse(arg4, out double y2))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Line argument 4 is not a valid number."
                };
            }

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

            var arg1 = command.Args[0].Value;
            var arg2 = command.Args[1].Value;
            var arg3 = command.Args[2].Value;
            var arg4 = command.Args[3].Value;

            if (arg1 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Fill argument 1 is null."
                };
            }

            if (arg2 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Fill argument 1 is null."
                };
            }

            if (arg3 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Fill argument 1 is null."
                };
            }

            if (arg4 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Fill argument 1 is null."
                };
            }

            if (!double.TryParse(arg1, out double x1))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Fill argument 1 is not a valid number."
                };
            }

            if (!double.TryParse(arg2, out double y1))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Fill argument 2 is not a valid number."
                };
            }

            if (!double.TryParse(arg3, out double x2))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Fill argument 3 is not a valid number."
                };
            }

            if (!double.TryParse(arg4, out double y2))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Fill argument 4 is not a valid number."
                };
            }

            drawables = drawables.Rectangle(x1, y1, x2, y2);

            return new CommandResult() 
            { 
                Status = CommandStatus.Success
            };
        }

        public static CommandResult HandleTextSizeCommand(LSCommand command, IDrawables<ushort> drawables)
        {
            if (command.Args.Count < 1 ||
                command.Args.Count > 1)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "TextSize command expects 1 argument."
                };
            }

            var arg1 = command.Args[0].Value;

            if(arg1 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "TextSize argument 1 is null."
                };
            }

            if(!double.TryParse(arg1, out double fontSize))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Fill argument 1 is not a valid number."
                };
            }

            drawables = drawables.FontPointSize(fontSize);

            return new CommandResult()
            {
                Status = CommandStatus.Success
            };
        }

        public static CommandResult HandleTextAlignCommand(LSCommand command, IDrawables<ushort> drawables)
        {
            if (command.Args.Count < 1 ||
                command.Args.Count > 1)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "TextAlign command expects 1 argument."
                };
            }

            var arg1 = command.Args[0].Value;

            if (arg1 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "TextAlign argument 1 is null."
                };
            }

            switch(arg1)
            {
                case "left":
                    drawables.TextAlignment(TextAlignment.Left);
                    break;

                case "right":
                    drawables.TextAlignment(TextAlignment.Right);
                    break;

                case "center":
                    drawables.TextAlignment(TextAlignment.Center);
                    break;

                default:
                    return new CommandResult()
                    {
                        Status = CommandStatus.Failed,

                        ErrorLineNumber = command.Command.LineNumber,
                        ErrorMessage = $"Unknown TextAlign '{arg1}'."
                    };
            }

            return new CommandResult()
            {
                Status = CommandStatus.Success
            };
        }

        public static CommandResult HandleTextCommand(LSCommand command, IDrawables<ushort> drawables)
        {
            if (command.Args.Count < 3)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Text command expects at least 3 arguments."
                };
            }

            var arg1 = command.Args[0].Value;
            var arg2 = command.Args[1].Value;
            var arg3 = command.Args.Skip(2).Select(arg => arg.Value);

            if (arg1 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Text argument 1 is null."
                };
            }

            if (arg2 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Text argument 2 is null."
                };
            }

            if (arg3 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Text argument 3 is null."
                };
            }

            if (!double.TryParse(arg1, out double x))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Text argument 1 is not a valid number."
                };
            }


            if (!double.TryParse(arg2, out double y))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Text argument 1 is not a valid number."
                };
            }

            var text = string.Join(' ', arg3);

            drawables.EnableTextAntialias();
            drawables = drawables.Text(x, y, text);

            return new CommandResult()
            {
                Status = CommandStatus.Success
            };
        }

        public static CommandResult HandleSizeCommand(LSCommand? command, ref MagickImage? image)
        {
            if(command is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = null,
                    ErrorMessage = "Missing size command."
                };
            }

            if (command.Args.Count < 2 ||
                command.Args.Count > 2)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Size command expects 2 arguments."
                };
            }

            var arg1 = command.Args[0].Value;
            var arg2 = command.Args[1].Value;

            if (arg1 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Size argument 1 is null."
                };
            }

            if (arg2 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Size argument 2 is null."
                };
            }

            if (!int.TryParse(arg1, out int width))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Size argument 1 is not a valid number."
                };
            }

            if (!int.TryParse(arg2, out int height))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Size argument 2 is not a valid number."
                };
            }

            image = new MagickImage(new MagickColor("#ffffff"), width, height);

            return new CommandResult()
            {
                Status = CommandStatus.Success
            };
        }

        public static CommandResult HandleImageCommand(LSCommand command, IDrawables<ushort> drawables)
        {
            if (command.Args.Count < 3)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Image command expects at least 3 arguments."
                };
            }

            var arg1 = command.Args[0].Value;
            var arg2 = command.Args[1].Value;
            var arg3 = command.Args[2].Value;

            if (arg1 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Image argument 1 is null."
                };
            }

            if (arg2 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Image argument 2 is null."
                };
            }

            if (arg3 is null)
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Image argument 3 is null."
                };
            }

            if (!double.TryParse(arg1, out double x))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Image argument 1 is not a valid number."
                };
            }


            if (!double.TryParse(arg2, out double y))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = "Image argument 1 is not a valid number."
                };
            }

            var path = arg3;
            if(!File.Exists(path))
            {
                return new CommandResult()
                {
                    Status = CommandStatus.Failed,

                    ErrorLineNumber = command.Command.LineNumber,
                    ErrorMessage = $"An image does not exist at the path '{path}'."
                };
            }

            var image = new MagickImage(path);
            foreach(var pixel in image.GetPixels())
            {
                var color = pixel.ToColor();
                if(color is null)
                {
                    return new CommandResult()
                    {
                        Status = CommandStatus.Failed,

                        ErrorLineNumber = command.Command.LineNumber,
                        ErrorMessage = $"There was an issue fetching a pixel color."
                    };
                }

                drawables = drawables.FillColor(color);
                drawables = drawables.Point(pixel.X, pixel.Y);
            }

            return new CommandResult()
            {
                Status = CommandStatus.Success
            };
        }
    }
}
