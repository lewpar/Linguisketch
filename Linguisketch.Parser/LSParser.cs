using System.Text;

namespace Linguisketch.Parser
{
    public class LSParser
    {
        public static List<LSToken> ParseScript(string script)
        {
            var tokens = new List<LSToken>();
            var lines = script.Split('\n');

            StringBuilder sb = new StringBuilder();

            for(int l = 0; l < lines.Length; l++)
            {
                var line = lines[l];
                var trimmed = line.Trim();

                if(trimmed.StartsWith("#") ||
                    string.IsNullOrWhiteSpace(trimmed))
                {
                    continue;
                }

                bool isFirstArgument = true;

                for(int i = 0; i < trimmed.Length; i++)
                {
                    char character = trimmed[i];

                    if (char.IsWhiteSpace(character) ||
                        i == trimmed.Length - 1)
                    {
                        if(!char.IsWhiteSpace(character))
                        {
                            sb.Append(character);
                        }

                        if(isFirstArgument)
                        {
                            tokens.Add(new LSToken()
                            {
                                LineNumber = l + 1,
                                TokenType = LSTokenType.Function,
                                Value = sb.ToString(),
                                Type = LSValueType.Function
                            });

                            isFirstArgument = false;
                        }
                        else
                        {
                            tokens.Add(new LSToken()
                            {
                                LineNumber = l + 1,
                                TokenType = LSTokenType.Argument,
                                Value = sb.ToString(),
                                Type = DepictType(sb.ToString())
                            });
                        }

                        sb.Clear();

                        continue;
                    }

                    if(character == '#')
                    {
                        break;
                    }

                    sb.Append(character);
                }
            }

            return tokens;
        }

        public static List<LSCommand> ParseCommands(List<LSToken> tokens)
        {
            var commands = new List<LSCommand>();
            var command = new LSCommand()
            {
                Args = new List<LSToken>()
            };

            bool state = false;

            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];

                switch(token.TokenType)
                {
                    case LSTokenType.Function:
                        if (state)
                        {
                            commands.Add(command);
                            command = new LSCommand() { Args = new List<LSToken>() };
                            state = false;
                        }

                        command.Command = token;
                        state = true;

                        break;

                    case LSTokenType.Argument:
                        command.Args.Add(token);
                        break;
                }

                if(i == tokens.Count - 1)
                {
                    commands.Add(command);
                }
            }

            return commands;
        }

        public static LSValueType DepictType(string arg)
        {
            bool isDigit = true;
            foreach(var c in arg)
            {
                if(!char.IsDigit(c))
                {
                    isDigit = false;
                }
            }

            return isDigit ? LSValueType.Number : LSValueType.Word;
        }
    }
}
