// using System.Collections.Generic;
// using System.Linq;
// using HousingContext;
//
// namespace SetupHousingDB.Builders.Occupants
// {
//     public interface IOccupantsBuilder
//     {
//         void Init();
//         void CreateOccupants(
//             List<Person> people, 
//             List<Gender> genders, 
//             HousingContext.Tenancy tenancy, 
//             List<Tenant> tenants);
//         List<Person> Occupants { get; }
//         int IdSeed { get; }
//     }
//
//     public abstract class OccupantsBuilder : IOccupantsBuilder
//     {
//         public int IdSeed => 10000;
//
//         public void Init()
//         {
//             BuiltOccupants = new List<Person>();   
//         }
//
//         protected int GetNextPersonId(List<Person> people)
//         {
//             if (Occupants.Count > 0)
//             {
//                 return Occupants.Select(x => x.Id).Max() + 1;
//             }
//             return people.Count > 0 ? people.Select(x => x.Id).Max() +1 : IdSeed;
//         }
//
//         protected int GetNexTenantId(List<Tenant> tenants)
//         {
//          
//             return tenants.Count > 0 ? tenants.Select(x => x.Id).Max() + 1 : IdSeed;
//         }
//
//         public abstract void CreateOccupants(List<Person> people, List<Gender> genders, HousingContext.Tenancy tenancy, List<Tenant> tenants);
//
//         protected List<Person> BuiltOccupants;
//         public List<Person> Occupants => BuiltOccupants;
//
//     }
//
//     public class SingleOccupancyBuilder : OccupantsBuilder
//     {
//         public override void CreateOccupants(List<Person> people, List<Gender> genders, 
//             HousingContext.Tenancy tenancy, List<Tenant> tenants)
//         {
//             var mainPerson = SocialPerson.GetNewAdult(genders, GetNextPersonId(people));
//             people.Add(mainPerson);
//             tenants.Add(new Tenant()
//             {
//                 Id = GetNexTenantId(tenants),
//                 PersonId = mainPerson,
//                 TenancyId = tenancy,
//                 IsPrimary = true,
//                 IsJoint = false
//             });
//         }
//     }
//
//     public class JointOccupancyBuilder : OccupantsBuilder
//     {
//         public override void CreateOccupants(List<Person> people, List<Gender> genders, HousingContext.Tenancy tenancy, List<Tenant> tenants)
//         {
//             var mainPerson = SocialPerson.GetNewAdult(genders, GetNextPersonId(people));
//             var socialPerson = new SocialPerson(mainPerson);
//             people.Add(mainPerson);
//             var jointPerson = socialPerson.CreatePartner(GetNextPersonId(people), genders);
//             people.Add(jointPerson);
//             tenants.Add(new Tenant()
//             {
//                 Id = GetNexTenantId(tenants),
//                 PersonId = mainPerson,
//                 TenancyId = tenancy,
//                 IsPrimary = true,
//                 IsJoint = true
//             });
//             tenants.Add(new Tenant()
//             {
//                 Id = GetNexTenantId(tenants),
//                 PersonId = jointPerson,
//                 TenancyId = tenancy,
//                 IsPrimary = false,
//                 IsJoint = true
//             });
//         }
//     }
//
//     public class CoupleOccupancyBuilder : OccupantsBuilder
//     {
//         public override void CreateOccupants(List<Person> people, List<Gender> genders, HousingContext.Tenancy tenancy, List<Tenant> tenants)
//         {
//             var mainPerson = SocialPerson.GetNewAdult(genders, GetNextPersonId(people));
//             var socialPerson = new SocialPerson(mainPerson);
//             people.Add(mainPerson);
//             var jointPerson = socialPerson.CreatePartner(GetNextPersonId(people),genders);
//             people.Add(jointPerson);
//             tenants.Add(new Tenant()
//             {
//                 Id = GetNexTenantId(tenants),
//                 PersonId = mainPerson,
//                 TenancyId = tenancy,
//                 IsPrimary = true,
//                 IsJoint = false
//             });
//             tenants.Add(new Tenant()
//             {
//                 Id = GetNexTenantId(tenants),
//                 PersonId = jointPerson,
//                 TenancyId = tenancy,
//                 IsPrimary = false,
//                 IsJoint = false
//             });
//         }
//     }
//
//     public class FamilyOccupancyBuilder : OccupantsBuilder
//     {
//         public override void CreateOccupants(List<Person> people, List<Gender> genders, HousingContext.Tenancy tenancy, List<Tenant> tenants)
//         {
//             var mainPerson = SocialPerson.GetNewAdult(genders, GetNextPersonId(people));
//             people.Add(mainPerson);
//             var socialPerson = new SocialPerson(mainPerson);
//             if (Faker.RandomNumber.Next(1, 2) == 1)
//             {
//                 people.Add(socialPerson.CreatePartner(GetNextPersonId(people),genders));
//                 tenants.Add(new Tenant()
//                 {
//                     Id = GetNexTenantId(tenants),
//                     PersonId = mainPerson,
//                     TenancyId = tenancy,
//                     IsPrimary = true,
//                     IsJoint = false
//                 });
//             }
//
//             for (var i = 0; i < Faker.RandomNumber.Next(1, 3); i++)
//             {
//                 var kid = socialPerson.CreateChild(GetNextPersonId(people),genders);
//                 people.Add(kid);
//                 tenants.Add(new Tenant()
//                 {
//                     Id = GetNexTenantId(tenants),
//                     PersonId = mainPerson,
//                     TenancyId = tenancy,
//                     IsPrimary = false,
//                     IsJoint = false
//                 });
//             }
//         }
//     }
//
//     public interface IOccupantsDirector
//     {
//         void Build(
//             IOccupantsBuilder builder,
//             List<Person> people,
//             List<Gender> genders,
//             HousingContext.Tenancy tenancy,
//             List<Tenant> tenants);
//     }
//
//     public class OccupantsDirector : IOccupantsDirector
//     {
//         public void Build(IOccupantsBuilder builder, List<Person> people, List<Gender> genders, HousingContext.Tenancy tenancy, List<Tenant> tenants)
//         {
//             builder.Init();
//             builder.CreateOccupants(people, genders,tenancy,tenants);
//         }
//     }
// }
