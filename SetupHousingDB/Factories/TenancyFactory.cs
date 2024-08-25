using System;
using HousingContext;
using SetupHousingDB.Builders.Person;
using SetupHousingDB.Builders.Tenancy;

namespace SetupHousingDB.Factories
{
    public class TenancyFactory
    {
        protected Random Random = new Random();
        private readonly Program.HousingContextDataService _housingContextDataService;
        private readonly TenancyDirector _tenancyDirector = new TenancyDirector();
        private readonly TenancyPremisesDirector _tenancyPremisesDirector = new TenancyPremisesDirector();
        private readonly TenancyOccupantDirector _tenancyOccupantDirector = new TenancyOccupantDirector();
        private readonly RevenueAccountDirector _revenueAccountDirector = new RevenueAccountDirector();
        private readonly PersonDirector _personDirector = new PersonDirector();

        public TenancyFactory(Program.HousingContextDataService housingContextDataService)
        {
            _housingContextDataService = housingContextDataService;
        }

        public void BuildTenancy(Premises premises)
        {
            var personBuilder = new PersonBuilder();
            var mainTenant = _personDirector.Build(personBuilder, _housingContextDataService.PersonList, "~CRMID~");
            _housingContextDataService.PersonList.Add(mainTenant);
            var tenancyBuilder = new TenancyBuilder();
            var tenancy = _tenancyDirector.Build(tenancyBuilder, _housingContextDataService.TenancyList, 
                _housingContextDataService.TenancyTypeList, _housingContextDataService.TenureTypeList);
            _housingContextDataService.TenancyList.Add(tenancy);
            var tenancyPremisesBuilder = new TenancyPremisesBuilder();
            var tenancyPremises = _tenancyPremisesDirector.Build(tenancyPremisesBuilder,
                _housingContextDataService.TenancyPremisesList, tenancy, premises);
            _housingContextDataService.TenancyPremisesList.Add(tenancyPremises);
            var tenancyOccupantBuilder = new TenancyOccupantBuilder();
            var tenancyOccupant = _tenancyOccupantDirector.Build(tenancyOccupantBuilder,
                _housingContextDataService.TenancyOccupantList, mainTenant, tenancy);
            _housingContextDataService.TenancyOccupantList.Add(tenancyOccupant);
            BuildRevenueAccount(tenancyPremises);

            if (RandomHelper.GenerateAOneInXChance(2))
            {
                var tenant2 = _personDirector.Build(personBuilder, _housingContextDataService.PersonList, "~CRMID~");
                _housingContextDataService.PersonList.Add(tenant2);
                var tenancyOccupant2 = _tenancyOccupantDirector.Build(tenancyOccupantBuilder,
                    _housingContextDataService.TenancyOccupantList, tenant2, tenancy);
                _housingContextDataService.TenancyOccupantList.Add(tenancyOccupant2);
            }
        }
        
        public void BuildRevenueAccount(TenancyPremises tenancyPremises)
        {
            var revenueAccountBuilder = new WeeklyRevenueAccountBuilder();
            var revenueAccount = _revenueAccountDirector.Build(revenueAccountBuilder, _housingContextDataService.RevenueAccountList, tenancyPremises, 
                _housingContextDataService.RevenueAccountTypeList, _housingContextDataService.FrequencyList, _housingContextDataService.TenancyList);
            _housingContextDataService.RevenueAccountList.Add(revenueAccount);
        }
    }
}