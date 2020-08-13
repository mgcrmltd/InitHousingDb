using System;
using System.Collections.Generic;
using System.Linq;
using HousingContext;

namespace SetupHousingDB.Builders.Tenancy
{
    public interface ITenancyBuilder
    {
        void Init(List<HousingContext.Tenancy> tenancies);
        void SetEndDate();
        void SetStartDate();
        void SetProperty(HousingContext.Property property);
        void SetTenancyType(List<TenancyType> tenancyTypes);
        void SetTenureType(List<TenureType> tenureTypes);
        void SetName();
        HousingContext.Tenancy Tenancy { get; }
        int IdSeed { get; }

    }
    public abstract class TenancyBuilder : ITenancyBuilder
    {
        public int IdSeed => 100000;
        public void Init(List<HousingContext.Tenancy> tenancies)
        {
            BuiltTenancy = new HousingContext.Tenancy()
            {
                Id = tenancies.Count < 1 ? IdSeed : (from p in tenancies select p.Id).Max() + 1
            };
        }
        public abstract void SetEndDate();
        public abstract void SetStartDate();
        public abstract void SetProperty(HousingContext.Property property);
        public abstract void SetTenancyType(List<TenancyType> tenancyTypes);
        public abstract void SetTenureType(List<TenureType> tenureTypes);
        public void SetName()
        {
            BuiltTenancy.Name = $"TEN{BuiltTenancy.Id.ToString()}";
        }

        protected HousingContext.Tenancy BuiltTenancy;
        public HousingContext.Tenancy Tenancy => BuiltTenancy;
    }

    public class TenancyBuilderStandard : TenancyBuilder
    {

        public override void SetEndDate()
        {
        }

        public override void SetStartDate()
        {
            BuiltTenancy.StartDate = DateTime.Now.Subtract(TimeSpan.FromDays(Faker.RandomNumber.Next(10, 8000)));
        }

        public override void SetProperty(HousingContext.Property property)
        {
            BuiltTenancy.Property = property;
        }

        public override void SetTenancyType(List<TenancyType> tenancyTypes)
        {
            BuiltTenancy.TenancyType = tenancyTypes.GetRandom();
        }

        public override void SetTenureType(List<TenureType> tenureTypes)
        {
            BuiltTenancy.TenureType = tenureTypes.GetRandom();
        }
    }

    public class TenancyBuilderExpired : TenancyBuilderStandard
    {
        public override void SetEndDate()
        {
            var potentialEnd = BuiltTenancy.StartDate.AddYears(Faker.RandomNumber.Next(3, 10));
            BuiltTenancy.EndDate = potentialEnd < DateTime.Now ? potentialEnd : DateTime.Now;
        }
    }

    public interface ITenancyDirector
    {
        HousingContext.Tenancy Build(
            ITenancyBuilder builder,
            List<HousingContext.Tenancy> tenancies,
            List<HousingContext.TenancyType> tenancyTypes,
            List<HousingContext.TenureType> tenureTypes,
            HousingContext.Property property
            );
    }

    public class TenancyDirector : ITenancyDirector
    {
        public HousingContext.Tenancy Build(
            ITenancyBuilder builder, 
            List<HousingContext.Tenancy> tenancies,
            List<TenancyType> tenancyTypes, 
            List<TenureType> tenureTypes, 
            HousingContext.Property property)
        {
            builder.Init(tenancies);
            builder.SetName();
            builder.SetStartDate();
            builder.SetEndDate();
            builder.SetTenancyType(tenancyTypes);
            builder.SetTenureType(tenureTypes);
            builder.SetProperty(property);
            return builder.Tenancy;
        }

    }

    public static class ListExtensions
    {
        public static T GetRandom<T>(this List<T> obj)
        {
            var random = Faker.RandomNumber.Next(0, obj.Count - 1);
            return obj[random];
        } 
    }
}