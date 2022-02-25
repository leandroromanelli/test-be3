using Be3Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Be3Test.Infra.Context
{
    public class Be3TestContext : DbContext
    {
        public Be3TestContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<InsuranceCard> InsuranceCards { get; set; }
    }
}
