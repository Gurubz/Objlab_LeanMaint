using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLeanMaint.Models
{
    [Table("Assets", Schema = "Maintenance")]
    public class MaintenanceAssets
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_Asset { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID_AssetType { get; set; }
        public int ID_OrganizationCenter { get; set; }
        public int? ID_Parent { get; set; }
        public int ID_CostCenter { get; set; }
        public int ID_GeographicCenter { get; set; }
        public int ID_ObjStatus { get; set; }
        }
}