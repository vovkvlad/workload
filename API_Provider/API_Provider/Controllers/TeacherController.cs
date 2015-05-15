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
    public class TeacherController : ApiController
    {
        private VovksStudentEntities1 db = new VovksStudentEntities1();

        public TeacherController ()
        {
            Mapper.CreateMap<nagruzka_details, int>().ConvertUsing(x => x.nagruzka_detail_id);
            Mapper.CreateMap<nagruzka_other, int>().ConvertUsing(x => x.nagruzka_other_id);
            Mapper.CreateMap<teachers, teachersDTO>()
                .ForMember(dest => dest.cathedra, opt => opt.MapFrom(src => src.cathedra.cathedra_id))
                .ForMember(dest => dest.faculty_all, opt => opt.MapFrom(src => src.faculty_all.faculty_id))
                .ForMember(dest => dest.nagruzka_details, opt => opt.MapFrom(src => src.nagruzka_details))
                .ForMember(dest => dest.nagruzka_other, opt => opt.MapFrom(src => src.nagruzka_other))
                .ForMember(dest => dest.post_all, opt => opt.MapFrom(src => src.post_all.post_id));
            Mapper.AssertConfigurationIsValid();
        }

        // GET api/Teacher
        public IEnumerable<teachersDTO> Getteachers()
        {
            var dto = Mapper.Map<IEnumerable<teachers>, IEnumerable<teachersDTO>>(db.teachers.Take(5));
            return dto;
        }

        // GET api/Teacher/5
        [ResponseType(typeof(teachers))]
        public IHttpActionResult Getteachers(int id)
        {
            teachers teachers = db.teachers.Find(id);

            if (teachers == null)
            {
                return NotFound();
            }

            var dto = Mapper.Map<teachers, teachersDTO>(teachers);

            return Ok(dto);
        }

        // PUT api/Teacher/5
        public IHttpActionResult Putteachers(int id, teachers teachers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teachers.teacher_id)
            {
                return BadRequest();
            }

            db.Entry(teachers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!teachersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Teacher
        [ResponseType(typeof(teachers))]
        public IHttpActionResult Postteachers(teachers teachers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.teachers.Add(teachers);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (teachersExists(teachers.teacher_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = teachers.teacher_id }, teachers);
        }

        // DELETE api/Teacher/5
        [ResponseType(typeof(teachers))]
        public IHttpActionResult Deleteteachers(int id)
        {
            teachers teachers = db.teachers.Find(id);
            if (teachers == null)
            {
                return NotFound();
            }

            db.teachers.Remove(teachers);
            db.SaveChanges();

            return Ok(teachers);
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