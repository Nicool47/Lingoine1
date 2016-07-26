//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lingoine1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class UserTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserTable()
        {
            this.UserLanguageTables = new HashSet<UserLanguageTable>();
        }
    
        public string Username { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public string SkypeId { get; set; }
        public bool IsPremium { get; set; }
        public bool Gender { get; set; }
        public bool IsOnline { get; set; }
        public bool IsBusy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLanguageTable> UserLanguageTables { get; set; }
    }
}
