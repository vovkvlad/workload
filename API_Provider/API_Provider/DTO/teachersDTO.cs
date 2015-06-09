using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Provider.DTO
{
    public class teachersDTO
    {
        public int teacher_id { get; set; }
        public int post_id { get; set; }
        public string rank { get; set; }
        public string degree { get; set; }
        public Nullable<int> rate { get; set; }
        public int cathedra_id { get; set; }
        public int faculty_id { get; set; }
        //public int admpost_id { get; set; }
        public int stag { get; set; }
        //public Nullable<System.DateTime> date_s { get; set; }
        //public Nullable<System.DateTime> date_e { get; set; }
        //public Nullable<System.DateTime> birthday { get; set; }

        public string cathedra { get; set; }
        public string faculty_all { get; set; }
        //public int[] nagruzka_details { get; set; }
        //public int[] nagruzka_other { get; set; }
        public string post_all { get; set; }
    }
}