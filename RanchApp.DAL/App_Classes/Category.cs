using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanchApp.DAL.App_Classes
{
    public class Category
    {
        //BüyükBaş - KüçükBaş
        public int ID { get; set; }
        public string Name { get; set; } 
        public byte[] Image { get; set; }

        public virtual ICollection<CattleType> CattleTypes { get; set; }
    }
}
