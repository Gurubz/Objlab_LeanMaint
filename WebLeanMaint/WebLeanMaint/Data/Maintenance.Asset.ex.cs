using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	public partial class Asset
	{
		public string AssetTypeName { get; set; }
		public string OrganizationCenterName { get; set; }
		public string CostCenterName { get; set; }
		public string GeographicCenterName { get; set; }
		public string ObjStatusName { get; set; }
		public string ParentName { get; set; }
	}
}
