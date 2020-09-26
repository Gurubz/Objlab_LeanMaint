using WebLeanMaint.Models;
using WebLeanMaint.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Maintenance;
using Data.Config;
using Data.Accountancy;
using Data.Security;
using Data.Planning;

namespace WebLeanMaint.ViewModel
{
	public class GeneralVM
	{
		public IEnumerable<PlanningOperatorTypes> opp_types { get; set; }
		public IEnumerable<Data.Maintenance.Asset> Assets { get; set; }
		public IEnumerable<Data.Maintenance.AssetMaterial> AssetMaterials { get; set; }
		public IEnumerable<Data.Maintenance.Material> Materials { get; set; }

		public PlanningOperators planningOperators { get; set; }
		public Data.Maintenance.Asset Asset { get; set; }
		public Data.Maintenance.AssetMaterial AssetMaterial { get; set; }
		public Data.Maintenance.Supplier Supplier { get; set; }
		public Data.Maintenance.Material Material { get; set; }
		public List<AssetType> AssetTypes { get; set; }
		public List<MaterialUM> MaterialUMs { get; set; }
		public List<OrganizationCenter> OrganizationCenters { get; internal set; }
		public List<CostCenter> CostCenters { get; internal set; }
		public List<GeographicCenter> GeographicCenters { get; internal set; }
		public List<StoreCenter> StoreCenters { get; internal set; }
		public List<ObjStatuse> ObjStatuses { get; internal set; }
		public List<Supplier> Suppliers { get; set; }
		public List<SupplierType> SupplierTypes { get; internal set; }
		public List<City> Cities { get; internal set; }
		public List<Country> Countries { get; internal set; }
		public List<User> Users { get; internal set; }
		public List<Calendar> Calendars { get; internal set; }
	}
}