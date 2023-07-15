﻿using System.Text;

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
                bool isFirstArgument = true;

                foreach(char character in line)
                {
                    if (char.IsWhiteSpace(character))
                    {
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
