using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLeanMaint.Models;

namespace WebLeanMaint.ViewModels
{
	public class GeographicCentersTree
	{
		public IEnumerable<Data.Config.GeographicCenterType> types_list { get; set; }
		public IEnumerable<Data.Config.GeographicCenter> complete { get; set; }
		public IEnumerable<Data.Config.GeographicCenter> parent_list { get; set; }
		public IEnumerable<Data.Config.GeographicCenter> child_list { get; set; }
	}
}