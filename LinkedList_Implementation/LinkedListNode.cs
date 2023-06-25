using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Implementation
{
	public class LinkedListNode<T>
	{
		public T Data;
		public LinkedListNode<T> Next;
		public LinkedListNode<T> Back; //Using for DoublyLinkedList

		public LinkedListNode(T _data)
		{
			this.Data = _data;
			this.Next = null;
			this.Back = null;
		}
	}
}
