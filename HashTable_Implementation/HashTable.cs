using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable_Implementation
{
	public class HashTable<TKey, TValue> where TKey : class
	{
		KeyValuePair[] Entries;
		int InitalSize;
		int EntriesCount;

		public HashTable()
		{
			this.InitalSize = 3;
			this.EntriesCount = 0;
			this.Entries = new KeyValuePair[this.InitalSize];
		}

		int GetHash(TKey key)
		{
			uint FNVOffsetBasis = 2166136261;
			uint FNVPrime = 16777619;
			byte[] data = Encoding.ASCII.GetBytes(key.ToString());

			uint hash = FNVOffsetBasis;

			for (int i = 0; i < data.Length; i++)
			{
				hash = hash ^ data[i];
				hash = hash * FNVPrime;
			}

			Console.WriteLine("[hash] " + key.ToString() + " " + hash + " " + hash.ToString("x") + " " + hash % (uint)this.Entries.Length);

			return (int)(hash % (uint)this.Entries.Length);
		}

		int CollisionHandling(TKey key, int hash, bool set)
		{
			int newHash;
			for (int i = 1; i < this.Entries.Length; i++)
			{
				newHash = (hash + i) % this.Entries.Length;

				Console.WriteLine("[coll] " + key.ToString() + " " + hash + ", new hash: " + newHash);

				if (set && (this.Entries[newHash] == null || this.Entries[newHash].Key == key))
				{
					return newHash;
				}
				else if (!set && this.Entries[newHash].Key == key)
				{
					return newHash;
				}
			}

			return -1;
		}

		void AddToEntries(TKey key, TValue value)
		{
			int hash = this.GetHash(key);
			if (this.Entries[hash] != null && this.Entries[hash].Key != key)
			{
				hash = this.CollisionHandling(key, hash, true);
			}

			if (hash == -1)
			{
				throw new Exception("Invalid HashTable!!!!");
			}

			if (this.Entries[hash] == null) //new pair
			{
				this.Entries[hash] = new KeyValuePair(key, value);
				this.EntriesCount++;
			}
			else if (this.Entries[hash].Key == key) //update pair value
			{
				this.Entries[hash].Value = value;
			}
			else
			{
				throw new Exception("Invalid HashTable!!!!");
			}

		}

		void ResizeOrNot()
		{
			if (this.EntriesCount < this.Entries.Length) return;

			int newSize = this.Entries.Length * 2;

			Console.WriteLine("[resize] from " + this.Entries.Length + " to " + newSize);

			KeyValuePair[] entriesCopy = new KeyValuePair[this.Entries.Length];
			Array.Copy(this.Entries, entriesCopy, this.Entries.Length);

			this.Entries = new KeyValuePair[newSize];
			this.EntriesCount = 0;
			for (int i = 0; i < entriesCopy.Length; i++) // Call AddToEntries again to ReCalculate Hash for new Entries size;
			{
				if (entriesCopy[i] == null) continue;
				this.AddToEntries(entriesCopy[i].Key, entriesCopy[i].Value);
			}
		}

		public void Set(TKey key, TValue value)
		{
			this.ResizeOrNot();
			this.AddToEntries(key, value);
		}

		public TValue Get(TKey key)
		{
			int hash = this.GetHash(key);
			if (this.Entries[hash] != null && this.Entries[hash].Key != key)
			{
				hash = this.CollisionHandling(key, hash, false);
			}

			if (hash == -1 || this.Entries[hash] == null)
			{
				return default(TValue);
			}

			if (this.Entries[hash].Key == key)
			{
				return this.Entries[hash].Value;
			}
			else
			{
				throw new Exception("Invalid HashTable!!!!");
			}
		}

		public void Remove(TKey key)
		{
			int hash = this.GetHash(key);
			if (this.Entries[hash] != null && this.Entries[hash].Key != key)
			{
				hash = this.CollisionHandling(key, hash, false);
			}

			if (hash == -1 || this.Entries[hash] == null)
			{
				return;
			}

			if (this.Entries[hash].Key == key)
			{
				this.Entries[hash] = null;
				this.EntriesCount--;
			}
			else
			{
				throw new Exception("Invalid HashTable!!!!");
			}
		}

		public int Size()
		{
			return this.EntriesCount;
		}
		public void Print()
		{
			Console.WriteLine("--------------");
			Console.WriteLine("[size] " + this.Size());

			for (int i = 0; i < this.Entries.Length; i++)
			{
				if (this.Entries[i] == null)
				{
					Console.WriteLine("[" + i + "]");
				}
				else
				{
					Console.WriteLine("[" + i + "]" + this.Entries[i].Key + ":" + this.Entries[i].Value);
				}
			}

			Console.WriteLine("==============");
		}

		class KeyValuePair
		{
			private TKey _key;
			private TValue _value;

			public TKey Key
			{
				get { return _key; }
			}

			public TValue Value
			{
				get { return _value; }
				set { _value = Value; }
			}

			public KeyValuePair(TKey key, TValue value)
			{
				_key = key;
				_value = value;
			}

		}
	}
}
