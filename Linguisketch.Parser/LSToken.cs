namespace Linguisketch.Parser
{
    public class LSToken
    {
        public int LineNumber { get; set; }
        public LSTokenType TokenType { get; set; }
        public string? Value { get; set; }
        public LSValueType Type { get; set; }
    }
}
