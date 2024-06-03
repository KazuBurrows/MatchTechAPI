using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MatchTech.Classes.Models.LinkedList;
using static MatchTech.Classes.Models.RoundRobinTimeTable;

namespace MatchTech.Classes.Models
{
	abstract class TimeTable
	{
		public abstract void Add(int id, object data);
		public abstract void Remove(int id);
		public abstract object GetData(int id);
		public abstract object GetTimeTable();
		public abstract void PrintTimeTable();
	}

	class RoundRobinTimeTable : TimeTable
	{
		public LinkedList linkedList = new LinkedList();
		
		public override void Add(int id, object data)
		{
			linkedList.Add(id, data);
		}
		public override void Remove(int id)
		{
			linkedList.Remove(id);
		}
		public override object GetData(int id)
		{
			return linkedList.GetNode(id);
		}
		public override object GetTimeTable()
		{
			return linkedList;
		}

        public override void PrintTimeTable()
		{
			linkedList.PrintTimeTable();
		}
		
	}

	class KnockOutTimeTable : TimeTable
	{
		public override void Add(int id, object data)
		{

		}
		public override void Remove(int id)
		{

		}
		public override object GetData(int id)
		{

			return null;
		}

        public override object GetTimeTable()
        {
            return null;
        }
        public override void PrintTimeTable()
		{
			Console.WriteLine("My Knock Out Time Table");
		}
	}



	class LinkedList
	{
		public Node head;

		/// <summary>
		/// Node represents a week in tournament schedule
		/// <example>
		internal class Node
		{
			public int Id { get; set; }
			public object Data { get; set; }
			internal Node next;
			public Node(int id, object data)
			{
				Id = id;
				Data = data;
				next = null;
			}
		}

		public void Add(int id, object data)
		{
			Node newNode = new Node(id, data);
			if (this.head == null)
			{
				this.head = newNode;
				return;
			}
			Node lastNode = GetLastNode();
			lastNode.next = newNode;
		}

		public Node GetFirstNode()
		{
			return this.head;
		}
		private Node GetLastNode()
		{
			Node temp = this.head;
			while (temp.next != null)
			{
				temp = temp.next;
			}
			return temp;
		}

		public Node GetNode(int id)
		{
			Node temp = this.head;
			if (temp != null)
			{
				while (temp != null)
				{
					if (temp.Id == id) return temp;
					temp = temp.next;
				}
			}

			return null;
		}

		public void Remove(int id)
		{
			Node temp = this.head;
			Node prev = null;
			if (temp != null && temp.Id == id)
			{
				this.head = temp.next;
				return;
			}
			while (temp != null && temp.Id != id)
			{
				prev = temp;
				temp = temp.next;
			}
			if (temp == null)
			{
				return;
			}
			prev.next = temp.next;
		}


		public void PrintTimeTable()
		{
			Node curr = this.head;
			MatchWeek matchWeek;
			if (curr != null)
			{
				Console.Write("The Time Table contains: " + System.Environment.NewLine);
				while (curr != null)
				{
					matchWeek = (MatchWeek)curr.Data;
					Console.Write("Week: " + matchWeek.Week + " - " + matchWeek.ToString() + " " + System.Environment.NewLine);
					curr = curr.next;
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("The list is empty.");
			}
		}

	}




}
