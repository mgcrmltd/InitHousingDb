using System;
using System.Collections.Generic;
using System.Linq;
using HousingContext;
using SetupHousingDB.Builders.Address;

namespace SetupHousingDB.Builders.Property
{
    public interface IPremisesPremisesGroupBuilder : ICdmBuilder
    {
        void Init(List<HousingContext.PremisesPremisesGroup> premisesPremisesGroupList);
        void SetName();
        void SetPremises(Premises premises);
        void SetPremisesGroup(PremisesGroup premisesGroup);
        HousingContext.PremisesPremisesGroup BuiltPremisesPremisesGroup { get; set; }
        int IdSeed { get; }
    }
    public class PremisesPremisesGroupBuilder : IPremisesPremisesGroupBuilder
    {
        public void Init(List<PremisesPremisesGroup> premisesPremisesGroupList)
        {
            BuiltPremisesPremisesGroup = new PremisesPremisesGroup()
            {
                Id = premisesPremisesGroupList.Count < 1 ? IdSeed : (from p in premisesPremisesGroupList select p.Id).Max() + 1
            };
        }

        public void SetName()
        {
            BuiltPremisesPremisesGroup.Name = Guid.NewGuid().ToString();
        }

        public void SetPremises(Premises premises)
        {
            BuiltPremisesPremisesGroup.PremisesId = premises;
        }

        public void SetPremisesGroup(PremisesGroup premisesGroup)
        {
            BuiltPremisesPremisesGroup.PremisesGroupId = premisesGroup;
        }

        public PremisesPremisesGroup BuiltPremisesPremisesGroup { get; set; }
        public int IdSeed => 100000;
        public void AddSourceApplication()
        {
            BuiltPremisesPremisesGroup.SourceApplication = "Northgate";
        }

        public void AddSourceKey()
        {
            BuiltPremisesPremisesGroup.SourceKey = BuiltPremisesPremisesGroup.Id.ToString();
        }
    }


    public interface IPremisesPremisesGroupDirector
    {
        HousingContext.PremisesPremisesGroup Build(IPremisesPremisesGroupBuilder builder, List<HousingContext.PremisesPremisesGroup> premisesPremisesGroups, 
            PremisesGroup premisesGroup, Premises premises);
    }

    public class PremisesPremisesGroupDirector : IPremisesPremisesGroupDirector
    {
        public HousingContext.PremisesPremisesGroup Build(IPremisesPremisesGroupBuilder builder, List<HousingContext.PremisesPremisesGroup> premisesPremisesGroups, 
            PremisesGroup premisesGroup, Premises premises)
        {
            builder.Init(premisesPremisesGroups);
            builder.SetPremises(premises);
            builder.SetPremisesGroup(premisesGroup);
            builder.SetName();
            builder.AddSourceKey();
            builder.AddSourceApplication();
            return builder.BuiltPremisesPremisesGroup;
        }
    }
}