using RanchApp.DAL.App_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanchApp.DAL.Entities
{
    public class RanchDbContext:DbContext
    {
        public RanchDbContext():base("")
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ranch> Ranches { get; set; }
        public DbSet<Cattle> Cattles { get; set; }
        public DbSet<CattleType> CattleTypes { get; set; }
        public DbSet<Insemination> Inseminations { get; set; }
        public DbSet<Milk> Milks { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Cattle>().HasMany(x => x.Milks).WithRequired().HasForeignKey(x => x.CattleID);
            //modelBuilder.Entity<Cattle>().HasMany(x => x.Inseminations).WithRequired().HasForeignKey(x => x.CattleID);
            modelBuilder.Entity<Cattle>().HasKey(x => x.EarringNumber);
            modelBuilder.Entity<Category>().Property(x => x.Image).HasColumnType("Image");

            modelBuilder.Entity<CattleType>().HasRequired(x => x.Ranch).WithMany(x=>x.CattleTypes).HasForeignKey(x => x.RanchID).WillCascadeOnDelete(false);

        }
    }
}
