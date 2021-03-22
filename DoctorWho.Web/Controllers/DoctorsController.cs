using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorsController(DoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository ??
              throw new ArgumentNullException(nameof(DoctorRepository));
            _mapper = mapper ??
              throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetDoctor")]
        [HttpHead]
        public ActionResult<IEnumerable<DoctorDto>> GetAllDoctors(Guid authorId)
        {
            var doctorsFromRepo = _doctorRepository.GetAllDoctors();
            return Ok(_mapper.Map<IEnumerable<DoctorDto>>(doctorsFromRepo));
        }
    }
}
