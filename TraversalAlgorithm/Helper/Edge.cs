using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalAlgorithm
{
	public class Edge
	{
		public double Weight;
		public Vertex Source;
		public Vertex Target;

		public Edge(Vertex source, Vertex target, double weight = 0)
		{
			this.Source = source;
			this.Target = target;
			this.Weight = weight;
		}

	}
}
