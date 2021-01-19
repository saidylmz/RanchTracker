using RanchApp.DAL.App_Classes;
using RanchApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanchApp.BLL
{
    public class InseminationController
    {
        InseminationDAL inseminationDAL;
        public InseminationController()
        {
            inseminationDAL = new InseminationDAL();
        }

        public List<Insemination> GetAllInseminationByRanchID(int RanchID)
        {
            return inseminationDAL.GetAll().Where(x => x.Cattle.RanchID == RanchID).ToList();
        } 

        public bool AddInseminationForCattle(Insemination insemination)
        {
            return inseminationDAL.Add(insemination) > 0;
        }

        public bool CancelInsemination(int id)
        {
            Insemination insemination = inseminationDAL.GetByID(id);
            insemination.Result = false;
            return inseminationDAL.Update(insemination) > 0;
        }
        
        public Insemination GetInsemination(int id)
        {
            return inseminationDAL.GetByID(id);
        }

        public bool UpdateInsemination(int id, string date)
        {
            Insemination insemination = inseminationDAL.GetByID(id);
            insemination.Date = DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            return inseminationDAL.Update(insemination) >  0;
        }

        public void DeleteAllInsemination(string EarringNumber)
        {
            foreach (var item in inseminationDAL.GetAll().Where(x => x.CattleID == EarringNumber).ToList())
            {
                inseminationDAL.Delete(item);
            }
        }
    }
}
