//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_Provider.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class semester_all
    {
        public semester_all()
        {
            this.nagruzka_all = new HashSet<nagruzka_all>();
        }
    
        public int semester_id { get; set; }
        public int year { get; set; }
        public int part { get; set; }
        public string name { get; set; }
    
        public ICollection<nagruzka_all> nagruzka_all { get; set; }
    }
}