using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanchTracker.DAL.App_Classes
{
    public class Token
    {
        public int ID { get; set; }
        public string DeviceToken { get; set; }
        public int RanchID { get; set; }

        //mapping
        public virtual Ranch Ranch { get; set; }


    }
}
