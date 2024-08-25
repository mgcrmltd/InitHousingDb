using System.Collections.Generic;
using System.Linq;
using HousingContext;
using SetupHousingDB.Builders.Address;

namespace SetupHousingDB.Builders.Tenancy
{
    //Create an interface and class for TenancyOccupantBuilder
    public interface ITenancyOccupantBuilder : ICdmBuilder
    {
        void Init(List<HousingContext.TenancyOccupant> tenancyOccupants);
        HousingContext.TenancyOccupant TenancyOccupant { get; }
        void AddPerson(HousingContext.Person person);
        void AddTenancy(HousingContext.Tenancy tenancy);
        void AddMainOccupant(List<HousingContext.TenancyOccupant> tenancyOccupants);
        void AddName();
        
        int IdSeed { get; }
    }
    
    public class TenancyOccupantBuilder : ITenancyOccupantBuilder
    {
        protected HousingContext.TenancyOccupant BuiltTenancyOccupant;
        public HousingContext.TenancyOccupant TenancyOccupant => BuiltTenancyOccupant;

        public void AddName()
        {
            TenancyOccupant.Name = $"TO{TenancyOccupant.PersonId.Id}:{TenancyOccupant.TenancyId.Id}";
        }

        public int IdSeed => 10000;

        public void AddPerson(HousingContext.Person person)
        {
            TenancyOccupant.PersonId = person;
        }

        public void AddTenancy(HousingContext.Tenancy tenancy)
        {
            TenancyOccupant.TenancyId = tenancy;
        }

        public void Init(List<HousingContext.TenancyOccupant> tenancyOccupants)
        {
            BuiltTenancyOccupant = new HousingContext.TenancyOccupant()
            {
                Id = tenancyOccupants.Count < 1 ? IdSeed : (from to in tenancyOccupants select to.Id).Max() + 1
            };
        }
        
        public void AddMainOccupant(List<TenancyOccupant> tenancyOccupants)
        {
            BuiltTenancyOccupant.MainTenant = !tenancyOccupants.Any(x =>  x.TenancyId == BuiltTenancyOccupant.TenancyId && x.MainTenant);
        }

        public void AddSourceApplication()
        {
            BuiltTenancyOccupant.SourceApplication = "Northgate";
        }

        public void AddSourceKey()
        {
            BuiltTenancyOccupant.SourceKey = BuiltTenancyOccupant.Id.ToString();
        }
    }
    
    public class TenancyOccupantDirector
    {

        public HousingContext.TenancyOccupant Build(ITenancyOccupantBuilder builder, List<HousingContext.TenancyOccupant> tenancyOccupants, 
            HousingContext.Person person, HousingContext.Tenancy tenancy)
        {
            builder.Init(tenancyOccupants);
            builder.AddPerson(person);
            builder.AddTenancy(tenancy);
            builder.AddName();
            builder.AddSourceApplication();
            builder.AddSourceKey();
            return builder.TenancyOccupant;
        }
    }
}