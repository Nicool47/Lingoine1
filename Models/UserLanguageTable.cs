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

    public partial class UserLanguageTable
    {
        [Key, ForeignKey("UserTable"), Column(Order = 1)]
        public string UserEmailId { get; set; }

        [Key, ForeignKey("LanguageTable"), Column(Order = 2)]
        public int LanguageId { get; set; }
        public int ProficiencyLevel { get; set; }
        public double Rating { get; set; }
        public int NumOfCalls { get; set; }
    
        public virtual LanguageTable LanguageTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}