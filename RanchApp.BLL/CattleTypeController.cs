using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RanchTracker.DAL.App_Classes;
using RanchTracker.DAL.Repositories;
namespace RanchTracker.BLL
{
     
    public class CattleTypeController
    {
        CattleTypeDAL cattleTypeDAL;
        public CattleTypeController()
        {
            cattleTypeDAL = new CattleTypeDAL();
        }
        public List<CattleType> GetCattleTypesByCategoryID(int CategoryID,int RanchID)
        {
            List<CattleType> cattleTypes = cattleTypeDAL.GetAll().Where(x => x.CategoryID == CategoryID && x.RanchID == RanchID).ToList();
            return cattleTypes;
        }

        public bool AddCattleType(CattleType cattleType)
        { 
            if (cattleTypeDAL.GetAll().Any(x => x.Name.ToLower() == cattleType.Name.ToLower() && x.RanchID == cattleType.RanchID))
                return false;
            return cattleTypeDAL.Add(cattleType) > 0;
        }

        public List<CattleType> GetAll(int RanchID)
        {
            return cattleTypeDAL.GetAll().Where(x=>x.RanchID == RanchID).ToList();
        }

        public bool DeleteCattleType(CattleType cattleType)
        {
            return cattleTypeDAL.Delete(cattleType) > 0;
        }

        
        
    }
}
