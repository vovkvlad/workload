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
    
    public partial class post_all
    {
        public post_all()
        {
            this.teachers = new HashSet<teachers>();
        }
    
        public int post_id { get; set; }
        public string name { get; set; }
    
        public ICollection<teachers> teachers { get; set; }
    }
}