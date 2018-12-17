namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            var command = inputParameters[0];

            var args = inputParameters.Skip(1).ToList();

            string output;

            Assembly assembly = Assembly.GetExecutingAssembly();

            try
            {
                if (command == "Vehicle")
                    command = "AddVehicle";
                if (command == "Part")
                    command = "AddPart";

                var tankController = this.tankManager.GetType().GetMethods().FirstOrDefault(x => x.Name == command);

                output = (string)tankController.Invoke(this.tankManager, new object[] { args });
            }
            catch (TargetInvocationException ex)
            {
                return ex.InnerException.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return output;
        }
    }
}