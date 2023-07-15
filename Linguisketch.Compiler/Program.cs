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

            Console.WriteLine(script);
        }
    }
}