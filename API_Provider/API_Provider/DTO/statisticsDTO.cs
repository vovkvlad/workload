using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Provider.DTO
{
    public class statisticsDTO
    {
        public statisticsDTO(int teacherId, int sum) 
        {
            this.teacher = teacherId;
            this.Sum = sum;
        }

        public int teacher;
        public int Sum;
    }
}