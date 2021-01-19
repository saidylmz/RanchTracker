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
    public class RanchDAL
    {
        RanchDbContext db;
        public RanchDAL()
        {
            db = new RanchDbContext();
        }

        public int Add(Ranch ranch)
        {
            db.Entry(ranch).State = EntityState.Added;
            return db.SaveChanges();
        }

        public int Update(Ranch ranch)
        {
            db.Entry(ranch).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(Ranch ranch)
        {
            db.Entry(ranch).State = EntityState.Deleted;
            return db.SaveChanges();
        }

        public List<Ranch> GetAll()
        {
            return db.Ranches.ToList();
        }

        public Ranch GetByID(int id)
        {
            return db.Ranches.Find(id);
        }
    }
}
