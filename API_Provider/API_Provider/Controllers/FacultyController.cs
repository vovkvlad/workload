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
    public class FacultyController : ApiController
    {
        private VovksStudentEntities1 db = new VovksStudentEntities1();

        public FacultyController()
        {
            Mapper.CreateMap<nagruzka_details, int>().ConvertUsing(x => x.nagruzka_detail_id);
            Mapper.CreateMap<nagruzka_other, int>().ConvertUsing(x => x.nagruzka_other_id);
            Mapper.CreateMap<nagruzka_all, int>().ConstructUsing(x => x.nagruzka_id);
            Mapper.CreateMap<teachers, int>().ConstructUsing(x => x.teacher_id);
            Mapper.CreateMap<faculty_all, facultyDTO>()
                .ForMember(dest => dest.faculty_type_all, opt => opt.MapFrom(src => src.faculty_type_all.faculty_type_id))
                .ForMember(dest => dest.nagruzka_all, opt => opt.MapFrom(src => src.nagruzka_all))
                .ForMember(dest => dest.nagruzka_details, opt => opt.MapFrom(src => src.nagruzka_details))
                .ForMember(dest => dest.nagruzka_other, opt => opt.MapFrom(src => src.nagruzka_other))
                .ForMember(dest => dest.teachers, opt => opt.MapFrom(src => src.teachers));
            Mapper.AssertConfigurationIsValid();
        }

        // GET api/Faculty
        public IEnumerable<facultyDTO> Getfaculty_all()
        {
            var dto = Mapper.Map<IEnumerable<faculty_all>, IEnumerable<facultyDTO>>(db.faculty_all.Take(5));
            return dto;
        }

        // GET api/Faculty/5
        [ResponseType(typeof(faculty_all))]
        public IHttpActionResult Getfaculty_all(int id)
        {
            faculty_all faculty_all = db.faculty_all.Find(id);
            if (faculty_all == null)
            {
                return NotFound();
            }
            var dto = Mapper.Map<faculty_all, facultyDTO>(faculty_all);
            return Ok(dto);
        }

        // PUT api/Faculty/5
        public IHttpActionResult Putfaculty_all(int id, faculty_all faculty_all)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != faculty_all.faculty_id)
            {
                return BadRequest();
            }

            db.Entry(faculty_all).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!faculty_allExists(id))
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

        // POST api/Faculty
        [ResponseType(typeof(faculty_all))]
        public IHttpActionResult Postfaculty_all(faculty_all faculty_all)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.faculty_all.Add(faculty_all);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (faculty_allExists(faculty_all.faculty_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = faculty_all.faculty_id }, faculty_all);
        }

        // DELETE api/Faculty/5
        [ResponseType(typeof(faculty_all))]
        public IHttpActionResult Deletefaculty_all(int id)
        {
            faculty_all faculty_all = db.faculty_all.Find(id);
            if (faculty_all == null)
            {
                return NotFound();
            }

            db.faculty_all.Remove(faculty_all);
            db.SaveChanges();

            return Ok(faculty_all);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool faculty_allExists(int id)
        {
            return db.faculty_all.Count(e => e.faculty_id == id) > 0;
        }
    }
}