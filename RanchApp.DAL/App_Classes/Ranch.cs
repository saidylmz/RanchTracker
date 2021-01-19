using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanchApp.DAL.App_Classes
{
    public class Ranch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Email { get; set; }
        public byte[] Logo { get; set; }
        public bool Role { get; set; } 

        //Mapping
        public virtual ICollection<Cattle> Cattles { get; set; }
        public virtual ICollection<CattleType> CattleTypes { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
    }
}
