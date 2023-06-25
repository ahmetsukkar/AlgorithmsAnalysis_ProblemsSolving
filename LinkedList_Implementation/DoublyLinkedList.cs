using System;

namespace LinkedList_Implementation
{
	public class DoublyLinkedList<T>
	{
		public LinkedListNode<T> Head;
		public LinkedListNode<T> Tail;
		private bool Unique;
		public int Length { get; private set; } // Property to store the length of the linked list

		public DoublyLinkedList(bool unique = false)
		{
			this.Head = null;
			this.Tail = null;
			this.Length = 0;
			this.Unique = unique;
		}

		public LinkedListIterator<T> Begin()
		{
			LinkedListIterator<T> itr = new LinkedListIterator<T>(this.Head);
			return itr;
		}

		private bool CanInsert(T _data)
		{
			if (this.Unique && IsExist(_data))
			{
				Console.WriteLine(_data + " --> already exist!");
				return false;
			}

			return true;
		}

		private bool IsExist(T _data)
		{
			if (this.Find(_data) != null)
				return true;

			return false;
		}

		private LinkedListNode<T> Find(T _data)
		{
			for (LinkedListIterator<T> itr = this.Begin(); itr.Current() != null; itr.Next())
			{
				if (itr.Data().Equals(_data))
				{
					return itr.Current();
				}
			}

			return null;
		}

		public void InsertAfter(T node_data, T _data)
		{
			if (!CanInsert(_data)) return;

			LinkedListNode<T> node = this.Find(node_data);

			LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
			newNode.Next = node.Next;
			newNode.Back = node;
			node.Next = newNode;

			if (newNode.Next == null)
			{
				this.Tail = newNode;
			}
			else
			{
				newNode.Next.Back = newNode;
			}

			Length++; // Increment length when a node is inserted
		}

		public void InsertLast(T _data)
		{
			if (!CanInsert(_data)) return;

			LinkedListNode<T> newNode = new LinkedListNode<T>(_data);

			if (this.Tail == null)
			{
				this.Head = newNode;
				this.Tail = newNode;
			}
			else
			{
				newNode.Back = this.Tail;
				this.Tail.Next = newNode;
				this.Tail = newNode;
			}

			Length++; // Increment length when a node is inserted
		}

		public void InsertBefore(T node_data, T _data)
		{
			if (!CanInsert(_data)) return;

			LinkedListNode<T> node = this.Find(node_data);

			LinkedListNode<T> newNode = new LinkedListNode<T>(_data);

			newNode.Next = node;

			if (node == this.Head)
			{
				this.Head = newNode;
			}
			else
			{
				node.Back.Next = newNode;
			}

			node.Back = newNode;

			Length++; // Increment length when a node is inserted

			//LinkedListNode newNode = new LinkedListNode(_data);

			//newNode.Back = node.Back;
			//newNode.Next = node;
			//node.Back = newNode;

			//if (newNode.Back == null)
			//{
			//	this.Head = newNode;
			//}
			//else
			//{
			//	newNode.Back.Next = newNode;
			//}

		}

		public void DeleteNode(T node_data)
		{
			LinkedListNode<T> node = this.Find(node_data);

			if (this.Head == this.Tail)
			{
				this.Head = null;
				this.Tail = null;
			}
			else if (node.Back == null)
			{
				this.Head = node.Next;
				node.Next.Back = null;
			}
			else if (node.Next == null)
			{
				this.Tail = node.Back;
				node.Back.Next = null;
			}
			else
			{
				node.Back.Next = node.Next;
				node.Next.Back = node.Back;
			}

			node = null;

			Length--; // Decrement length when a node is deleted
		}

		public void PrintList()
		{
			for (LinkedListIterator<T> itr = this.Begin(); itr.Current() != null; itr.Next())
			{
				Console.Write(itr.Data() + " -> ");
			}
			Console.WriteLine();
		}

		public DoublyLinkedList<T> CopyList()
		{
			DoublyLinkedList<T> copiedList = new DoublyLinkedList<T>();

			for (LinkedListIterator<T> itr = this.Begin(); itr.Current() != null; itr.Next())
			{
				copiedList.InsertLast(itr.Data());
			}

			return copiedList;
		}
	}
}
