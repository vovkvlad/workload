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
    [RoutePrefix("api/Post")]
    public class PostController : ApiController
    {
        private VovksStudentEntities db = new VovksStudentEntities();

        public PostController ()
        {

            Mapper.CreateMap<post_all, postDTO>();
            Mapper.AssertConfigurationIsValid();
        }

        // GET api/Post
        [Route("")]
        public IEnumerable<postDTO> Getpost_all()
        {
            var dto = Mapper.Map<IEnumerable<post_all>, IEnumerable<postDTO>>(db.post_all);
            return dto;
        }

        // GET api/Post/5
        [Route("{id}")]
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