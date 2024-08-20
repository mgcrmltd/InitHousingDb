using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HousingContext;
using SetupHousingDB.Builders.Address;

namespace SetupHousingDB.Builders.Address
{
    public interface ICdmBuilder
    {
        void AddSourceApplication();
        void AddSourceKey();
    }

    public interface IAddressBuilder : ICdmBuilder
    {
        public void Init(List<HousingContext.Address> addresses);

        public void AddName(HousingContext.Address parentAddress);
        public void AddAddress1(HousingContext.Address parentAddress);
        public void AddAddress2(HousingContext.Address parentAddress);
        public void AddAddress3(HousingContext.Address parentAddress);
        public void AddAddress4(HousingContext.Address parentAddress);
        public void AddAddress5(HousingContext.Address parentAddress);
        
        public void AddPostCode(HousingContext.Address estateInfo);
        public void AddFormattedAddress();

        public HousingContext.Address Address { get; }
        int IdSeed { get; }
    };

    // public class EstateInfo
    // {
    //     public string EstateName { get; set; }
    //     public string PostCode { get; set; }
    //     public int NumberOfBlocks { get; set; }
    //     public int NumberOfPropertiesPerBlock { get; set; }
    // }

    public abstract class AddressBuilder : IAddressBuilder
    {
        protected List<HousingContext.Address> AddressList;
        protected Random Random;
        protected AddressBuilder(List<HousingContext.Address> addresses)
        {
            AddressList = addresses;
            Random = new Random();
        }

        public bool IsChance(int val, int oneIn)
        {
            return val % oneIn == 0;
        }

        public void Init(List<HousingContext.Address> addresses)
        {
            BuiltAddress = new HousingContext.Address()
            {
                Id = (addresses.Count < 1 ? IdSeed : (from p in addresses select p.Id).Max() + 1) + 100000
            };
        }


        public virtual void AddName(HousingContext.Address parentAddress)
        {
            BuiltAddress.Name = IdSeed.ToString();
        }
        public abstract void AddAddress1(HousingContext.Address parentAddress);
        public abstract void AddAddress2(HousingContext.Address parentAddress);
        public abstract void AddAddress3(HousingContext.Address parentAddress);
        public abstract void AddAddress4(HousingContext.Address parentAddress);
        public abstract void AddAddress5(HousingContext.Address parentAddress);
        public abstract void AddPostCode(HousingContext.Address parentAddress);

        public void AddFormattedAddress()
        {
            var formattedAddress = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(BuiltAddress.pea_Address1))
            {
                formattedAddress.AppendLine(BuiltAddress.pea_Address1);
            }
            if (!string.IsNullOrWhiteSpace(BuiltAddress.pea_Address2))
            {
                formattedAddress.AppendLine(BuiltAddress.pea_Address2);
            }
            if (!string.IsNullOrWhiteSpace(BuiltAddress.pea_Address3))
            {
                formattedAddress.AppendLine(BuiltAddress.pea_Address3);
            }
            if (!string.IsNullOrWhiteSpace(BuiltAddress.pea_Address4))
            {
                formattedAddress.AppendLine(BuiltAddress.pea_Address4);
            }
            if (!string.IsNullOrWhiteSpace(BuiltAddress.pea_Address5))
            {
                formattedAddress.AppendLine(BuiltAddress.pea_Address5);
            }
            BuiltAddress.pea_FormattedAddress = formattedAddress.ToString();
        }

        protected HousingContext.Address BuiltAddress;
        public HousingContext.Address Address => BuiltAddress;
        public int IdSeed => 100000;
        public void AddSourceApplication()
        {
            BuiltAddress.SourceApplication = "Northgate";
        }

