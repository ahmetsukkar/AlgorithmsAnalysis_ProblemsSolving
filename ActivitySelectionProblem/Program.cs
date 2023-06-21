using System;

namespace ActivitySelectionProblem
{
	class Program
	{
		static void Main(string[] args)
		{
			//Suppose the tasks sorted by EndTime, if it is not sort First Should be Sort by EndTime

			Task[] tasks = {
				new Task("#1", 9, 11),
				new Task("#2", 10, 11),
				new Task("#3", 11, 12),
				new Task("#4", 12, 14),
				new Task("#5", 13, 15),
				new Task("#6", 15, 16)};

			Task[] selectedTasks = Task.ActivitySelection(tasks);

			Console.WriteLine("Selected Tasks");
			foreach (var task in selectedTasks)
			{
				Console.WriteLine(task.TaskName + "	" + task.StartTime + "	" + task.EndTime);
			}

			Console.ReadLine();
		}
	}
}
