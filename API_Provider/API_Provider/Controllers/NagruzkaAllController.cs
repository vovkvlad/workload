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
    public class NagruzkaAllController : ApiController
    {
        private VovksStudentEntities1 db = new VovksStudentEntities1();

        public NagruzkaAllController()
        {
            Mapper.CreateMap<nagruzka_all, nagruzkaAllDTO>()
                .ForMember(dest => dest.faculty_all, opt => opt.MapFrom(src => src.faculty_all.faculty_id))
                .ForMember(dest => dest.semester_all, opt => opt.MapFrom(src => src.semester_all.semester_id));
            Mapper.AssertConfigurationIsValid();
        }
        // GET api/NagruzkaAll
        public IEnumerable<nagruzkaAllDTO> Getnagruzka_all()
        {
            var dto = Mapper.Map<IEnumerable<nagruzka_all>, IEnumerable<nagruzkaAllDTO>>(db.nagruzka_all.Take(5));
            return dto;
        }

        // GET api/NagruzkaAll/5
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

        // PUT api/NagruzkaAll/5
        public IHttpActionResult Putnagruzka_all(int id, nagruzka_all nagruzka_all)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nagruzka_all.nagruzka_id)
            {
                return BadRequest();
            }

            db.Entry(nagruzka_all).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!nagruzka_allExists(id))
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

        // POST api/NagruzkaAll
        [ResponseType(typeof(nagruzka_all))]
        public IHttpActionResult Postnagruzka_all(nagruzka_all nagruzka_all)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.nagruzka_all.Add(nagruzka_all);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (nagruzka_allExists(nagruzka_all.nagruzka_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nagruzka_all.nagruzka_id }, nagruzka_all);
        }

        // DELETE api/NagruzkaAll/5
        [ResponseType(typeof(nagruzka_all))]
        public IHttpActionResult Deletenagruzka_all(int id)
        {
            nagruzka_all nagruzka_all = db.nagruzka_all.Find(id);
            if (nagruzka_all == null)
            {
                return NotFound();
            }

            db.nagruzka_all.Remove(nagruzka_all);
            db.SaveChanges();

            return Ok(nagruzka_all);
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