using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;

using HousingContext;
using SetupHousingDB.Builders.Occupants;
using SetupHousingDB.Builders.Property;
using SetupHousingDB.Builders.Tenancy;

namespace SetupHousingDB
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Start DB Setup");
            var housingContext = new HousingDbContext();
            housingContext.Database.EnsureDeleted();
            housingContext.Database.EnsureCreated();

            var dataGenerator = new GenDataUsingBuilders();
            dataGenerator.Generate();
            dataGenerator.PopulateContext(housingContext);
            housingContext.SaveChanges();
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        public class GenDataUsingBuilders
        {
            protected List<Property> PropertyList = new List<Property>();
            protected List<PropertyType> PropertyTypeList = new List<PropertyType>();
            protected List<PropertySubType> PropertySubTypeList = new List<PropertySubType>();
            protected List<LeaseType> LeaseTypeList = new List<LeaseType>();
            protected List<TenancyType> TenancyTypeList = new List<TenancyType>();
            protected List<TenureType> TenureTypeList = new List<TenureType>();
            protected List<Tenancy> TenancyList = new List<Tenancy>();
            protected List<Tenant> TenantList = new List<Tenant>();
            protected List<Person> PersonList = new List<Person>();
            protected List<Gender> GenderList = new List<Gender>();
            protected List<AddressType> AddressTypeList = new List<AddressType>();
            protected List<Address> AddressList = new List<Address>();
            protected List<AssociatedAddress> AssociatedAddressList = new List<AssociatedAddress>();

            public void Generate()
            {
                GenerateReferenceData();
                CreateProperties();
                CreateTenancies();
                CreateTenants();
            }

            public void PopulateContext(HousingDbContext context)
            {
                context.LeaseTypes.AddRange(LeaseTypeList);
                context.Genders.AddRange(GenderList);
                context.AddressTypes.AddRange(AddressTypeList);
                context.Addresses.AddRange(AddressList);
                context.Properties.AddRange(PropertyList);
                context.PropertyTypes.AddRange(PropertyTypeList);
                context.PropertySubTypes.AddRange(PropertySubTypeList);
                context.TenancyTypes.AddRange(TenancyTypeList);
                context.TenureTypes.AddRange(TenureTypeList);
                context.Tenants.AddRange(TenantList);
                context.People.AddRange(PersonList);
                context.AssociatedAddresses.AddRange(AssociatedAddressList);
            }

            private void CreateTenants()
            {
                var occDirector = new OccupantsDirector();
                var single = new SingleOccupancyBuilder();
                var joint = new JointOccupancyBuilder();
                var couple = new CoupleOccupancyBuilder();
                var family = new FamilyOccupancyBuilder();

                foreach (var tenancy in TenancyList)
                {
                    switch (Faker.RandomNumber.Next(1, 4))
                    {
                        case 1:
                            occDirector.Build(single, PersonList, GenderList, tenancy, TenantList);
                            break;
                        case 2:
                            occDirector.Build(joint, PersonList, GenderList, tenancy, TenantList);
                            break;
                        case 3:
                            occDirector.Build(couple, PersonList, GenderList, tenancy, TenantList);
                            break;
                        case 4:
                            occDirector.Build(family, PersonList, GenderList, tenancy, TenantList);
                            break;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                }
            }

            private void CreateTenancies()
            {
                
                var tenancyDirector = new TenancyDirector();
                var tBuilder = new TenancyBuilderStandard();

                var ids = (from p in PropertyList
                    where p.PropertyTypeId.Name != "BLK" && p.PropertyTypeId.Name != "EST"
                    select p.Id);

                foreach (var id in ids)
                {
                    var prop = PropertyList.First(x => x.Id == id);
                    TenancyList.Add(tenancyDirector.Build(tBuilder, TenancyList, TenancyTypeList, TenureTypeList,
                        prop));
                }
            }

            private void CreateProperties()
            {
                var estateBuilder = new EstatePropertyBuilder();
                var blockBuilder = new BlockPropertyBuilder();
                var flatBuilder = new FlatPropertyBuilder();
                var propDirector = new PropertyDirector();

                PropertyList.Add(propDirector.Build(estateBuilder, PropertyList, PropertyTypeList, PropertySubTypeList, LeaseTypeList,
                    AddressList, AssociatedAddressList, AddressTypeList, null));

                PropertyList.Add(propDirector.Build(estateBuilder, PropertyList, PropertyTypeList, PropertySubTypeList, LeaseTypeList,
                    AddressList, AssociatedAddressList, AddressTypeList, null));

                PropertyList.Add(propDirector.Build(estateBuilder, PropertyList, PropertyTypeList, PropertySubTypeList, LeaseTypeList,
                    AddressList, AssociatedAddressList, AddressTypeList, null));

                PropertyList.Add(propDirector.Build(estateBuilder, PropertyList, PropertyTypeList, PropertySubTypeList, LeaseTypeList,
                    AddressList, AssociatedAddressList, AddressTypeList, null));

                //USe ToList to get a copy. Cannot iterate through list we will modify
                var estates = PropertyList.Where(x => x.PropertyTypeId.Name == "EST").ToList();

                foreach(var est in estates)
                {
                    for (var i = 0; i < 3; i++)
                    {
                        PropertyList.Add(propDirector.Build(blockBuilder, PropertyList, PropertyTypeList, PropertySubTypeList, LeaseTypeList,
                            AddressList, AssociatedAddressList, AddressTypeList, est));
                    }
                }

                var blocks = PropertyList.Where(x => x.PropertyTypeId.Name == "BLK").ToList();

                foreach(var blk in blocks)
                {
                    var flatCount = Faker.RandomNumber.Next(20, 30);
                    for (var i = 0; i < flatCount; i++)
                    {
                        PropertyList.Add(propDirector.Build(flatBuilder, PropertyList, PropertyTypeList, PropertySubTypeList, LeaseTypeList,
                            AddressList, AssociatedAddressList, AddressTypeList, blk));
                    }
                }

                var houseBuilder = new HousePropertyBuilder();

                for(var i = 0; i < 300; i++)
                {
                    PropertyList.Add(propDirector.Build(houseBuilder, PropertyList, PropertyTypeList, PropertySubTypeList, LeaseTypeList,
                        AddressList, AssociatedAddressList, AddressTypeList, null));
                }
            }
            private void GenerateReferenceData()
            {
                AddPropertyTypes();
                AddPropertySubTypes();
                AddLeaseTypes();
                AddTenancyTypes();
                AddTenureTypes();
                AddAddressTypes();
                AddGenders();
            }
            
            private void AddAddressTypes()
            {
                AddressTypeList.Add(new AddressType()
                    {Name = "Postal", Description = "Main address", Id = 10001});
                AddressTypeList.Add(new AddressType()
                    {Name = "Correspondence", Description = "Preferred address for correspondence", Id=10002});
                AddressTypeList.Add(new AddressType() {Name = "Legal", Description = "Used by legal team", Id=10003});
                AddressTypeList.Add(new AddressType()
                    {Name = "Alternate", Description = "For private correspondence",Id=10004});
            }

            private void AddTenureTypes()
            {
                TenureTypeList.Add(new TenureType()
                    {Name = "FMT", Description = "LdnHomes Tenure", Id = 10001});
                TenureTypeList.Add(new TenureType()
                    {Name = "FREE", Description = "FREEHOLDER TUNURE", Id = 10002});
                TenureTypeList.Add(new TenureType()
                    {Name = "GENERAL NEEDS", Description = "General Needs", Id = 10003});
                TenureTypeList.Add(new TenureType()
                    {Name = "INTRO", Description = "INTRODUCTORY", Id = 10004});
                TenureTypeList.Add(new TenureType()
                    {Name = "LEASHOLD", Description = "Leasehold", Id = 10005});
                TenureTypeList.Add(new TenureType() {Name = "MIG", Description = "Migration", Id = 10006});
                TenureTypeList.Add(new TenureType()
                    {Name = "MOSMIG", Description = "LdnHomes MIGRATION", Id = 10007});
                TenureTypeList.Add(new TenureType()
                    {Name = "NONSEC", Description = "NON-SECURE", Id = 10008});
                TenureTypeList.Add(new TenureType()
                    {Name = "PBMIG", Description = "LdnHomes Migration", Id = 10009});
                TenureTypeList.Add(new TenureType() {Name = "SECURE", Description = "SECURE", Id = 100010});
                TenureTypeList.Add(new TenureType() {Name = "STD", Description = "STANDARD", Id = 100011});
                TenureTypeList.Add(new TenureType()
                    {Name = "SUPPORTED HOUSING", Description = "Supported Housing", Id = 100012});
                TenureTypeList.Add(new TenureType()
                    {Name = "TEMPORARY ACCOMMODATION", Description = "Temporary Accommodation", Id = 100013});
            }

            private void AddTenancyTypes()
            {
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AGENCY", Description = "AGENCY MANAGED", Id = 10001});
                TenancyTypeList.Add(
                    new TenancyType() {Name = "ASS02", Description = "CBHA Assured", Id = 10002});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "ASS03", Description = "Regency Assured", Id = 10003});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "ASS06", Description = "Affordable Lifetime (Assured)", Id = 10004});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "ASS07", Description = "CBHA Affordable Lifetime (Ass)", Id = 10005});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "ASSURED", Description = "ASSURED", Id = 10006});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AST_KEY", Description = "KEYWORKER ASSURED SHORTHOLD", Id = 10007});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AST_RTTB", Description = "RENT TO BUY ASSURED SHORTHOLD", Id = 10008});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AST01", Description = "Affordable Rent 1 Year Intro", Id = 10009});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AST02", Description = "General Needs 1Year Intro AST", Id = 100010});
                TenancyTypeList.Add(
                    new TenancyType() {Name = "AST04", Description = "Market Rent", Id = 100011});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AST05", Description = "2 year fixed AST", Id = 100012});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AST06", Description = "Cost Rent AST", Id = 100013});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AST07", Description = "CBHA 17 to 24 AST", Id = 100014});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AST08", Description = "CBHA over 25 AST", Id = 100015});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AST09", Description = "Affordable Rent 5 Year Fixed", Id = 100016});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AST10", Description = "General Needs 5 Year Fixed AST", Id = 100017});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AST11", Description = "RSI 6 Month Introductory", Id = 100018});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AST12", Description = "Periodic AST", Id = 100019});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AST13", Description = "Afford Rent 2nd 5 Year Fixed", Id = 100020});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "AST14", Description = "Gen Needs 2nd 5 Year Fixed AST", Id = 100021});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "CARESUPP", Description = "CARE AND SUPPORT", Id = 100022});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "COM1", Description = "Commercial Property", Id = 100023});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "COM2", Description = "Live/Work Lease", Id = 100024});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "COMMAGE", Description = "Commercial Agency Managed", Id = 100025});
                TenancyTypeList.Add(
                    new TenancyType() {Name = "EMPLOYEE", Description = "EMPLOYEE", Id = 100026});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "FIX02", Description = "Second 5yr Fixed Ter tenancy", Id = 100027});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "FIXED", Description = "Fixed Term Tenancy", Id = 100028});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "FREEHOLD", Description = "FREE HOLD TENANCY TYPE", Id = 100029});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "GARAGE", Description = "GARAGE PARKING SPACE", Id = 100030});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "HMBY2010", Description = "HOMEBUY 2010", Id = 100031});
                TenancyTypeList.Add(
                    new TenancyType() {Name = "HOSTEL", Description = "HOSTEL", Id = 100032});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "INTERMED", Description = "INTERMEDIATE RENT", Id = 100033});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "LEASE100", Description = "LEASEHOLD 100% OWNERSHIP", Id = 100034});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "LEASECTH", Description = "LdnHomes Leaseholders", Id = 100035});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "LEASEHB5", Description = "5 year rent free period HOME BUY product", Id = 100036});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "LEASEHMB", Description = "LEASE HOMEBUY", Id = 100037});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "LEASEHSO", Description = "LEASE HOMEBUY SHARED OWNER", Id = 100038});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "LEASEOAK", Description = "OLD OAK LEASEHOLDERS", Id = 100039});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "LEASESEC", Description = "LEASEHOLD BIANNUAL FAIR RENT INCREASE", Id = 100040});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "LEASESHR", Description = "LEASEHOLD SHARED", Id = 100041});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "LIC01", Description = "Company Let (Resedential)", Id = 100042});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "LIC02", Description = "Shortlife Lease", Id = 100043});
                TenancyTypeList.Add(
                    new TenancyType() {Name = "LICENSEE", Description = "LICENSEE", Id = 100044});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "LICHOST", Description = "LICENCE HOSTLES", Id = 100045});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "LIFETIME", Description = "Lifetime Tenancy", Id = 100046});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "LMASHOLD", Description = "LMA SHOLDASS tenancies", Id = 100047});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "LMASSURE", Description = "LMA Assured", Id = 100048});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "OFFICE", Description = "OFFICE COMMERCIAL", Id = 100049});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "PEABTCY", Description = "LdnHomes TENANCY (EX LdnHomes)", Id = 100050});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "RTHMB3YR", Description = "Rent To Homebuy (3 year tenancy)", Id = 100051});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "SECP", Description = "SECURE LdnHomes", Id = 100052});
                TenancyTypeList.Add(
                    new TenancyType() {Name = "SECURE", Description = "SECURE", Id = 100053});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "SECUREV", Description = "SECURE TENANCIES WITH VARIABLE SERVICE C", Id = 100054});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "SHOLDASS", Description = "ASSURED SHORTHOLD", Id = 100055});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "SIMBA", Description = "Simba Housing Association", Id = 100056});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "SLEEPER", Description = "SLEEPING ROOM", Id = 100057});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "SOCSER", Description = "SOCIAL SERVICES", Id = 100058});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "SSHOSTEL", Description = "SOCIAL SERVICES HOSTEL", Id = 100059});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "STARTER", Description = "***DO NOT USE FOR NEW STARTER TENANCY***", Id = 100060});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "STARTFIX", Description = "Fixed Term Tenancy (in probation period)", Id = 100061});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "STARTLIF", Description = "Lifetime Tenancy (in probation period)", Id = 100062});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "SUB01", Description = "Store Licence", Id = 100063});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "TDE1", Description = "Temporary Decant", Id = 100064});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "TEMPLIC", Description = "TEMP LICENSEE", Id = 100065});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "USENOCCU", Description = "USE AND OCCUPATION ACCOUNTS", Id = 100066});
                TenancyTypeList.Add(new TenancyType()
                    {Name = "USENOCCU", Description = "USE AND OCCUPATION ACCOUNTS", Id = 100067});
            }

            private void AddPropertySubTypes()
            {
                PropertySubTypeList.Add(new PropertySubType()
                    {Name = "BASE", Description = "BASEMENT", Id = 10001});
                PropertySubTypeList.Add(new PropertySubType()
                    {Name = "DET", Description = "DETACHED", Id = 10002});
                PropertySubTypeList.Add(new PropertySubType()
                    {Name = "GROUD", Description = "GROUND", Id = 10003});
                PropertySubTypeList.Add(new PropertySubType()
                    {Name = "INT", Description = "INTERMEDIATE", Id = 10004});
                PropertySubTypeList.Add(new PropertySubType()
                    {Name = "SEMI", Description = "SEMI-DETACHED", Id = 10005});
                PropertySubTypeList.Add(new PropertySubType()
                    {Name = "TERR", Description = "TERRACED HOUSE", Id = 10006});
                PropertySubTypeList.Add(new PropertySubType()
                    {Name = "TGRN", Description = "External Green Space", Id = 10007});
                PropertySubTypeList.Add(new PropertySubType()
                    {Name = "TOP", Description = "TOP FLOOR", Id = 10008});
                PropertySubTypeList.Add(new PropertySubType()
                    {Name = "TREND", Description = "END OF TERRACE", Id = 10009});
                PropertySubTypeList.Add(new PropertySubType()
                    {Name = "TRMID", Description = "MID TERRACE", Id = 100010});
            }

            private void AddPropertyTypes()
            {
                PropertyTypeList.Add(new PropertyType() {Name = "FLT", Description = "FLAT OR APARTMENT", Id = 100024});
                PropertyTypeList.Add(
                    new PropertyType() {Name = "HSE", Description = "HOUSE", Id = 100025});
                PropertyTypeList.Add(new PropertyType() {Name = "BLK", Description = "BLOCK", Id = 100027});
                PropertyTypeList.Add(new PropertyType()
                    {Name = "EST", Description = "ESTATE", Id = 100028});
            }

            private void AddLeaseTypes()
            {
                LeaseTypeList.Add(
                    new LeaseType() {Name = "R01", Description = "1 YEAR RENEWAL", Id = 10005});
                LeaseTypeList.Add(
                    new LeaseType() {Name = "R02", Description = "2 YEAR RENEWAL", Id = 10006});
                LeaseTypeList.Add(
                    new LeaseType() {Name = "R03", Description = "3 YEAR RENEWAL", Id = 10007});
                LeaseTypeList.Add(
                    new LeaseType() {Name = "R04", Description = "4 YEAR RENEWAL", Id = 10008});
                LeaseTypeList.Add(
                    new LeaseType() {Name = "R05", Description = "5 YEAR RENEWAL", Id = 10009});
                LeaseTypeList.Add(
                    new LeaseType() {Name = "SOWFLT", Description = "FLAT LEASEHOLD", Id = 100019});
                LeaseTypeList.Add(new LeaseType()
                    {Name = "SOWHSE", Description = "HOUSE LEASEHOLD", Id = 100020});
                LeaseTypeList.Add(new LeaseType()
                    {Name = "Y01", Description = "1 YEAR LEASE", Id = 100021});
                LeaseTypeList.Add(new LeaseType()
                    {Name = "Y02", Description = "2 YEAR LEASE", Id = 100022});
                LeaseTypeList.Add(new LeaseType()
                    {Name = "Y03", Description = "3 YEAR LEASE", Id = 100023});
                LeaseTypeList.Add(new LeaseType()
                    {Name = "Y04", Description = "4 YEAR LEASE", Id = 100024});
                LeaseTypeList.Add(new LeaseType()
                    {Name = "Y05", Description = "5 YEAR LEASE", Id = 100025});
                LeaseTypeList.Add(new LeaseType()
                    {Name = "Y06", Description = "6 YEAR LEASE", Id = 100026});
                LeaseTypeList.Add(new LeaseType()
                    {Name = "Y07", Description = "7 YEAR LEASE", Id = 100027});
                LeaseTypeList.Add(new LeaseType()
                    {Name = "Y08", Description = "8 YEAR LEASE", Id = 100028});
                LeaseTypeList.Add(new LeaseType()
                    {Name = "Y09", Description = "9 YEAR LEASE", Id = 100029});
                LeaseTypeList.Add(
                    new LeaseType() {Name = "Y10", Description = "10 YEAR LEASE", Id = 100030});
                LeaseTypeList.Add(
                    new LeaseType() {Name = "Y11", Description = "11 YEAR LEASE", Id = 100031});
                LeaseTypeList.Add(
                    new LeaseType() {Name = "Y12", Description = "12 YEAR LEASE", Id = 100032});
                LeaseTypeList.Add(
                    new LeaseType() {Name = "Y13", Description = "13 YEAR LEASE", Id = 100033});
                LeaseTypeList.Add(
                    new LeaseType() {Name = "Y14", Description = "14 YEAR LEASE", Id = 100034});
                LeaseTypeList.Add(
                    new LeaseType() {Name = "Y15", Description = "15 YEAR LEASE", Id = 100035});
                LeaseTypeList.Add(
                    new LeaseType() {Name = "Y15", Description = "15 YEAR LEASE", Id = 100036});
            }

            private void AddGenders()
            {
                GenderList.Add(new Gender() {Id = 100001, Name = "Male", Description = "Male"});
                GenderList.Add(new Gender() {Id = 100002, Name = "Female", Description = "Female"});
            }

        }

        public class GenerateData
        {
            private List<Property> _properties = new List<Property>();
            private List<Address> _addresses = new List<Address>();
            private List<AssociatedAddress> _associatedAddresses = new List<AssociatedAddress>();
            private HousingDbContext _context;

            public GenerateData(HousingDbContext housingContext)
            {
                _context = housingContext;
            }

            public void Generate()
            {
                GenerateReferenceData();
            }

            private void GenerateReferenceData()
            {
                AddPropertyTypes(_context);
                AddPropertySubTypes(_context);
                AddLeaseTypes(_context);
                AddTenancyTypes(_context);
                AddTenureTypes(_context);
                AddAddressTypes(_context);
                AddGenders(_context);
            }
            
            private static void AddAddressTypes(HousingDbContext housingContext)
            {
                housingContext.AddressTypes.Add(new AddressType()
                    {Name = "Postal", Description = "Main address", Id = 10001});
                housingContext.AddressTypes.Add(new AddressType()
                    {Name = "Correspondence", Description = "Preferred address for correspondence"});
                housingContext.AddressTypes.Add(new AddressType() {Name = "Legal", Description = "Used by legal team"});
                housingContext.AddressTypes.Add(new AddressType()
                    {Name = "Alternate", Description = "For private correspondence"});
            }

            private static void AddTenureTypes(HousingDbContext housingContext)
            {
                housingContext.TenureTypes.Add(new TenureType()
                    {Name = "FMT", Description = "LdnHomes Tenure", Id = 10001});
                housingContext.TenureTypes.Add(new TenureType()
                    {Name = "FREE", Description = "FREEHOLDER TUNURE", Id = 10002});
                housingContext.TenureTypes.Add(new TenureType()
                    {Name = "GENERAL NEEDS", Description = "General Needs", Id = 10003});
                housingContext.TenureTypes.Add(new TenureType()
                    {Name = "INTRO", Description = "INTRODUCTORY", Id = 10004});
                housingContext.TenureTypes.Add(new TenureType()
                    {Name = "LEASHOLD", Description = "Leasehold", Id = 10005});
                housingContext.TenureTypes.Add(new TenureType() {Name = "MIG", Description = "Migration", Id = 10006});
                housingContext.TenureTypes.Add(new TenureType()
                    {Name = "MOSMIG", Description = "LdnHomes MIGRATION", Id = 10007});
                housingContext.TenureTypes.Add(new TenureType()
                    {Name = "NONSEC", Description = "NON-SECURE", Id = 10008});
                housingContext.TenureTypes.Add(new TenureType()
                    {Name = "PBMIG", Description = "LdnHomes Migration", Id = 10009});
                housingContext.TenureTypes.Add(new TenureType() {Name = "SECURE", Description = "SECURE", Id = 100010});
                housingContext.TenureTypes.Add(new TenureType() {Name = "STD", Description = "STANDARD", Id = 100011});
                housingContext.TenureTypes.Add(new TenureType()
                    {Name = "SUPPORTED HOUSING", Description = "Supported Housing", Id = 100012});
                housingContext.TenureTypes.Add(new TenureType()
                    {Name = "TEMPORARY ACCOMMODATION", Description = "Temporary Accommodation", Id = 100013});
            }

            private static void AddTenancyTypes(HousingDbContext housingContext)
            {
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AGENCY", Description = "AGENCY MANAGED", Id = 10001});
                housingContext.TenancyTypes.Add(
                    new TenancyType() {Name = "ASS02", Description = "CBHA Assured", Id = 10002});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "ASS03", Description = "Regency Assured", Id = 10003});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "ASS06", Description = "Affordable Lifetime (Assured)", Id = 10004});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "ASS07", Description = "CBHA Affordable Lifetime (Ass)", Id = 10005});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "ASSURED", Description = "ASSURED", Id = 10006});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AST_KEY", Description = "KEYWORKER ASSURED SHORTHOLD", Id = 10007});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AST_RTTB", Description = "RENT TO BUY ASSURED SHORTHOLD", Id = 10008});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AST01", Description = "Affordable Rent 1 Year Intro", Id = 10009});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AST02", Description = "General Needs 1Year Intro AST", Id = 100010});
                housingContext.TenancyTypes.Add(
                    new TenancyType() {Name = "AST04", Description = "Market Rent", Id = 100011});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AST05", Description = "2 year fixed AST", Id = 100012});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AST06", Description = "Cost Rent AST", Id = 100013});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AST07", Description = "CBHA 17 to 24 AST", Id = 100014});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AST08", Description = "CBHA over 25 AST", Id = 100015});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AST09", Description = "Affordable Rent 5 Year Fixed", Id = 100016});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AST10", Description = "General Needs 5 Year Fixed AST", Id = 100017});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AST11", Description = "RSI 6 Month Introductory", Id = 100018});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AST12", Description = "Periodic AST", Id = 100019});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AST13", Description = "Afford Rent 2nd 5 Year Fixed", Id = 100020});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "AST14", Description = "Gen Needs 2nd 5 Year Fixed AST", Id = 100021});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "CARESUPP", Description = "CARE AND SUPPORT", Id = 100022});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "COM1", Description = "Commercial Property", Id = 100023});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "COM2", Description = "Live/Work Lease", Id = 100024});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "COMMAGE", Description = "Commercial Agency Managed", Id = 100025});
                housingContext.TenancyTypes.Add(
                    new TenancyType() {Name = "EMPLOYEE", Description = "EMPLOYEE", Id = 100026});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "FIX02", Description = "Second 5yr Fixed Ter tenancy", Id = 100027});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "FIXED", Description = "Fixed Term Tenancy", Id = 100028});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "FREEHOLD", Description = "FREE HOLD TENANCY TYPE", Id = 100029});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "GARAGE", Description = "GARAGE PARKING SPACE", Id = 100030});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "HMBY2010", Description = "HOMEBUY 2010", Id = 100031});
                housingContext.TenancyTypes.Add(
                    new TenancyType() {Name = "HOSTEL", Description = "HOSTEL", Id = 100032});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "INTERMED", Description = "INTERMEDIATE RENT", Id = 100033});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "LEASE100", Description = "LEASEHOLD 100% OWNERSHIP", Id = 100034});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "LEASECTH", Description = "LdnHomes Leaseholders", Id = 100035});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "LEASEHB5", Description = "5 year rent free period HOME BUY product", Id = 100036});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "LEASEHMB", Description = "LEASE HOMEBUY", Id = 100037});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "LEASEHSO", Description = "LEASE HOMEBUY SHARED OWNER", Id = 100038});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "LEASEOAK", Description = "OLD OAK LEASEHOLDERS", Id = 100039});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "LEASESEC", Description = "LEASEHOLD BIANNUAL FAIR RENT INCREASE", Id = 100040});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "LEASESHR", Description = "LEASEHOLD SHARED", Id = 100041});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "LIC01", Description = "Company Let (Resedential)", Id = 100042});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "LIC02", Description = "Shortlife Lease", Id = 100043});
                housingContext.TenancyTypes.Add(
                    new TenancyType() {Name = "LICENSEE", Description = "LICENSEE", Id = 100044});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "LICHOST", Description = "LICENCE HOSTLES", Id = 100045});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "LIFETIME", Description = "Lifetime Tenancy", Id = 100046});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "LMASHOLD", Description = "LMA SHOLDASS tenancies", Id = 100047});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "LMASSURE", Description = "LMA Assured", Id = 100048});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "OFFICE", Description = "OFFICE COMMERCIAL", Id = 100049});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "PEABTCY", Description = "LdnHomes TENANCY (EX LdnHomes)", Id = 100050});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "RTHMB3YR", Description = "Rent To Homebuy (3 year tenancy)", Id = 100051});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "SECP", Description = "SECURE LdnHomes", Id = 100052});
                housingContext.TenancyTypes.Add(
                    new TenancyType() {Name = "SECURE", Description = "SECURE", Id = 100053});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "SECUREV", Description = "SECURE TENANCIES WITH VARIABLE SERVICE C", Id = 100054});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "SHOLDASS", Description = "ASSURED SHORTHOLD", Id = 100055});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "SIMBA", Description = "Simba Housing Association", Id = 100056});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "SLEEPER", Description = "SLEEPING ROOM", Id = 100057});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "SOCSER", Description = "SOCIAL SERVICES", Id = 100058});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "SSHOSTEL", Description = "SOCIAL SERVICES HOSTEL", Id = 100059});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "STARTER", Description = "***DO NOT USE FOR NEW STARTER TENANCY***", Id = 100060});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "STARTFIX", Description = "Fixed Term Tenancy (in probation period)", Id = 100061});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "STARTLIF", Description = "Lifetime Tenancy (in probation period)", Id = 100062});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "SUB01", Description = "Store Licence", Id = 100063});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "TDE1", Description = "Temporary Decant", Id = 100064});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "TEMPLIC", Description = "TEMP LICENSEE", Id = 100065});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "USENOCCU", Description = "USE AND OCCUPATION ACCOUNTS", Id = 100066});
                housingContext.TenancyTypes.Add(new TenancyType()
                    {Name = "USENOCCU", Description = "USE AND OCCUPATION ACCOUNTS", Id = 100067});
            }

            private static void AddPropertySubTypes(HousingDbContext housingContext)
            {
                housingContext.PropertySubTypes.Add(new PropertySubType()
                    {Name = "BASE", Description = "BASEMENT", Id = 10001});
                housingContext.PropertySubTypes.Add(new PropertySubType()
                    {Name = "DET", Description = "DETACHED", Id = 10002});
                housingContext.PropertySubTypes.Add(new PropertySubType()
                    {Name = "GROUD", Description = "GROUND", Id = 10003});
                housingContext.PropertySubTypes.Add(new PropertySubType()
                    {Name = "INT", Description = "INTERMEDIATE", Id = 10004});
                housingContext.PropertySubTypes.Add(new PropertySubType()
                    {Name = "SEMI", Description = "SEMI-DETACHED", Id = 10005});
                housingContext.PropertySubTypes.Add(new PropertySubType()
                    {Name = "TERR", Description = "TERRACED HOUSE", Id = 10006});
                housingContext.PropertySubTypes.Add(new PropertySubType()
                    {Name = "TGRN", Description = "External Green Space", Id = 10007});
                housingContext.PropertySubTypes.Add(new PropertySubType()
                    {Name = "TOP", Description = "TOP FLOOR", Id = 10008});
                housingContext.PropertySubTypes.Add(new PropertySubType()
                    {Name = "TREND", Description = "END OF TERRACE", Id = 10009});
                housingContext.PropertySubTypes.Add(new PropertySubType()
                    {Name = "TRMID", Description = "MID TERRACE", Id = 100010});
            }

            private static void AddPropertyTypes(HousingDbContext housingContext)
            {
                housingContext.PropertyTypes.Add(new PropertyType() {Name = "FLT", Description = "FLAT OR APARTMENT", Id = 100024});
                housingContext.PropertyTypes.Add(
                    new PropertyType() {Name = "HSE", Description = "HOUSE", Id = 100025});
                housingContext.PropertyTypes.Add(new PropertyType() {Name = "BLK", Description = "BLOCK", Id = 100027});
                housingContext.PropertyTypes.Add(new PropertyType()
                    {Name = "EST", Description = "ESTATE", Id = 100028});
            }

            private static void AddLeaseTypes(HousingDbContext housingContext)
            {
                housingContext.LeaseTypes.Add(
                    new LeaseType() {Name = "R01", Description = "1 YEAR RENEWAL", Id = 10005});
                housingContext.LeaseTypes.Add(
                    new LeaseType() {Name = "R02", Description = "2 YEAR RENEWAL", Id = 10006});
                housingContext.LeaseTypes.Add(
                    new LeaseType() {Name = "R03", Description = "3 YEAR RENEWAL", Id = 10007});
                housingContext.LeaseTypes.Add(
                    new LeaseType() {Name = "R04", Description = "4 YEAR RENEWAL", Id = 10008});
                housingContext.LeaseTypes.Add(
                    new LeaseType() {Name = "R05", Description = "5 YEAR RENEWAL", Id = 10009});
                housingContext.LeaseTypes.Add(
                    new LeaseType() {Name = "SOWFLT", Description = "FLAT LEASEHOLD", Id = 100019});
                housingContext.LeaseTypes.Add(new LeaseType()
                    {Name = "SOWHSE", Description = "HOUSE LEASEHOLD", Id = 100020});
                housingContext.LeaseTypes.Add(new LeaseType()
                    {Name = "Y01", Description = "1 YEAR LEASE", Id = 100021});
                housingContext.LeaseTypes.Add(new LeaseType()
                    {Name = "Y02", Description = "2 YEAR LEASE", Id = 100022});
                housingContext.LeaseTypes.Add(new LeaseType()
                    {Name = "Y03", Description = "3 YEAR LEASE", Id = 100023});
                housingContext.LeaseTypes.Add(new LeaseType()
                    {Name = "Y04", Description = "4 YEAR LEASE", Id = 100024});
                housingContext.LeaseTypes.Add(new LeaseType()
                    {Name = "Y05", Description = "5 YEAR LEASE", Id = 100025});
                housingContext.LeaseTypes.Add(new LeaseType()
                    {Name = "Y06", Description = "6 YEAR LEASE", Id = 100026});
                housingContext.LeaseTypes.Add(new LeaseType()
                    {Name = "Y07", Description = "7 YEAR LEASE", Id = 100027});
                housingContext.LeaseTypes.Add(new LeaseType()
                    {Name = "Y08", Description = "8 YEAR LEASE", Id = 100028});
                housingContext.LeaseTypes.Add(new LeaseType()
                    {Name = "Y09", Description = "9 YEAR LEASE", Id = 100029});
                housingContext.LeaseTypes.Add(
                    new LeaseType() {Name = "Y10", Description = "10 YEAR LEASE", Id = 100030});
                housingContext.LeaseTypes.Add(
                    new LeaseType() {Name = "Y11", Description = "11 YEAR LEASE", Id = 100031});
                housingContext.LeaseTypes.Add(
                    new LeaseType() {Name = "Y12", Description = "12 YEAR LEASE", Id = 100032});
                housingContext.LeaseTypes.Add(
                    new LeaseType() {Name = "Y13", Description = "13 YEAR LEASE", Id = 100033});
                housingContext.LeaseTypes.Add(
                    new LeaseType() {Name = "Y14", Description = "14 YEAR LEASE", Id = 100034});
                housingContext.LeaseTypes.Add(
                    new LeaseType() {Name = "Y15", Description = "15 YEAR LEASE", Id = 100035});
                housingContext.LeaseTypes.Add(
                    new LeaseType() {Name = "Y15", Description = "15 YEAR LEASE", Id = 100035});
            }

            private static void AddGenders(HousingDbContext housingContext)
            {
                housingContext.Genders.Add(new Gender() {Id = 100001, Name = "Male", Description = "Male"});
                housingContext.Genders.Add(new Gender() {Id = 100002, Name = "Female", Description = "Female"});
            }
        }
    }
}
