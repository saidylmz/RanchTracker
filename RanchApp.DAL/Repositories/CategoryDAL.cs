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
    public class CategoryDAL
    {
        RanchDbContext db;
        public CategoryDAL()
        {
            db = new RanchDbContext();
        }

        public int Add(Category category)
        {
            db.Entry(category).State = EntityState.Added;
            return db.SaveChanges();
        }

        public int Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(Category category)
        {
            db.Entry(category).State = EntityState.Deleted;
            return db.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }
        
        public Category GetByID (int id)
        {
            return db.Categories.Find(id);
        }
    }
}
