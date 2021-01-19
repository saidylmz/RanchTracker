using RanchTracker.DAL.App_Classes;
using RanchTracker.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanchTracker.BLL
{
    public class CattleController
    {
        CattleDAL cattleDAL;
        public CattleController()
        {
            cattleDAL = new CattleDAL();
        }

        public List<Cattle> GetCattlesByCattleTypeID(int cattleTypeID,int RanchID)
        {

            List<Cattle> cattles = cattleDAL.GetAll().Where(x => x.CattleTypeID == cattleTypeID && x.RanchID == RanchID).ToList();
            return cattles;
        }

        public bool AnyEarringNumber(string EarringNumber)
        {
            return cattleDAL.GetAll().Any(x => x.EarringNumber.ToLower() == EarringNumber.ToLower());
        }

        public bool AddCattle(Cattle cattle)
        {
            if (cattleDAL.GetAll().Any(x => x.EarringNumber.ToLower() == cattle.EarringNumber.ToLower()))
                return false;
            return cattleDAL.Add(cattle) > 0;
        }

        public Cattle GetCattleByEarringNumber(string EarringNumber)
        {
            return cattleDAL.GetAll().Where(x => x.EarringNumber == EarringNumber).FirstOrDefault();
        }

        public bool UpdateCattle(Cattle cattle)
        {
            return cattleDAL.Update(cattle) > 0;
        }

        public bool DeleteCattle(string EarringNumber)
        {
            Cattle WillDeleteCattle = cattleDAL.GetByEarringNumber(EarringNumber);
            return cattleDAL.Delete(WillDeleteCattle) > 0;
        }

        public List<Cattle> AllCattleMilksByRanchID(int RanchID)
        {
            return cattleDAL.GetAll().Where(x => x.RanchID == RanchID).ToList();
        }


    }
}
