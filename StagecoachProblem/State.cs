using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecoachProblem
{
	public class State
	{
		public string From;
		public string To;
		public int Cost;

		public State(string from, string to, int cost)
		{
			this.From = from;
			this.To = to;
			this.Cost = cost;
		}
	}
}
