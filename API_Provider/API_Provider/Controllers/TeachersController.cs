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
    public class TeachersController : ApiController
    {
        private VovksStudentEntities db = new VovksStudentEntities();

        // GET api/Teachers
        public IQueryable<teachers> Getteachers()
        {
            return db.teachers;
        }

        // GET api/Teachers/5
        [ResponseType(typeof(teachers))]
        public IHttpActionResult Getteachers(int id)
        {
            teachers teachers = db.teachers.Find(id);
            if (teachers == null)
            {
                return NotFound();
            }

            return Ok(teachers);
        }

        // PUT api/Teachers/5
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

        // POST api/Teachers
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

        // DELETE api/Teachers/5
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