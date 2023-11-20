using System;
using System.Collections.Generic;
using UsingInterfaceExample.Interface;

namespace UsingInterfaceExample
{
    internal class Program
	{
		static void Main(string[] args)
		{
			int value1 = 5, value2 = 2;

			//string [] operations = { "add", "subtract", "sqrt" };

			//foreach (string operation in operations)
			//{
			//	Console.WriteLine(operation + ": " + RunOperation(value1,value2,operation));
			//}


			// Create instances of each operation
			List<IOperation> operations = new List<IOperation>
			{
				new Add(),
				new Subtract(),
				new Sqrt()
			};

			// Perform and display the results
			foreach (var operation in operations)
			{
				Console.WriteLine($"{operation.GetType().Name}: {operation.RunOperation(value1, value2)}");
			}

			Console.ReadLine();
		}

		//private static int RunOperation(int value1, int value2, string operation)
		//{
		//	int returnVal = 0;

		//	if (operation == "add")
		//	{
		//		returnVal = value1 + value2;
		//	}
		//	else if (operation == "subtract")
		//	{
		//		returnVal = value1 - value2;
		//	}
		//	else if (operation == "sqrt")
		//	{
		//		returnVal = (int)Math.Sqrt(value1 * value2);
		//	}

		//	return returnVal;
		//}
	}
}
