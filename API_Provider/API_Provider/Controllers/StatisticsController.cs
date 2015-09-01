using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_Provider.Models;
using API_Provider.DTO;
using AutoMapper;


namespace API_Provider.Controllers
{
    [RoutePrefix("api/Statistics")]
    public class StatisticsController : ApiController
    {
        private VovksStudentEntities db = new VovksStudentEntities();

        //public StatisticsController()
        //{
        //    Mapper.CreateMap<nagruzka_all, nagruzkaAllDTO>()
        //        .ForMember(dest => dest.faculty_all, opt => opt.MapFrom(src => src.faculty_all.name))
        //        .ForMember(dest => dest.sum, opt => opt.MapFrom(src => src.lec + src.sem + src.lab + src.kons + src.exam + src.prac))
        //        .ForMember(dest => dest.semester_all, opt => opt.MapFrom(src => src.semester_all.name));
        //    Mapper.AssertConfigurationIsValid();
        //}

        //// GET api/Statistics
        //[Route("")]
        //public IEnumerable<nagruzkaAllDTO> Getnagruzka_all()
        //{
        //    var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(db.nagruzka_all.Take(15));
        //    return dto;
        //}

        //// GET api/Statistics/5
        //[Route("{id}")]
        //public IHttpActionResult Getnagruzka_all(int id)
        //{
        //    List<statisticsDTO> result = new List<statisticsDTO>();
        //    var tmp = (from n in db.nagruzka_all
        //               join t in db.teachers on n.teacher_id equals t.teacher_id
        //               where t.rate == 100 && n.faculty_id == 1
        //               select n).GroupBy(x => x.teacher_id);

        //    foreach (var t in tmp)
        //    {
        //        int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
        //        int teacherId = t.ElementAt(0).teacher_id;
        //        result.Add(new statisticsDTO(teacherId, sum));
        //    }
        //    //var dist = (from d in tmp select d.teacher_id).Distinct();
        //    //var list = dist.ToList();
        //    //foreach(int t in list) {
        //    //    var teacher = tmp.Where(d => d.teacher_id == t);
        //    //    var sum = teacher.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
        //    //}
        //    nagruzka_all nagruzka_all = db.nagruzka_all.Find(id);
        //    if (nagruzka_all == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(nagruzka_all);
        //}

        #region DO NOT NEED THIS
        //[Route("faculty/{faculty_id}/year/{year_id}")]
        //public IHttpActionResult GetStatisticsByFacultyYear(int faculty_id, int year_id)
        //{
        //    var semesters = db.semester_all.Where(x => x.year == year_id).ToList();
        //    int semester1 = semesters[0].semester_id;
        //    int semester2 = semesters[1].semester_id;

        //    List<statisticsDTO> result = new List<statisticsDTO>();
        //    var tmp = (from n in db.nagruzka_all
        //               join t in db.teachers on n.teacher_id equals t.teacher_id
        //               where n.faculty_id == faculty_id && (n.semester_id == semester1 || n.semester_id == semester2) && 
        //               t.rate == 100 && (t.post_id == 1 || t.post_id == 6 || t.post_id == 7)
        //               select n).GroupBy(x => x.teacher_id);

        //    foreach (var t in tmp)
        //    {
        //        int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
        //        int teacherId = t.ElementAt(0).teacher_id;
        //        result.Add(new statisticsDTO(teacherId, sum));
        //    }
            
        //    if (result.Count() == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}

        //[Route("faculty/{faculty_id}/semester/{semester_id}")]
        //public IHttpActionResult GetStatisticsByFacultyYear(int faculty_id, int semester_id)
        //{
        //    List<statisticsDTO> result = new List<statisticsDTO>();
        //    var tmp = (from n in db.nagruzka_all
        //               join t in db.teachers on n.teacher_id equals t.teacher_id
        //               where n.faculty_id == faculty_id && n.semester_id == semester_id &&
        //               t.rate == 100 && (t.post_id == 1 || t.post_id == 6 || t.post_id == 7)
        //               select n).GroupBy(x => x.teacher_id);

        //    foreach (var t in tmp)
        //    {
        //        int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
        //        int teacherId = t.ElementAt(0).teacher_id;
        //        result.Add(new statisticsDTO(teacherId, sum));
        //    }

        //    if (result.Count() == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}

