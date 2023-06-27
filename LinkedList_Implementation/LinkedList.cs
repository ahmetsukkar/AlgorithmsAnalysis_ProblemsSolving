using System;

namespace LinkedList_Implementation
{
	public class LinkedList<T>
	{
		public LinkedListNode<T> Head;
		public LinkedListNode<T> Tail;
		private bool Unique;
		public int Length { get; private set; } // Property to store the length of the linked list

		public LinkedList(bool unique = false)
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

		private LinkedListNode<T> FindParent(LinkedListNode<T> node)
		{
			for (LinkedListIterator<T> itr = this.Begin(); itr.Current() != null; itr.Next())
			{
				if (itr.Current().Next == node)
				{
					return itr.Current();
				}
			}

			return null;
		}

		public void InsertLast(T _data)
		{
			if (!CanInsert(_data)) return;

			LinkedListNode<T> newNode = new LinkedListNode<T>(_data);

			if (this.Head == null)
			{
				this.Head = newNode;
				this.Tail = newNode;
			}
			else
			{
				this.Tail.Next = newNode;
				this.Tail = newNode;
			}

			Length++; // Increment length when a node is inserted
		}

		public void InsertAfter(T node_data, T _data)
		{
			if (!CanInsert(_data)) return;

			LinkedListNode<T> node = this.Find(node_data);

			LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
			newNode.Next = node.Next;
			node.Next = newNode;

			if (this.Tail == node)
				this.Tail = newNode;

			Length++; // Increment length when a node is inserted
		}

		public void InsertBefore(T node_data, T _data)
		{
			if (!CanInsert(_data)) return;

			LinkedListNode<T> node = this.Find(node_data);

			LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
			newNode.Next = node;

			LinkedListNode<T> parent = this.FindParent(node);

			if (parent == null)
				this.Head = newNode;
			else
				parent.Next = newNode;

			Length++; // Increment length when a node is inserted
		}

		public void DeleteNode(T node_data)
		{
			LinkedListNode<T> node = this.Find(node_data);

			if (this.Head == this.Tail)
			{
				this.Head = null;
				this.Tail = null;
			}
			else if (this.Head == node)
			{
				this.Head = node.Next;
			}
			else
			{
				LinkedListNode<T> parent = FindParent(node);

				if (this.Tail == node)
				{
					this.Tail = parent;
				}
				else
				{
					parent.Next = node.Next;
				}
			}

			node = null;

			Length--; // Decrement length when a node is deleted
		}

		#region "Stack"

		public void InsertFirst(T _data)
		{
			if (!CanInsert(_data)) return;

			LinkedListNode<T> newNode = new LinkedListNode<T>(_data);

			if (this.Head == null)
			{
				this.Head = newNode;
				this.Tail = newNode;
			}
			else
			{
				newNode.Next = this.Head;
				this.Head = newNode;
			}

			Length++; // Increment length when a node is inserted
		}

		public void DeleteHead()
		{
			if (this.Head == null) return;

			this.Head = this.Head.Next;

			Length--; // Decrement length when a node is deleted
		}

		#endregion

		public void PrintList()
		{
			for (LinkedListIterator<T> itr = this.Begin(); itr.Current() != null; itr.Next())
			{
				Console.Write(itr.Data() + " -> ");
			}
			Console.WriteLine();
		}

		public LinkedList<T> CopyList()
		{
			LinkedList<T> copiedList = new LinkedList<T>();

			for (LinkedListIterator<T> itr = this.Begin(); itr.Current() != null; itr.Next())
			{
				copiedList.InsertLast(itr.Data());
			}

			return copiedList;
		}
	}

}
