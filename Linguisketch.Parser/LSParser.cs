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

            foreach (string line in lines)
            {
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
                                TokenType = LSTokenType.Function,
                                Value = sb.ToString(),
                                Type = "Function"
                            });

                            isFirstArgument = false;
                        }
                        else
                        {
                            tokens.Add(new LSToken()
                            {
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

        public static string? DepictType(string arg)
        {
            bool isDigit = true;
            foreach(var c in arg)
            {
                if(!char.IsDigit(c))
                {
                    isDigit = false;
                }
            }

            return isDigit ? "Number" : "Word";
        }
    }
}
