using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Planning
{
	public partial class Order
	{
		public Data.Planning.OrderAsset[] Assets { get; set; }
		public Data.Planning.OrderOperator[] Operators { get; set; }
	}
}