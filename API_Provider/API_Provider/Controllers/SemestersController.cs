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
using AutoMapper;
using API_Provider.DTO;

namespace API_Provider.Controllers
{
    [RoutePrefix("api/Semesters")]
    public class SemestersController : ApiController
    {
        private VovksStudentEntities1 db = new VovksStudentEntities1();

        public SemestersController()
        {
            Mapper.CreateMap<nagruzka_all, int>().ConvertUsing(x => x.nagruzka_id);
            Mapper.CreateMap<semester_all, semesterallDTO>()
                .ForMember(dest => dest.nagruzka_all, opt => opt.MapFrom(src => src.nagruzka_all));
            Mapper.AssertConfigurationIsValid();
        }
        // GET api/Semesters
        [Route("")]
        public IEnumerable<semesterallDTO> Getsemester_all()
        {
            var dto = Mapper.Map<IEnumerable<semester_all>, IEnumerable<semesterallDTO>>(db.semester_all.Take(10));
            return dto;
        }

        [Route("{id}")]
        // GET api/Semesters/5
        [ResponseType(typeof(semester_all))]
        public IHttpActionResult Getsemester_all(int id)
        {
            semester_all semester_all = db.semester_all.Find(id);
            if (semester_all == null)
            {
                return NotFound();
            }
            var dto = Mapper.Map<semester_all, semesterallDTO>(semester_all);
            return Ok(dto);
        }

        [Route("year/{yearNumber}")]
        [ResponseType(typeof(semester_all))]
        public IHttpActionResult GetsemesterByYear(int yearNumber)
        {
            IEnumerable<semester_all> semester_all = db.semester_all.Where(x => x.year == yearNumber);
            if (semester_all == null)
            {
                return NotFound();
            }
            var dto = Mapper.Map<IEnumerable<semester_all>, IEnumerable<semesterallDTO>>(semester_all);
            return Ok(dto);
        }

        [Route("year/{yearNumber}/semester/{semesterNumber}")]
        [ResponseType(typeof(semester_all))]
        public IHttpActionResult GetsemesterByYearAndPart(int yearNumber, int semesterNumber)
        {
            IEnumerable<semester_all> semester_all = db.semester_all.Where(x => x.year == yearNumber && x.part == semesterNumber).Take(10);
            if (semester_all == null)
            {
                return NotFound();
            }
            var dto = Mapper.Map<IEnumerable<semester_all>, IEnumerable<semesterallDTO>>(semester_all);
            return Ok(dto);
        }

        [Route("semester/{semesterNumber}")]
        [ResponseType(typeof(semester_all))]
        public IHttpActionResult GetsemesterByPart(int semesterNumber)
        {
            IEnumerable<semester_all> semester_all = db.semester_all.Where(x => x.part == semesterNumber).Take(10);
            if (semester_all == null)
            {
                return NotFound();
            }
            var dto = Mapper.Map<IEnumerable<semester_all>, IEnumerable<semesterallDTO>>(semester_all);
            return Ok(dto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool semester_allExists(int id)
        {
            return db.semester_all.Count(e => e.semester_id == id) > 0;
        }
    }
}