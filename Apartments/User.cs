//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apartments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Apartments = new HashSet<Apartment>();
        }

        public int IDUser { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "{0} can have a max of {1} characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "{0} can have a max of {1} characters")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "{0} can have a max of {1} characters")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "{0} can have a max of {1} characters")]
        public string Phone { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Apartment> Apartments { get; set; }


    }
}
