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
    
    public partial class nagruzka_details
    {
        public int nagruzka_detail_id { get; set; }
        public int teacher_id { get; set; }
        public string nagruzka_year { get; set; }
        public int faculty_id { get; set; }
        public int hours { get; set; }
        public int nagruzka_type_id { get; set; }
        public Nullable<int> atfaculty_id { get; set; }
        public Nullable<int> kurs_id { get; set; }
        public Nullable<int> form_id { get; set; }
        public Nullable<int> specialty_id { get; set; }
        public Nullable<int> groups { get; set; }
        public Nullable<int> persons { get; set; }
        public Nullable<int> nagruzka_norm_id { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<int> potok { get; set; }
    
        public virtual faculty_all faculty_all { get; set; }
        public virtual nagruzka_norm nagruzka_norm { get; set; }
        public virtual nagruzka_type nagruzka_type { get; set; }
        public virtual teachers teachers { get; set; }
    }
}