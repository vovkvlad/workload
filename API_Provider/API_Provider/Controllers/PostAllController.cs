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
    public class PostAllController : ApiController
    {
        private VovksStudentEntities db = new VovksStudentEntities();

        // GET api/PostAll
        public IQueryable<post_all> Getpost_all()
        {
            return db.post_all;
        }

        // GET api/PostAll/5
        [ResponseType(typeof(post_all))]
        public IHttpActionResult Getpost_all(int id)
        {
            post_all post_all = db.post_all.Find(id);
            if (post_all == null)
            {
                return NotFound();
            }

            return Ok(post_all);
        }

        // PUT api/PostAll/5
        public IHttpActionResult Putpost_all(int id, post_all post_all)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post_all.post_id)
            {
                return BadRequest();
            }

            db.Entry(post_all).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!post_allExists(id))
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

        // POST api/PostAll
        [ResponseType(typeof(post_all))]
        public IHttpActionResult Postpost_all(post_all post_all)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.post_all.Add(post_all);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (post_allExists(post_all.post_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = post_all.post_id }, post_all);
        }

        // DELETE api/PostAll/5
        [ResponseType(typeof(post_all))]
        public IHttpActionResult Deletepost_all(int id)
        {
            post_all post_all = db.post_all.Find(id);
            if (post_all == null)
            {
                return NotFound();
            }

            db.post_all.Remove(post_all);
            db.SaveChanges();

            return Ok(post_all);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool post_allExists(int id)
        {
            return db.post_all.Count(e => e.post_id == id) > 0;
        }
    }
}