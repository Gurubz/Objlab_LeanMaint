using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLeanMaint.Models
{
   [Table("OperatorTypes", Schema = "Planning")]
    public class PlanningOperatorTypes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_OperatorType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}