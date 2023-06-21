using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitySelectionProblem
{
	public class Task
	{
		public string TaskName;
		public int StartTime;
		public int EndTime;

		public Task(string name, int start, int end)
		{
			this.TaskName = name;
			this.StartTime = start;
			this.EndTime = end;
		}

		public static Task[] ActivitySelection(Task[] tasks)
		{
			List<Task> result = new List<Task>() { tasks[0] };

			int j = 0;
			for (int i = 1; i < tasks.Length; i++)
			{
				if (tasks[i].StartTime >= tasks[j].EndTime)
				{
					result.Add(tasks[i]);
					j = i;
				}
			}

			return result.ToArray();
		}
	}
}
