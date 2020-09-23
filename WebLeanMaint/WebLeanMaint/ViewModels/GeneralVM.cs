using WebLeanMaint.Models;
using WebLeanMaint.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Maintenance;
using Data.Config;
using Data.Accountancy;

namespace WebLeanMaint.ViewModel
{
	public class GeneralVM
	{
		public IEnumerable<MaintenanceSupplierTypes> supp_type { get; set; }
		public IEnumerable<PlanningOperatorTypes> opp_types { get; set; }
		public IEnumerable<MaintenanceSuppliers> main_supp { get; set; }
		public IEnumerable<MaintenanceMaterialUMs> main_suppum { get; set; }
		public IEnumerable<General_query> country { get; set; }
		public IEnumerable<General_query> city { get; set; }
		public IEnumerable<General_query> user { get; set; }
		public IEnumerable<General_query> cal { get; set; }
		public IEnumerable<General_query> main_stores { get; set; }
		public IEnumerable<Data.Maintenance.Asset> Assets { get; set; }

		public PlanningOperators planningOperators { get; set; }
		public Data.Maintenance.Asset Asset { get; set; }
		public MaintenanceSuppliers maintenanceSuppliers { get; set; }
		public MaintenanceMaterials maintenanceMaterials { get; set; }
		public List<AssetType> AssetTypes { get; internal set; }
		public List<OrganizationCenter> OrganizationCenters { get; internal set; }
		public List<CostCenter> CostCenters { get; internal set; }
		public List<GeographicCenter> GeographicCenters { get; internal set; }
		public List<ObjStatuse> ObjStatuses { get; internal set; }
	}
}