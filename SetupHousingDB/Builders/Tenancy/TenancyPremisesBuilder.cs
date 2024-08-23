using System;
using System.Collections.Generic;
using System.Linq;
using HousingContext;
using SetupHousingDB.Builders.Address;

namespace SetupHousingDB.Builders.Tenancy
{
    public interface ITenancyPremisesBuilder : ICdmBuilder
    {
        HousingContext.TenancyPremises BuiltTenancyPremises { get; set; }
        void Init(List<HousingContext.TenancyPremises> tenancyPremises);
        void SetName();
        void SetTenancy(HousingContext.Tenancy tenancy);
        void SetPremises(HousingContext.Premises premises);
        void SetStartDate();
        void SetEndDate();
    }
    
    public class TenancyPremisesBuilder : ITenancyPremisesBuilder
    {
        public HousingContext.TenancyPremises BuiltTenancyPremises { get; set; }
        public int IdSeed => 100000;
        
        public void Init(List<HousingContext.TenancyPremises> tenancyPremises)
        {
            BuiltTenancyPremises = new HousingContext.TenancyPremises()
            {
                Id = tenancyPremises.Count < 1 ? IdSeed : (from p in tenancyPremises select p.Id).Max() + 1
            };
        }

        public void SetName()
        {
            BuiltTenancyPremises.Name = BuiltTenancyPremises.Id.ToString();
        }

        public void SetTenancy(HousingContext.Tenancy tenancy)
        {
            BuiltTenancyPremises.TenancyId = tenancy;
        }

        public void SetPremises(HousingContext.Premises premises)
        {
            BuiltTenancyPremises.PremisesId = premises;
        }

        public void SetEndDate()
        {
        }
        public void SetStartDate()
        {
            BuiltTenancyPremises.StartDate = DateTime.Now.Subtract(TimeSpan.FromDays(Faker.RandomNumber.Next(10, 8000)));
        }

        public void AddSourceApplication()
        {
            BuiltTenancyPremises.SourceApplication = "Northgate";
        }

        public void AddSourceKey()
        {
            BuiltTenancyPremises.SourceKey = BuiltTenancyPremises.Id.ToString();
        }
    }
    
    public interface ITenancyPremisesBuilderDirector
    {
        TenancyPremises Build(ITenancyPremisesBuilder builder, List<HousingContext.TenancyPremises> tenancyPremises, 
            HousingContext.Tenancy tenancy, HousingContext.Premises premises);
    }
    
    public class TenancyPremisesDirector : ITenancyPremisesBuilderDirector
    {
        public TenancyPremises Build(ITenancyPremisesBuilder builder, List<TenancyPremises> tenancyPremises,
            HousingContext.Tenancy tenancy, Premises premises)
        {
            builder.Init(tenancyPremises);
            builder.SetName();
            builder.SetTenancy(tenancy);
            builder.SetPremises(premises);
            builder.SetStartDate();
            builder.SetEndDate();
            builder.AddSourceApplication();
            builder.AddSourceKey();
            return builder.BuiltTenancyPremises;
        }
    }
}