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
    
    public partial class Apartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Apartment()
        {
            this.UploadedFiles = new HashSet<UploadedFile>();
        }
    
        public int IDApartment { get; set; }
        public string Address { get; set; }
        public int CityIDCity { get; set; }
        public int UserIDUser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UploadedFile> UploadedFiles { get; set; }
        public virtual City City { get; set; }
        public virtual User User { get; set; }
    }
}
