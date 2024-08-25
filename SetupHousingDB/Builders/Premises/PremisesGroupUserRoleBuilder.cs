using System;
using System.Collections.Generic;
using System.Linq;
using HousingContext;
using SetupHousingDB.Builders.Address;

namespace SetupHousingDB.Builders.Property
{
    public interface IPremisesGroupUserRoleBuilder : ICdmBuilder
    {
        void Init(List<HousingContext.PremisesGroupUserRole> premisesGroupUserRoleList);
        void SetName();
        void SetRole(Role role);
        void SetPerson(HousingContext.Person person);
        void SetUser(HousingContext.User user);
        void SetPremisesGroup(PremisesGroup premisesGroup);
        HousingContext.PremisesGroupUserRole BuiltPremisesGroupUserRole { get; set; }
        int IdSeed { get; }
    }
    public class PremisesGroupUserRoleBuilder : IPremisesGroupUserRoleBuilder
    {
        public void Init(List<PremisesGroupUserRole> premisesGroupUserRoleList)
        {
            BuiltPremisesGroupUserRole = new PremisesGroupUserRole()
            {
                Id = premisesGroupUserRoleList.Count < 1 ? IdSeed : (from p in premisesGroupUserRoleList select p.Id).Max() + 1
            };
        }

        public void SetName()
        {
            BuiltPremisesGroupUserRole.Name = Guid.NewGuid().ToString();
        }

        public void SetRole(Role role)
        {
            BuiltPremisesGroupUserRole.RoleId = role;
        }

        public void SetPerson(HousingContext.Person person)
        {
            BuiltPremisesGroupUserRole.PersonId = person;
        }

        public void SetUser(User user)
        {
            BuiltPremisesGroupUserRole.User = user;
        }

        public void SetPremisesGroup(PremisesGroup premisesGroup)
        {
            BuiltPremisesGroupUserRole.PremisesGroupId = premisesGroup;
        }

        public PremisesGroupUserRole BuiltPremisesGroupUserRole { get; set; }
        public int IdSeed => 100000;
        public void AddSourceApplication()
        {
            BuiltPremisesGroupUserRole.SourceApplication = "Northgate";
        }

        public void AddSourceKey()
        {
            BuiltPremisesGroupUserRole.SourceKey = BuiltPremisesGroupUserRole.Id.ToString();
        }
    }

    public interface IPremisesGroupUserRoleDirector
    {
        PremisesGroupUserRole Build(IPremisesGroupUserRoleBuilder builder, List<HousingContext.PremisesGroupUserRole> premisesGroupUserRoles, 
            PremisesGroup premisesGroup,User user, Role role);
    }

    public class PremisesGroupUserRoleDirector : IPremisesGroupUserRoleDirector
    {
        public HousingContext.PremisesGroupUserRole Build(IPremisesGroupUserRoleBuilder builder, List<HousingContext.PremisesGroupUserRole> premisesGroupUserRoles, 
            PremisesGroup premisesGroup,User user, Role role)
        {
            builder.Init(premisesGroupUserRoles);
            builder.SetPremisesGroup(premisesGroup);
            builder.SetUser(user);
            builder.SetRole(role);
            builder.SetName();
            builder.AddSourceKey();
            builder.AddSourceApplication();
            return builder.BuiltPremisesGroupUserRole;
        }
    }
}