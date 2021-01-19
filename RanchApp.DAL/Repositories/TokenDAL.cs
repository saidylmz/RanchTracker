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
    public class TokenDAL
    {
        RanchDbContext db;
        public TokenDAL()
        {
            db = new RanchDbContext();
        }

        public int Add(Token token)
        {
            db.Entry(token).State = EntityState.Added;
            return db.SaveChanges();
        }

        public int Update(Token token)
        {
            db.Entry(token).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(Token token)
        {
            db.Entry(token).State = EntityState.Deleted;
            return db.SaveChanges();
        }

        public List<Token> GetAll()
        {
            return db.Tokens.ToList();
        }

        public Token GetByID(int id)
        {
            return db.Tokens.Find(id);
        }
    }
}
