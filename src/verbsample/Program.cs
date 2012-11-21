using System;
using CommandLine;

namespace VerbSample
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (!VerbParser.Default.ParseArguments(
                new[] { "commit", "-m", "'my message'"}, new Verbs()))
            {
                Environment.Exit(1);
            }

            Environment.Exit(0);
        }
    }

    class Verbs
    {
        internal class CommitOptions : CommandLineOptionsBase
        {
            [Option("m", "message", Required = true)]
            public string Message { get; set; }
        }

        [Verb]
        public void Commit(CommitOptions options)
        {
            Console.WriteLine(options.Message);
        }
    }
}
