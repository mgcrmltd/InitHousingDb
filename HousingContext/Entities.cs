using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HousingContext
{
    public class Address
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string pea_Address1 { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string pea_Address2 { get; set; }
        
        [MaxLength(30)]
        public string pea_Address3 { get; set; }
        
        [MaxLength(30)]
        public string pea_Address4 { get; set; }
        
        [MaxLength(30)]
        public string pea_Address5 { get; set; }

        [Required]
        [MaxLength(300)]
        public string pea_FormattedAddress { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string pea_PostCode { get; set; }

        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
       
    }
    
    public class Premises
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }

        [Required]
        public bool Residential { get; set; }
        
        [Required]
        public bool Owned { get; set; }

        public virtual Premises ParentId { get; set; }
        
        [Required]
        public virtual PremisesType PremisesTypeId { get; set; }

        public virtual PropertyType PropertyTypeId { get; set; }
        
        public virtual PropertySubType PropertySubTypeId { get; set; }
        public virtual PropertySource PropertySourceId { get; set; }
        public virtual PropertyStatus PropertyStatusId { get; set; }
        public virtual LeaseType LeaseTypeId { get; set; }
    }

    public class PremisesAddress
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        [MaxLength(100)]
        public string LocalAuthority { get; set; }
        
        [Required]
        public Address AddressId { get; set; }
        
        [Required]
        public Premises PremisesId { get; set; }
        
        [Required]
        public virtual AddressType AddressTypeId { get; set; }
        
        [Required]
        public bool IsCurrent { get; set; }
        
    }
    
    public class RevenueAccount
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        [Required]
        public Frequency FrequencyId { get; set; }
        
        [Required]
        public RevenueAccountType RevenueAccountTypeId { get; set; }
  
        
        [Required]
        public TenancyPremises TenancyPremisesId { get; set; }

        [Required]
        public decimal GrossRent { get; set; }
        
        [Required]
        public decimal LastAccountBalance { get; set; }
        
        public DateTime? LastBalanceDate { get; set; }
        
        public string HBCLaimNumber { get; set; }
        
        public decimal StatementBalance { get; set; }
        
        public DateTime? StatementToDate { get; set; }
        
        [Required]
        public bool IsCurrent { get; set; }
        
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }

        [Required]
        public virtual TenancyType TenancyTypeId { get; set; }

        public virtual TenureType TenureTypeId { get; set; }
        
        public virtual TenancySource TenancySourceId { get; set; }
    }

    public class TenancyPremises
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        [Required]
        public Tenancy TenancyId { get; set; }
        
        [Required]
        public Premises PremisesId { get; set; }
    }

    public class TenancyOccupant
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        [Required]
        public Tenancy TenancyId { get; set; }

        [Required] 
        public Person PersonId { get; set; }
        
        [Required]
        public bool MainTenant { get; set; }
    }
    
    public class PremisesGroup
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        public PremisesGroup ParentId { get; set; }
        
        [Required]
        public PremisesGroupType PremisesGroupTypeId { get; set; }
    }

    public class PremisesPremisesGroup 
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
        
        [Required]
        public PremisesGroup PremisesGroupId { get; set; }
        
        [Required]
        public Premises PremisesId { get; set; }
    }
    
    public class PremisesGroupUserRole 
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        [Required]
        public PremisesGroup PremisesGroupId { get; set; }
        
        [Required]
        public Role RoleId { get; set; }
        
        [Required]
        public Person PersonId { get; set; }
        
        [Required]
        public User User { get; set; }

    }
    
    public class PremisesContactMethod
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        [Required]
        public Premises PremisesId { get; set; }
        
        [Required]
        public ContactMethod ContactMethodId { get; set; }
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

    public class Role 
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
    }
    
    public class User 
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        [Required]
        public string CrmUserId { get; set; }
    }
    
    public class PremisesElement
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        public string Value { get; set; }
        public string FurtherValue { get; set; }
        public string AttributeCode { get; set; }
        public string FurtherAttributeCode { get; set; }
        
        [Required]
        public Element ElementId { get; set; }
        
        [Required]
        public Premises PremisesId { get; set; }
    }

    public class Element
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        
        [Required]
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        public string Category { get; set; }
    }
    
    public class Person 
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(64)]
        public string CrmId { get; set; } 
        
        [MaxLength(300)]
        public string FirstName { get; set; }
        
        [MaxLength(300)]
        public string LastName { get; set; }
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        // [Required]
        // public Party PartyId { get; set; }
        
        
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
    }
    
    public class TenancySource
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
    }
    
    public class PremisesType
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
    }
    
    public class PremisesGroupType
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
    }
    
    public class RevenueAccountType
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        

        
    }
    
    public class PropertySource
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
    }
    
    public class PropertyStatus
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
    }

    public class PropertyType
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
    }
    public class PropertySubType
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
    }
    
    public class OwnershipType
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
    }
    
    public class Frequency
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
    }
    
    public class ContactMethod
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
    }
    
    public class PartyType
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
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
    }
    
    public class Party
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        [Required]
        public PartyType PartyTypeId { get; set; }
    }
    
    public class PartyAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        [Required]
        public Party PartyId { get; set; }
        
        [Required]
        public Address AddressId { get; set; }

    }
    
    public class PartyContactMethod
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [MaxLength(30)]
        public string SourceApplication { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceKey { get; set; }
        
        [Required]
        public Party PartyId { get; set; }
        
        [Required]
        public ContactMethod ContactMethodId { get; set; }

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
