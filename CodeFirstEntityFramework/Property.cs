﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEntityFramework
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
        [Required]
        public virtual PropertySubType PropertySubTypeId { get; set; }
        [Required]
        public virtual LeaseType LeaseTypeId { get; set; }

        [MaxLength(30)]
        public List<AssociatedAddress> Addresses { get; set; }
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

    public class Person
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
        public List<AssociatedAddress> Addresses { get; set; }
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

        [MaxLength(10)]
        public string FlatNumber { get; set; }
        
        [MaxLength(10)]
        public string HouseNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [MaxLength(100)]
        public string Area { get; set; }

        [MaxLength(100)]
        public string District { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string City { get; set; }

        [Required]
        [MaxLength(20)]
        public string County { get; set; }

        [MaxLength(10)]
        public string PostCode { get; set; }
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
}

/*
pea_LeaseTypeId
pea_name
pea_Owned
pea_OwnershipTypeId
pea_ParentId
pea_PremisesTypeId
pea_PropertySourceId
pea_PropertyStatusId
pea_PropertySubTypeId
pea_PropertyTypeId
pea_Reference
pea_Residential
pea_SourceApplication
pea_SourceKey
pea_StartDate
 */