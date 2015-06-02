using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Provider.DTO
{
    public class facultyDTO
    {
        public int faculty_id { get; set; }
        public int faculty_type_id { get; set; }
        public string name { get; set; }

        //public int faculty_type_all { get; set; }
        //public int[] nagruzka_all { get; set; }
        //public int[] nagruzka_details { get; set; }
        //public int[] nagruzka_other { get; set; }
        //public int[] teachers { get; set; }
    }
}