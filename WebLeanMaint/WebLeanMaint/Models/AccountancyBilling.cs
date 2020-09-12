using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLeanMaint.Models
{
    [Table("Billings",Schema ="Accountancy")]
     public class AccountancyBilling
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_Billing { get; set; }
        public int ID_Operator { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Activation { get; set; }
        public DateTime End { get; set; }
        public decimal HourlyCost { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public decimal Value { get; set; }
    }
}