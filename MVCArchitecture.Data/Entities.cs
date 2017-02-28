using MVCArchitecture.Data.Configuration;
using MVCArchitecture.Model.Models;
using System.Data.Entity;

namespace MVCArchitecture.Data
{
    public class Entities : DbContext
    {
        public Entities() : base("DataBaseConexion") { }

        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GadgetConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
