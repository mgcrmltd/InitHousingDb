using System.Collections.Generic;
using System.Linq;
using HousingContext;
using SetupHousingDB.Builders.Address;

namespace SetupHousingDB.Builders.Property
{
    public interface IPremisesAddressBuilder : ICdmBuilder
    {
        void Init(List<HousingContext.PremisesAddress> premisesAddressList);
        void AddAddress(HousingContext.Address address);
        void AddName(Premises premises);
        void AddPremises(Premises premises);
        void AddAddressType(List<AddressType> addressTypes);
        
        HousingContext.PremisesAddress BuiltPremisesAddress { get; }
        int IdSeed { get; }
    }
    public class PremisesAddressBuilder : IPremisesAddressBuilder
    {
        public PremisesAddress BuiltPremisesAddress { get; set; }
        public int IdSeed => 100000;
        
        public void AddSourceApplication()
        {
            BuiltPremisesAddress.SourceApplication = "Northgate";
        }

        public void AddSourceKey()
        {
            BuiltPremisesAddress.SourceKey = BuiltPremisesAddress.Id.ToString();
        }

        public void Init(List<PremisesAddress> premisesAddressList)
        {
            BuiltPremisesAddress = new PremisesAddress()
            {
                Id = premisesAddressList.Count < 1 ? IdSeed : (from p in premisesAddressList select p.Id).Max() + 1
            };
        }

        public void AddAddress(HousingContext.Address address)
        {
            BuiltPremisesAddress.AddressId = address;
        }

        public void AddName(Premises premises)
        {
            BuiltPremisesAddress.Name = premises.Name;
        }

        public void AddPremises(Premises premises)
        {
            BuiltPremisesAddress.PremisesId = premises;
        }

        public void AddAddressType(List<AddressType> addressTypes)
        {
            BuiltPremisesAddress.AddressTypeId = addressTypes.First(x => x.Name == "PHYSICAL");
        }
        
    }

    public interface IPremisesAddressDirector
    {
    }

    public class PremisesAddressDirector : IPremisesAddressDirector
    {

        public PremisesAddress Build(IPremisesAddressBuilder builder, List<PremisesAddress> premisesAddressList, 
            List<AddressType> addressTypes, HousingContext.Address address, Premises premises)
        {
            builder.Init(premisesAddressList);
            builder.AddAddress(address);
            builder.AddName(premises);
            builder.AddPremises(premises);
            builder.AddAddressType(addressTypes);
            builder.AddSourceApplication();
            builder.AddSourceKey();
            return builder.BuiltPremisesAddress;
        }
    }
}