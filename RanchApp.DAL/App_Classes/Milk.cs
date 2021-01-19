using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanchTracker.DAL.App_Classes
{
    public class Milk
    {
        public int ID { get; set; }
        [ForeignKey("Cattle")]
        public string CattleID { get; set; } 
        public DateTime Date { get; set; }
        [Column(TypeName ="decimal")]
        public decimal Liter { get; set; }

        // Mapping 
        public virtual Cattle Cattle { get; set; }
    }
}
