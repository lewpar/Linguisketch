namespace Linguisketch.Parser
{
    public class LSCommand
    {
        public LSToken Command { get; set; }
        public List<LSToken> Args { get; set; }
    }
}