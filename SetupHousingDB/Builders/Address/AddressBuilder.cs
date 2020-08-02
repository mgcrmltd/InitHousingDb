using System;
using System.Collections.Generic;
using System.Linq;
using HousingContext;
using SetupHousingDB.Builders.Address;

namespace SetupHousingDB.Builders.Address
{
    public interface IAddressBuilder
    {
        public void Init();
        public void AddBuildingName();
        public void AddFlatNumber();
        public void AddStreet(HousingContext.Property property);
        public void AddStreetNumber();
        public void AddArea(HousingContext.Property property);
        public void AddCity(HousingContext.Property property);
        public void AddPostCode(HousingContext.Property property);
        public void AddComposite(HousingContext.Property property);
        public HousingContext.Address Address { get; }
    };
    
    public abstract class AddressBuilder : IAddressBuilder
    {
        protected List<HousingContext.Address> AddressList;
        protected List<AssociatedAddress> AssociatedAddressList;
        protected Random Random;
        protected AddressBuilder(List<HousingContext.Address> addresses, List<AssociatedAddress> associatedAddresses)
        {
            AddressList = addresses;
            AssociatedAddressList = associatedAddresses;
            Random = new Random();
        }

        
        public static bool IsChance(int val, int oneIn)
        {
            return val % oneIn == 0;
        }

        public void Init()
        {
            BuiltAddress = new HousingContext.Address();
        }

        public abstract void AddBuildingName();

        public abstract void AddFlatNumber();
        public abstract void AddStreet(HousingContext.Property property);
        public abstract void AddStreetNumber();
        public abstract void AddArea(HousingContext.Property property);
        public abstract void AddCity(HousingContext.Property property);
        public abstract void AddPostCode(HousingContext.Property property);
        public abstract void AddComposite(HousingContext.Property property);

        protected HousingContext.Address BuiltAddress;
        public HousingContext.Address Address => BuiltAddress;
    }

    public class EstateAddressBuilder : AddressBuilder
    {
        public EstateAddressBuilder(List<HousingContext.Address> addresses, List<AssociatedAddress> associatedAddresses) : base(addresses, associatedAddresses)
        {
        }

        public override void AddBuildingName()
        {
            BuiltAddress.BuildingName = Faker.Name.Last() + " Estate";
        }

        public override void AddFlatNumber()
        {
        }

        public override void AddStreet(HousingContext.Property property)
        {
            BuiltAddress.Street = Faker.Address.StreetName();
        }

        public override void AddStreetNumber()
        {

        }

        public override void AddArea(HousingContext.Property property)
        {
            BuiltAddress.Area = IsChance(Random.Next(1, 20), 20) ? Faker.Address.StreetName() : null;
        }

        public override void AddCity(HousingContext.Property property)
        {
            BuiltAddress.City = Faker.Address.City();
        }

        public override void AddPostCode(HousingContext.Property property)
        {
            BuiltAddress.PostCode = Faker.Address.UkPostCode();

        }

        public override void AddComposite(HousingContext.Property property)
        {
            BuiltAddress.Composite = $"{BuiltAddress.BuildingName}";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(BuiltAddress.Street) ? $"\n{BuiltAddress.StreetNumber} {BuiltAddress.Street}" : "";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(BuiltAddress.Area) ? $"\n{BuiltAddress.Area}" : "";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(BuiltAddress.City) ? $"\n{BuiltAddress.City}" : "";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(BuiltAddress.County) ? $"\n{BuiltAddress.County}" : "";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(BuiltAddress.PostCode) ? $"\n{BuiltAddress.PostCode}" : "";
        }
    }

    public class BlockAddressBuilder : AddressBuilder
    {
        public BlockAddressBuilder(List<HousingContext.Address> addresses, List<AssociatedAddress> associatedAddresses) : base(addresses, associatedAddresses)
        {
            
        }

        public override void AddBuildingName()
        {
            BuiltAddress.BuildingName = Faker.Address.UkCounty() + " Court";
        }

        public override void AddFlatNumber()
        {
        }

        public override void AddStreet(HousingContext.Property property)
        {
            var estateAddress = AssociatedAddressList.First(x => x.PropertyId == property.ParentId).AddressId;
            BuiltAddress.Street = estateAddress.Street;
        }

        public override void AddStreetNumber()
        {
        }

        public override void AddArea(HousingContext.Property property)
        {
            var estateAddress = AssociatedAddressList.First(x => x.PropertyId == property.ParentId).AddressId;
            BuiltAddress.Area = estateAddress.Area;
        }

        public override void AddCity(HousingContext.Property property)
        {
            var estateAddress = AssociatedAddressList.First(x => x.PropertyId == property.ParentId).AddressId;
            BuiltAddress.City = estateAddress.City;
        }

        public override void AddPostCode(HousingContext.Property property)
        {
            var estateAddress = AssociatedAddressList.First(x => x.PropertyId == property.ParentId).AddressId;
            BuiltAddress.PostCode = estateAddress.PostCode;
        }

