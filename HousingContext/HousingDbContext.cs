using Microsoft.EntityFrameworkCore;

namespace HousingContext
{
    public class HousingDbContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PropertySubType> PropertySubTypes { get; set; }
        public DbSet<LeaseType> LeaseTypes { get; set; }
        public DbSet<TenancyType> TenancyTypes { get; set; }
        public DbSet<TenureType> TenureTypes { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=172.30.115.88;User ID=SA;Password=xxxxxxx;Initial Catalog=Housing;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
