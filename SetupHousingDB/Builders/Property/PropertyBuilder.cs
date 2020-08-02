using System;
using System.Collections.Generic;
using System.Linq;
using HousingContext;
using SetupHousingDB.Builders.Address;

namespace SetupHousingDB.Builders.Property
{
    public interface IPropertyBuilder
    {
        void Init(List<HousingContext.Property> properties);
        void SetPropertyType(List<PropertyType> propertyTypes);
        void SetPropertySubType(List<PropertySubType> propertySubTypes);
        void SetLeaseType(List<LeaseType> leaseTypes);
        void SetParent(HousingContext.Property property);
        void SetName();
        void SetPostalAddress(List<HousingContext.Address> addresses,
            List<AssociatedAddress> associatedAddresses, List<AddressType> addressTypes);

        IAddressBuilder GetAddressBuilder(List<HousingContext.Address> addresses, List<AssociatedAddress> associatedAddresses);

        HousingContext.Property Property { get; }
        int IdSeed { get; }
    }

    public abstract class PropertyBuilder : IPropertyBuilder
    {
        //protected List<PropertyType> PropertyTypeList;
        //protected List<PropertySubType> PropertySubTypeList;
        //protected List<HousingContext.Address> AddressList;
        //protected List<AssociatedAddress> AssociatedAddressList;
        protected IAddressDirector AddressDirector;
        protected HousingContext.Property BuiltProperty;
        public HousingContext.Property Property => BuiltProperty;
        public int IdSeed => 100000;
        protected Random Random;

        protected PropertyBuilder()
        {
            AddressDirector = new AddressDirector();
            Random = new Random();
        }

        public abstract IAddressBuilder GetAddressBuilder(List<HousingContext.Address> addresses, List<AssociatedAddress> associatedAddresses);

        public void Init(List<HousingContext.Property> properties)
        {
            BuiltProperty = new HousingContext.Property()
            {
                Id = properties.Count < 1 ? IdSeed : (from p in properties select p.Id).Max() + 1
            };
        }

        public abstract void SetPropertyType(List<PropertyType> propertyTypes);
     
        public bool GenerateAOneInXChance(int x)
        {
            var i = Random.Next(1, x);
            return i % x == 0;
        }

        public abstract void SetPropertySubType(List<PropertySubType> propertySubTypes);
        public abstract void SetLeaseType(List<LeaseType> leaseTypes);
        public void SetParent(HousingContext.Property property)
        {
            BuiltProperty.ParentId = property;
        }

        public void SetName()
        {
            BuiltProperty.Name = $@"{BuiltProperty.PropertyTypeId.Name}-{BuiltProperty.Id.ToString()}";
        }

        public void SetPostalAddress(List<HousingContext.Address> addresses, List<AssociatedAddress> associatedAddresses, List<AddressType> addressTypes)
        {
            var address = AddressDirector.Build(GetAddressBuilder(addresses,associatedAddresses), BuiltProperty, addresses);
            addresses.Add(address);
            associatedAddresses.Add(new AssociatedAddress()
            {
                Id = associatedAddresses.Count < 1 ? IdSeed : (from p in associatedAddresses select p.Id).Max() + 1,
                AddressId = address,
                PropertyAddressTypeId = addressTypes.First(x => x.Name == "Postal"),
                PropertyId = BuiltProperty
            });
        }
    }

    public class EstatePropertyBuilder : PropertyBuilder
    {
        public override void SetPropertyType(List<PropertyType> propertyTypes)
        {
            BuiltProperty.PropertyTypeId = propertyTypes.First(x => x.Name == "EST");
        }

        public override void SetPropertySubType(List<PropertySubType> propertySubTypes)
        {
        }

        public override void SetLeaseType(List<LeaseType> leaseTypes)
        {
        }

        public override IAddressBuilder GetAddressBuilder(List<HousingContext.Address> addresses,
            List<AssociatedAddress> associatedAddresses)
        {
            return new EstateAddressBuilder(addresses, associatedAddresses);
        }

    }

    public class BlockPropertyBuilder : PropertyBuilder
    {
        public override void SetPropertyType(List<PropertyType> propertyTypes)
        {
            BuiltProperty.PropertyTypeId = propertyTypes.First(x => x.Name == "BLK");
        }

        public override void SetPropertySubType(List<PropertySubType> propertySubTypes)
        {
        }

