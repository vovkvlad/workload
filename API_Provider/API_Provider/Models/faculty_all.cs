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
    
    public partial class faculty_all
    {
        public faculty_all()
        {
            this.nagruzka_all = new HashSet<nagruzka_all>();
            this.nagruzka_details = new HashSet<nagruzka_details>();
            this.nagruzka_other = new HashSet<nagruzka_other>();
            this.teachers = new HashSet<teachers>();
        }
    
        public int faculty_id { get; set; }
        public int faculty_type_id { get; set; }
        public string name { get; set; }
    
        public faculty_type_all faculty_type_all { get; set; }
        public ICollection<nagruzka_all> nagruzka_all { get; set; }
        public ICollection<nagruzka_details> nagruzka_details { get; set; }
        public ICollection<nagruzka_other> nagruzka_other { get; set; }
        public ICollection<teachers> teachers { get; set; }
    }
}