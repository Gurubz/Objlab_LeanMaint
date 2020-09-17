using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLeanMaint.ViewQueryModel
{
	public class CostCenterJoinQuery
	{
		public int ID_CostCenter { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int ID_CostCenterType { get; set; }
		public string ID_ObjStatus { get; set; }
		public int? ID_Parent { get; set; }
	}
}