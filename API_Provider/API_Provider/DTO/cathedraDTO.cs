using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Provider.DTO
{
    public class cathedraDTO
    {
        public int cathedra_id { get; set; }
        public int faculty_id { get; set; }
        public string nameshort { get; set; }
        public string name { get; set; }

        //public int cathedra_type_id { get; set; }

        //public int cathedra_type { get; set; }
        //public int[] teachers { get; set; }
    }
}