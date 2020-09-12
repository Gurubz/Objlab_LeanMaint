using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLeanMaint.Models
{
   [Table("Materials", Schema = "Maintenance")]
    public class MaintenanceMaterials
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_Material { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID_ObjStatus { get; set; }
        public string ReferenceCode { get; set; }
        public int ID_Supplier { get; set; }
        public decimal CostPerUM { get; set; }
        public string Brand { get; set; }
        public int ID_MaterialUM { get; set; }
        public int ID_StoreCenter { get; set; }
        public string Type { get; set; }
        public string Barcode { get; set; }
    }
}