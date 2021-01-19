using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanchTracker.DAL.App_Classes
{
    public class Cattle
    {
    
        [Key]
        public string EarringNumber { get; set; }
        public string MomEarringNumber { get; set; }
        public string Name { get; set; } 
        public DateTime BirthDate { get; set; } 
        public string Type { get; set; }
        public string Description { get; set; }
        public int RanchID { get; set; }
        public int CattleTypeID { get; set; }

        // Mapping 
        public virtual CattleType CattleType { get; set; }
        public virtual Ranch Ranch { get; set; }
        public virtual ICollection<Insemination> Inseminations { get; set; }
        public virtual ICollection<Milk> Milks { get; set; }

    }
}
