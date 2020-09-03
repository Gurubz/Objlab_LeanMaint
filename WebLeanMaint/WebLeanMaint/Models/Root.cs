using Data.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLeanMaint.Models
{
	public class Root<K, T>
	{
		public Root()
		{
			this.Children = new List<Node<K, T>>();
		}

		public List<Node<K, T>> Children { get; set; }

		public List<Node<K, T>> BuildTree(List<Node<K, T>> aNodes, int nMaxDeep = 20)
		{
			List<Node<K, T>> aRet = new List<Node<K, T>>();

			foreach (Node<K, T> oNode in aNodes)
			{
				if (oNode.HasParent==false) this.Children.Add(oNode);
				else
				{
					Node<K, T> oParentNode = this.FindByKey(oNode.ParentKey);
					if (oParentNode != null) oParentNode.Children.Add(oNode);
					else aRet.Add(oNode);
				}
			}

			for(int i = 0; i<nMaxDeep; i++)
			{
				if (aRet.Count > 0)
				{
					aRet = this.BuildTree(aRet);
				}
			}

			return (aRet);
		}

		public Node<K, T> FindByKey(K oKey)
		{
			Node<K, T> oRet = null;

			foreach (Node<K, T> oNode in this.Children)
			{
				if (oNode.Key.Equals(oKey) == true) oRet = oNode;
				else oRet = oNode.FindByKey(oKey);

				if (oRet != null) break;
			}

			return (oRet);
		}
	}
}