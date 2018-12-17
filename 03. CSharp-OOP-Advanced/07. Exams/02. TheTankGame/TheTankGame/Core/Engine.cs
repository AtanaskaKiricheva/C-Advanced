namespace TheTankGame.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader,
            IWriter writer,
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            //this.isRunning = false;
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine();

                var result = commandInterpreter.ProcessInput(input.Split());
                Console.WriteLine(result);

                if (input.Contains("Terminate"))
                {
                    break;
                }
            }
        }
    }
}