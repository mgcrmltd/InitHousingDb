using System.Collections.Generic;
using System.Linq;
using HousingContext;
using SetupHousingDB.Builders.Address;

namespace SetupHousingDB.Builders.Person
{
    public interface IPersonBuilder : ICdmBuilder
    {
        void Init(List<HousingContext.Person> people);
        HousingContext.Person Person { get; }
        int IdSeed { get; }
        // void AddParty(Party party);
        void AddCrmId(string crmId);
        void AddFirstName();
        void AddLastName();

    }

    public class PersonBuilder : IPersonBuilder
    {
        protected HousingContext.Person BuiltPerson;
        public HousingContext.Person Person => BuiltPerson;
        public int IdSeed => 10000;

        // public void AddParty(Party party)
        // {
        //     Person.PartyId = party;
        // }

        public void AddCrmId(string crmId)
        {
            Person.CrmId = crmId;
        }

        public virtual void AddFirstName()
        {
            Person.FirstName = Faker.Name.First();
        }

        public virtual void AddLastName()
        {
            Person.LastName = Faker.Name.Last();
        }

        public void Init(List<HousingContext.Person > people)
        {
            BuiltPerson = new HousingContext.Person ()
            {
                Id = people.Count < 1 ? IdSeed : (from p in people select p.Id).Max() + 1
            };
        }

        public void AddSourceApplication()
        {
            BuiltPerson.SourceApplication = "Northgate";
        }

        public void AddSourceKey()
        {
            BuiltPerson.SourceKey = BuiltPerson.Id.ToString();
        }
    }
    
    public interface IPersonDirector
    {
        HousingContext.Person Build(IPersonBuilder personBuilder, List<HousingContext.Person> personList, string crmId);
    }
    
    public class PersonDirector : IPersonDirector
    {
        public HousingContext.Person Build(IPersonBuilder personBuilder, List<HousingContext.Person> personList, string crmId)
        {
            personBuilder.Init(personList);
            // personBuilder.AddParty(party);
            personBuilder.AddCrmId(crmId);
            personBuilder.AddFirstName();
            personBuilder.AddLastName();
            personBuilder.AddSourceApplication();
            personBuilder.AddSourceKey();
            return personBuilder.Person;
        }
    }
}