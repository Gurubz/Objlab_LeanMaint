using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLeanMaint.ViewQueryModel
{
	public class GeographicCenterJoinQuery
	{
		public int ID_GeographicCenter { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int ID_GeographicCenterType { get; set; }
		public string ID_ObjStatus { get; set; }
		public int? ID_Parent { get; set; }
	}
}