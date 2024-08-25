using System;
using System.Collections.Generic;
using System.Linq;
using Faker;
using HousingContext;
using SetupHousingDB.Builders.Address;

namespace SetupHousingDB.Builders.Tenancy
{
    public interface IRevenueAccountBuilder : ICdmBuilder
    {
        HousingContext.RevenueAccount BuiltRevenueAccount { get; set; }
        void Init(List<HousingContext.RevenueAccount> revenueAccounts);
        void SetName();
        void SetTenancyPremises(HousingContext.TenancyPremises tenancyPremises);
        void SetRevenueAccountType(List<HousingContext.RevenueAccountType> revenueAccountTypes);
        void SetGrossRent();
        void SetHbClaimNumber();
        void SetLastAccountBalance();
        void SetBalanceDate();
        void SetFrequency(List<HousingContext.Frequency> frequencies);
        void SetStartDate(List<HousingContext.Tenancy> tenancies);
        void SetEndDate();
    }
    
    public class WeeklyRevenueAccountBuilder : IRevenueAccountBuilder
    {
        public HousingContext.RevenueAccount BuiltRevenueAccount { get; set; }
        public int IdSeed => 100000;
        
        public void Init(List<HousingContext.RevenueAccount> revenueAccounts)
        {
            BuiltRevenueAccount = new HousingContext.RevenueAccount()
            {
                Id = revenueAccounts.Count < 1 ? IdSeed : (from p in revenueAccounts select p.Id).Max() + 1
            };
        }

        public void SetName()
        {
            BuiltRevenueAccount.Name = BuiltRevenueAccount.Id.ToString();
        }

        public void SetTenancyPremises(TenancyPremises tenancyPremises)
        {
            BuiltRevenueAccount.TenancyPremisesId = tenancyPremises;
        }

        public void SetRevenueAccountType(List<RevenueAccountType> revenueAccountTypes)
        {
            BuiltRevenueAccount.RevenueAccountTypeId = revenueAccountTypes.First(x => x.Name == "REN");
        }


        public virtual void SetGrossRent()
        {
            var pounds = (decimal)Faker.RandomNumber.Next(100, 450);
            var pence = (decimal)Faker.RandomNumber.Next(0, 99) / 100;
            BuiltRevenueAccount.GrossRent = pounds + pence;
        }

        public void SetHbClaimNumber()
        {
            BuiltRevenueAccount.HBCLaimNumber = Faker.RandomNumber.Next(100000, 999999).ToString();
        }

        public void SetLastAccountBalance()
        {
            var multiples = Faker.RandomNumber.Next(0, 3);
            BuiltRevenueAccount.LastAccountBalance = BuiltRevenueAccount.GrossRent * multiples;
        }

        public void SetBalanceDate()
        {
            BuiltRevenueAccount.LastBalanceDate = DateTime.Today.AddMonths(-1).AddDays(DateTime.Today.Day * -1)
                .AddDays(BuiltRevenueAccount.StartDate.Day);
        }

        public virtual void SetFrequency(List<HousingContext.Frequency> frequencies)
        {
            BuiltRevenueAccount.FrequencyId = frequencies.First(x => x.Name == "WEEKLY");
        }

        public void SetEndDate()
        {
        }

        public void SetStartDate(List<HousingContext.Tenancy> tenancies)
        {
            var tenancy = tenancies.First(x => x.Id == BuiltRevenueAccount.TenancyPremisesId.TenancyId.Id);
            BuiltRevenueAccount.StartDate = tenancy.StartDate;
        }

        public void AddSourceApplication()
        {
            BuiltRevenueAccount.SourceApplication = "Northgate";
        }

        public void AddSourceKey()
        {
            BuiltRevenueAccount.SourceKey = BuiltRevenueAccount.Id.ToString();
        }
    }


    public interface IRevenueAccountDirector
    {
        RevenueAccount Build(IRevenueAccountBuilder builder, List<RevenueAccount> revenueAccounts,
            TenancyPremises tenancyPremises, List<RevenueAccountType> revenueAccountTypes,
            List<Frequency> frequencies, List<HousingContext.Tenancy> tenancies);
    }

    public class RevenueAccountDirector : IRevenueAccountDirector
    {
        public RevenueAccount Build(IRevenueAccountBuilder builder, List<RevenueAccount> revenueAccounts,
            TenancyPremises tenancyPremises, List<RevenueAccountType> revenueAccountTypes,
            List<Frequency> frequencies, List<HousingContext.Tenancy> tenancies)
        {
            builder.Init(revenueAccounts);
            builder.SetName();
            builder.SetTenancyPremises(tenancyPremises);
            builder.SetRevenueAccountType(revenueAccountTypes);
            builder.SetStartDate(tenancies);
            builder.SetEndDate();
            builder.SetGrossRent();
            builder.SetHbClaimNumber();
            builder.SetLastAccountBalance();
            builder.SetBalanceDate();
            builder.SetFrequency(frequencies);
            builder.AddSourceApplication();
            builder.AddSourceKey();
            return builder.BuiltRevenueAccount;
        }
    }
}