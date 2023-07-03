using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Implementation
{
	public class Queue_LinkedListBased<T>
	{

		private LinkedList<T> Data_List;

		public Queue_LinkedListBased()
		{
			this.Data_List = new LinkedList<T>();
		}

		public void Enqueue(T _data)
		{
			this.Data_List.InsertLast(_data);
		}

		public T Dequeue()
		{
			T head_data = this.Data_List.Head.Data;
			this.Data_List.DeleteHead();
			return head_data;
		}

		public T Peek()
		{
			if (this.Data_List.Head == null) return default(T);

			return this.Data_List.Head.Data;
		}

		public bool IsEmpty()
		{
			return this.Data_List.Length == 0;
		}

		public int Size()
		{
			return this.Data_List.Length;
		}

		public void Print()
		{
			this.Data_List.PrintList();
		}

	}
}
