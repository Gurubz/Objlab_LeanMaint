using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLeanMaint.Models;

namespace WebLeanMaint.ViewModels
{
	public class CostCentersTree
	{
		public IEnumerable<Data.Accountancy.CostCenterType> types_list { get; set; }
		public IEnumerable<Data.Accountancy.CostCenter> complete { get; set; }
		public IEnumerable<Data.Accountancy.CostCenter> parent_list { get; set; }
		public IEnumerable<Data.Accountancy.CostCenter> child_list { get; set; }
	}
}