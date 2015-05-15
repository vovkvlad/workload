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
    public class AdmPostController : ApiController
    {
        private VovksStudentEntities1 db = new VovksStudentEntities1();

        // GET api/AdmPost
        public IQueryable<admpost_all> Getadmpost_all()
        {
            return db.admpost_all;
        }

        // GET api/AdmPost/5
        [ResponseType(typeof(admpost_all))]
        public IHttpActionResult Getadmpost_all(int id)
        {
            admpost_all admpost_all = db.admpost_all.Find(id);
            if (admpost_all == null)
            {
                return NotFound();
            }

            return Ok(admpost_all);
        }

        // PUT api/AdmPost/5
        public IHttpActionResult Putadmpost_all(int id, admpost_all admpost_all)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admpost_all.admpost_id)
            {
                return BadRequest();
            }

            db.Entry(admpost_all).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!admpost_allExists(id))
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

        // POST api/AdmPost
        [ResponseType(typeof(admpost_all))]
        public IHttpActionResult Postadmpost_all(admpost_all admpost_all)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.admpost_all.Add(admpost_all);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (admpost_allExists(admpost_all.admpost_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = admpost_all.admpost_id }, admpost_all);
        }

        // DELETE api/AdmPost/5
        [ResponseType(typeof(admpost_all))]
        public IHttpActionResult Deleteadmpost_all(int id)
        {
            admpost_all admpost_all = db.admpost_all.Find(id);
            if (admpost_all == null)
            {
                return NotFound();
            }

            db.admpost_all.Remove(admpost_all);
            db.SaveChanges();

            return Ok(admpost_all);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool admpost_allExists(int id)
        {
            return db.admpost_all.Count(e => e.admpost_id == id) > 0;
        }
    }
}