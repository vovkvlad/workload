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

namespace API_Provider.Controllers
{
    public class CathedraController : ApiController
    {
        private VovksStudentEntities db = new VovksStudentEntities();

        // GET api/Cathedra
        public IQueryable<cathedra> Getcathedra()
        {
            return db.cathedra;
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

            return Ok(cathedra);
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