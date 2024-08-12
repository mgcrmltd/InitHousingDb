using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace HousingContext
{
    public class HousingDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Premises> Premises { get; set; }
        public DbSet<PremisesAddress> PremisesAddresses { get; set; }
        public DbSet<RevenueAccount> RevenueAccounts { get; set; }
        public DbSet<Tenancy> Tenancies { get; set; }
        public DbSet<TenancyPremises> TenancyPremises { get; set; }
        public DbSet<TenancyOccupant> TenancyOccupants { get; set; }
        public DbSet<PremisesGroup> PremisesGroups { get; set; }
        public DbSet<PremisesPremisesGroup> PremisesPremisesGroups { get; set; }
        public DbSet<PremisesGroupUserRole> PremisesGroupUserRoles { get; set; }
        public DbSet<PremisesContactMethod> PremisesContactMethods { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<PremisesElement> PremisesElements { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<LeaseType> LeaseTypes { get; set; }
        public DbSet<TenancyType> TenancyTypes { get; set; }
        public DbSet<TenancySource> TenancySources { get; set; }
        public DbSet<TenureType> TenureTypes { get; set; }
        public DbSet<PremisesType> PremisesTypes { get; set; }
        public DbSet<PremisesGroupType> PremisesGroupTypes { get; set; }
        public DbSet<RevenueAccountType> RevenueAccountTypes { get; set; }
        public DbSet<PropertySource> PropertySources { get; set; }
        public DbSet<PropertyStatus> PropertyStatuses { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<OwnershipType> OwnershipTypes { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<ContactMethod> ContactMethods { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=tcp:mgxrmpeabody.database.windows.net,1433;Initial Catalog=peabodyremote;Persist Security Info=False;User ID=peabodyadmin;Password=HFJv9pt$7j#h;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=3000");
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
