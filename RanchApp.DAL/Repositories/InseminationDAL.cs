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
    public class InseminationDAL
    {
        RanchDbContext db;
        public InseminationDAL()
        {
            db = new RanchDbContext();
        }

        public int Add(Insemination insemination)
        {
            db.Entry(insemination).State = EntityState.Added;
            return db.SaveChanges();
        }

        public int Update(Insemination insemination)
        {
            db.Entry(insemination).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(Insemination insemination)
        {
            db.Entry(insemination).State = EntityState.Deleted;
            return db.SaveChanges();
        }

        public List<Insemination> GetAll()
        {
            return db.Inseminations.ToList();
        }

        public Insemination GetByID(int id)
        {
            return db.Inseminations.Find(id);
        }
    }
}
