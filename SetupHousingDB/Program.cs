using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;

using HousingContext;
// using SetupHousingDB.Builders.Occupants;
// using SetupHousingDB.Builders.Property;
// using SetupHousingDB.Builders.Tenancy;

namespace SetupHousingDB
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Start DB Setup");
            var housingContext = new HousingDbContext();
            var t = housingContext.Database.CanConnect();
            if (!t) throw new Exception("Cannot connect");
            // housingContext.Database.EnsureDeleted();
            // housingContext.Database.EnsureCreated();
            // housingContext.SaveChangesAsync();
            //
            // var dataGenerator = new GenDataUsingBuilders();
            // dataGenerator.Generate();
            // dataGenerator.PopulateContext(housingContext);
            // housingContext.SaveChanges();
            // housingContext.SaveChanges();
            // Console.WriteLine("Done");
            // Console.ReadKey();
        }


        public class GenDataUsingBuilders
        {
            #region Lists
            protected List<Address> AddressList = new List<Address>();
            protected List<Premises> PremisesList = new List<Premises>();
            protected List<PremisesAddress> PremisesAddressList = new List<PremisesAddress>();
            protected List<RevenueAccount> RevenueAccountList = new List<RevenueAccount>();
            protected List<Tenancy> TenancyList = new List<Tenancy>();
            protected List<TenancyPremises> TenancyPremisesList = new List<TenancyPremises>();
            protected List<TenancyOccupant> TenancyOccupantList = new List<TenancyOccupant>();
            protected List<PremisesGroup> PremisesGroupList = new List<PremisesGroup>();
            protected List<PremisesPremisesGroup> PremisesPremisesGroupList = new List<PremisesPremisesGroup>();
            protected List<PremisesGroupUserRole> PremisesGroupUserRoleList = new List<PremisesGroupUserRole>();
            protected List<ContactMethod> ContactMethodList = new List<ContactMethod>();
            protected List<PremisesContactMethod> PremisesContactMethodList = new List<PremisesContactMethod>();
            protected List<Tenant> TenantList = new List<Tenant>();
            protected List<Role> RoleList = new List<Role>();
            protected List<User> UserList = new List<User>();
            protected List<Element> ElementList = new List<Element>();
            protected List<PremisesElement> PremisesElementList = new List<PremisesElement>();
            protected List<Person> PersonList = new List<Person>();
            protected List<AddressType> AddressTypeList = new List<AddressType>();
            protected List<LeaseType> LeaseTypeList = new List<LeaseType>();
            protected List<TenancyType> TenancyTypeList = new List<TenancyType>();
            protected List<TenancySource> TenancySourceList = new List<TenancySource>();
            protected List<TenureType> TenureTypeList = new List<TenureType>();
            protected List<PremisesType> PremisesTypeList = new List<PremisesType>();
            protected List<PremisesGroupType> PremisesGroupTypeList = new List<PremisesGroupType>();
            protected List<RevenueAccountType> RevenueAccountTypeList = new List<RevenueAccountType>();
            protected List<PropertySource> PropertySourceList = new List<PropertySource>();
            protected List<PropertyStatus> PropertyStatusList = new List<PropertyStatus>();
            protected List<PropertyType> PropertyTypeList = new List<PropertyType>();
            protected List<OwnershipType> OwnershipTypeList = new List<OwnershipType>();
            protected List<Frequency> FrequencyList = new List<Frequency>();
            #endregion

            
            public void GenerateEstates()
            {
                GenerateReferenceData();
            }
            
            public void Generate()
            {
                GenerateReferenceData();
            }

            public void PopulateContext(HousingDbContext context)
            {
                context.AddressTypes.AddRange(AddressTypeList);
                context.ContactMethods.AddRange(ContactMethodList);
                context.Elements.AddRange(ElementList);
                context.LeaseTypes.AddRange(LeaseTypeList);
                context.TenancyTypes.AddRange(TenancyTypeList);
                context.TenancySources.AddRange(TenancySourceList);
                context.TenureTypes.AddRange(TenureTypeList);
                context.PremisesTypes.AddRange(PremisesTypeList);
                context.PremisesGroupTypes.AddRange(PremisesGroupTypeList);
                context.RevenueAccountTypes.AddRange(RevenueAccountTypeList);
                context.PropertySources.AddRange(PropertySourceList);
                context.PropertyStatuses.AddRange(PropertyStatusList);
                context.PropertyTypes.AddRange(PropertyTypeList);
                context.OwnershipTypes.AddRange(OwnershipTypeList);
                context.Frequencies.AddRange(FrequencyList);
                context.Addresses.AddRange(AddressList);
                context.Premises.AddRange(PremisesList);
                context.PremisesAddresses.AddRange(PremisesAddressList);
                context.RevenueAccounts.AddRange(RevenueAccountList);
                context.Tenancies.AddRange(TenancyList);
                context.TenancyPremises.AddRange(TenancyPremisesList);
                context.TenancyOccupants.AddRange(TenancyOccupantList);
                context.PremisesGroups.AddRange(PremisesGroupList);
                context.PremisesPremisesGroups.AddRange(PremisesPremisesGroupList);
                context.PremisesGroupUserRoles.AddRange(PremisesGroupUserRoleList);
                context.PremisesContactMethods.AddRange(PremisesContactMethodList);
                context.Tenants.AddRange(TenantList);
                context.Roles.AddRange(RoleList);
                context.Users.AddRange(UserList);
                context.PremisesElements.AddRange(PremisesElementList);
                context.People.AddRange(PersonList);
            }

            public void GenerateReferenceData()
            {
                AddAddressTypes();
                AddContactMethods();
                AddElements();
                AddLeaseTypes();
                AddTenancyTypes();
                AddTenancySources();
                AddTenureTypes();
                AddPremisesTypes();
                AddPremisesGroupTypes();
                AddRevenueAccountTypes();
                AddPropertySources();
                AddPropertyStatuses();
                AddPropertyTypes();
                AddOwnershipTypes();
                AddFrequencies();
                AddRoles();
            }
            private void AddAddressTypes()
            {
                AddressTypeList.Add(new AddressType()
                {
                    Name = "CORR",
                    Description = "CORR",
                    Id = 10001,
                    SourceKey = "CORR",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "SITE",
                    Description = "SITE",
                    Id = 10002,
                    SourceKey = "SITE",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "CASE",
                    Description = "CASE",
                    Id = 10003,
                    SourceKey = "CASE",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "OFFICE",
                    Description = "OFFICE",
                    Id = 10004,
                    SourceKey = "OFFICE",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "APPLICATN",
                    Description = "APPLICATN",
                    Id = 10005,
                    SourceKey = "APPLICATN",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "OTHE",
                    Description = "OTHE",
                    Id = 10006,
                    SourceKey = "OTHE",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "AGENT",
                    Description = "AGENT",
                    Id = 10007,
                    SourceKey = "AGENT",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "APPL",
                    Description = "APPL",
                    Id = 10008,
                    SourceKey = "APPL",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "HB",
                    Description = "HB",
                    Id = 10009,
                    SourceKey = "HB",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "HB_OFFICE",
                    Description = "HB_OFFICE",
                    Id = 10010,
                    SourceKey = "HB_OFFICE",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "EHO",
                    Description = "EHO",
                    Id = 10011,
                    SourceKey = "EHO",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "HPU",
                    Description = "HPU",
                    Id = 10012,
                    SourceKey = "HPU",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "PHYSICAL",
                    Description = "PHYSICAL",
                    Id = 10013,
                    SourceKey = "PHYSICAL",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "FORWARD",
                    Description = "FORWARD",
                    Id = 10014,
                    SourceKey = "FORWARD",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "CORRESPOND",
                    Description = "CORRESPOND",
                    Id = 10015,
                    SourceKey = "CORRESPOND",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "CONTACT",
                    Description = "CONTACT",
                    Id = 10016,
                    SourceKey = "CONTACT",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "COURT",
                    Description = "COURT",
                    Id = 10017,
                    SourceKey = "COURT",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "LENDER",
                    Description = "LENDER",
                    Id = 10018,
                    SourceKey = "LENDER",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "RENTOFF",
                    Description = "RENTOFF",
                    Id = 10019,
                    SourceKey = "RENTOFF",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "THIRDPAR",
                    Description = "THIRDPAR",
                    Id = 10020,
                    SourceKey = "THIRDPAR",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "ABROAD",
                    Description = "ABROAD",
                    Id = 10021,
                    SourceKey = "ABROAD",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "OLDAPPL",
                    Description = "OLDAPPL",
                    Id = 10022,
                    SourceKey = "OLDAPPL",
                    SourceApplication = "Northgate"
                });

                AddressTypeList.Add(new AddressType()
                {
                    Name = "DSS",
                    Description = "DSS",
                    Id = 10023,
                    SourceKey = "DSS",
                    SourceApplication = "Northgate"
                });


            }

            private void AddContactMethods()
            {
                ContactMethodList.Add(new ContactMethod()
                {
                    Name = "HOMETEL",
                    Description = "Home Telephone Number",
                    Id = 10001,
                    SourceKey = "HOMETEL",
                    SourceApplication = "Northgate"
                });

                ContactMethodList.Add(new ContactMethod()
                {
                    Name = "DAYTEL",
                    Description = "Day Time Telephone Number",
                    Id = 10002,
                    SourceKey = "DAYTEL",
                    SourceApplication = "Northgate"
                });

                ContactMethodList.Add(new ContactMethod()
                {
                    Name = "MOBILE",
                    Description = "Mobile Phone",
                    Id = 10003,
                    SourceKey = "MOBILE",
                    SourceApplication = "Northgate"
                });

                ContactMethodList.Add(new ContactMethod()
                {
                    Name = "EMAIL",
                    Description = "E-mail",
                    Id = 10004,
                    SourceKey = "EMAIL",
                    SourceApplication = "Northgate"
                });

                ContactMethodList.Add(new ContactMethod()
                {
                    Name = "SMS",
                    Description = "SMS",
                    Id = 10005,
                    SourceKey = "SMS",
                    SourceApplication = "Northgate"
                });

                ContactMethodList.Add(new ContactMethod()
                {
                    Name = "TELEPHONE",
                    Description = "Telephone",
                    Id = 10006,
                    SourceKey = "TELEPHONE",
                    SourceApplication = "Northgate"
                });

                ContactMethodList.Add(new ContactMethod()
                {
                    Name = "CONTACTTEL",
                    Description = "CONTACT Telephone 3rd party Emergency",
                    Id = 10007,
                    SourceKey = "CONTACTTEL",
                    SourceApplication = "Northgate"
                });

            }

            private void AddElements()
            {
                ElementList.Add(new Element()
                {
                    Name = "REPINTREP",
                    Category = "Repairs",
                    Description = "Internal Repairs Responsibility",
                    Id = 10001,
                    SourceKey = "REPINTREP",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "REPFIREREP",
                    Category = "Repairs",
                    Description = "Fire Equipment Replacement Responsibility",
                    Id = 10002,
                    SourceKey = "REPFIREREP",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "REPCLEAN",
                    Category = "Repairs",
                    Description = "Cleaning Responsibility",
                    Id = 10003,
                    SourceKey = "REPCLEAN",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "REPBATHHOI",
                    Category = "Repairs",
                    Description = "Bath Hoist Responsibility",
                    Id = 10004,
                    SourceKey = "REPBATHHOI",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "REPWINDGLA",
                    Category = "Repairs",
                    Description = "Window glazing/pane repair responsibility",
                    Id = 10005,
                    SourceKey = "REPWINDGLA",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "REPENTPHON",
                    Category = "Repairs",
                    Description = "Entry Phone Maintenance Responsibility",
                    Id = 10006,
                    SourceKey = "REPENTPHON",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "REPMINORS",
                    Category = "Repairs",
                    Description = "Minor Repairs Responsibility",
                    Id = 10007,
                    SourceKey = "REPMINORS",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "REPA",
                    Category = "Repairs",
                    Description = "REPAIRS NOTICE",
                    Id = 10008,
                    SourceKey = "REPA",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "REPELECPAT",
                    Category = "Repairs",
                    Description = "Portable Appliance Testing for electrics responsibility",
                    Id = 10009,
                    SourceKey = "REPELECPAT",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "REPWINDREP",
                    Category = "Repairs",
                    Description = "Window Repairs Responsibility",
                    Id = 10010,
                    SourceKey = "REPWINDREP",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "REPROADADT",
                    Category = "Repairs",
                    Description = "Road Adoption Maintenance Responsibility",
                    Id = 10011,
                    SourceKey = "REPROADADT",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "REPPLAYGRD",
                    Category = "Repairs",
                    Description = "Playground Maintenance Responsibility",
                    Id = 10012,
                    SourceKey = "REPPLAYGRD",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "MOS4350",
                    Category = null,
                    Description = "SERVICE CHARGE 4350",
                    Id = 10013,
                    SourceKey = "MOS4350",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "FM4430",
                    Category = null,
                    Description = "LIFT MAINTENANCE",
                    Id = 10014,
                    SourceKey = "FM4430",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "NRMANAGE",
                    Category = null,
                    Description = "NROSH MANAGEMENT CODE",
                    Id = 10015,
                    SourceKey = "NRMANAGE",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "MOS4200",
                    Category = null,
                    Description = "SERVICE CHARGE 4200",
                    Id = 10016,
                    SourceKey = "MOS4200",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "MOS4910",
                    Category = null,
                    Description = "SERVICE CHARGE 4910",
                    Id = 10017,
                    SourceKey = "MOS4910",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "ZPLA",
                    Category = null,
                    Description = "PLAY AREAS",
                    Id = 10018,
                    SourceKey = "ZPLA",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "LANDLORD",
                    Category = null,
                    Description = "LANDLORD",
                    Id = 10019,
                    SourceKey = "LANDLORD",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "MS4710",
                    Category = null,
                    Description = "Warden systems (Mthly)",
                    Id = 10020,
                    SourceKey = "MS4710",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "PSPA",
                    Category = null,
                    Description = "PARKING SPACE",
                    Id = 10021,
                    SourceKey = "PSPA",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "FTPU",
                    Category = null,
                    Description = "FHA TENANT PARTICIPATION UNIT",
                    Id = 10022,
                    SourceKey = "FTPU",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "A_4740",
                    Category = null,
                    Description = "Water Rates (A)",
                    Id = 10023,
                    SourceKey = "A_4740",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "FM4750",
                    Category = null,
                    Description = "WINDOW CLEANING",
                    Id = 10024,
                    SourceKey = "FM4750",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "CLSCADJM",
                    Category = null,
                    Description = "Service Charge Monthly adjustment (btw Actual & Estimates)",
                    Id = 10025,
                    SourceKey = "CLSCADJM",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "WS4740",
                    Category = null,
                    Description = "Communal Water Supplies & Sewerage (Wkly)",
                    Id = 10026,
                    SourceKey = "WS4740",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "NEWREGRENT",
                    Category = null,
                    Description = "NEW REGISTERED RENT",
                    Id = 10027,
                    SourceKey = "NEWREGRENT",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "FMWA",
                    Category = null,
                    Description = "FHA MONTHLY CHARGED WATER RATES",
                    Id = 10028,
                    SourceKey = "FMWA",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "C_4540",
                    Category = null,
                    Description = "Pest Control [C]",
                    Id = 10029,
                    SourceKey = "C_4540",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "FM4610",
                    Category = null,
                    Description = "RESIDENT REHAB/ACTIVITIES",
                    Id = 10030,
                    SourceKey = "FM4610",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "GASR",
                    Category = null,
                    Description = "GAS SERVICING WARNING",
                    Id = 10031,
                    SourceKey = "GASR",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "FM3140",
                    Category = null,
                    Description = "HEALTH & SAFTY",
                    Id = 10032,
                    SourceKey = "FM3140",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "LS4810",
                    Category = null,
                    Description = "Replacement Prov-Sinking Funds (LH)",
                    Id = 10033,
                    SourceKey = "LS4810",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "FNCP",
                    Category = null,
                    Description = "FHA NEGATE ASS'D POLICY RENT CAPPING CHG",
                    Id = 10034,
                    SourceKey = "FNCP",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "OOSC",
                    Category = null,
                    Description = "OLD OAK SERVICE CHARGE",
                    Id = 10035,
                    SourceKey = "OOSC",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "WS4190",
                    Category = null,
                    Description = "Communal Boiler Maintenance (Wkly)",
                    Id = 10036,
                    SourceKey = "WS4190",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "FM4530",
                    Category = null,
                    Description = "PARKING BARRIER",
                    Id = 10037,
                    SourceKey = "FM4530",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "OUTS",
                    Category = null,
                    Description = "EXTERNAL AREA BELONGING TO THE PROPERTY",
                    Id = 10038,
                    SourceKey = "OUTS",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "NFRM",
                    Category = null,
                    Description = "NEGATE FHA RENT RESTRUCTURE MONTHLY",
                    Id = 10039,
                    SourceKey = "NFRM",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "FSEC",
                    Category = null,
                    Description = "FHA SECURE TENANT NET RENT",
                    Id = 10040,
                    SourceKey = "FSEC",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "NOOFUNITS",
                    Category = null,
                    Description = "NO OF UNITS IN A BLOCK",
                    Id = 10041,
                    SourceKey = "NOOFUNITS",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "WC",
                    Category = null,
                    Description = "SEPARATE WC",
                    Id = 10042,
                    SourceKey = "WC",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "MS4045",
                    Category = null,
                    Description = "Cleaning (Mthly)",
                    Id = 10043,
                    SourceKey = "MS4045",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "LS4340",
                    Category = null,
                    Description = "Gas (LH)",
                    Id = 10044,
                    SourceKey = "LS4340",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "ARENTMTHLY",
                    Category = null,
                    Description = "AFFORDABLE MONTHLY RENT",
                    Id = 10045,
                    SourceKey = "ARENTMTHLY",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "FM4440",
                    Category = null,
                    Description = "LIGHT & HEAT",
                    Id = 10046,
                    SourceKey = "FM4440",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "MP4740",
                    Category = null,
                    Description = "Water & Sewerage Personal (Mthly)",
                    Id = 10047,
                    SourceKey = "MP4740",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "CL4340",
                    Category = null,
                    Description = "CLIENT CHARGE GAS",
                    Id = 10048,
                    SourceKey = "CL4340",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "C_4370",
                    Category = null,
                    Description = "TV & Radio Relay [C]",
                    Id = 10049,
                    SourceKey = "C_4370",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "LS4270",
                    Category = null,
                    Description = "Smoke Vents Fire Systems (LH)",
                    Id = 10050,
                    SourceKey = "LS4270",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "MOS4045",
                    Category = null,
                    Description = "SERVICE CHARGE 4045",
                    Id = 10051,
                    SourceKey = "MOS4045",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "LHMNSC",
                    Category = null,
                    Description = "LEASEHOLDERS MONTHLY SERVICE CHARGE",
                    Id = 10052,
                    SourceKey = "LHMNSC",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "A_4225",
                    Category = null,
                    Description = "External Communal Repairs (A)",
                    Id = 10053,
                    SourceKey = "A_4225",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "D_4740",
                    Category = null,
                    Description = "Water Rates [D]",
                    Id = 10054,
                    SourceKey = "D_4740",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "PVAL1999",
                    Category = null,
                    Description = "PLEASE USE PVAL INSTEAD - CODE OBSOLETE 1999 PROPERTY VALUATION",
                    Id = 10055,
                    SourceKey = "PVAL1999",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "FM4400",
                    Category = null,
                    Description = "INTERPRETATION",
                    Id = 10056,
                    SourceKey = "FM4400",
                    SourceApplication = "Northgate"
                });

                ElementList.Add(new Element()
                {
                    Name = "FNST",
                    Category = null,
                    Description = "FHA NEGATE ASSURED STORE CHARGE",
                    Id = 10057,
                    SourceKey = "FNST",
                    SourceApplication = "Northgate"
                });
            }

            private void AddFrequencies()
            {
                FrequencyList.Add(new Frequency()
                {
                    Name = "FHACOMMWKLY",
                    Description = "FHA COMMERCIAL WEEKLY",
                    Id = 10001,
                    SourceKey = "FHACOMMWKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "EHSSTNDWKLY",
                    Description = "EHS STANDARD WEEKLY",
                    Id = 10002,
                    SourceKey = "EHSSTNDWKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "DAILY",
                    Description = "DAILY RENTAL ADMIN UNIT",
                    Id = 10003,
                    SourceKey = "DAILY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "MTHMON",
                    Description = "MONTHLY MON START",
                    Id = 10004,
                    SourceKey = "MTHMON",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "BENEFITS SUSPENSE",
                    Description = "BENEFITS SUSPENSE",
                    Id = 10005,
                    SourceKey = "BENEFITS SUSPENSE",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "FHARPIWKLY",
                    Description = "FHA RPI WEEKLY RENTS",
                    Id = 10006,
                    SourceKey = "FHARPIWKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "GNMONTHLY",
                    Description = "GN MONTHLY RENTAL ADMIN UNIT",
                    Id = 10007,
                    SourceKey = "GNMONTHLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "FHASTNDMTHLY",
                    Description = "FHA STANDARD MONTHLY",
                    Id = 10008,
                    SourceKey = "FHASTNDMTHLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "FHALHAMWKLY",
                    Description = "FHA LANDMARK MANAGED WEEKLY DEBIT",
                    Id = 10009,
                    SourceKey = "FHALHAMWKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "LHARPISHOWNMTHLY",
                    Description = "LANDMARK & FM RPI SHARED OWNERSHIP DEBIT",
                    Id = 10010,
                    SourceKey = "LHARPISHOWNMTHLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "SPSTNDWKLY",
                    Description = "SUPPORTING PEOPLE",
                    Id = 10011,
                    SourceKey = "SPSTNDWKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "FHASTNDWKLY",
                    Description = "FHA STANDARD WEEKLY",
                    Id = 10012,
                    SourceKey = "FHASTNDWKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "WEEKLY",
                    Description = "WEEKLY RENTAL ADMIN UNIT",
                    Id = 10013,
                    SourceKey = "WEEKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "FHAPECKWKLY",
                    Description = "FHA PECKHAM PARTENRSHIP WEEKLY DEBIT",
                    Id = 10014,
                    SourceKey = "FHAPECKWKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "FHACOMMYRLY",
                    Description = "FHACOMMYRLY",
                    Id = 10015,
                    SourceKey = "FHACOMMYRLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "CTHTRBWKLY",
                    Description = "CHARLTON TRIANGLE BALANCE TTRANSFER",
                    Id = 10016,
                    SourceKey = "CTHTRBWKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "SITSTNDWKLY",
                    Description = "SIT STANDARD WEEKLY",
                    Id = 10017,
                    SourceKey = "SITSTNDWKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "OOHSTNDWKLY",
                    Description = "OLD OAK STANDARD WEEKLY DEBIT",
                    Id = 10018,
                    SourceKey = "OOHSTNDWKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "SUSPENSE ACCOUNT",
                    Description = "SUSPENSE ACCOUNT",
                    Id = 10019,
                    SourceKey = "SUSPENSE ACCOUNT",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "FHACOMMMTHLY",
                    Description = "FHA COMMERCIAL MONTHLY",
                    Id = 10020,
                    SourceKey = "FHACOMMMTHLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "FMQUAWKLY",
                    Description = "FAMILY MOSAIC QUAKERS WEEKLY",
                    Id = 10021,
                    SourceKey = "FMQUAWKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "FMDAILY",
                    Description = "FMDAILY ADMIN UNITS",
                    Id = 10022,
                    SourceKey = "FMDAILY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "LHASHOWNMTHLY",
                    Description = "LANDMARK SHARED OWNERSHIP DEBIT",
                    Id = 10023,
                    SourceKey = "LHASHOWNMTHLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "MTHANY",
                    Description = "MONTHLY START END ANY DAY OF THE WEEK",
                    Id = 10024,
                    SourceKey = "MTHANY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "FMHMBSTDMTHLY",
                    Description = "FAMILY MOSAIC SOCIAL HOMEBUY STD MTH CHG",
                    Id = 10025,
                    SourceKey = "FMHMBSTDMTHLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "MONTHLY",
                    Description = "MONTHLY RENTAL ADMIN UNIT",
                    Id = 10026,
                    SourceKey = "MONTHLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "LHASTNDWKLY",
                    Description = "LANDMARK STANDARD WEEKLY DEBIT",
                    Id = 10027,
                    SourceKey = "LHASTNDWKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "CTHCOMMWKLY",
                    Description = "CHARLTON COMMERCIAL WEEKLY DEBIT",
                    Id = 10028,
                    SourceKey = "CTHCOMMWKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "ANNUAL",
                    Description = "ANNUAL RENTAL ADMIN YEAR",
                    Id = 10029,
                    SourceKey = "ANNUAL",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "CTHSTNDWKLY",
                    Description = "CHARLTON STANDARD WEEKLY DEBIT",
                    Id = 10030,
                    SourceKey = "CTHSTNDWKLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "FHACOMMQTRLY",
                    Description = "FHACOMMQTRLY",
                    Id = 10031,
                    SourceKey = "FHACOMMQTRLY",
                    SourceApplication = "Northgate"
                });

                FrequencyList.Add(new Frequency()
                {
                    Name = "LHAFHAOWNWKLY",
                    Description = "LHAFHAOWNWKLY",
                    Id = 10032,
                    SourceKey = "LHAFHAOWNWKLY",
                    SourceApplication = "Northgate"
                });
            }


            private void AddLeaseTypes()
            {
                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "LSON",
                    Description = "LONDON SHARED OWNERSHIP NORTH & WEST",
                    SourceKey = "LSON",
                    SourceApplication = "Northgate",
                    Id = 10001
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "R14",
                    Description = "14 YEAR RENEWAL",
                    SourceKey = "R14",
                    SourceApplication = "Northgate",
                    Id = 10002
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "SOWHSE",
                    Description = "HOUSE LEASEHOLD",
                    SourceKey = "SOWHSE",
                    SourceApplication = "Northgate",
                    Id = 10003
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y07",
                    Description = "7 YEAR LEASE",
                    SourceKey = "Y07",
                    SourceApplication = "Northgate",
                    Id = 10004
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "R01",
                    Description = "1 YEAR RENEWAL",
                    SourceKey = "R01",
                    SourceApplication = "Northgate",
                    Id = 10005
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "R04",
                    Description = "4 YEAR RENEWAL",
                    SourceKey = "R04",
                    SourceApplication = "Northgate",
                    Id = 10006
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "R12",
                    Description = "12 YEAR RENEWAL",
                    SourceKey = "R12",
                    SourceApplication = "Northgate",
                    Id = 10007
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "R09",
                    Description = "9 YEAR RENEWAL",
                    SourceKey = "R09",
                    SourceApplication = "Northgate",
                    Id = 10008
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "SOWFLT",
                    Description = "FLAT LEASEHOLD",
                    SourceKey = "SOWFLT",
                    SourceApplication = "Northgate",
                    Id = 10009
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y03",
                    Description = "3 YEAR LEASE",
                    SourceKey = "Y03",
                    SourceApplication = "Northgate",
                    Id = 10010
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "R11",
                    Description = "11 YEAR RENEWAL",
                    SourceKey = "R11",
                    SourceApplication = "Northgate",
                    Id = 10011
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "R10",
                    Description = "10 YEAR RENEWAL",
                    SourceKey = "R10",
                    SourceApplication = "Northgate",
                    Id = 10012
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y08",
                    Description = "8 YEAR LEASE",
                    SourceKey = "Y08",
                    SourceApplication = "Northgate",
                    Id = 10013
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "R05",
                    Description = "5 YEAR RENEWAL",
                    SourceKey = "R05",
                    SourceApplication = "Northgate",
                    Id = 10014
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y10",
                    Description = "10 YEAR LEASE",
                    SourceKey = "Y10",
                    SourceApplication = "Northgate",
                    Id = 10015
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y06",
                    Description = "6 YEAR LEASE",
                    SourceKey = "Y06",
                    SourceApplication = "Northgate",
                    Id = 10016
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y02",
                    Description = "2 YEAR LEASE",
                    SourceKey = "Y02",
                    SourceApplication = "Northgate",
                    Id = 10017
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "R08",
                    Description = "8 YEAR RENEWAL",
                    SourceKey = "R08",
                    SourceApplication = "Northgate",
                    Id = 10018
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y09",
                    Description = "9 YEAR LEASE",
                    SourceKey = "Y09",
                    SourceApplication = "Northgate",
                    Id = 10019
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y01",
                    Description = "1 YEAR LEASE",
                    SourceKey = "Y01",
                    SourceApplication = "Northgate",
                    Id = 10020
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y04",
                    Description = "4 YEAR LEASE",
                    SourceKey = "Y04",
                    SourceApplication = "Northgate",
                    Id = 10021
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "R13",
                    Description = "13 YEAR RENEWAL",
                    SourceKey = "R13",
                    SourceApplication = "Northgate",
                    Id = 10022
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "R02",
                    Description = "2 YEAR RENEWAL",
                    SourceKey = "R02",
                    SourceApplication = "Northgate",
                    Id = 10023
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "R07",
                    Description = "7 YEAR RENEWAL",
                    SourceKey = "R07",
                    SourceApplication = "Northgate",
                    Id = 10024
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y12",
                    Description = "12 YEAR LEASE",
                    SourceKey = "Y12",
                    SourceApplication = "Northgate",
                    Id = 10025
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y05",
                    Description = "5 YEAR LEASE",
                    SourceKey = "Y05",
                    SourceApplication = "Northgate",
                    Id = 10026
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "LOLE",
                    Description = "LONDON LEASEHOLD EAST",
                    SourceKey = "LOLE",
                    SourceApplication = "Northgate",
                    Id = 10027
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y13",
                    Description = "13 YEAR LEASE",
                    SourceKey = "Y13",
                    SourceApplication = "Northgate",
                    Id = 10028
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y11",
                    Description = "11 YEAR LEASE",
                    SourceKey = "Y11",
                    SourceApplication = "Northgate",
                    Id = 10029
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "LSOE",
                    Description = "LONDON SHARED OWNERSHIP EAST",
                    SourceKey = "LSOE",
                    SourceApplication = "Northgate",
                    Id = 10030
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "LSOS",
                    Description = "LONDON SHARED OWNERSHIP SOUTH",
                    SourceKey = "LSOS",
                    SourceApplication = "Northgate",
                    Id = 10031
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y14",
                    Description = "14 YEAR LEASE",
                    SourceKey = "Y14",
                    SourceApplication = "Northgate",
                    Id = 10032
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "Y15",
                    Description = "15 YEAR LEASE",
                    SourceKey = "Y15",
                    SourceApplication = "Northgate",
                    Id = 10033
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "R06",
                    Description = "6 YEAR RENEWAL",
                    SourceKey = "R06",
                    SourceApplication = "Northgate",
                    Id = 10034
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "R03",
                    Description = "3 YEAR RENEWAL",
                    SourceKey = "R03",
                    SourceApplication = "Northgate",
                    Id = 10035
                });

                LeaseTypeList.Add(new LeaseType()
                {
                    Name = "ZZZ",
                    Description = "test",
                    SourceKey = "ZZZ",
                    SourceApplication = "Northgate",
                    Id = 10036
                });

            }

            private void AddOwnershipTypes()
            {
                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "COMMO",
                    Description = "COMMERCIAL ORGANISATION",
                    Id = 10001,
                    SourceKey = "COMMO",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "SO_ONM",
                    Description = "Shared Ownership Owned Not Managed",
                    Id = 10002,
                    SourceKey = "SO_ONM",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "MNO_OTHER",
                    Description = "Managed but not Owned-Other",
                    Id = 10003,
                    SourceKey = "MNO_OTHER",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "ASSOC",
                    Description = "HOUSING ASSOCIATION OWNED",
                    Id = 10004,
                    SourceKey = "ASSOC",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "OM999",
                    Description = "Owned and Managed - 999 year lease",
                    Id = 10005,
                    SourceKey = "OM999",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "SO",
                    Description = "Shared Ownership",
                    Id = 10006,
                    SourceKey = "SO",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "FHAMANAGED",
                    Description = "MANAGED BUT NOT OWNED BY FHA",
                    Id = 10007,
                    SourceKey = "FHAMANAGED",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "DLOAD",
                    Description = "DATALOAD DEFAULT",
                    Id = 10008,
                    SourceKey = "DLOAD",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "ONMNONFM",
                    Description = "Owned not Managed - no FM repairs",
                    Id = 10009,
                    SourceKey = "ONMNONFM",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "MNO_RSL",
                    Description = "Managed but not Owned-RSL",
                    Id = 10010,
                    SourceKey = "MNO_RSL",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "ONM",
                    Description = "Owned but not Managed",
                    Id = 10011,
                    SourceKey = "ONM",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "ONMFMREP",
                    Description = "Owned not Managed - FM repairs",
                    Id = 10012,
                    SourceKey = "ONMFMREP",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "RTHB",
                    Description = "Rent to Homebuy",
                    Id = 10013,
                    SourceKey = "RTHB",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "PVTIN",
                    Description = "PRIVATE INDIVIDUAL",
                    Id = 10014,
                    SourceKey = "PVTIN",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "FREE",
                    Description = "FREEHOLDER",
                    Id = 10015,
                    SourceKey = "FREE",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "OM",
                    Description = "Owned and Managed",
                    Id = 10016,
                    SourceKey = "OM",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "LEASH",
                    Description = "SHORT TERM LEASE",
                    Id = 10017,
                    SourceKey = "LEASH",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "MNO_LA",
                    Description = "Managed but not Owned-Local Authority",
                    Id = 10018,
                    SourceKey = "MNO_LA",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "FHALEASE",
                    Description = "FHA LONG TERM LEASE",
                    Id = 10019,
                    SourceKey = "FHALEASE",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "LEASL",
                    Description = "LONG TERM LEASE",
                    Id = 10020,
                    SourceKey = "LEASL",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "COUN",
                    Description = "COUNCIL OWNED",
                    Id = 10021,
                    SourceKey = "COUN",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "OMLEASED",
                    Description = "Owned and managed LEASEHOLD",
                    Id = 10022,
                    SourceKey = "OMLEASED",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "LEASE",
                    Description = "LEASEHOLD 100%",
                    Id = 10023,
                    SourceKey = "LEASE",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "NMNO",
                    Description = "NOT MANAGED AND NOT OWNED",
                    Id = 10024,
                    SourceKey = "NMNO",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "LA",
                    Description = "LOCAL AUTHORITY",
                    Id = 10025,
                    SourceKey = "LA",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "ORHA",
                    Description = "OTHER REGISTERED HOUSING ASSOCIATION",
                    Id = 10026,
                    SourceKey = "ORHA",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "MNO_PL",
                    Description = "Managed but not Owned-Private Lease",
                    Id = 10027,
                    SourceKey = "MNO_PL",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "VOLOR",
                    Description = "VOLUNTARY ORGANISATION",
                    Id = 10028,
                    SourceKey = "VOLOR",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "LHAO",
                    Description = "LANDMARK OWNED",
                    Id = 10029,
                    SourceKey = "LHAO",
                    SourceApplication = "Northgate"
                });

                OwnershipTypeList.Add(new OwnershipType()
                {
                    Name = "OPUBB",
                    Description = "OTHER PUBLIC BODY",
                    Id = 10030,
                    SourceKey = "OPUBB",
                    SourceApplication = "Northgate"
                });
            }

            private void AddPremisesGroupTypes()
            {
                PremisesGroupTypeList.Add(new PremisesGroupType()
                {
                    Name = "RHM",
                    Description = "Regional Housing Manager",
                    Id = 10001,
                    SourceKey = "RHM",
                    SourceApplication = "Northgate"
                });

                PremisesGroupTypeList.Add(new PremisesGroupType()
                {
                    Name = "AHM",
                    Description = "Area Housing Manager",
                    Id = 10002,
                    SourceKey = "AHM",
                    SourceApplication = "Northgate"
                });

                PremisesGroupTypeList.Add(new PremisesGroupType()
                {
                    Name = "LA",
                    Description = "Local Authority",
                    Id = 10003,
                    SourceKey = "LA",
                    SourceApplication = "Northgate"
                });

                PremisesGroupTypeList.Add(new PremisesGroupType()
                {
                    Name = "COM",
                    Description = "Company",
                    Id = 10004,
                    SourceKey = "COM",
                    SourceApplication = "Northgate"
                });

                PremisesGroupTypeList.Add(new PremisesGroupType()
                {
                    Name = "LOP",
                    Description = "Letting Officer Patch",
                    Id = 10005,
                    SourceKey = "LOP",
                    SourceApplication = "Northgate"
                });

                PremisesGroupTypeList.Add(new PremisesGroupType()
                {
                    Name = "PAT",
                    Description = "Patch",
                    Id = 10006,
                    SourceKey = "PAT",
                    SourceApplication = "Northgate"
                });

                PremisesGroupTypeList.Add(new PremisesGroupType()
                {
                    Name = "SHA",
                    Description = "Shared House Or Flat",
                    Id = 10007,
                    SourceKey = "SHA",
                    SourceApplication = "Northgate"
                });

                PremisesGroupTypeList.Add(new PremisesGroupType()
                {
                    Name = "OM",
                    Description = "Repairs",
                    Id = 10008,
                    SourceKey = "REP",
                    SourceApplication = "Northgate"
                });

                PremisesGroupTypeList.Add(new PremisesGroupType()
                {
                    Name = "OFF",
                    Description = "Area Office",
                    Id = 10009,
                    SourceKey = "OFF",
                    SourceApplication = "Northgate"
                });

                PremisesGroupTypeList.Add(new PremisesGroupType()
                {
                    Name = "TEN",
                    Description = "Neighbourhood Managers",
                    Id = 10010,
                    SourceKey = "TEN",
                    SourceApplication = "Northgate"
                });

                PremisesGroupTypeList.Add(new PremisesGroupType()
                {
                    Name = "DIV",
                    Description = "Sub-Divided Flat",
                    Id = 10011,
                    SourceKey = "DIV",
                    SourceApplication = "Northgate"
                });

                PremisesGroupTypeList.Add(new PremisesGroupType()
                {
                    Name = "WAR",
                    Description = "Ward",
                    Id = 10012,
                    SourceKey = "WAR",
                    SourceApplication = "Northgate"
                });

                PremisesGroupTypeList.Add(new PremisesGroupType()
                {
                    Name = "REG",
                    Description = "Region",
                    Id = 10013,
                    SourceKey = "REG",
                    SourceApplication = "Northgate"
                });

                PremisesGroupTypeList.Add(new PremisesGroupType()
                {
                    Name = "CON",
                    Description = "Parliamentary Constituency",
                    Id = 10014,
                    SourceKey = "CON",
                    SourceApplication = "Northgate"
                });
            }

            private void AddPremisesTypes()
            {
                PremisesTypeList.Add(new PremisesType()
                {
                    Name = "BLK",
                    Description = "Block",
                    Id = 10001,
                    SourceKey = "BLK",
                    SourceApplication = "Northgate"
                });

                PremisesTypeList.Add(new PremisesType()
                {
                    Name = "PRO",
                    Description = "Property",
                    Id = 10002,
                    SourceKey = "PRO",
                    SourceApplication = "Northgate"
                });

                PremisesTypeList.Add(new PremisesType()
                {
                    Name = "EST",
                    Description = "Estate",
                    Id = 10003,
                    SourceKey = "EST",
                    SourceApplication = "Northgate"
                });
            }

            private void AddPropertyStatuses()
            {
                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "DEMO",
                    Description = "PROPERTY DEMOLISHED",
                    Id = 10001,
                    SourceKey = "DEMO",
                    SourceApplication = "Northgate"
                });

                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "OCCP",
                    Description = "Occupied",
                    Id = 10002,
                    SourceKey = "OCCP",
                    SourceApplication = "Northgate"
                });

                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "STCF",
                    Description = "STAIRCASED TO FREEHOLD",
                    Id = 10003,
                    SourceKey = "STCF",
                    SourceApplication = "Northgate"
                });

                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "VOID",
                    Description = "Void",
                    Id = 10004,
                    SourceKey = "VOID",
                    SourceApplication = "Northgate"
                });

                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "CONV",
                    Description = "DEVELOPMENT CONVERSION",
                    Id = 10005,
                    SourceKey = "CONV",
                    SourceApplication = "Northgate"
                });

                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "CLSD",
                    Description = "Closed",
                    Id = 10006,
                    SourceKey = "CLSD",
                    SourceApplication = "Northgate"
                });

                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "FRES",
                    Description = "FREEHOLD SALE",
                    Id = 10007,
                    SourceKey = "FRES",
                    SourceApplication = "Northgate"
                });

                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "STCE",
                    Description = "STAIRCASED TO EMA",
                    Id = 10008,
                    SourceKey = "STCE",
                    SourceApplication = "Northgate"
                });

                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "STR",
                    Description = "STOCK TRANSFERRED",
                    Id = 10009,
                    SourceKey = "STR",
                    SourceApplication = "Northgate"
                });

                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "HBK",
                    Description = "HANDED BACK TO LANDLORD",
                    Id = 10010,
                    SourceKey = "HBK",
                    SourceApplication = "Northgate"
                });

                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "AUCT",
                    Description = "SOLD AT AUCTION",
                    Id = 10011,
                    SourceKey = "AUCT",
                    SourceApplication = "Northgate"
                });

                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "SOLD",
                    Description = "SOLD OPEN MARKET",
                    Id = 10012,
                    SourceKey = "SOLD",
                    SourceApplication = "Northgate"
                });

                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "RTA",
                    Description = "SOLD RIGHT TO ACQUIRE",
                    Id = 10013,
                    SourceKey = "RTA",
                    SourceApplication = "Northgate"
                });

                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "DEV",
                    Description = "IN DEVELOPMENT",
                    Id = 10014,
                    SourceKey = "DEV",
                    SourceApplication = "Northgate"
                });

                PropertyStatusList.Add(new PropertyStatus()
                {
                    Name = "RTB",
                    Description = "SOLD RIGHT TO BUY",
                    Id = 10015,
                    SourceKey = "RTB",
                    SourceApplication = "Northgate"
                });
            }

            private void AddPropertyTypes()
            {
                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "SCO",
                    Description = "SPECIAL PROJECT SELF CONTAINED",
                    Id = 10001,
                    SourceKey = "SCO",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "FAC",
                    Description = "FACILITY - COMMUNITY RESOURCE ROOM ETC",
                    Id = 10002,
                    SourceKey = "FAC",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "LAN",
                    Description = "LAND SITE - PROPERTIES FOR DEMOLITION",
                    Id = 10003,
                    SourceKey = "LAN",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "BUN",
                    Description = "BUNGALOW",
                    Id = 10004,
                    SourceKey = "BUN",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "GAR",
                    Description = "GARAGE",
                    Id = 10005,
                    SourceKey = "GAR",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "STU",
                    Description = "STUDIO FLAT",
                    Id = 10006,
                    SourceKey = "STU",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "HSE",
                    Description = "HOUSE",
                    Id = 10007,
                    SourceKey = "HSE",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "FLT",
                    Description = "FLAT",
                    Id = 10008,
                    SourceKey = "FLT",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "PKG",
                    Description = "PARKING SPACE",
                    Id = 10009,
                    SourceKey = "PKG",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "BSI",
                    Description = "BEDSIT",
                    Id = 10010,
                    SourceKey = "BSI",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "STO",
                    Description = "STORE",
                    Id = 10011,
                    SourceKey = "STO",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "FHO",
                    Description = "FAMILY HOUSING OFFICE",
                    Id = 10012,
                    SourceKey = "FHO",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "PIP",
                    Description = "PIPELINE UNITS",
                    Id = 10013,
                    SourceKey = "PIP",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "WAR",
                    Description = "WAREHOUSE",
                    Id = 10014,
                    SourceKey = "WAR",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "SHA",
                    Description = "SHARED FLAT OR HOUSE",
                    Id = 10015,
                    SourceKey = "SHA",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "COM",
                    Description = "COMMERCIAL UNIT",
                    Id = 10016,
                    SourceKey = "COM",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "BAR",
                    Description = "BARE SITE NO FUNDING",
                    Id = 10017,
                    SourceKey = "BAR",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "MAI",
                    Description = "MAISONETTE",
                    Id = 10018,
                    SourceKey = "MAI",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "STA",
                    Description = "STAFF FLAT",
                    Id = 10019,
                    SourceKey = "STA",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "NRP",
                    Description = "NON RESIDENTIAL PROPERTY (DATALOAD)",
                    Id = 10020,
                    SourceKey = "NRP",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "BB",
                    Description = "BED AND BREAKFAST",
                    Id = 10021,
                    SourceKey = "BB",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "SHP",
                    Description = "SHOP",
                    Id = 10022,
                    SourceKey = "SHP",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "OFF",
                    Description = "OFFICE",
                    Id = 10023,
                    SourceKey = "OFF",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "BSP",
                    Description = "BEDSPACE",
                    Id = 10024,
                    SourceKey = "BSP",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "ROO",
                    Description = "ROOM IN SHARED HOUSE",
                    Id = 10025,
                    SourceKey = "ROO",
                    SourceApplication = "Northgate"
                });

                PropertyTypeList.Add(new PropertyType()
                {
                    Name = "BAS",
                    Description = "BASEMENT",
                    Id = 10026,
                    SourceKey = "BAS",
                    SourceApplication = "Northgate"
                });
            }

            private void AddTenancyTypes()
            {
                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SUCCASSO",
                    Description = "SUCCESSOR TO ASSURED OLD",
                    Id = 10001,
                    SourceKey = "SUCCASSO",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "USENOCCU",
                    Description = "USE AND OCCUPATION ACCOUNTS",
                    Id = 10002,
                    SourceKey = "USENOCCU",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LICENSEE",
                    Description = "LICENSEE",
                    Id = 10003,
                    SourceKey = "LICENSEE",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SUCCSECN",
                    Description = "SECCESSOR TO SECURE NEW",
                    Id = 10004,
                    SourceKey = "SUCCSECN",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LEASE100",
                    Description = "LEASEHOLD 100% OWNERSHIP",
                    Id = 10005,
                    SourceKey = "LEASE100",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SUCCSECO",
                    Description = "SUCCESSOR TO SECURE OLD",
                    Id = 10006,
                    SourceKey = "SUCCSECO",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSSA",
                    Description = "SUSPENSE ACCOUNT",
                    Id = 10007,
                    SourceKey = "MOSSA",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MANAGR",
                    Description = "MANAGEMENT AGREEMENT WITH AGENCY",
                    Id = 10008,
                    SourceKey = "MANAGR",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SHOLDASS",
                    Description = "ASSURED SHORTHOLD",
                    Id = 10009,
                    SourceKey = "SHOLDASS",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSK",
                    Description = "LBH LEASEBACK",
                    Id = 10010,
                    SourceKey = "MOSK",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "EHSLIC",
                    Description = "EHS AGENCY MANAGED",
                    Id = 10011,
                    SourceKey = "EHSLIC",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSA",
                    Description = "SECURE SELFCONTAINED",
                    Id = 10012,
                    SourceKey = "MOSA",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "OFFICE",
                    Description = "OFFICE COMMERCIAL",
                    Id = 10013,
                    SourceKey = "OFFICE",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LINONPRO",
                    Description = "NON PROTECTED LICENCE",
                    Id = 10014,
                    SourceKey = "LINONPRO",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SERVCHRG",
                    Description = "SERVICE CHARGES",
                    Id = 10015,
                    SourceKey = "SERVCHRG",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "TANONSEC",
                    Description = "TEMP ACCOM NON SECURE",
                    Id = 10016,
                    SourceKey = "TANONSEC",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "ASSURED",
                    Description = "ASSURED",
                    Id = 10017,
                    SourceKey = "ASSURED",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "STORELIC",
                    Description = "Rent To Homebuy (3 year tenancy)",
                    Id = 10018,
                    SourceKey = "RTHMB3YR",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "REGEN60",
                    Description = "Fixed Term Tenancy (in probation period)",
                    Id = 10019,
                    SourceKey = "STARTFIX",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "EHSASSUR",
                    Description = "EHS ASSURED",
                    Id = 10020,
                    SourceKey = "EHSASSUR",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "DATALOAD",
                    Description = "DATALOAD DEFAULT",
                    Id = 10021,
                    SourceKey = "DATALOAD",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "EMPLOYEE",
                    Description = "EMPLOYEE",
                    Id = 10022,
                    SourceKey = "EMPLOYEE",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LMASHOLD",
                    Description = "LMA SHOLDASS tenancies",
                    Id = 10023,
                    SourceKey = "LMASHOLD",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LICOO",
                    Description = "OLD OAK LICENCE",
                    Id = 10024,
                    SourceKey = "LICOO",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSNR",
                    Description = "NON SO RESID. LEASE",
                    Id = 10025,
                    SourceKey = "MOSNR",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "RPIASS",
                    Description = "RPI ASSURED",
                    Id = 10026,
                    SourceKey = "RPIASS",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SECUREV",
                    Description = "SECURE TENANCIES WITH VARIABLE SERVICE C",
                    Id = 10027,
                    SourceKey = "SECUREV",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "EHSASSSH",
                    Description = "EHS ASSURED SHORTHOLD",
                    Id = 10028,
                    SourceKey = "EHSASSSH",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LEASEHMB",
                    Description = "LEASE HOMEBUY",
                    Id = 10029,
                    SourceKey = "LEASEHMB",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "STDX",
                    Description = "QUAKER STANDARD",
                    Id = 10030,
                    SourceKey = "STDX",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MARKETRE",
                    Description = "Lifetime Tenancy (in probation period)",
                    Id = 10031,
                    SourceKey = "STARTLIF",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSE",
                    Description = "ASSURED SHARED",
                    Id = 10032,
                    SourceKey = "MOSE",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "GARAGE",
                    Description = "GARAGE PARKING SPACE",
                    Id = 10033,
                    SourceKey = "GARAGE",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "STD",
                    Description = "STANDARD",
                    Id = 10034,
                    SourceKey = "STD",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSN",
                    Description = "SHARED OWNERSHP LEAS",
                    Id = 10035,
                    SourceKey = "MOSN",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SSHOSTEL",
                    Description = "SOCIAL SERVICES HOSTEL",
                    Id = 10036,
                    SourceKey = "SSHOSTEL",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LEASEOAK",
                    Description = "OLD OAK LEASEHOLDERS",
                    Id = 10037,
                    SourceKey = "LEASEOAK",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "REGEN80",
                    Description = "CARE AND SUPPORT",
                    Id = 10038,
                    SourceKey = "CARESUPP",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "INTERMED",
                    Description = "INTERMEDIATE RENT",
                    Id = 10039,
                    SourceKey = "INTERMED",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SUBTENLE",
                    Description = "LEASEHOLDERS LEGAL TENANT",
                    Id = 10040,
                    SourceKey = "SUBTENLE",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSD",
                    Description = "ASSURED SELFCONTAINED",
                    Id = 10041,
                    SourceKey = "MOSD",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SOHMBY",
                    Description = "Social Home Buy",
                    Id = 10042,
                    SourceKey = "SOHMBY",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "RSIASS",
                    Description = "RSI ASSURED",
                    Id = 10043,
                    SourceKey = "RSIASS",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "AST09",
                    Description = "Lifetime Tenancy",
                    Id = 10044,
                    SourceKey = "LIFETIME",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LNDOWNER",
                    Description = "LANDMARK 100% OWNER",
                    Id = 10045,
                    SourceKey = "LNDOWNER",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "FREEHOLD",
                    Description = "FREE HOLD TENANCY TYPE-",
                    Id = 10046,
                    SourceKey = "FREEHOLD",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "REGEN100",
                    Description = "HOSTEL",
                    Id = 10047,
                    SourceKey = "HOSTEL",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SOCSER",
                    Description = "SOCIAL SERVICES",
                    Id = 10048,
                    SourceKey = "SOCSER",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "CONTRACT",
                    Description = "CONTRACTUAL",
                    Id = 10049,
                    SourceKey = "CONTRACT",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "AST_RTTB",
                    Description = "RENT TO BUY ASSURED SHORTHOLD",
                    Id = 10050,
                    SourceKey = "AST_RTTB",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "FIXED",
                    Description = "Fixed Term Tenancy",
                    Id = 10051,
                    SourceKey = "FIXED",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SECUREO",
                    Description = "SECURE OLD TENANCY",
                    Id = 10052,
                    SourceKey = "SECUREO",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "TEMPDEC",
                    Description = "TEMP LICENSEE",
                    Id = 10053,
                    SourceKey = "TEMPLIC",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "EHSNOSEC",
                    Description = "EHS NON SECURE",
                    Id = 10054,
                    SourceKey = "EHSNOSEC",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LEASESHR",
                    Description = "LEASEHOLD SHARED",
                    Id = 10055,
                    SourceKey = "LEASESHR",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSSO",
                    Description = "SERVICE OCCUPIER",
                    Id = 10056,
                    SourceKey = "MOSSO",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LEASECTH",
                    Description = "Charlton Leaseholders",
                    Id = 10057,
                    SourceKey = "LEASECTH",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSCS",
                    Description = "CARE.SUPPRT SHD ONLY",
                    Id = 10058,
                    SourceKey = "MOSCS",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LICRES",
                    Description = "RESIDENTIAL LICENCE",
                    Id = 10059,
                    SourceKey = "LICRES",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "ASSPRTB",
                    Description = "ASSURED PRESERVED RIGHT TO BUY",
                    Id = 10060,
                    SourceKey = "ASSPRTB",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "AGENCY",
                    Description = "AGENCY MANAGED",
                    Id = 10061,
                    SourceKey = "AGENCY",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSI",
                    Description = "LBI LEASEBACK",
                    Id = 10062,
                    SourceKey = "MOSI",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "RENTFREE",
                    Description = "RENT FREE",
                    Id = 10063,
                    SourceKey = "RENTFREE",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "ASSUREDN",
                    Description = "ASSURED NEW",
                    Id = 10064,
                    SourceKey = "ASSUREDN",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LMASSURE",
                    Description = "LMA Assured",
                    Id = 10065,
                    SourceKey = "LMASSURE",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSBL",
                    Description = "BASILDON LEASEBACK",
                    Id = 10066,
                    SourceKey = "MOSBL",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SECURE",
                    Description = "SECURE",
                    Id = 10067,
                    SourceKey = "SECURE",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SECP",
                    Description = "SLEEPING ROOM",
                    Id = 10068,
                    SourceKey = "SLEEPER",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LICSQUAT",
                    Description = "LICENCE TO SQUAT",
                    Id = 10069,
                    SourceKey = "LICSQUAT",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "COM1",
                    Description = "Commercial Agency Managed",
                    Id = 10070,
                    SourceKey = "COMMAGE",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SECUREN",
                    Description = "SECURE NEW TENANCY",
                    Id = 10071,
                    SourceKey = "SECUREN",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSOA",
                    Description = "OFFICE ACCOMMODATION",
                    Id = 10072,
                    SourceKey = "MOSOA",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSM",
                    Description = "COMMERCIAL LEASE",
                    Id = 10073,
                    SourceKey = "MOSM",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "ASSSHOLD",
                    Description = "ASSURED SHORTHOLD",
                    Id = 10074,
                    SourceKey = "ASSSHOLD",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LEASEHSO",
                    Description = "LEASE HOMEBUY SHARED OWNER",
                    Id = 10075,
                    SourceKey = "LEASEHSO",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSC",
                    Description = "ASSURED SHOLD SHARED",
                    Id = 10076,
                    SourceKey = "MOSC",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "STARTER",
                    Description = "***DO NOT USE FOR NEW STARTER TENANCY***",
                    Id = 10077,
                    SourceKey = "STARTER",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LBISLING",
                    Description = "LEASE BACK ISLINGTON",
                    Id = 10078,
                    SourceKey = "LBISLING",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SUCCASSN",
                    Description = "SUCCESSOR TO ASSURED NEW",
                    Id = 10079,
                    SourceKey = "SUCCASSN",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSL",
                    Description = "LICENSEE",
                    Id = 10080,
                    SourceKey = "MOSL",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MINOR",
                    Description = "PERMANENT LETTING TO MINOR",
                    Id = 10081,
                    SourceKey = "MINOR",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "NONSEC",
                    Description = "NONSEC",
                    Id = 10082,
                    SourceKey = "NONSEC",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LICHOST",
                    Description = "LICENCE HOSTLES",
                    Id = 10083,
                    SourceKey = "LICHOST",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSAS",
                    Description = "ASSURED SHORTHOLD",
                    Id = 10084,
                    SourceKey = "MOSAS",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSSS",
                    Description = "SUPP. LIVING SCHEME",
                    Id = 10085,
                    SourceKey = "MOSSS",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSJ",
                    Description = "LBC LEASEBACK",
                    Id = 10086,
                    SourceKey = "MOSJ",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSAG",
                    Description = "AGENCY LEASE LICEN.",
                    Id = 10087,
                    SourceKey = "MOSAG",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LEASEHB5",
                    Description = "5 year rent free period HOME BUY product",
                    Id = 10088,
                    SourceKey = "LEASEHB5",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MIG",
                    Description = "MIG",
                    Id = 10089,
                    SourceKey = "MIG",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSTD",
                    Description = "TEMP DECANT",
                    Id = 10090,
                    SourceKey = "MOSTD",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "HMBY2010",
                    Description = "HOMEBUY 2010",
                    Id = 10091,
                    SourceKey = "HMBY2010",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LICGAR",
                    Description = "GARAGE/PARKING SPACE LICENCE",
                    Id = 10092,
                    SourceKey = "LICGAR",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "ASSUREDO",
                    Description = "ASSURED OLD",
                    Id = 10093,
                    SourceKey = "ASSUREDO",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "TOLDTRES",
                    Description = "TOLERATED TRESPASSER",
                    Id = 10094,
                    SourceKey = "TOLDTRES",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "USEOCC",
                    Description = "USE AND OCCUPATION",
                    Id = 10095,
                    SourceKey = "USEOCC",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "ASSSPEC",
                    Description = "SPECIAL ASSURED",
                    Id = 10096,
                    SourceKey = "ASSSPEC",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LBCAMDEN",
                    Description = "CAMDEN LEASEBACKS",
                    Id = 10097,
                    SourceKey = "LBCAMDEN",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "SHARED",
                    Description = "SHARED OWNERSHIP",
                    Id = 10098,
                    SourceKey = "SHARED",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "MOSGR",
                    Description = "GUEST ROOM",
                    Id = 10099,
                    SourceKey = "MOSGR",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "AST_KEY",
                    Description = "KEYWORKER ASSURED SHORTHOLD",
                    Id = 10100,
                    SourceKey = "AST_KEY",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "NONASSUR",
                    Description = "NON ASSURED",
                    Id = 10101,
                    SourceKey = "NONASSUR",
                    SourceApplication = "Northgate"
                });

                TenancyTypeList.Add(new TenancyType()
                {
                    Name = "LEASESEC",
                    Description = "LEASEHOLD BIANNUAL FAIR RENT INCREASE",
                    Id = 10102,
                    SourceKey = "LEASESEC",
                    SourceApplication = "Northgate"
                });
            }
            
            private void AddTenureTypes()
            {
                TenureTypeList.Add(new TenureType()
                {
                    Name = "SECURE",
                    Description = "SECURE",
                    Id = 10001,
                    SourceKey = "SECURE",
                    SourceApplication = "Northgate"
                });

                TenureTypeList.Add(new TenureType()
                {
                    Name = "FREE",
                    Description = "FREEHOLDER TUNURE",
                    Id = 10002,
                    SourceKey = "FREE",
                    SourceApplication = "Northgate"
                });

                TenureTypeList.Add(new TenureType()
                {
                    Name = "MIG",
                    Description = "Migration",
                    Id = 10003,
                    SourceKey = "MIG",
                    SourceApplication = "Northgate"
                });

                TenureTypeList.Add(new TenureType()
                {
                    Name = "INTRO",
                    Description = "INTRODUCTORY",
                    Id = 10004,
                    SourceKey = "INTRO",
                    SourceApplication = "Northgate"
                });

                TenureTypeList.Add(new TenureType()
                {
                    Name = "MOSMIG",
                    Description = "MOSAIC MIGRATION",
                    Id = 10005,
                    SourceKey = "MOSMIG",
                    SourceApplication = "Northgate"
                });

                TenureTypeList.Add(new TenureType()
                {
                    Name = "STD",
                    Description = "STANDARD",
                    Id = 10006,
                    SourceKey = "STD",
                    SourceApplication = "Northgate"
                });

                TenureTypeList.Add(new TenureType()
                {
                    Name = "NONSEC",
                    Description = "NON-SECURE",
                    Id = 10007,
                    SourceKey = "NONSEC",
                    SourceApplication = "Northgate"
                });

                TenureTypeList.Add(new TenureType()
                {
                    Name = "FMT",
                    Description = "Family Mosaic Tenure",
                    Id = 10008,
                    SourceKey = "FMT",
                    SourceApplication = "Northgate"
                });
            }

            private void AddTenancySources()
            {
                TenancySourceList.Add(new TenancySource()
                {
                    Name = "RC",
                    Description = "RECIP WITH LA OUTSIDE HMS",
                    Id = 10001,
                    SourceKey = "RC",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "CH",
                    Description = "CHARLTON-HOMES MOBILITY SCHEME OUT",
                    Id = 10002,
                    SourceKey = "CH",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "JOINTNEW",
                    Description = "FROM SINGLE TO JOINT TENANCY",
                    Id = 10003,
                    SourceKey = "JOINTNEW",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "CL",
                    Description = "CHARLTON LOCAL LETTINGS SCHEME",
                    Id = 10004,
                    SourceKey = "CL",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "AM",
                    Description = "ACADEMY MIGRATION",
                    Id = 10005,
                    SourceKey = "AM",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "GENERAL",
                    Description = "GENERAL LIST",
                    Id = 10006,
                    SourceKey = "GENERAL",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "STRHYDE",
                    Description = "HYDE HOUSING STOCK TRANSFER",
                    Id = 10007,
                    SourceKey = "STRHYDE",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "TC",
                    Description = "TRANSFERS CHARLTON TRIANGLE",
                    Id = 10008,
                    SourceKey = "TC",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "DC",
                    Description = "DECANT CHARLTON",
                    Id = 10009,
                    SourceKey = "DC",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "CM",
                    Description = "CHARLTON-MISCELLANEOUS",
                    Id = 10010,
                    SourceKey = "CM",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "CO",
                    Description = "CO-OP DEVELOPMENT SCHEME",
                    Id = 10011,
                    SourceKey = "CO",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "STREAST",
                    Description = "EAST THAMES STOCK TRANSFER",
                    Id = 10012,
                    SourceKey = "STREAST",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "GA",
                    Description = "GARAGE LIST",
                    Id = 10013,
                    SourceKey = "GA",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "STRMHT",
                    Description = "Metropolitan Housing Stock Transfer",
                    Id = 10014,
                    SourceKey = "STRMHT",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "MO",
                    Description = "SPECIAL PROJECT MOVE ON",
                    Id = 10015,
                    SourceKey = "MO",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "RD",
                    Description = "RETURNING DECANT",
                    Id = 10016,
                    SourceKey = "RD",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "MEX",
                    Description = "Mutual Exchange of Property",
                    Id = 10017,
                    SourceKey = "MEX",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "XT",
                    Description = "TENANCY ASSIGNMENT (NON MX)",
                    Id = 10018,
                    SourceKey = "XT",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "HO",
                    Description = "HOMES MOBILITY SCHEME (FHA) OUT",
                    Id = 10019,
                    SourceKey = "HO",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "FA",
                    Description = "FAMILY MOSAIC NON RENTABLE UNIT",
                    Id = 10020,
                    SourceKey = "FA",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "LA",
                    Description = "LA NOM",
                    Id = 10021,
                    SourceKey = "LA",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "DI",
                    Description = "DIRECT APP CHARTLON TRIANGLE",
                    Id = 10022,
                    SourceKey = "DI",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "MX",
                    Description = "EXTERNAL OR OTHER MUTUAL EXCHANGE",
                    Id = 10023,
                    SourceKey = "MX",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "STRGHA",
                    Description = "Genesis Stock Transfer",
                    Id = 10024,
                    SourceKey = "STRGHA",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "MA",
                    Description = "MANAGEMENT AGENCY",
                    Id = 10025,
                    SourceKey = "MA",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "TF",
                    Description = "INTERNAL TRANSFER",
                    Id = 10026,
                    SourceKey = "TF",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "OOLEASE",
                    Description = "OLD OAK LEASEHOLDERS",
                    Id = 10027,
                    SourceKey = "OOLEASE",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "XC",
                    Description = "CO-OP DEVELOPMENT SCHEME",
                    Id = 10028,
                    SourceKey = "XC",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "STRTVHA",
                    Description = "Thames Valley Housing Stock Transfer",
                    Id = 10029,
                    SourceKey = "STRTVHA",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "CTHLSS",
                    Description = "Charlton lease spead sheet",
                    Id = 10030,
                    SourceKey = "CTHLSS",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "SU",
                    Description = "SUCCESSION",
                    Id = 10031,
                    SourceKey = "SU",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "ZZ",
                    Description = "RELETTING OF TENANCY ENDED IN ERROR",
                    Id = 10032,
                    SourceKey = "ZZ",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "EX",
                    Description = "EXCEPTION/DIRECT APPN",
                    Id = 10033,
                    SourceKey = "EX",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "OM",
                    Description = "OLD OAK MISCELLANEOUS LIST",
                    Id = 10034,
                    SourceKey = "OM",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "SO",
                    Description = "SHARED OWNERSHIP WAITING LIST",
                    Id = 10035,
                    SourceKey = "SO",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "RTTB",
                    Description = "RENT TO BUY",
                    Id = 10036,
                    SourceKey = "RTTB",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "LM",
                    Description = "LANDMARK RECIPROCAL",
                    Id = 10037,
                    SourceKey = "LM",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "STRELIM",
                    Description = "Elim Stock Transfer",
                    Id = 10038,
                    SourceKey = "STRELIM",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "DO",
                    Description = "DECANT OLD OAK",
                    Id = 10039,
                    SourceKey = "DO",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "NG",
                    Description = "NEW GENERATIONS SCHEME",
                    Id = 10040,
                    SourceKey = "NG",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "DN",
                    Description = "DIRECT APP FROM NON FHA UNIT",
                    Id = 10041,
                    SourceKey = "DN",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "KW",
                    Description = "KEY WORKER SE LONDON",
                    Id = 10042,
                    SourceKey = "KW",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "XG",
                    Description = "GARAGES/PARKING SPACES",
                    Id = 10043,
                    SourceKey = "XG",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "RS",
                    Description = "ROUGH SLEEPERS INITIATIVE",
                    Id = 10044,
                    SourceKey = "RS",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "KEYWINT",
                    Description = "KEY WORKER INTERMEDIATE/SUB-MARKET RENT",
                    Id = 10045,
                    SourceKey = "KEYWINT",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "SOLDLHAUCT",
                    Description = "Sold leasehold at auction",
                    Id = 10046,
                    SourceKey = "SOLDLHAUCT",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "SI",
                    Description = "SITTING TENANT",
                    Id = 10047,
                    SourceKey = "SI",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "RF",
                    Description = "REFERRAL",
                    Id = 10048,
                    SourceKey = "RF",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "RTB",
                    Description = "RIGHT TO BUY",
                    Id = 10049,
                    SourceKey = "RTB",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "CI",
                    Description = "CHARLTON-HOMES MOBILITY SCHEME IN",
                    Id = 10050,
                    SourceKey = "CI",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "NK",
                    Description = "NOT KNOWN",
                    Id = 10051,
                    SourceKey = "NK",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "HI",
                    Description = "HOMES MOBILITY IN",
                    Id = 10052,
                    SourceKey = "HI",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "RA",
                    Description = "REFERRAL AGENCY - SHELTERED",
                    Id = 10053,
                    SourceKey = "RA",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "STR",
                    Description = "Transform Stock Transfer",
                    Id = 10054,
                    SourceKey = "STR",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "TO",
                    Description = "TRANSFERS OLD OAK",
                    Id = 10055,
                    SourceKey = "TO",
                    SourceApplication = "Northgate"
                });

                TenancySourceList.Add(new TenancySource()
                {
                    Name = "XB",
                    Description = "BUSINESS LETTING",
                    Id = 10056,
                    SourceKey = "XB",
                    SourceApplication = "Northgate"
                });
            }


            private void AddRevenueAccountTypes()
            {
                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "CCO",
                    Description = "COURT COSTS",
                    Id = 10001,
                    SourceKey = "CCO",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "GRD",
                    Description = "Ground Rent",
                    Id = 10002,
                    SourceKey = "GRD",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "GAS",
                    Description = "Gas Injunction legal fees",
                    Id = 10003,
                    SourceKey = "GAS",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "TSC",
                    Description = "TENANCY SERVICE CHARGE ACCOUNT",
                    Id = 10004,
                    SourceKey = "TSC",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "UNO",
                    Description = "Use and Occupation",
                    Id = 10005,
                    SourceKey = "UNO",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "MJW",
                    Description = "MAJOR WORKS ACCOUNTS",
                    Id = 10006,
                    SourceKey = "MJW",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "H&W",
                    Description = "Heating and Water",
                    Id = 10007,
                    SourceKey = "H&W",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "MWO",
                    Description = "MAJOR WORKS ACCOUNT",
                    Id = 10008,
                    SourceKey = "MWO",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "APC",
                    Description = "Affordable Personal Charge",
                    Id = 10009,
                    SourceKey = "APC",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "SUN",
                    Description = "SUNDRY DEBT ACCOUNT",
                    Id = 10010,
                    SourceKey = "SUN",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "SUS",
                    Description = "ON-LINE SUSPENSE ACCOUNT",
                    Id = 10011,
                    SourceKey = "SUS",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "VRL",
                    Description = "VOID RENT LOSS",
                    Id = 10012,
                    SourceKey = "VRL",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "SPA",
                    Description = "SUPPORTING PEOPLE ACCOUNT",
                    Id = 10013,
                    SourceKey = "SPA",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "REP",
                    Description = "RECHARGEABLE REPAIRS ACCOUNT",
                    Id = 10014,
                    SourceKey = "REP",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "EMF",
                    Description = "Employment Fix term",
                    Id = 10015,
                    SourceKey = "EMF",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "REN",
                    Description = "RENT ACCOUNT",
                    Id = 10016,
                    SourceKey = "REN",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "HBO",
                    Description = "HOUSING BENEFIT OVERPAYMENT (update)",
                    Id = 10017,
                    SourceKey = "HBO",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "TRB",
                    Description = "TRANSFERS OF BALANCES",
                    Id = 10018,
                    SourceKey = "TRB",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "MRA",
                    Description = "Mileage Recharge Accounts",
                    Id = 10019,
                    SourceKey = "MRA",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "EMW",
                    Description = "Employment Welfare Rights",
                    Id = 10020,
                    SourceKey = "EMW",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "LOT",
                    Description = "ALLOTMENT",
                    Id = 10021,
                    SourceKey = "LOT",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "VRC",
                    Description = "VOID RECHARGE SUBACCOUNT",
                    Id = 10022,
                    SourceKey = "VRC",
                    SourceApplication = "Northgate"
                });

                RevenueAccountTypeList.Add(new RevenueAccountType()
                {
                    Name = "SER",
                    Description = "LEASEHOLD SERVICE CHARGE ACCOUNT",
                    Id = 10023,
                    SourceKey = "SER",
                    SourceApplication = "Northgate"
                });
            }

            private void AddPropertySources()
            {
                PropertySourceList.Add(new PropertySource()
                {
                    Name = "HAT",
                    Description = "HAT",
                    Id = 10001,
                    SourceKey = "HAT",
                    SourceApplication = "Northgate"
                });

                PropertySourceList.Add(new PropertySource()
                {
                    Name = "REF",
                    Description = "REF",
                    Id = 10002,
                    SourceKey = "REF",
                    SourceApplication = "Northgate"
                });

                PropertySourceList.Add(new PropertySource()
                {
                    Name = "LAT",
                    Description = "LAT",
                    Id = 10003,
                    SourceKey = "LAT",
                    SourceApplication = "Northgate"
                });

                PropertySourceList.Add(new PropertySource()
                {
                    Name = "NEW",
                    Description = "NEW",
                    Id = 10004,
                    SourceKey = "NEW",
                    SourceApplication = "Northgate"
                });

                PropertySourceList.Add(new PropertySource()
                {
                    Name = "ACQ",
                    Description = "ACQ",
                    Id = 10005,
                    SourceKey = "ACQ",
                    SourceApplication = "Northgate"
                });

                PropertySourceList.Add(new PropertySource()
                {
                    Name = "RTTB",
                    Description = "RTTB",
                    Id = 10006,
                    SourceKey = "RTTB",
                    SourceApplication = "Northgate"
                });

                PropertySourceList.Add(new PropertySource()
                {
                    Name = "LSE",
                    Description = "LSE",
                    Id = 10007,
                    SourceKey = "LSE",
                    SourceApplication = "Northgate"
                });

                PropertySourceList.Add(new PropertySource()
                {
                    Name = "HMP",
                    Description = "HMP",
                    Id = 10008,
                    SourceKey = "HMP",
                    SourceApplication = "Northgate"
                });

                PropertySourceList.Add(new PropertySource()
                {
                    Name = "BBK",
                    Description = "BBK",
                    Id = 10009,
                    SourceKey = "BBK",
                    SourceApplication = "Northgate"
                });
            }
            
            private void AddRoles()
            {
                RoleList.Add(new Role()
                {
                    Name = "LOP",
                    Description = "Lettings Officer",
                    Id = 10001,
                    SourceKey = "LOP",
                    SourceApplication = "Northgate"
                });

                RoleList.Add(new Role()
                {
                    Name = "AHM",
                    Description = "Area Housing Manager",
                    Id = 10002,
                    SourceKey = "AHM",
                    SourceApplication = "Northgate"
                });

                RoleList.Add(new Role()
                {
                    Name = "TEN",
                    Description = "Neighbourhood Manager",
                    Id = 10003,
                    SourceKey = "TEN",
                    SourceApplication = "Northgate"
                });

                RoleList.Add(new Role()
                {
                    Name = "RHM",
                    Description = "Regional Housing Manager",
                    Id = 10004,
                    SourceKey = "RHM",
                    SourceApplication = "Northgate"
                });

                RoleList.Add(new Role()
                {
                    Name = "PAT",
                    Description = "Patch Officer",
                    Id = 10005,
                    SourceKey = "PAT",
                    SourceApplication = "Northgate"
                });
            }


            // private void GenerateReferenceData()
            // {
            //     AddPropertyTypes();
            //     AddPropertySubTypes();
            //     AddLeaseTypes();
            //     AddTenancyTypes();
            //     AddTenureTypes();
            //     AddAddressTypes();
            //     AddGenders();
            // }
            //
           

            /*
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
            */
        }

    }
}
