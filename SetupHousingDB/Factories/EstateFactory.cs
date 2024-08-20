using System;
using System.Collections.Generic;
using System.Linq;
using HousingContext;
using SetupHousingDB.Builders.Address;
using SetupHousingDB.Builders.Property;

namespace SetupHousingDB.Factories
{
    public class EstateFactory
    {
        protected Random Random = new Random();
        private readonly Program.HousingContextDataService _housingContextDataService;
        private readonly AddressDirector _addressDirector = new AddressDirector();
        private readonly PremisesDirector _premisesDirector = new PremisesDirector();
        private readonly PremisesAddressDirector _premisesAddressDirector = new PremisesAddressDirector();

        public EstateFactory(Program.HousingContextDataService housingContextDataService, int numberOfBlocks = 3, int numberOfPropertiesPerBlock = 20)
        {
            _housingContextDataService = housingContextDataService;
        }
        
        public void BuildEstate(int numberOfBlocks = 3, int numberOfPropertiesPerBlock = 20)
        {
            // var estateAddressBuilder = new EstateAddressBuilder(_housingContextDataService.AddressList);
            // var estateAddress = _addressDirector.Build(estateAddressBuilder, null, _housingContextDataService.AddressList);
            // _housingContextDataService.AddressList.Add(estateAddress);

            var premisesAddressBuilder = new PremisesAddressBuilder();
            var estatePremisesBuilder = new EstatePremisesBuilder();
            var estatePremises = _premisesDirector.Build(estatePremisesBuilder,
                _housingContextDataService.PremisesList,
                _housingContextDataService.PremisesTypeList,
                _housingContextDataService.PropertyTypeList,
                _housingContextDataService.PropertySubTypeList,
                _housingContextDataService.LeaseTypeList,
                _housingContextDataService.AddressList,
                _housingContextDataService.AddressTypeList,
                null);
            _housingContextDataService.PremisesList.Add(estatePremises);

            var blockAddressBuilder = new BlockAddressBuilder(_housingContextDataService.AddressList);
            for(var i = 0; i < numberOfBlocks; i++)
            {
                var blockAddress = _addressDirector.Build(blockAddressBuilder, null, _housingContextDataService.AddressList);
                _housingContextDataService.AddressList.Add(blockAddress);
                var blockPremisesBuilder = new BlockPremisesBuilder();
                var blockPremises = _premisesDirector.Build(blockPremisesBuilder,
                    _housingContextDataService.PremisesList,
                    _housingContextDataService.PremisesTypeList,
                    _housingContextDataService.PropertyTypeList,
                    _housingContextDataService.PropertySubTypeList,
                    _housingContextDataService.LeaseTypeList,
                    _housingContextDataService.AddressList,
                    _housingContextDataService.AddressTypeList,
                    estatePremises);
                _housingContextDataService.PremisesList.Add(blockPremises);
                var blockPremisesAddress = _premisesAddressDirector.Build(premisesAddressBuilder, _housingContextDataService.PremisesAddressList, _housingContextDataService.AddressTypeList, blockAddress, blockPremises);
                _housingContextDataService.PremisesAddressList.Add(blockPremisesAddress);
                
            }
            
            var blockType = _housingContextDataService.PremisesTypeList.First(x => x.Name == "BLK");

            var blockIds = _housingContextDataService.PremisesList.Where(x => x.PremisesTypeId?.Id == blockType.Id)
                .Select(y => y.Id).ToList();
            
            foreach(var blockId in blockIds)
            {
                var block = _housingContextDataService.PremisesList.First(x => x.Id == blockId);
                for(var i = 0; i < numberOfPropertiesPerBlock; i++)
                {
                    var flatAddressBuilder = new FlatAddressBuilder(_housingContextDataService.AddressList);
                    var blockPremisesAddress = _housingContextDataService.PremisesAddressList.First(x => x.PremisesId.Id == block.Id);
                    var blockAddress = _housingContextDataService.AddressList.First(x => x.Id == blockPremisesAddress.AddressId.Id);
                    var flatAddress = _addressDirector.Build(flatAddressBuilder, blockAddress, _housingContextDataService.AddressList);
                    _housingContextDataService.AddressList.Add(flatAddress);
                    var flatPremisesBuilder = new FlatPremisesBuilder();
                    var flatPremises = _premisesDirector.Build(flatPremisesBuilder,
                        _housingContextDataService.PremisesList,
                        _housingContextDataService.PremisesTypeList,
                        _housingContextDataService.PropertyTypeList,
                        _housingContextDataService.PropertySubTypeList,
                        _housingContextDataService.LeaseTypeList,
                        _housingContextDataService.AddressList,
                        _housingContextDataService.AddressTypeList,
                        block);
                    _housingContextDataService.PremisesList.Add(flatPremises);
                    var flatPremisesAddress = _premisesAddressDirector.Build(premisesAddressBuilder, _housingContextDataService.PremisesAddressList, _housingContextDataService.AddressTypeList, flatAddress, flatPremises);
                    _housingContextDataService.PremisesAddressList.Add(flatPremisesAddress);
                }
            }
           
        }
        
        public void BuildBlock(Premises estate, HousingContext.Address estateAddress)
        {
            
        }
        
        public static bool IsChance(int val, int oneIn)
        {
            return val % oneIn == 0;
        }
        
    }
}