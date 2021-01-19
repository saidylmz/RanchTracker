using RanchApp.DAL.App_Classes;
using RanchApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanchApp.DAL.Repositories
{
    public class MilkDAL
    {
        RanchDbContext db;
        public MilkDAL()
        {
            db = new RanchDbContext();
        }

        public int Add(Milk milk)
        {
            db.Entry(milk).State = EntityState.Added;
            return db.SaveChanges();
        }

        public int Update(Milk milk)
        {
            db.Entry(milk).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(Milk milk)
        {
            db.Entry(milk).State = EntityState.Deleted;
            return db.SaveChanges();
        }

        public List<Milk> GetAll()
        {
            return db.Milks.ToList();
        }

        public Milk GetByID(int id)
        {
            return db.Milks.Find(id);
        }
    }
}
