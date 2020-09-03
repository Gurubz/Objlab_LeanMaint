using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLeanMaint.Models
{
	public class Node<K, T> : Root<K, T>
	{
		public Node()
		{
			this.Key = default(K);
			this.Value = default(T);
			this.HasParent = false;
			this.ParentKey = default(K);

			this.Children = new List<Node<K, T>>();
		}

		public Node(K oKey, T oValue)
		{
			this.Key = oKey;
			this.Value = oValue;
			this.HasParent = false;
			this.ParentKey = default(K);

			this.Children = new List<Node<K, T>>();
		}

		public Node(K oKey, T oValue, K oParentKey)
		{
			this.Key = oKey;
			this.Value = oValue;
			this.HasParent = true;
			this.ParentKey = oParentKey;

			this.Children = new List<Node<K, T>>();
		}

		public K Key { get; set; }
		public T Value { get; set; }
		public bool HasParent { get; set; }
		public K ParentKey { get; set; }
	}
}