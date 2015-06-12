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
    [RoutePrefix("api/NagruzkaAll")]
    public class NagruzkaAllController : ApiController
    {
        private VovksStudentEntities db = new VovksStudentEntities();

        public NagruzkaAllController()
        {
            Mapper.CreateMap<nagruzka_all, nagruzkaAllDTO>()
                .ForMember(dest => dest.faculty_all, opt => opt.MapFrom(src => src.faculty_all.name))
                .ForMember(dest => dest.sum, opt => opt.MapFrom(src => src.lec + src.sem + src.lab + src.kons + src.exam + src.prac))
                .ForMember(dest => dest.semester_all, opt => opt.MapFrom(src => src.semester_all.name));
            Mapper.AssertConfigurationIsValid();
        }
        // GET api/NagruzkaAll
        [Route("")]
        public IEnumerable<nagruzkaAllDTO> Getnagruzka_all()
        {
            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(db.nagruzka_all.Take(15));
            return dto;
        }

        // GET api/NagruzkaAll/5
        [Route("{id}")]
        [ResponseType(typeof(nagruzka_all))]
        public IHttpActionResult Getnagruzka_all(int id)
        {
            nagruzka_all nagruzka_all = db.nagruzka_all.Find(id);
            if (nagruzka_all == null)
            {
                return NotFound();
            }
            var dto = Mapper.Map<nagruzka_all, nagruzkaAllDTO>(nagruzka_all);
            return Ok(dto);
        }

        [Route("name/{name}")]

        public IHttpActionResult Getnagruzka_allByCoureseNameId(string name)
        {
            var x = name;
            var result = db.nagruzka_all.ToList().Where(text => text.name.Contains(name));
            if (result.Count() == 0)
            {
                return NotFound();
            }
            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);
            return Ok(dto);
        }

        [Route("teacher/{teacher_id}")]
        
        public IHttpActionResult Getnagruzka_allByTeacherId(int teacher_id)
        {
            var firstfifteen = db.nagruzka_all.Where(nagruzka => nagruzka.teacher_id.Equals(teacher_id)).Take(15);
            var result = firstfifteen.ToList();
            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);

            return Ok(dto);
        }

        [Route("faculty/{faculty_id}")]
        
        public IHttpActionResult Getnagruzka_allByFacultyId(int faculty_id)
        {
            var firstfifteen = db.nagruzka_all.Where(nagruzka => nagruzka.faculty_id.Equals(faculty_id)).Take(20);
            var result = firstfifteen.ToList();
            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);

            return Ok(dto);
        }

        [Route("semester/{semester_id}")]

        public IHttpActionResult Getnagruzka_allBySemesterId(int semester_id)
        {
            var firstfifteen = db.nagruzka_all.Where(nagruzka => nagruzka.semester_id.Equals(semester_id)).Take(20);
            var result = firstfifteen.ToList();
            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);

            return Ok(dto);
        }

        [Route("semester/{semester_id}/name/{name}")]

        public IHttpActionResult Getnagruzka_allBySemesterIdName(int semester_id, string name)
        {
            var yearQuery = db.nagruzka_all.Where(text => text.name.Contains(name));
            var firstfifteen = yearQuery.Where(nagruzka => nagruzka.semester_id.Equals(semester_id)).Take(20);
            var result = firstfifteen.ToList();
            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);

            return Ok(dto);
        }

        [Route("year/{year}")]
        
        public IHttpActionResult Getnagruzka_allByYearId(int year)
        {
            var semesters = db.semester_all.Where(x => x.year == year).ToList();
            int semester1 = semesters[0].semester_id;
            int semester2 = semesters[1].semester_id;
            var firstfifteen = db.nagruzka_all.Where(nagruzka => nagruzka.semester_id == semester1 || nagruzka.semester_id == semester1).Take(20);
            var result = firstfifteen.ToList();
            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);

            return Ok(dto);
        }

        [Route("year/{year}/name/{name}")]

        public IHttpActionResult Getnagruzka_allByYearIdName(int year, string name)
        {
            var semesters = db.semester_all.Where(x => x.year == year).ToList();
            int semester1 = semesters[0].semester_id;
            int semester2 = semesters[1].semester_id;
            var yearQuery = db.nagruzka_all.Where(text => text.name.Contains(name));
            var firstfifteen = yearQuery.Where(nagruzka => nagruzka.semester_id == semester1 || nagruzka.semester_id == semester1).Take(20);
            var result = firstfifteen.ToList();
            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);

            return Ok(dto);
        }

        [Route("faculty/{faculty_id}/semester/{semester_id}")]
        
        public IHttpActionResult Getnagruzka_allByFacultySemesterId(int faculty_id, int semester_id)
        {
            var firstfifteen = db.nagruzka_all.Where(nagruzka => nagruzka.faculty_id == faculty_id && nagruzka.semester_id == semester_id).Take(20);
            var result = firstfifteen.ToList();

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);

            return Ok(dto);
        }

        [Route("faculty/{faculty_id}/year/{year_id}")]

        public IHttpActionResult Getnagruzka_allByFacultyYear(int faculty_id, int year_id)
        {
            var semesters = db.semester_all.Where(x => x.year == year_id).ToList();
            int semester1 = semesters[0].semester_id;
            int semester2 = semesters[1].semester_id;

            var firstfifteen = db.nagruzka_all.Where(nagruzka => nagruzka.faculty_id == faculty_id && (nagruzka.semester_id == semester1 || nagruzka.semester_id == semester2)).Take(20);
            var result = firstfifteen.ToList();

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);

            return Ok(dto);
        }

        [Route("teacher/{teacher_id}/semester/{semester_id}")]
        
        public IHttpActionResult Getnagruzka_allByTeacherSemesterId(int teacher_id, int semester_id)
        {
            var firstfifteen = db.nagruzka_all.Where(nagruzka => nagruzka.teacher_id == teacher_id && nagruzka.semester_id == semester_id);
            var result = firstfifteen.ToList();
            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);

            return Ok(dto);
        }

        [Route("teacher/{teacher_id}/year/{year_id}")]

        public IHttpActionResult Getnagruzka_allByTeacherYear(int teacher_id, int year_id)
        {
            var semesters = db.semester_all.Where(x => x.year == year_id).ToList();
            int semester1 = semesters[0].semester_id;
            int semester2 = semesters[1].semester_id;

            var firstfifteen = db.nagruzka_all.Where(nagruzka => nagruzka.teacher_id == teacher_id && (nagruzka.semester_id == semester1 || nagruzka.semester_id == semester2)).Take(20);
            var result = firstfifteen.ToList();

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);

            return Ok(dto);
        }


        [Route("faculty/{faculty_id}/kurs/{kurs_id}")]
        
        public IHttpActionResult Getnagruzka_allByFacultyKursId(int faculty_id, int kurs_id)
        {
            var firstfifteen = db.nagruzka_all.Where(nagruzka => nagruzka.faculty_id == faculty_id && nagruzka.kurs_id == kurs_id).Take(20);
            var result = firstfifteen.ToList();

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);

            return Ok(dto);
        }

        [Route("teacher/{teacher_id}/kurs/{kurs_id}")]
        
        public IHttpActionResult Getnagruzka_allByNagruzkaKursId(int teacher_id, int kurs_id)
        {
            var firstfifteen = db.nagruzka_all.Where(nagruzka => nagruzka.teacher_id == teacher_id && nagruzka.kurs_id == kurs_id).Take(20);
            var result = firstfifteen.ToList();

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);

            return Ok(dto);
        }

        [Route("faculty/{faculty_id}/semester/{semester_id}/kurs/{kurs_id}")]
        
        public IHttpActionResult Getnagruzka_allByFacultySemesterKursId(int faculty_id, int semester_id, int kurs_id)
        {
            var firstfifteen = db.nagruzka_all.Where(nagruzka => nagruzka.faculty_id == faculty_id && nagruzka.semester_id == semester_id && nagruzka.kurs_id == kurs_id).Take(20);
            var result = firstfifteen.ToList();
            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);

            return Ok(dto);
        }

        [Route("teacher/{teacher_id}/semester/{semester_id}/kurs/{kurs_id}")]
        
        public IHttpActionResult Getnagruzka_allByNagruzkaKursId(int teacher_id, int semester_id, int kurs_id)
        {
            var firstfifteen = db.nagruzka_all.Where(nagruzka => nagruzka.teacher_id == teacher_id && nagruzka.semester_id == semester_id && nagruzka.kurs_id == kurs_id).Take(20);
            var result = firstfifteen.ToList();
            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(result);

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

        private bool nagruzka_allExists(int id)
        {
            return db.nagruzka_all.Count(e => e.nagruzka_id == id) > 0;
        }
    }
}