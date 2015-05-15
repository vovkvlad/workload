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
    public class CathedraController : ApiController
    {
        private VovksStudentEntities1 db = new VovksStudentEntities1();

        public CathedraController()
        {
            Mapper.CreateMap<teachers, int>().ConvertUsing(x => x.teacher_id);
            Mapper.CreateMap<cathedra, cathedraDTO>()
                .ForMember(dest => dest.teachers, opt => opt.MapFrom(src => src.teachers))
                .ForMember(dest => dest.cathedra_type, opt => opt.MapFrom(src => src.cathedra_type.cathedra_type_id));
            Mapper.AssertConfigurationIsValid();
        }

        // GET api/Cathedra
        public IEnumerable<cathedraDTO> Getcathedra()
        {
            var dto = Mapper.Map<IEnumerable<cathedra>, IEnumerable<cathedraDTO>>(db.cathedra.Take(5));
            return dto;
        }

        // GET api/Cathedra/5
        [ResponseType(typeof(cathedra))]
        public IHttpActionResult Getcathedra(int id)
        {
            cathedra cathedra = db.cathedra.Find(id);
            if (cathedra == null)
            {
                return NotFound();
            }

            var dto = Mapper.Map<cathedra, cathedraDTO>(cathedra);
            return Ok(dto);
        }

        // PUT api/Cathedra/5
        public IHttpActionResult Putcathedra(int id, cathedra cathedra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cathedra.cathedra_id)
            {
                return BadRequest();
            }

            db.Entry(cathedra).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cathedraExists(id))
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

        // POST api/Cathedra
        [ResponseType(typeof(cathedra))]
        public IHttpActionResult Postcathedra(cathedra cathedra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cathedra.Add(cathedra);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (cathedraExists(cathedra.cathedra_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cathedra.cathedra_id }, cathedra);
        }

        // DELETE api/Cathedra/5
        [ResponseType(typeof(cathedra))]
        public IHttpActionResult Deletecathedra(int id)
        {
            cathedra cathedra = db.cathedra.Find(id);
            if (cathedra == null)
            {
                return NotFound();
            }

            db.cathedra.Remove(cathedra);
            db.SaveChanges();

            return Ok(cathedra);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cathedraExists(int id)
        {
            return db.cathedra.Count(e => e.cathedra_id == id) > 0;
        }
    }
}