        //[Route("cathedra/{cathedra_id}/year/{year_id}")]
        //public IHttpActionResult GetStatisticsByCathedraYear(int cathedra_id, int year_id)
        //{
        //    var semesters = db.semester_all.Where(x => x.year == year_id).ToList();
        //    int semester1 = semesters[0].semester_id;
        //    int semester2 = semesters[1].semester_id;

        //    List<statisticsDTO> result = new List<statisticsDTO>();
        //    var tmp = (from n in db.nagruzka_all
        //               join t in db.teachers on n.teacher_id equals t.teacher_id
        //               where t.cathedra_id == cathedra_id && (n.semester_id == semester1 || n.semester_id == semester2)
        //               && t.rate == 100 && (t.post_id == 1 || t.post_id == 6 || t.post_id == 7)
        //               select n).GroupBy(x => x.teacher_id);

        //    foreach (var t in tmp)
        //    {
        //        int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
        //        int teacherId = t.ElementAt(0).teacher_id;
        //        result.Add(new statisticsDTO(teacherId, sum));
        //    }

        //    if (result.Count() == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}

        //[Route("cathedra/{cathedra_id}/semester/{semester_id}")]
        //public IHttpActionResult GetStatisticsByCathedraYear(int cathedra_id, int semester_id)
        //{
        //    List<statisticsDTO> result = new List<statisticsDTO>();
        //    var tmp = (from n in db.nagruzka_all
        //               join t in db.teachers on n.teacher_id equals t.teacher_id
        //               where t.cathedra_id == cathedra_id && n.semester_id == semester_id
        //               && t.rate == 100 && (t.post_id == 1 || t.post_id == 6 || t.post_id == 7)
        //               select n).GroupBy(x => x.teacher_id);

        //    foreach (var t in tmp)
        //    {
        //        int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
        //        int teacherId = t.ElementAt(0).teacher_id;
        //        result.Add(new statisticsDTO(teacherId, sum));
        //    }

        //    if (result.Count() == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}

        //

        #endregion

        [Route("faculty/{faculty_id}/year/{year_id}/rate/{rate_id?}")]
        public IHttpActionResult GetStatisticsByFacultyRateYear(int faculty_id, int year_id, int rate_id = 100)
        {
            var semesters = db.semester_all.Where(x => x.year == year_id).ToList();
            int semester1 = semesters[0].semester_id;
            int semester2 = semesters[1].semester_id;

            List<statisticsDTO> result = new List<statisticsDTO>();
            List<statisticsDTO> result1 = new List<statisticsDTO>();
            List<statisticsDTO> result2 = new List<statisticsDTO>();
            List<statisticsDTO> result3 = new List<statisticsDTO>();
            List<statisticsDTO> result4 = new List<statisticsDTO>();


            var tmp = (from n in db.nagruzka_all
                       join t in db.teachers on n.teacher_id equals t.teacher_id
                       where n.faculty_id == faculty_id && (n.semester_id == semester1 || n.semester_id == semester2)
                       && t.rate == rate_id && (t.post_id == 1 || t.post_id == 6 || t.post_id == 7)
                       select n).GroupBy(x => x.teacher_id);

            var tmp2 = (from n in db.nagruzka_all
                        join t in db.teachers on n.teacher_id equals t.teacher_id
                        where n.faculty_id == faculty_id && (n.semester_id == semester1 || n.semester_id == semester2)
                        && t.rate == rate_id && (t.post_id == 6 || t.post_id == 7)
                        select n).GroupBy(x => x.teacher_id);

            var tmp3 = (from n in db.nagruzka_all
                        join t in db.teachers on n.teacher_id equals t.teacher_id
                        where n.faculty_id == faculty_id && (n.semester_id == semester1 || n.semester_id == semester2)
                        && t.rate == rate_id && (t.post_id == 6)
                        select n).GroupBy(x => x.teacher_id);

            var tmp4 = (from n in db.nagruzka_all
                        join t in db.teachers on n.teacher_id equals t.teacher_id
                        where n.faculty_id == faculty_id && (n.semester_id == semester1 || n.semester_id == semester2)
                        && t.rate == rate_id && (t.post_id == 1)
                        select n).GroupBy(x => x.teacher_id);

            var tmp5 = (from n in db.nagruzka_all
                        join t in db.teachers on n.teacher_id equals t.teacher_id
                        where n.faculty_id == faculty_id && (n.semester_id == semester1 || n.semester_id == semester2)
                        && t.rate == rate_id && (t.post_id == 7)
                        select n).GroupBy(x => x.teacher_id);

            foreach (var t in tmp)
            {
                int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
                int teacherId = t.ElementAt(0).teacher_id;
                statisticsDTO dtoobj = new statisticsDTO(teacherId, sum);
                dtoobj.post = "167";
                result.Add(dtoobj);
            }
            foreach (var t in tmp2)
            {
                int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
                int teacherId = t.ElementAt(0).teacher_id;
                statisticsDTO dtoobj = new statisticsDTO(teacherId, sum);
                dtoobj.post = "67";
                result1.Add(dtoobj);
            }
            foreach (var t in tmp3)
            {
                int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
                int teacherId = t.ElementAt(0).teacher_id;
                statisticsDTO dtoobj = new statisticsDTO(teacherId, sum);
                dtoobj.post = "6";
                result2.Add(dtoobj);
            }
            foreach (var t in tmp4)
            {
                int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
                int teacherId = t.ElementAt(0).teacher_id;
                statisticsDTO dtoobj = new statisticsDTO(teacherId, sum);
                dtoobj.post = "1";
                result3.Add(dtoobj);
            }
            foreach (var t in tmp5)
            {
                int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
                int teacherId = t.ElementAt(0).teacher_id;
                statisticsDTO dtoobj = new statisticsDTO(teacherId, sum);
                dtoobj.post = "7";
                result4.Add(dtoobj);
            }

            List<List<statisticsDTO>> final = new List<List<statisticsDTO>>();
            final.Add(result);
            final.Add(result1);
            final.Add(result2);
            final.Add(result3);
            final.Add(result4);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(final);
        }

