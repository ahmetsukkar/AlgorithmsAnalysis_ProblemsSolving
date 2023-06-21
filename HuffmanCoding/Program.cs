using System;

namespace HuffmanCoding
{
	class Program
	{
		static void Main(string[] args)
		{
			string message = "internet";

			Huffman huff = new Huffman(message);

			foreach (var key in huff.codes.Keys)
			{
				Console.WriteLine(key + " " + huff.codes[key]);
			}

			Console.ReadLine();
		}
	}
}
