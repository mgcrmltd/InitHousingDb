using System;
using System.Collections.Generic;
using System.Linq;
using HousingContext;
using SetupHousingDB.Builders.Address;

namespace SetupHousingDB.Builders.Property
{
    public interface IPremisesBuilder
    {
        void Init(List<HousingContext.Premises> premisesList);
        void SetPremisesType(List<PremisesType> premisesTypes);
        void SetPropertyType(List<PropertyType> propertyTypes);
        void SetPropertySubType(List<PropertySubType> propertySubTypes);
        void SetLeaseType(List<LeaseType> leaseTypes);

        void SetPropertySource(List<PropertySource> propertySources);
        void SetPropertyStatus(List<PropertyStatus> propertyStatuses);
        void SetParent(HousingContext.Premises parentPremises);
        void SetName();

        void AddSourceApplication();
        void AddSourceKey();

        HousingContext.Premises BuiltPremises { get; set; }
        int IdSeed { get; }
    }

    public abstract class PremisesBuilder : IPremisesBuilder, ICdmBuilder
    {
        public HousingContext.Premises BuiltPremises { get; set; }
        public int IdSeed => 100000;
        protected Random Random;

        protected PremisesBuilder()
        {
            Random = new Random();
        }

        public void Init(List<Premises> premisesList)
        {
            BuiltPremises = new Premises()
            {
                Id = premisesList.Count < 1 ? IdSeed : (from p in premisesList select p.Id).Max() + 1
            };
        }

        public abstract void SetPremisesType(List<PremisesType> premisesTypes);

        public abstract void SetPropertyType(List<PropertyType> propertyTypes);

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
            BuiltPremises.Name = $@"{BuiltPremises.PremisesTypeId.Name}-{BuiltPremises.Id.ToString()}";
        }

        public void AddSourceApplication()
        {
            BuiltPremises.SourceApplication = "Northgate";
        }

        public void AddSourceKey()
        {
            BuiltPremises.SourceKey = BuiltPremises.Id.ToString();
        }
    }

    public class EstatePremisesBuilder : PremisesBuilder
    {
        public override void SetPremisesType(List<PremisesType> premisesTypes)
        {
            BuiltPremises.PremisesTypeId = premisesTypes.First(x => x.Name == "EST");
        }

        public override void SetPropertyType(List<PropertyType> propertyTypes)
        {
            BuiltPremises.PropertyTypeId = null;
        }

        public override void SetPropertySubType(List<PropertySubType> propertySubTypes)
        {
            BuiltPremises.PropertySubTypeId = null;
        }

        public override void SetLeaseType(List<LeaseType> leaseTypes)
        {
            BuiltPremises.LeaseTypeId = null;
        }
    }

    public class BlockPremisesBuilder : EstatePremisesBuilder
    {
        public override void SetPremisesType(List<PremisesType> premisesTypes)
        {
            BuiltPremises.PremisesTypeId = premisesTypes.First(x => x.Name == "BLK");
        }
    }

    public class FlatPremisesBuilder : PremisesBuilder
    {
        public override void SetPremisesType(List<PremisesType> premisesTypes)
        {
            BuiltPremises.PremisesTypeId = premisesTypes.First(x => x.Name == "PRO");
        }
        
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
            BuiltPremises.LeaseTypeId = leaseTypes.First(x => x.Name == "SOWFLT");
        }
    }

    public interface IPremisesDirector
    {
        HousingContext.Premises Build(
            IPremisesBuilder builder,
            List<HousingContext.Premises> properties,
            List<PremisesType> premisesTypes,
            List<PropertyType> propertyTypes,
            List<PropertySubType> propertySubTypes,
            List<LeaseType> leaseTypes,
            List<HousingContext.Address> addresses,
            List<AddressType> addressTypes,
            HousingContext.Premises parent);
    }
    
    public class PremisesDirector : IPremisesDirector
    {
        public HousingContext.Premises Build(
            IPremisesBuilder builder, 
            List<HousingContext.Premises> properties,
            List<PremisesType> premisesTypes,
            List<PropertyType> propertyTypes,
            List<PropertySubType> propertySubTypes,
            List<LeaseType> leaseTypes,
            List<HousingContext.Address> addresses,
            List<AddressType> addressTypes,
            HousingContext.Premises parent)
        {
            builder.Init(properties);
            builder.SetPremisesType(premisesTypes);
            builder.SetName();
            builder.SetParent(parent);
            builder.SetPropertyType(propertyTypes);
            builder.SetPropertySubType(propertySubTypes);
            builder.SetLeaseType(leaseTypes);
            builder.AddSourceApplication();
            builder.AddSourceKey();
            
            return builder.BuiltPremises;
        }
    }
}