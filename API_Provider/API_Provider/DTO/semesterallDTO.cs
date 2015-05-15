using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Provider.DTO
{
    public class semesterallDTO
    {
        public int semester_id { get; set; }
        public int year { get; set; }
        public int part { get; set; }
        public string name { get; set; }

        public int[] nagruzka_all { get; set; }
    }
}