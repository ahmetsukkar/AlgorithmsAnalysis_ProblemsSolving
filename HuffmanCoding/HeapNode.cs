using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding
{
	public class HeapNode
	{
		public char Data;
		public int Freq;
		public HeapNode LeftNode;
		public HeapNode RightNode;

		public HeapNode(char data, int freq)
		{
			this.Data = data;
			this.Freq = freq;
			this.LeftNode = null;
			this.RightNode = null;
		}
	}
}
