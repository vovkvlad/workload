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
    
    public partial class teacher
    {
        public teacher()
        {
            this.nagruzka_details = new HashSet<nagruzka_details>();
            this.nagruzka_other = new HashSet<nagruzka_other>();
        }
    
        public int teacher_id { get; set; }
        public int post_id { get; set; }
        public string rank { get; set; }
        public string degree { get; set; }
        public Nullable<int> rate { get; set; }
        public int cathedra_id { get; set; }
        public int faculty_id { get; set; }
        public int admpost_id { get; set; }
        public int stag { get; set; }
        public Nullable<System.DateTime> date_s { get; set; }
        public Nullable<System.DateTime> date_e { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
    
        public virtual cathedra cathedra { get; set; }
        public virtual faculty_all faculty_all { get; set; }
        public virtual ICollection<nagruzka_details> nagruzka_details { get; set; }
        public virtual ICollection<nagruzka_other> nagruzka_other { get; set; }
        public virtual post_all post_all { get; set; }
    }
}
