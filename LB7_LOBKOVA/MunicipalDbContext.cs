using System.Data.Entity;

namespace LB7_LOBKOVA
{
    public class MunicipalDbContext : DbContext
    {
        public MunicipalDbContext() : base("MunicipalConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MunicipalDbContext>());
        }

        public DbSet<Division> Divisions { get; set; }
    }
}