        public override void SetLeaseType(List<LeaseType> leaseTypes)
        {
        }

        public override IAddressBuilder GetAddressBuilder(List<HousingContext.Address> addresses,
            List<AssociatedAddress> associatedAddresses)
        {
            return new BlockAddressBuilder(addresses, associatedAddresses);
        }
    }

    public class FlatPropertyBuilder : PropertyBuilder
    {
        public override void SetPropertyType(List<PropertyType> propertyTypes)
        {
            BuiltProperty.PropertyTypeId = propertyTypes.First(x => x.Name == "FLT");
        }

        public override void SetPropertySubType(List<PropertySubType> propertySubTypes)
        {
            var types = new[] {"BASE", "GROUD", "INT", "TOP"};
            var st = (from p in propertySubTypes where types.Contains(p.Name) select p).ToList();
            BuiltProperty.PropertySubTypeId = st[Random.Next(0,st.Count -1)];
        }

        public override void SetLeaseType(List<LeaseType> leaseTypes)
        {
            var useOther = GenerateAOneInXChance(100);
            if (useOther)
            {
                var leaseList = leaseTypes.Where(x => x.Name != "SOWHSE" && x.Name != "SOWFLT").ToList();
                BuiltProperty.LeaseTypeId = leaseList[Random.Next(0,leaseList.Count -1)];
            }
            else
            {
                BuiltProperty.LeaseTypeId = leaseTypes.First(x => x.Name == "SOWFLT");
            }
        }

        public override IAddressBuilder GetAddressBuilder(List<HousingContext.Address> addresses,
            List<AssociatedAddress> associatedAddresses)
        {
            return new FlatAddressBuilder(addresses, associatedAddresses);
        }
    }

    public class HousePropertyBuilder : PropertyBuilder
    {
        public override void SetPropertyType(List<PropertyType> propertyTypes)
        {
            BuiltProperty.PropertyTypeId = propertyTypes.First(x => x.Name == "HSE");
        }

        public override void SetPropertySubType(List<PropertySubType> propertySubTypes)
        {
            var types = new[] {"DET", "SEMI", "TERR", "TREND", "TRMID"};
            var st = (from p in propertySubTypes where types.Contains(p.Name) select p).ToList();
            BuiltProperty.PropertySubTypeId = st[Random.Next(0,st.Count -1)];
        }

        public override void SetLeaseType(List<LeaseType> leaseTypes)
        {
            var useOther = GenerateAOneInXChance(100);
            if (useOther)
            {
                var leaseList = leaseTypes.Where(x => x.Name != "SOWHSE" && x.Name != "SOWFLT").ToList();
                BuiltProperty.LeaseTypeId = leaseList[Random.Next(0,leaseList.Count -1)];
            }
            else
            {
                BuiltProperty.LeaseTypeId = leaseTypes.First(x => x.Name == "SOWHSE");
            }
        }

        public override IAddressBuilder GetAddressBuilder(List<HousingContext.Address> addresses,
            List<AssociatedAddress> associatedAddresses)
        {
            return new HouseAddressBuilder(addresses, associatedAddresses);
        }
    }

    public interface IPropertyDirector
    {
        HousingContext.Property Build(
            IPropertyBuilder builder,
            List<HousingContext.Property> properties,
            List<PropertyType> propertyTypes,
            List<PropertySubType> propertySubTypes,
            List<LeaseType> leaseTypes,
            List<HousingContext.Address> addresses,
            List<AssociatedAddress> associatedAddresses,
            List<AddressType> addressTypes,
            HousingContext.Property parent);
    }
    
    public class PropertyDirector : IPropertyDirector
    {
        public HousingContext.Property Build(
            IPropertyBuilder builder, 
            List<HousingContext.Property> properties,
            List<PropertyType> propertyTypes,
            List<PropertySubType> propertySubTypes,
            List<LeaseType> leaseTypes,
            List<HousingContext.Address> addresses,
            List<AssociatedAddress> associatedAddresses,
            List<AddressType> addressTypes,
            HousingContext.Property parent)
        {
            builder.Init(properties);
            builder.SetParent(parent);
            builder.SetPropertyType(propertyTypes);
            builder.SetPropertySubType(propertySubTypes);
            builder.SetLeaseType(leaseTypes);
            builder.SetName();
            builder.SetPostalAddress(addresses,associatedAddresses,addressTypes);
            
            return builder.Property;
        }
    }
}