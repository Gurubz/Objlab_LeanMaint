using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLeanMaint.Models;

namespace WebLeanMaint.ViewModels
{
	public class OrganizationCentersTree
	{
		public IEnumerable<Data.Config.OrganizationCenterType> types_list { get; set; }
		public IEnumerable<Data.Config.OrganizationCenter> complete { get; set; }
		public IEnumerable<Data.Config.OrganizationCenter> parent_list { get; set; }
		public IEnumerable<Data.Config.OrganizationCenter> child_list { get; set; }
	}
}