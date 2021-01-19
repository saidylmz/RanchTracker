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
    public class CattleTypeDAL
    {
        RanchDbContext db;
        public CattleTypeDAL()
        {
            db = new RanchDbContext();
        }

        public int Add(CattleType cattleType)
        {
            db.Entry(cattleType).State = EntityState.Added;
            return db.SaveChanges();
        }

        public int Update(CattleType cattleType)
        {
            db.Entry(cattleType).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(CattleType cattleType)
        {
            db.Entry(cattleType).State = EntityState.Deleted;
            return db.SaveChanges();
        }

        public List<CattleType> GetAll()
        {
            return db.CattleTypes.ToList();
        }

        public CattleType GetByID(int id)
        {
            return db.CattleTypes.Find(id);
        }
    }
}
