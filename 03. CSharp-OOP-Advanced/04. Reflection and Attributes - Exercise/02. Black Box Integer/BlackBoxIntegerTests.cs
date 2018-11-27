namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type blackBoxType = typeof(BlackBoxInteger);

            ConstructorInfo blackBoxConstructor = blackBoxType
                .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);

            Object blackBoxInstance = blackBoxConstructor.Invoke(new object[] { });

            string[] command = Console.ReadLine().Split("_");

            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "Add":
                        Operation("Add", command[1]);
                        break;
                    case "Subtract":
                        Operation("Subtract", command[1]);
                        break;
                    case "Divide":
                        Operation("Divide", command[1]);
                        break;
                    case "Multiply":
                        Operation("Multiply", command[1]);
                        break;
                    case "RightShift":
                        Operation("RightShift", command[1]);
                        break;
                    case "LeftShift":
                        Operation("LeftShift", command[1]);
                        break;
                }

                command = Console.ReadLine().Split("_");
            }

            void Operation(string methodName, string param)
            {
                var operation = blackBoxType
                    .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);//flags for private
                operation.Invoke(blackBoxInstance, new object[] { int.Parse(command[1]) }); //obj=>method params

                var field = blackBoxType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

                Console.WriteLine(field.GetValue(blackBoxInstance));
            }
        }
    }
}
