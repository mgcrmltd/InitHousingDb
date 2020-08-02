using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HousingContext
{
    public class Property
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }

        [Required]
        public bool Residential { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }

        public virtual Property ParentId { get; set; }

        [Required]
        public virtual PropertyType PropertyTypeId { get; set; }
        
        public virtual PropertySubType PropertySubTypeId { get; set; }
        public virtual LeaseType LeaseTypeId { get; set; }

        //[MaxLength(30)]
        //public List<AssociatedAddress> Addresses { get; set; }
    }

    public class PropertyType
    {
        [Key] 
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
    }

    public class PropertySubType
    {
        [Key] 
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
    }
    
    public class LeaseType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
    }

    public class TenancyType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
    }

    public class TenureType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
    }

    public class Tenancy
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }

        public virtual Property PropertyId { get; set; }

        public virtual TenancyType TenancyTypeId { get; set; }

        public virtual TenureType TenureTypeId { get; set; }
    }

    public class Tenant
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        public virtual Person PersonId { get; set; }

        [Required]
        public virtual Tenancy TenancyId { get; set; }

        [Required]
        public bool IsPrimary { get; set; }

        [Required]
        public bool IsJoint { get; set; }
    }

    public interface IPerson
    {
        int Id { get; set; }
        
        string FirstName { get; set; }

        string MiddleName { get; set; }

        string Surname { get; set; }

        string Title { get; set; }

        DateTime DateOfBirth { get; set; }

        Gender Gender { get; set; }
    }
    public class Person : IPerson
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }

    public class Gender
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
    }

    public class AddressType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
    }

    public class Address
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [MaxLength(30)]
        public string BuildingName { get; set; }

        [MaxLength(20)]
        public string FlatNumber { get; set; }
        
        [MaxLength(10)]
        public string StreetNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [MaxLength(30)]
        public string Area { get; set; }

        //[MaxLength(100)]
        //public string District { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(30)]
        public string County { get; set; }

        [Required]
        [MaxLength(10)]
        public string PostCode { get; set; }

        [MaxLength(300)]
        public string Composite { get; set; }
    }

    public class AssociatedAddress
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public virtual Property PropertyId { get; set; }
        
        public virtual Person PersonId { get; set; }

        [Required]
        public virtual AddressType PropertyAddressTypeId { get; set; }

        [Required]
        public virtual Address AddressId { get; set; }
      
    }

    public class SocialPerson : IPerson
    {
        #region Decorator
        private IPerson _person;
    
        public SocialPerson(IPerson person)
        {
            _person = person;
        }

        public int Id
        {
            get => _person.Id;
            set => _person.Id = value;
        }

        public string FirstName
        {
            get => _person.FirstName;
            set => _person.FirstName = value;
        }
        public string MiddleName {
            get => _person.MiddleName;
            set => _person.MiddleName = value;
        }
        public string Surname
        {
            get => _person.Surname;
            set => _person.Surname = value;
        }
        public string Title
        {
            get => _person.Title;
            set => _person.Title = value;
        }
        public DateTime DateOfBirth
        {
            get => _person.DateOfBirth;
            set => _person.DateOfBirth = value;
        }

        public Gender Gender
        {
            get => _person.Gender;
            set => _person.Gender = value;
        }

        #endregion

        public static Person GetNewAdult(List<Gender> genders, int id)
        {
            var p = new Person
            {
                FirstName = Faker.Name.First(),
                Surname = Faker.Name.Last(),
                DateOfBirth = DateTime.Now.AddDays(Faker.RandomNumber.Next(-29200,-6570)),
                Gender = genders.GetRandom(),
                Title = Faker.Name.Prefix(),
                Id = id
            };

            if (Faker.RandomNumber.Next(1, 100) > 80)
            {
                p.MiddleName = Faker.Name.First();
            }

            return p;
        }

        public Person CreatePartner(int id, List<Gender> genders)
        {
            var p = new Person
            {
                Id = id,
                Gender = genders.First(x => x.Id != _person.Gender.Id), 
                Surname = _person.Surname
            };
            var yesNo = new[] {-1, 1};
            var multiplier = yesNo[Faker.RandomNumber.Next(0, 1)];
            p.DateOfBirth = _person.DateOfBirth.AddDays(Faker.RandomNumber.Next(10, 3000) * multiplier);
            p.FirstName = Faker.Name.First();
            if (Faker.RandomNumber.Next(1, 100) > 80)
            {
                p.MiddleName = Faker.Name.First();
            }
            if (Faker.RandomNumber.Next(1, 100) < 80)
            {
                p.Surname = _person.Surname;
            }
            else
            {
                p.Surname = Faker.Name.Last();
            }

            p.Title = Faker.Name.Prefix();
            return p;
        }

        public Person CreateChild(int id, List<Gender> genders)
        {
            var p = new Person
            {
                Id = id,
                Surname = _person.Surname
            };

            p.Gender = genders.GetRandom();
            p.DateOfBirth = DateTime.Now.AddYears(-18).AddDays(Faker.RandomNumber.Next(1,9570));
            p.FirstName = Faker.Name.First();
            if (Faker.RandomNumber.Next(1, 100) > 80)
            {
                p.MiddleName = Faker.Name.First();
            }
            p.Surname = _person.Surname;
            p.Title = Faker.Name.Prefix();
            return p;
        }
    }

    public static class ListExtensions
    {
        public static T GetRandom<T>(this List<T> obj)
        {
            var random = Faker.RandomNumber.Next(0, obj.Count - 1);
            return obj[random];
        } 
    }
}
