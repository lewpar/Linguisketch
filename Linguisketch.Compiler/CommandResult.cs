namespace Linguisketch.Compiler
{
    public enum CommandStatus
    {
        Success,
        Failed
    }

    public class CommandResult
    {
        public CommandStatus Status { get; set; }

        public int? ErrorLineNumber { get; set; }
        public string? ErrorMessage { get; set; }
    }
}