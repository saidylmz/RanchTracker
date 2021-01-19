using RanchTracker.DAL.App_Classes;
using RanchTracker.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanchTracker.BLL
{
    public class MilkController
    {
        MilkDAL milkDAL; 
        public MilkController()
        {
            milkDAL = new MilkDAL(); 
        }

        public bool AddMilkByEarringNumber(Milk milk)
        {
            return milkDAL.Add(milk) > 0;
        }

        public bool DeleteMilkByMilkID(int ID)
        {
            return milkDAL.Delete(milkDAL.GetByID(ID)) > 0;
        }

        public Milk GetMilkForUpdate(int id)
        {
            return milkDAL.GetByID(id);
        }

        public bool UpdateMilk(Milk milk)
        {
            return milkDAL.Update(milk) > 0;
        }

        
    }
}
