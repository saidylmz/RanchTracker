using RanchTracker.DAL.App_Classes;
using RanchTracker.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanchTracker.DAL.Repositories
{
    public class CattleDAL
    {
        RanchDbContext db;
        public CattleDAL()
        {
            db = new RanchDbContext();
        }

        public int Add(Cattle cattle)
        {
            db.Entry(cattle).State = EntityState.Added;
            return db.SaveChanges();
        }

        public int Update(Cattle cattle)
        {
            db.Entry(cattle).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(Cattle cattle)
        {
            db.Entry(cattle).State = EntityState.Deleted;
            return db.SaveChanges();
        }

        public List<Cattle> GetAll()
        {
            return db.Cattles.ToList();
        }

        public Cattle GetByEarringNumber(string EarringNumber)
        {
            return db.Cattles.Find(EarringNumber);
        }
    }
}
