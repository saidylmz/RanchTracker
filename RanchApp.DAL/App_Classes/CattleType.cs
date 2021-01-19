using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanchApp.DAL.App_Classes
{
    public class CattleType
    {   //inek-boğa
        public int ID { get; set; }
        public string Name { get; set; } 
        public bool IsInsemination { get; set; }   //Tohumlama
        [ForeignKey("Categories")]
        public int CategoryID { get; set; }
        [ForeignKey("Ranch")]
        public int RanchID { get; set; }
        //Mapping
        public virtual Category Categories { get; set; }
        public virtual Ranch Ranch { get; set; }

        public virtual ICollection<Cattle> Cattles { get; set; }
    }
}
