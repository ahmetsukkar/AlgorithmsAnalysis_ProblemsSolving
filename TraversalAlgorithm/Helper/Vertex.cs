using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalAlgorithm
{
	public class Vertex
	{
		public string Name;
		public bool Visited;
		public double TotalLength;
		public Vertex SourceOfTotalLength;
		public Edge[] VertexLinks;
	}
}
