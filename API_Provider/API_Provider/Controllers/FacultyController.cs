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
    [RoutePrefix("api/Faculty")]
    public class FacultyController : ApiController
    {
        private VovksStudentEntities db = new VovksStudentEntities();

        public FacultyController()
        {
            //Mapper.CreateMap<nagruzka_details, int>().ConvertUsing(x => x.nagruzka_detail_id);
            //Mapper.CreateMap<nagruzka_other, int>().ConvertUsing(x => x.nagruzka_other_id);
            //Mapper.CreateMap<nagruzka_all, int>().ConstructUsing(x => x.nagruzka_id);
            //Mapper.CreateMap<teachers, int>().ConstructUsing(x => x.teacher_id);
            Mapper.CreateMap<faculty_all, facultyDTO>();
                /*.ForMember(dest => dest.faculty_type_all, opt => opt.Ignore())//opt.MapFrom(src => src.faculty_type_all.faculty_type_id))
                .ForMember(dest => dest.nagruzka_all, opt => opt.Ignore())//MapFrom(src => src.nagruzka_all))
                .ForMember(dest => dest.nagruzka_details, opt => opt.Ignore())
                .ForMember(dest => dest.nagruzka_other, opt => opt.Ignore())
                .ForMember(dest => dest.teachers, opt => opt.Ignore());*/
            Mapper.AssertConfigurationIsValid();
        }

        // GET api/Faculty
        [Route("")]
        public IEnumerable<facultyDTO> Getfaculty_all()
        {
            var dto = Mapper.Map<IEnumerable<faculty_all>, IEnumerable<facultyDTO>>(db.faculty_all.Take(5));
            return dto;
        }

        // GET api/Faculty/5
        [Route("{id}")]
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

        [Route("name/{name}")]
        public IHttpActionResult Getfaculty_all(string name)
        {
            var x = name;
            var result = db.faculty_all.ToList().Where(text => text.name.Contains(name));
            if (result.Count() == 0)
            {
                return NotFound();
            }
            var dto = Mapper.Map<IEnumerable<faculty_all>, IEnumerable<facultyDTO>>(result);
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

        private bool faculty_allExists(int id)
        {
            return db.faculty_all.Count(e => e.faculty_id == id) > 0;
        }
    }
}