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
        public IEnumerable<semesterallDTO> Getsemester_all()
        {
            var dto = Mapper.Map<IEnumerable<semester_all>, IEnumerable<semesterallDTO>>(db.semester_all.Take(5));
            return dto;
        }

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

        // PUT api/Semesters/5
        public IHttpActionResult Putsemester_all(int id, semester_all semester_all)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != semester_all.semester_id)
            {
                return BadRequest();
            }

            db.Entry(semester_all).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!semester_allExists(id))
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

        // POST api/Semesters
        [ResponseType(typeof(semester_all))]
        public IHttpActionResult Postsemester_all(semester_all semester_all)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.semester_all.Add(semester_all);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (semester_allExists(semester_all.semester_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = semester_all.semester_id }, semester_all);
        }

        // DELETE api/Semesters/5
        [ResponseType(typeof(semester_all))]
        public IHttpActionResult Deletesemester_all(int id)
        {
            semester_all semester_all = db.semester_all.Find(id);
            if (semester_all == null)
            {
                return NotFound();
            }

            db.semester_all.Remove(semester_all);
            db.SaveChanges();

            return Ok(semester_all);
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