        public void AddSourceKey()
        {
            BuiltAddress.SourceKey = BuiltAddress.Id.ToString();
        }
    }
    
    public class EstateAddressBuilder : AddressBuilder
    {
        public EstateAddressBuilder(List<HousingContext.Address> addresses) : base(addresses)
        {
        }

        public override void AddAddress1(HousingContext.Address parentAddress)
        {
            BuiltAddress.pea_Address1 = $"{Faker.RandomNumber.Next(1, 100)} {Faker.Address.StreetName()}";
        }

        public override void AddAddress2(HousingContext.Address parentAddress)
        {
            BuiltAddress.pea_Address2 = "London";
        }
        
        public override void AddAddress3(HousingContext.Address parentAddress)
        {
            BuiltAddress.pea_Address3 = IsChance(Random.Next(1, 20), 20) ? "London" : null;
        }
        
        public override void AddAddress4(HousingContext.Address parentAddress)
        {
            throw new NotImplementedException();
        }
        
        public override void AddAddress5(HousingContext.Address parentAddress)
        {
            throw new NotImplementedException();
        }

        public override void AddPostCode(HousingContext.Address parentAddress)
        {
            BuiltAddress.pea_PostCode = parentAddress.pea_PostCode;
        }
    }

    
    public class BlockAddressBuilder : AddressBuilder
    {
        public BlockAddressBuilder(List<HousingContext.Address> addresses) : base(addresses)
        {
        }

        public override void AddAddress1(HousingContext.Address parentAddress)
        {
            var bName = IsChance(Random.Next(1, 20), 20) ? "House" : "Mansions";
            BuiltAddress.pea_Address1 = $"{Faker.Name.Last()} {bName}";
        }

        public override void AddAddress2(HousingContext.Address parentAddress)
        {
            BuiltAddress.pea_Address2 = $"{Faker.RandomNumber.Next(1, 100)} {Faker.Address.StreetName()}";
        }
        
        public override void AddAddress3(HousingContext.Address parentAddress)
        {
            BuiltAddress.pea_Address3 =  IsChance(Random.Next(1, 20), 20) ? "Mitcham" : "London";
        }
        
        public override void AddAddress4(HousingContext.Address parentAddress)
        {
            BuiltAddress.pea_Address4 = IsChance(Random.Next(1, 20), 20) ? BuiltAddress.pea_Address2  : null;
        }
        
        public override void AddAddress5(HousingContext.Address parentAddress)
        {
            
        }

        public override void AddPostCode(HousingContext.Address parentAddress)
        {
            BuiltAddress.pea_PostCode = Faker.Address.UkPostCode();
        }
    }
    
   
    public class FlatAddressBuilder : AddressBuilder
    {
        public FlatAddressBuilder(List<HousingContext.Address> addresses) : base(addresses)
        {
        }
        
        private string GetLine1AfterFLatNumber(HousingContext.Address parentAddress)
        {
            return $"Flat {Faker.RandomNumber.Next(1,100)}, {parentAddress.pea_Address1}";
        }

        public override void AddAddress1(HousingContext.Address parentAddress)
        {
            BuiltAddress.pea_Address1 =  $"Flat {Faker.RandomNumber.Next(1,100)}, {parentAddress.pea_Address1}";
        }

        public override void AddAddress2(HousingContext.Address parentAddress)
        {
            BuiltAddress.pea_Address2 = parentAddress.pea_Address2;
        }

        public override void AddAddress3(HousingContext.Address parentAddress)
        {
            BuiltAddress.pea_Address3 = parentAddress.pea_Address3;
        }

        public override void AddAddress4(HousingContext.Address parentAddress)
        {
            BuiltAddress.pea_Address4 = parentAddress.pea_Address4;
        }

        public override void AddAddress5(HousingContext.Address parentAddress)
        {
            BuiltAddress.pea_Address5 = parentAddress.pea_Address5;
        }

        public override void AddPostCode(HousingContext.Address parentAddress)
        {
            BuiltAddress.pea_PostCode = parentAddress.pea_PostCode;
        }
    }

    // public class HouseAddressBuilder : AddressBuilder
    // {
    //     public HouseAddressBuilder(List<HousingContext.Address> addresses, List<AssociatedAddress> associatedAddresses) : base(addresses, associatedAddresses)
    //     {
    //     }
    //
    //     public override void AddBuildingName()
    //     {
    //     }
    //
    //     public override void AddFlatNumber()
    //     {
    //     }
    //
    //     public override void AddStreet(HousingContext.Property property)
    //     {
    //         BuiltAddress.Street = Faker.Address.StreetName();
    //     }
    //
    //     public override void AddStreetNumber()
    //     {
    //         BuiltAddress.StreetNumber = Faker.RandomNumber.Next(1, 200).ToString();
    //     }
    //
    //     public override void AddArea(HousingContext.Property property)
    //     {
    //         BuiltAddress.Area = IsChance(Random.Next(1, 20), 20) ? Faker.Address.StreetName() : null;
    //     }
    //
    //     public override void AddCity(HousingContext.Property property)
    //     {
    //         BuiltAddress.City = Faker.Address.City();
    //     }
    //
    //     public override void AddPostCode(HousingContext.Property property)
    //     {
    //         BuiltAddress.PostCode = Faker.Address.UkPostCode();
    //
    //     }
    //
    //     public override void AddComposite(HousingContext.Property property)
    //     {
    //         BuiltAddress.Composite =
    //             !string.IsNullOrEmpty(BuiltAddress.Street) ? $"{BuiltAddress.StreetNumber} {BuiltAddress.Street}" : "";
    //         BuiltAddress.Composite +=
    //             !string.IsNullOrEmpty(BuiltAddress.Area) ? $"\n{BuiltAddress.Area}" : "";
    //         BuiltAddress.Composite +=
    //             !string.IsNullOrEmpty(BuiltAddress.City) ? $"\n{BuiltAddress.City}" : "";
    //         BuiltAddress.Composite +=
    //             !string.IsNullOrEmpty(BuiltAddress.County) ? $"\n{BuiltAddress.County}" : "";
    //         BuiltAddress.Composite +=
    //             !string.IsNullOrEmpty(BuiltAddress.PostCode) ? $"\n{BuiltAddress.PostCode}" : "";
    //     }
    // }
    //
    // public class NonPropertyAddressBuilder : AddressBuilder
    // {
    //     public NonPropertyAddressBuilder(List<HousingContext.Address> addresses, List<AssociatedAddress> associatedAddresses) : base(addresses, associatedAddresses)
    //     {
    //     }
    //
    //     public override void AddBuildingName()
    //     {
    //         if (!RandomHelper.GenerateAOneInXChance(200)) return;
    //         
    //         BuiltAddress.BuildingName = Faker.Name.Last() + " ESTATE";
    //     }
    //
    //     public override void AddFlatNumber()
    //     {
    //     }
    //
    //     public override void AddStreet(HousingContext.Property property)
    //     {
    //         BuiltAddress.Street = Faker.Address.StreetName();
    //     }
    //
    //     public override void AddStreetNumber()
    //     {
    //         BuiltAddress.StreetNumber = Faker.RandomNumber.Next(1, 300).ToString();
    //     }
    //
    //     public override void AddArea(HousingContext.Property property)
    //     {
    //         if (!RandomHelper.GenerateAOneInXChance(200)) return;
    //         BuiltAddress.Area = Faker.Address.StreetName();
    //     }
    //
    //     public override void AddCity(HousingContext.Property property)
    //     {
    //         BuiltAddress.City = Faker.Address.City();
    //     }
    //
    //     public override void AddPostCode(HousingContext.Property property)
    //     {
    //         BuiltAddress.PostCode = Faker.Address.UkPostCode();
    //     }
    //
    //     public override void AddComposite(HousingContext.Property property)
    //     {
    //         BuiltAddress.Composite = $"{BuiltAddress.BuildingName}";
    //         BuiltAddress.Composite +=
    //             !string.IsNullOrEmpty(BuiltAddress.Street) ? $"\n{BuiltAddress.StreetNumber} {BuiltAddress.Street}" : "";
    //         BuiltAddress.Composite +=
    //             !string.IsNullOrEmpty(BuiltAddress.Area) ? $"\n{BuiltAddress.Area}" : "";
    //         BuiltAddress.Composite +=
    //             !string.IsNullOrEmpty(BuiltAddress.City) ? $"\n{BuiltAddress.City}" : "";
    //         BuiltAddress.Composite +=
    //             !string.IsNullOrEmpty(BuiltAddress.County) ? $"\n{BuiltAddress.County}" : "";
    //         BuiltAddress.Composite +=
    //             !string.IsNullOrEmpty(BuiltAddress.PostCode) ? $"\n{BuiltAddress.PostCode}" : "";
    //     }
    // }

    public interface IAddressDirector
    {
        HousingContext.Address Build(IAddressBuilder builder, HousingContext.Address parent, List<HousingContext.Address> addresses);
    }

    public class AddressDirector : IAddressDirector
    {
        public HousingContext.Address Build(
            IAddressBuilder builder, HousingContext.Address parentAddress, List<HousingContext.Address> addresses)
        {
            builder.Init(addresses);
            builder.AddName(parentAddress);
            builder.AddAddress1(parentAddress);
            builder.AddAddress2(parentAddress);
            builder.AddAddress3(parentAddress);
            builder.AddAddress4(parentAddress);
            builder.AddAddress5(parentAddress);
            builder.AddPostCode(parentAddress);
            builder.AddFormattedAddress();
            builder.AddSourceApplication();
            builder.AddSourceKey();

            return builder.Address;
        }
    }
}