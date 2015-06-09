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
    [RoutePrefix("api/Cathedra")]
    public class CathedraController : ApiController
    {
        private VovksStudentEntities db = new VovksStudentEntities();

        public CathedraController()
        {
            Mapper.CreateMap<teacher, int>().ConvertUsing(x => x.teacher_id);
            Mapper.CreateMap<cathedra, cathedraDTO>();
                //.ForMember(dest => dest.teachers, opt => opt.MapFrom(src => src.teachers))
                //.ForMember(dest => dest.cathedra_type, opt => opt.MapFrom(src => src.cathedra_type.cathedra_type_id));
            Mapper.AssertConfigurationIsValid();
        }

        // GET api/Cathedra
        [Route("")]
        public IEnumerable<cathedraDTO> Getcathedra()
        {
            var dto = Mapper.Map<IEnumerable<cathedra>, IEnumerable<cathedraDTO>>(db.cathedras.Take(5));
            return dto;
        }

        // GET api/Cathedra/5
        [Route("{id}")]
        [ResponseType(typeof(cathedra))]
        public IHttpActionResult Getcathedra(int id)
        {
            cathedra cathedra = db.cathedras.Find(id);
            if (cathedra == null)
            {
                return NotFound();
            }

            var dto = Mapper.Map<cathedra, cathedraDTO>(cathedra);
            return Ok(dto);
        }

        [Route("faculty/{id}")]
        [ResponseType(typeof(cathedra))]
        public IHttpActionResult GetcathedraByFacultyId(int id)
        {
            var result = db.cathedras.ToList().Where(cathedra => cathedra.faculty_id.Equals(id));
            if (result.Count() == 0)
            {
                return NotFound();
            }

            var dto = Mapper.Map<IEnumerable<cathedra>, IEnumerable<cathedraDTO>>(result);
            return Ok(dto);
        }

        [Route("name/{name}")]
        public IHttpActionResult GetcathedraByName_all(string name)
        {
            var x = name;
            var result = db.cathedras.ToList().Where(text => text.name.Contains(name));
            if (result.Count() == 0)
            {
                return NotFound();
            }
            var dto = Mapper.Map<IEnumerable<cathedra>, IEnumerable<cathedraDTO>>(result);
            return Ok(dto);
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
            return db.cathedras.Count(e => e.cathedra_id == id) > 0;
        }
    }
}