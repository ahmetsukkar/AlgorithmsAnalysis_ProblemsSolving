using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Implementation
{
	public class Stack_LinkedListBased<T>
	{
		private LinkedList<T> Data_List;

		public Stack_LinkedListBased(bool unique = false)
		{
			this.Data_List = new LinkedList<T>(unique);
		}

		public void Push(T _data)
		{
			this.Data_List.InsertFirst(_data);
		}

		public T Pop()
		{
			T head_data = this.Data_List.Head.Data;
			this.Data_List.DeleteHead();
			return head_data;
		}

		public T Peek()
		{
			return this.Data_List.Head.Data; ;
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
