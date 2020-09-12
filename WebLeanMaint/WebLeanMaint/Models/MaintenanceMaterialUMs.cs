using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;

namespace WebLeanMaint.Models
{
  [Table("MaterialUMs", Schema = "Maintenance")]
  public class MaintenanceMaterialUMs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_MaterialUM { get; set; }
        public string Name { get; set; }
        
    }
}