using System;

namespace LinkedList_Implementation
{
	public class LinkedListIterator<T>
	{
		private LinkedListNode<T> CurrentNode;

		public LinkedListIterator()
		{
			this.CurrentNode = null;
		}

		public LinkedListIterator(LinkedListNode<T> node)
		{
			this.CurrentNode = node;
		}

		public T Data()
		{
			return this.CurrentNode.Data;
		}

		public LinkedListIterator<T> Next()
		{
			this.CurrentNode = this.CurrentNode.Next;
			return this;
		}

		public LinkedListNode<T> Current()
		{
			return this.CurrentNode;
		}
	}
}
