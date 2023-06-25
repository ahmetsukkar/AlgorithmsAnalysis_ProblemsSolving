using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Implementation
{
	class Program
	{
		static void Main(string[] args)
		{
			#region "LinkedList Example"
			Console.WriteLine("LinkedList");

			LinkedList<int> linkedList = new LinkedList<int>();
			linkedList.InsertLast(1);
			linkedList.InsertLast(2);
			linkedList.InsertLast(3);
			linkedList.PrintList();

			linkedList.InsertAfter(2, 74);
			linkedList.PrintList();

			linkedList.InsertBefore(74, 55);
			linkedList.PrintList();

			linkedList.DeleteNode(74);
			linkedList.PrintList();

			linkedList.DeleteNode(1);
			linkedList.PrintList();

			Console.WriteLine("List Count: " + linkedList.Length);

			Console.WriteLine("Head: " + linkedList.Head.Data);

			LinkedList<int> copyLinkedList = linkedList.CopyList();
			copyLinkedList.InsertLast(99);

			Console.WriteLine("Copy List: ");
			copyLinkedList.PrintList();

			Console.WriteLine("Original List: ");
			linkedList.PrintList();

			#endregion

			Console.WriteLine();

			#region "DoublyLinkedList Example"
			Console.WriteLine("DoublyLinkedList");

			DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>(true);
			doublyLinkedList.InsertLast("A");
			doublyLinkedList.InsertLast("B");
			doublyLinkedList.InsertLast("C");
			doublyLinkedList.InsertLast("B");
			doublyLinkedList.PrintList();

			doublyLinkedList.InsertAfter("B", "Y");
			doublyLinkedList.PrintList();

			doublyLinkedList.DeleteNode("B");
			doublyLinkedList.PrintList();

			doublyLinkedList.InsertBefore("Y", "Z");
			doublyLinkedList.PrintList();

			Console.WriteLine("List Count: " + doublyLinkedList.Length);

			Console.WriteLine("Head: " + doublyLinkedList.Head.Data);

			DoublyLinkedList<string> copyDoublyLinkedList = doublyLinkedList.CopyList();
			copyDoublyLinkedList.InsertLast("SS");

			Console.WriteLine("Copy List: ");
			copyDoublyLinkedList.PrintList();

			Console.WriteLine("Original List: ");
			doublyLinkedList.PrintList();

			#endregion


			Console.ReadLine();
		}
	}
}
