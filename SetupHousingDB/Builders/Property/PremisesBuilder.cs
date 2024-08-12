using System;
using System.Collections.Generic;
using System.Linq;
using HousingContext;

namespace SetupHousingDB.Builders.Property
{
    public interface IPremisesBuilder
    {
        void Init(List<HousingContext.Premises> premisesList);
        void SetPropertyType(List<PropertyType> propertyTypes);
        void SetPropertySubType(List<PropertySubType> propertySubTypes);
        void SetLeaseType(List<LeaseType> leaseTypes);
        
        void SetPropertySource(List<PropertySource> propertySources);
        void SetPropertyStatus(List<PropertyStatus> propertyStatuses);
        void SetParent(HousingContext.Premises parentPremises);
        void SetName();
        void SetPostalAddress(List<HousingContext.Address> addresses, List<AddressType> addressTypes);

        HousingContext.Premises BuiltPremises { get; }
        int IdSeed { get; }
    }

    public abstract class PremisesBuilder : IPremisesBuilder
    {
        //protected List<PropertyType> PropertyTypeList;
        //protected List<PropertySubType> PropertySubTypeList;
        //protected List<HousingContext.Address> AddressList;
        //protected List<AssociatedAddress> AssociatedAddressList;
        public HousingContext.Premises BuiltPremises { get; set; }
        public abstract void SetPostalAddress(List<Address> addresses, List<AddressType> addressTypes);
        public int IdSeed => 100000;
        protected Random Random;

        protected PremisesBuilder()
        {
            Random = new Random();
        }

        // public void Init(List<HousingContext.Premises> properties)
        // {
        //     BuiltPremises = new HousingContext.Premises()
        //     {
        //         Id = properties.Count < 1 ? IdSeed : (from p in properties select p.Id).Max() + 1
        //     };
        // }

        public void Init(List<Premises> premisesList)
        {
            BuiltPremises = new Premises()
            {
                Id = premisesList.Count < 1 ? IdSeed : (from p in premisesList select p.Id).Max() + 1
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
        public virtual void SetPropertySource(List<PropertySource> propertySources)
        {
            BuiltPremises.PropertySourceId = propertySources.First(x => x.Name == "LSE");
        }

        public virtual void SetPropertyStatus(List<PropertyStatus> propertyStatuses)
        {
            BuiltPremises.PropertyStatusId = propertyStatuses.First(x => x.Name == "OCCP");
        }

        public void SetParent(HousingContext.Premises property)
        {
            BuiltPremises.ParentId = property;
        }

        public void SetName()
        {
            BuiltPremises.Name = $@"{BuiltPremises.PropertyTypeId.Name}-{BuiltPremises.Id.ToString()}";
        }
    }

    public class EstatePremisesBuilder : PremisesBuilder
    {
        public override void SetPropertyType(List<PropertyType> propertyTypes)
        {
            BuiltPremises.PropertyTypeId = propertyTypes.First(x => x.Name == "EST");
        }

        public override void SetPropertySubType(List<PropertySubType> propertySubTypes)
        {
            BuiltPremises.PropertySubTypeId = null;
        }

        public override void SetLeaseType(List<LeaseType> leaseTypes)
        {
            BuiltPremises.LeaseTypeId = null;
        }

        public override void SetPostalAddress(List<Address> addresses, List<AddressType> addressTypes)
        {
            throw new NotImplementedException();
        }
    }

    public class BlockPremisesBuilder : EstatePremisesBuilder
    {
        public override void SetPropertyType(List<PropertyType> propertyTypes)
        {
            BuiltPremises.PropertyTypeId = propertyTypes.First(x => x.Name == "BLK");
        }
    }

    public class FlatPremisesBuilder : PremisesBuilder
    {
        public override void SetPropertyType(List<PropertyType> propertyTypes)
        {
            BuiltPremises.PropertyTypeId = propertyTypes.First(x => x.Name == "FLT");
        }

        public override void SetPropertySubType(List<PropertySubType> propertySubTypes)
        {
            var types = new[] {"BASE", "GROUD", "INT", "TOP"};
            var st = (from p in propertySubTypes where types.Contains(p.Name) select p).ToList();
            BuiltPremises.PropertySubTypeId = st[Random.Next(0,st.Count -1)];
        }

        public override void SetLeaseType(List<LeaseType> leaseTypes)
        {
            BuiltPremises.LeaseTypeId = leaseTypes.First(x => x.Name == "FLT");
        }

        public override void SetPostalAddress(List<Address> addresses, List<AddressType> addressTypes)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPropertyDirector
    {
        HousingContext.Premises Build(
            IPremisesBuilder builder,
            List<HousingContext.Premises> properties,
            List<PropertyType> propertyTypes,
            List<PropertySubType> propertySubTypes,
            List<LeaseType> leaseTypes,
            List<HousingContext.Address> addresses,
            List<AddressType> addressTypes,
            HousingContext.Premises parent);
    }
    
    public class PropertyDirector : IPropertyDirector
    {
        public HousingContext.Premises Build(
            IPremisesBuilder builder, 
            List<HousingContext.Premises> properties,
            List<PropertyType> propertyTypes,
            List<PropertySubType> propertySubTypes,
            List<LeaseType> leaseTypes,
            List<HousingContext.Address> addresses,
            List<AddressType> addressTypes,
            HousingContext.Premises parent)
        {
            builder.Init(properties);
            builder.SetParent(parent);
            builder.SetPropertyType(propertyTypes);
            builder.SetPropertySubType(propertySubTypes);
            builder.SetLeaseType(leaseTypes);
            builder.SetPostalAddress(addresses, addressTypes);
            
            return builder.BuiltPremises;
        }
    }
}