        public override void AddComposite(HousingContext.Property property)
        {
            var estateAddress = AssociatedAddressList.First(x => x.PropertyId == property.ParentId).AddressId;
            BuiltAddress.Composite = $"{BuiltAddress.BuildingName}";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(estateAddress.Street) ? $"\n{estateAddress.StreetNumber} {estateAddress.Street}" : "";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(estateAddress.Area) ? $"\n{estateAddress.Area}" : "";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(estateAddress.City) ? $"\n{estateAddress.City}" : "";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(estateAddress.County) ? $"\n{estateAddress.County}" : "";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(estateAddress.PostCode) ? $"\n{estateAddress.PostCode}" : "";
        }
    }

    public class FlatAddressBuilder : BlockAddressBuilder
    {
        protected HousingContext.Address BlockAddress;
        public FlatAddressBuilder(List<HousingContext.Address> addresses, List<AssociatedAddress> associatedAddresses) : base(addresses, associatedAddresses)
        {
        }

        public override void AddBuildingName()
        {
            //Do nothing
        }

        public override void AddFlatNumber()
        {
            BuiltAddress.FlatNumber = Faker.Address.SecondaryAddress();
        }

        public override void AddComposite(HousingContext.Property property)
        {
           base.AddComposite(property);
           BuiltAddress.Composite = $"{BuiltAddress.FlatNumber} {BuiltAddress.Composite}";
        }
    }

    public class HouseAddressBuilder : AddressBuilder
    {
        public HouseAddressBuilder(List<HousingContext.Address> addresses, List<AssociatedAddress> associatedAddresses) : base(addresses, associatedAddresses)
        {
        }

        public override void AddBuildingName()
        {
        }

        public override void AddFlatNumber()
        {
        }

        public override void AddStreet(HousingContext.Property property)
        {
            BuiltAddress.Street = Faker.Address.StreetName();
        }

        public override void AddStreetNumber()
        {
            BuiltAddress.StreetNumber = Faker.RandomNumber.Next(1, 200).ToString();
        }

        public override void AddArea(HousingContext.Property property)
        {
            BuiltAddress.Area = IsChance(Random.Next(1, 20), 20) ? Faker.Address.StreetName() : null;
        }

        public override void AddCity(HousingContext.Property property)
        {
            BuiltAddress.City = Faker.Address.City();
        }

        public override void AddPostCode(HousingContext.Property property)
        {
            BuiltAddress.PostCode = Faker.Address.UkPostCode();

        }

        public override void AddComposite(HousingContext.Property property)
        {
            throw new NotImplementedException();
        }
    }

    public class NonPropertyAddressBuilder : AddressBuilder
    {
        public NonPropertyAddressBuilder(List<HousingContext.Address> addresses, List<AssociatedAddress> associatedAddresses) : base(addresses, associatedAddresses)
        {
        }

        public override void AddBuildingName()
        {
            if (!RandomHelper.GenerateAOneInXChance(200)) return;
            
            BuiltAddress.BuildingName = Faker.Name.Last() + " Estate";
        }

        public override void AddFlatNumber()
        {
        }

        public override void AddStreet(HousingContext.Property property)
        {
            BuiltAddress.Street = Faker.Address.StreetName();
        }

        public override void AddStreetNumber()
        {
            BuiltAddress.StreetNumber = Faker.RandomNumber.Next(1, 300).ToString();
        }

        public override void AddArea(HousingContext.Property property)
        {
            if (!RandomHelper.GenerateAOneInXChance(200)) return;
            BuiltAddress.Area = Faker.Address.StreetName();
        }

        public override void AddCity(HousingContext.Property property)
        {
            BuiltAddress.City = Faker.Address.City();
        }

        public override void AddPostCode(HousingContext.Property property)
        {
            BuiltAddress.PostCode = Faker.Address.UkPostCode();
        }

        public override void AddComposite(HousingContext.Property property)
        {
            BuiltAddress.Composite = $"{BuiltAddress.BuildingName}";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(BuiltAddress.Street) ? $"\n{BuiltAddress.StreetNumber} {BuiltAddress.Street}" : "";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(BuiltAddress.Area) ? $"\n{BuiltAddress.Area}" : "";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(BuiltAddress.City) ? $"\n{BuiltAddress.City}" : "";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(BuiltAddress.County) ? $"\n{BuiltAddress.County}" : "";
            BuiltAddress.Composite +=
                !string.IsNullOrEmpty(BuiltAddress.PostCode) ? $"\n{BuiltAddress.PostCode}" : "";
        }
    }

    public interface IAddressDirector
    {
        HousingContext.Address Build(IAddressBuilder builder, HousingContext.Property property);
    }

    public class AddressDirector : IAddressDirector
    {
        public HousingContext.Address Build(
            IAddressBuilder builder, HousingContext.Property property)
        {
            builder.Init();
            builder.AddBuildingName();
            builder.AddStreetNumber();
            builder.AddStreet(property);
            builder.AddFlatNumber();
            builder.AddArea(property);
            builder.AddCity(property);
            builder.AddPostCode(property);
            builder.AddCity(property);
            builder.AddComposite(property);

            return builder.Address;
        }
    }
}