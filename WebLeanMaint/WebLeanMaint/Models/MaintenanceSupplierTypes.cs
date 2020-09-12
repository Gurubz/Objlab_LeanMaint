using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLeanMaint.Models
{
	[Table("SupplierTypes", Schema = "Maintenance")]
	public class MaintenanceSupplierTypes
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int ID_SupplierType { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}