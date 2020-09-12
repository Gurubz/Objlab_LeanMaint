using WebLeanMaint.Models;
using WebLeanMaint.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
		public IEnumerable<General_query> main_types { get; set; }
		public IEnumerable<General_query> main_subj { get; set; }
		public IEnumerable<General_query> main_geo { get; set; }
		public IEnumerable<General_query> main_cost { get; set; }
		public IEnumerable<General_query> main_orga { get; set; }
		public IEnumerable<MaintenanceAssets> list { get; set; }

		public PlanningOperators planningOperators { get; set; }
		public MaintenanceAssets maintenance { get; set; }
		public MaintenanceSuppliers maintenanceSuppliers { get; set; }
		public MaintenanceMaterials maintenanceMaterials { get; set; }
	}
}