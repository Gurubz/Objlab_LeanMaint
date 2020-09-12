using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLeanMaint.Models
{
   [Table("Suppliers", Schema = "Maintenance")]
    public class MaintenanceSuppliers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_Supplier { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }    
        public int ID_SupplierType { get; set; }    
        public int ID_ObjStatus { get; set; }    
        public string Address1 { get; set; }    
        public int ID_CostCenter { get; set; }    
        public string Address2 { get; set; }    
        public decimal HourlyCost { get; set; }    
        public int ID_City { get; set; }    
        public string Zip { get; set; }    
        public int ID_Country { get; set; }
        public DateTime ValidFrom { get; set; }    
        public int ID_User { get; set; }    
    }
}