using System;
using System.Linq;
using HousingContext;
using SetupHousingDB.Builders.Property;

namespace SetupHousingDB.Factories
{
    public class PremisesGroupsFactory
    {
        protected Random Random = new Random();
        private readonly Program.HousingContextDataService _housingContextDataService;
        
        private readonly IPremisesPremisesGroupDirector _premisesPremisesGroupsDirector = new PremisesPremisesGroupDirector();
        private readonly PremisesPremisesGroupBuilder _premisesPremisesGroupBuilder = new PremisesPremisesGroupBuilder();
        private readonly IPremisesGroupDirector _premisesGroupsDirector = new PremisesGroupDirector();
        private readonly AreaHousingManagerPremisesGroupBuilder _areaHousingManagerPremisesGroupBuilder = new AreaHousingManagerPremisesGroupBuilder();
        private readonly RegionalHousingManagerPremisesGroupBuilder _regionalHousingManagerPremisesGroupBuilder = new RegionalHousingManagerPremisesGroupBuilder();
        private readonly NeighbourhoodManagerPremisesGroupBuilder _neighbourhoodManagerPremisesGroupBuilder = new NeighbourhoodManagerPremisesGroupBuilder();
        private readonly LocalAuthorityPremisesGroupBuilder _localAuthorityPremisesGroupBuilder = new LocalAuthorityPremisesGroupBuilder();
        private readonly PatchOfficerPremisesGroupBuilder _patchOfficerPremisesGroupBuilder = new PatchOfficerPremisesGroupBuilder();
        private readonly OmPremisesGroupBuilder _omPremisesGroupBuilder = new OmPremisesGroupBuilder();

        public PremisesGroupsFactory(Program.HousingContextDataService housingContextDataService)
        {
            _housingContextDataService = housingContextDataService;
        }

        public void BuildPremisesGroups(Premises estate)
        {
            /*
             * Build Premises Groups
             * 
             * Build Branch group for estate and blocks
             * Build RHM group
             * Build AHM group
             * For each PR
             *     Build a TEN
             *     Build a WAR
             *     Build a LA
             *     Build a PAT
            */
           
            var branchGroup = _premisesGroupsDirector.Build(_omPremisesGroupBuilder, _housingContextDataService.PremisesGroupList, 
                _housingContextDataService.PremisesGroupTypeList, null);
            _housingContextDataService.PremisesGroupList.Add(branchGroup);
            var premPremGroupEstate = _premisesPremisesGroupsDirector.Build(_premisesPremisesGroupBuilder,
                _housingContextDataService.PremisesPremisesGroupList,
                branchGroup, estate);
            _housingContextDataService.PremisesPremisesGroupList.Add(premPremGroupEstate);
            var blocks = _housingContextDataService.PremisesList.Where(x => x.ParentId.Id == estate.Id).ToList();
            foreach (var premPremGroupBlock in blocks.Select(block => _premisesPremisesGroupsDirector.Build(_premisesPremisesGroupBuilder,
                _housingContextDataService.PremisesPremisesGroupList,
                branchGroup, block)))
            {
                _housingContextDataService.PremisesPremisesGroupList.Add(premPremGroupBlock);
            }

            var rhmGroup = _premisesGroupsDirector.Build(_regionalHousingManagerPremisesGroupBuilder, _housingContextDataService.PremisesGroupList, 
                _housingContextDataService.PremisesGroupTypeList, null);
            _housingContextDataService.PremisesGroupList.Add(rhmGroup);

            var ahmGroup = _premisesGroupsDirector.Build(_areaHousingManagerPremisesGroupBuilder, _housingContextDataService.PremisesGroupList, 
                _housingContextDataService.PremisesGroupTypeList, rhmGroup);
            _housingContextDataService.PremisesGroupList.Add(ahmGroup);
            
            var nmGroup = _premisesGroupsDirector.Build(_neighbourhoodManagerPremisesGroupBuilder, _housingContextDataService.PremisesGroupList, 
                _housingContextDataService.PremisesGroupTypeList, ahmGroup);
            _housingContextDataService.PremisesGroupList.Add(nmGroup);
            
            // var premisesGroupsBuilder = new PremisesGroupsBuilder();
            // var premisesGroups = _premisesGroupsDirector.Build(premisesGroupsBuilder,
            //     _housingContextDataService.PremisesList,
            //     _housingContextDataService.PremisesTypeList,
            //     _housingContextDataService.PropertyTypeList,
            //     _housingContextDataService.PropertySubTypeList,
            //     _housingContextDataService.LeaseTypeList,
            //     _housingContextDataService.AddressList,
            //     _housingContextDataService.AddressTypeList,
            //     null);
            // _housingContextDataService.PremisesList.Add(premisesGroups);
        }

    }
}