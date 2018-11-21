using Exercise.Appenders.Contracts;
using Exercise.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();
                commandInterpreter.AddAppender(args);
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] args = input.Split('|');

                commandInterpreter.AddMessage(args);

                input = Console.ReadLine();
            }
            commandInterpreter.PrintInfo();
        }
    }
}
