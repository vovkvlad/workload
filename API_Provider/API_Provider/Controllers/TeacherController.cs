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
    [RoutePrefix("api/Teacher")]
    public class TeacherController : ApiController
    {
        private VovksStudentEntities db = new VovksStudentEntities();

        public TeacherController ()
        {
            //Mapper.CreateMap<nagruzka_details, int>().ConvertUsing(x => x.nagruzka_detail_id);
            //Mapper.CreateMap<nagruzka_other, int>().ConvertUsing(x => x.nagruzka_other_id);
            Mapper.CreateMap<teacher, teachersDTO>()
                .ForMember(dest => dest.cathedra, opt => opt.MapFrom(src => src.cathedra.name))
                .ForMember(dest => dest.faculty_all, opt => opt.MapFrom(src => src.faculty_all.name))
                .ForMember(dest => dest.post_all, opt => opt.MapFrom(src => src.post_all.name));
            Mapper.AssertConfigurationIsValid();
        }

        // GET api/Teacher
        [Route("")]
        public IEnumerable<teachersDTO> Getteachers()
        {
            var dto = Mapper.Map<IEnumerable<teacher>, IEnumerable<teachersDTO>>(db.teachers.Take(5));
            return dto;
        }

        // GET api/Teacher/5
        [Route("{id}")]
        [ResponseType(typeof(teacher))]
        public IHttpActionResult Getteachers(int id)
        {
            teacher teachers = db.teachers.Find(id);

            if (teachers == null)
            {
                return NotFound();
            }

            var dto = Mapper.Map<teacher, teachersDTO>(teachers);

            return Ok(dto);
        }

        [Route("post/{post_id}")]
        [ResponseType(typeof(teacher))]
        public IHttpActionResult GetteachersByPostId(int post_id)
        {
            var result = db.teachers.ToList().Where(teacher => teacher.post_id.Equals(post_id));

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<teacher>, IEnumerable<teachersDTO>>(result);

            return Ok(dto);
        }

        [Route("rate/{rate_id}")]
        [ResponseType(typeof(teacher))]
        public IHttpActionResult GetteachersByRateId(int rate_id)
        {
            var result = db.teachers.ToList().Where(teacher => teacher.rate.Equals(rate_id));

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<teacher>, IEnumerable<teachersDTO>>(result);

            return Ok(dto);
        }

        [Route("cathedra/{cathedra_id}")]
        [ResponseType(typeof(teacher))]
        public IHttpActionResult GetteachersByCathedraId(int cathedra_id)
        {
            var result = db.teachers.ToList().Where(teacher => teacher.cathedra_id.Equals(cathedra_id));

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<teacher>, IEnumerable<teachersDTO>>(result);

            return Ok(dto);
        }

        [Route("faculty/{faculty_id}")]
        [ResponseType(typeof(teacher))]
        public IHttpActionResult GetteachersByFacultyId(int faculty_id)
        {
            var result = db.teachers.ToList().Where(teacher => teacher.faculty_id.Equals(faculty_id));

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<teacher>, IEnumerable<teachersDTO>>(result);

            return Ok(dto);
        }

        [Route("faculty/{faculty_id}/post/{post_id}/rate/{rate_id}")]
        [ResponseType(typeof(teacher))]
        public IHttpActionResult GetteachersByFacultyPostRateId(int faculty_id, int post_id, int rate_id)
        {
            var result = db.teachers.ToList().Where(teacher => teacher.faculty_id == faculty_id && teacher.post_id == post_id && teacher.rate == rate_id);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<teacher>, IEnumerable<teachersDTO>>(result);

            return Ok(dto);
        }

        [Route("cathedra/{cathedra_id}/post/{post_id}/rate/{rate_id}")]
        [ResponseType(typeof(teacher))]
        public IHttpActionResult GetteachersByCathedraPostRateId(int cathedra_id, int post_id, int rate_id)
        {
            var result = db.teachers.ToList().Where(teacher => teacher.cathedra_id == cathedra_id && teacher.post_id == post_id && teacher.rate == rate_id);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<teacher>, IEnumerable<teachersDTO>>(result);

            return Ok(dto);
        }

        [Route("faculty/{faculty_id}/post/{post_id}")]
        [ResponseType(typeof(teacher))]
        public IHttpActionResult GetteachersByFacultyPostId(int faculty_id, int post_id)
        {
            var result = db.teachers.ToList().Where(teacher => teacher.faculty_id == faculty_id && teacher.post_id == post_id);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<teacher>, IEnumerable<teachersDTO>>(result);

            return Ok(dto);
        }

        [Route("faculty/{faculty_id}/rate/{rate_id}")]
        [ResponseType(typeof(teacher))]
        public IHttpActionResult GetteachersByFacultyRateId(int faculty_id, int rate_id)
        {
            var result = db.teachers.ToList().Where(teacher => teacher.faculty_id == faculty_id && teacher.rate == rate_id);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<teacher>, IEnumerable<teachersDTO>>(result);

            return Ok(dto);
        }

        [Route("cathedra/{cathedra_id}/post/{post_id}")]
        [ResponseType(typeof(teacher))]
        public IHttpActionResult GetteachersByCathedraPostId(int cathedra_id, int post_id)
        {
            var result = db.teachers.ToList().Where(teacher => teacher.cathedra_id == cathedra_id && teacher.post_id == post_id);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<teacher>, IEnumerable<teachersDTO>>(result);

            return Ok(dto);
        }

        [Route("cathedra/{cathedra_id}/rate/{rate_id}")]
        [ResponseType(typeof(teacher))]
        public IHttpActionResult GetteachersByCathedraRateId(int cathedra_id, int rate_id)
        {
            var result = db.teachers.ToList().Where(teacher => teacher.cathedra_id == cathedra_id && teacher.rate == rate_id);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<teacher>, IEnumerable<teachersDTO>>(result);

            return Ok(dto);
        }

        [Route("post/{post_id}/rate/{rate_id}")]
        [ResponseType(typeof(teacher))]
        public IHttpActionResult GetteachersByPostRateId(int post_id, int rate_id)
        {
            var result = db.teachers.ToList().Where(teacher => teacher.post_id == post_id && teacher.rate == rate_id);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<teacher>, IEnumerable<teachersDTO>>(result);

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

        private bool teachersExists(int id)
        {
            return db.teachers.Count(e => e.teacher_id == id) > 0;
        }
    }
}