        [Route("faculty/{faculty_id}/semester/{semester_id}/rate/{rate_id?}")]
        public IHttpActionResult GetStatisticsByFacultyRateSemester(int faculty_id, int semester_id, int rate_id = 100)
        {
            List<statisticsDTO> result = new List<statisticsDTO>();
            var tmp = (from n in db.nagruzka_all
                       join t in db.teachers on n.teacher_id equals t.teacher_id
                       where n.faculty_id == faculty_id && n.semester_id == semester_id
                       && t.rate == rate_id && (t.post_id == 1 || t.post_id == 6 || t.post_id == 7)
                       select n).GroupBy(x => x.teacher_id);

            foreach (var t in tmp)
            {
                int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
                int teacherId = t.ElementAt(0).teacher_id;
                result.Add(new statisticsDTO(teacherId, sum));
            }

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("cathedra/{cathedra_id}/year/{year_id}/rate/{rate_id?}")]
        public IHttpActionResult GetStatisticsByCathedraRateYear(int cathedra_id, int year_id, int rate_id = 100)
        {
            var semesters = db.semester_all.Where(x => x.year == year_id).ToList();
            int semester1 = semesters[0].semester_id;
            int semester2 = semesters[1].semester_id;

            List<statisticsDTO> result = new List<statisticsDTO>();
            var tmp = (from n in db.nagruzka_all
                       join t in db.teachers on n.teacher_id equals t.teacher_id
                       where t.cathedra_id == cathedra_id && (n.semester_id == semester1 || n.semester_id == semester2)
                       && t.rate == rate_id && (t.post_id == 1 || t.post_id == 6 || t.post_id == 7)
                       select n).GroupBy(x => x.teacher_id);

            foreach (var t in tmp)
            {
                int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
                int teacherId = t.ElementAt(0).teacher_id;
                result.Add(new statisticsDTO(teacherId, sum));
            }

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("cathedra/{cathedra_id}/semester/{semester_id}/rate/{rate_id?}")]
        public IHttpActionResult GetStatisticsByCathedraRateSemester(int cathedra_id, int semester_id, int rate_id = 100)
        {
            List<statisticsDTO> result = new List<statisticsDTO>();
            var tmp = (from n in db.nagruzka_all
                       join t in db.teachers on n.teacher_id equals t.teacher_id
                       where t.cathedra_id == cathedra_id && n.semester_id == semester_id
                       && t.rate == rate_id && (t.post_id == 1 || t.post_id == 6 || t.post_id == 7)
                       select n).GroupBy(x => x.teacher_id);

            foreach (var t in tmp)
            {
                int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
                int teacherId = t.ElementAt(0).teacher_id;
                result.Add(new statisticsDTO(teacherId, sum));
            }

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("faculty/{faculty_id}/year/{year_id}/rate/{rate_id}/post/{post_id1?}/{post_id2?}/{post_id3?}")]
        public IHttpActionResult GetStatisticsByFacultyRatePostYear(int faculty_id, int year_id, int rate_id, int post_id1 = 1, int post_id2 = 6, int post_id3 = 7)
        {
            var semesters = db.semester_all.Where(x => x.year == year_id).ToList();
            int semester1 = semesters[0].semester_id;
            int semester2 = semesters[1].semester_id;

            List<statisticsDTO> result = new List<statisticsDTO>();
            var tmp = (from n in db.nagruzka_all
                       join t in db.teachers on n.teacher_id equals t.teacher_id
                       where n.faculty_id == faculty_id && (n.semester_id == semester1 || n.semester_id == semester2)
                       && t.rate == rate_id && (t.post_id == post_id1 || t.post_id == post_id2 || t.post_id == post_id3)
                       select n).GroupBy(x => x.teacher_id);

            foreach (var t in tmp)
            {
                int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
                int teacherId = t.ElementAt(0).teacher_id;
                result.Add(new statisticsDTO(teacherId, sum));
            }

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("faculty/{faculty_id}/semester/{semester_id}/rate/{rate_id}/post/{post_id1?}/{post_id2?}/{post_id3?}")]
        public IHttpActionResult GetStatisticsByFacultyRatePostSemester(int faculty_id, int semester_id, int rate_id, int post_id1 = 1, int post_id2 = 6, int post_id3 = 7)
        {
            List<statisticsDTO> result = new List<statisticsDTO>();
            var tmp = (from n in db.nagruzka_all
                       join t in db.teachers on n.teacher_id equals t.teacher_id
                       where n.faculty_id == faculty_id && n.semester_id == semester_id
                       && t.rate == rate_id && (t.post_id == post_id1 || t.post_id == post_id2 || t.post_id == post_id3)
                       select n).GroupBy(x => x.teacher_id);

            foreach (var t in tmp)
            {
                int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
                int teacherId = t.ElementAt(0).teacher_id;
                result.Add(new statisticsDTO(teacherId, sum));
            }

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("cathedra/{cathedra_id}/year/{year_id}/rate/{rate_id}/post/{post_id1?}/{post_id2?}/{post_id3?}")]
        public IHttpActionResult GetStatisticsByCathedraRatePostYear(int cathedra_id, int year_id, int rate_id, int post_id1 = 1, int post_id2 = 6, int post_id3 = 7)
        {
            var semesters = db.semester_all.Where(x => x.year == year_id).ToList();
            int semester1 = semesters[0].semester_id;
            int semester2 = semesters[1].semester_id;

            List<statisticsDTO> result = new List<statisticsDTO>();
            var tmp = (from n in db.nagruzka_all
                       join t in db.teachers on n.teacher_id equals t.teacher_id
                       where t.cathedra_id == cathedra_id && (n.semester_id == semester1 || n.semester_id == semester2)
                       && t.rate == rate_id && (t.post_id == post_id1 || t.post_id == post_id2 || t.post_id == post_id3)
                       select n).GroupBy(x => x.teacher_id);

            foreach (var t in tmp)
            {
                int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
                int teacherId = t.ElementAt(0).teacher_id;
                result.Add(new statisticsDTO(teacherId, sum));
            }

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [Route("cathedra/{cathedra_id}/semester/{semester_id}/rate/{rate_id}/post/{post_id1?}/{post_id2?}/{post_id3?}")]
        public IHttpActionResult GetStatisticsByCathedraRatePostSemester(int cathedra_id, int semester_id, int rate_id, int post_id1 = 1, int post_id2 = 6, int post_id3 = 7)
        {
            List<statisticsDTO> result = new List<statisticsDTO>();
            var tmp = (from n in db.nagruzka_all
                       join t in db.teachers on n.teacher_id equals t.teacher_id
                       where t.cathedra_id == cathedra_id && n.semester_id == semester_id
                       && t.rate == rate_id && (t.post_id == post_id1 || t.post_id == post_id2 || t.post_id == post_id3)
                       select n).GroupBy(x => x.teacher_id);

            foreach (var t in tmp)
            {
                int sum = t.Sum(f => f.lec + f.lab + f.sem + f.kons + f.exam + f.prac);
                int teacherId = t.ElementAt(0).teacher_id;
                result.Add(new statisticsDTO(teacherId, sum));
            }

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool nagruzka_allExists(int id)
        {
            return db.nagruzka_all.Count(e => e.nagruzka_id == id) > 0;
        }
    }
}