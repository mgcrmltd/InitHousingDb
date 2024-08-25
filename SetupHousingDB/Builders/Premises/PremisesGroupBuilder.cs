using System;
using System.Collections.Generic;
using System.Linq;
using HousingContext;
using SetupHousingDB.Builders.Address;

namespace SetupHousingDB.Builders.Property
{
    public interface IPremisesGroupBuilder : ICdmBuilder
    {
        void Init(List<HousingContext.PremisesGroup> premisesGroupList);
        void SetParent(HousingContext.PremisesGroup parentPremisesGroup);
        void SetName();
        void SetPremisesGroupType(List<PremisesGroupType> premisesGroupTypes);
        HousingContext.PremisesGroup BuiltPremisesGroup { get; set; }
        int IdSeed { get; }
    }
    public abstract class PremisesGroupBuilder : IPremisesGroupBuilder
    {
        public void Init(List<PremisesGroup> premisesGroupList)
        {
            BuiltPremisesGroup = new PremisesGroup()
            {
                Id = premisesGroupList.Count < 1 ? IdSeed : (from p in premisesGroupList select p.Id).Max() + 1
            };
        }

        public void SetParent(PremisesGroup parentPremisesGroup)
        {
            BuiltPremisesGroup.ParentId = parentPremisesGroup;
        }

        public void SetName()
        {
            BuiltPremisesGroup.Name = Guid.NewGuid().ToString();
        }

        public abstract void SetPremisesGroupType(List<PremisesGroupType> premisesGroupTypes);

        public PremisesGroup BuiltPremisesGroup { get; set; }
        public int IdSeed => 100000;
        public void AddSourceApplication()
        {
            BuiltPremisesGroup.SourceApplication = "Northgate";
        }

        public void AddSourceKey()
        {
            BuiltPremisesGroup.SourceKey = BuiltPremisesGroup.Id.ToString();
        }
    }
    
    public class AreaHousingManagerPremisesGroupBuilder : PremisesGroupBuilder
    {
        public override void SetPremisesGroupType(List<PremisesGroupType> premisesGroupTypes)
        {
            BuiltPremisesGroup.PremisesGroupTypeId = premisesGroupTypes.First(x => x.Name == "AHM");
        }
    }
    
    public class RegionalHousingManagerPremisesGroupBuilder : PremisesGroupBuilder
    {
        public override void SetPremisesGroupType(List<PremisesGroupType> premisesGroupTypes)
        {
            BuiltPremisesGroup.PremisesGroupTypeId = premisesGroupTypes.First(x => x.Name == "RHM");
        }
    }
    
    public class NeighbourhoodManagerPremisesGroupBuilder : PremisesGroupBuilder
    {
        public override void SetPremisesGroupType(List<PremisesGroupType> premisesGroupTypes)
        {
            BuiltPremisesGroup.PremisesGroupTypeId = premisesGroupTypes.First(x => x.Name == "TEN");
        }
    }
    
    public class LocalAuthorityPremisesGroupBuilder : PremisesGroupBuilder
    {
        public override void SetPremisesGroupType(List<PremisesGroupType> premisesGroupTypes)
        {
            BuiltPremisesGroup.PremisesGroupTypeId = premisesGroupTypes.First(x => x.Name == "LA");
        }
    }
    
    public class PatchOfficerPremisesGroupBuilder : PremisesGroupBuilder
    {
        public override void SetPremisesGroupType(List<PremisesGroupType> premisesGroupTypes)
        {
            BuiltPremisesGroup.PremisesGroupTypeId = premisesGroupTypes.First(x => x.Name == "PAT");
        }
    }
    
    public class OmPremisesGroupBuilder : PremisesGroupBuilder
    {
        public override void SetPremisesGroupType(List<PremisesGroupType> premisesGroupTypes)
        {
            BuiltPremisesGroup.PremisesGroupTypeId = premisesGroupTypes.First(x => x.Name == "PAT");
        }
    }
    
    public class WardenPremisesGroupBuilder : PremisesGroupBuilder
    {
        public override void SetPremisesGroupType(List<PremisesGroupType> premisesGroupTypes)
        {
            BuiltPremisesGroup.PremisesGroupTypeId = premisesGroupTypes.First(x => x.Name == "PAT");
        }
    }
    
    public interface IPremisesGroupDirector
    {
        HousingContext.PremisesGroup Build(IPremisesGroupBuilder builder, List<HousingContext.PremisesGroup> premisesGroups, 
            List<PremisesGroupType> premisesGroupTypes, PremisesGroup parentPremisesGroup);
    }
    
    public class PremisesGroupDirector : IPremisesGroupDirector
    {
        public HousingContext.PremisesGroup Build(IPremisesGroupBuilder builder, List<HousingContext.PremisesGroup> premisesGroups, 
            List<PremisesGroupType> premisesGroupTypes, PremisesGroup parentPremisesGroup)
        {
            builder.Init(premisesGroups);
            builder.SetParent(parentPremisesGroup);
            builder.SetName();
            builder.SetPremisesGroupType(premisesGroupTypes);
            builder.AddSourceKey();
            builder.AddSourceApplication();
            return builder.BuiltPremisesGroup;
        }
    }
}