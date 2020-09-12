using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLeanMaint.Models
{
   [Table("Operators", Schema = "Planning")]
    public class PlanningOperators
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_Operator { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public int ID_OperatorType { get; set; }
        public int ID_Calendar { get; set; }
        public int? ID_Supplier { get; set; }
        public int? ID_CostCenter { get; set; }
        public decimal HourlyCost { get; set; }
        public int ID_ObjStatus { get; set; }
        public int ID_User { get; set; }
    }
}