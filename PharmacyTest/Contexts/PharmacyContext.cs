using Microsoft.EntityFrameworkCore;
using PharmacyTest.Domains;

namespace PharmacyTest.Contexts
{
    public class PharmacyContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= DESKTOP-3BKCPN3; Database=Pharmacy; User Id =sa; pwd =Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
