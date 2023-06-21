using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding
{
	public class Huffman
	{
		char internal_char = (char)0; // mean empty 
		public Hashtable codes = new Hashtable();
		Hashtable freqHash = new Hashtable();
		private PriorityQueue<HeapNode, int> minHeap = new PriorityQueue<HeapNode, int>();
		public Huffman(string message)
		{
			foreach (char c in message)
			{
				if (freqHash[c] == null)
					freqHash[c] = 1;
				else
					freqHash[c] = (int)freqHash[c] + 1;
			}

			foreach (char key in freqHash.Keys)
			{
				HeapNode newNode = new HeapNode(key, (int)freqHash[key]);
				minHeap.Enqueue(newNode, (int)freqHash[key]);
			}

			HeapNode left, right, top;
			int newFreq;
			while (minHeap.Count != 1)
			{
				left = minHeap.Dequeue();
				right = minHeap.Dequeue();
				newFreq = left.Freq + right.Freq;
				top = new HeapNode(internal_char, newFreq);
				top.LeftNode = left;
				top.RightNode = right;
				minHeap.Enqueue(top, newFreq);
			}

			this.GenerateCodes(minHeap.Peek(), String.Empty);
		}

		private void GenerateCodes(HeapNode node, string str)
		{
			if (node == null) return;

			if (node.Data != internal_char)
			{
				codes[node.Data] = str;
			}

			GenerateCodes(node.LeftNode, str + "0");
			GenerateCodes(node.RightNode, str + "1");
		}
	}
}
