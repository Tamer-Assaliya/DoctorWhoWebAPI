using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using DoctorWho.Web.Models;
using DoctorWho.Db.Contracts;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorsController(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository ??
              throw new ArgumentNullException(nameof(DoctorRepository));
            _mapper = mapper ??
              throw new ArgumentNullException(nameof(mapper));
        }

        [TypeFilter(typeof(Filters.AuthorizationFilter))]
        [TypeFilter(typeof(Filters.DoctorNameRadictionActionFilter))]
        [HttpGet(Name = "GetDoctors")]
        [HttpHead]
        public ActionResult<IEnumerable<DoctorDto>> GetAllDoctors()
        {
            var doctorsFromRepo = _doctorRepository.GetAllDoctors();
            return Ok(_mapper.Map<IEnumerable<DoctorDto>>(doctorsFromRepo));
        }

        [HttpGet("{doctorId}", Name = "GetDoctor")]
        public ActionResult<DoctorDto> GetDoctor(int doctorId)
        {
            var doctorFromRepo = _doctorRepository.GetDoctor(doctorId);
            if (doctorFromRepo == null)
                return NotFound();
            return Ok(_mapper.Map<DoctorDto>(doctorFromRepo));
        }

        [HttpPut("{doctorId}")]
        public IActionResult UpsertDoctor(int doctorId, DoctorForUpadteDto doctor)
        {
            var courseForDoctorFromRepo = _doctorRepository.GetDoctor(doctorId);
            if (_doctorRepository.GetDoctor(doctorId) == null)
            {
                var doctorToAdd = _mapper.Map<Doctor>(doctor);
                doctorToAdd.DoctorId = doctorId;
                _doctorRepository.CreatDoctor(doctorId, doctorToAdd);
                var doctorToReturn = _mapper.Map<DoctorDto>(doctorToAdd);
                return CreatedAtRoute("GetDoctor",
                new { doctorId = doctorToReturn.DoctorId },
                doctorToReturn);
            }
            _mapper.Map(doctor, courseForDoctorFromRepo);
            _doctorRepository.UpdateDoctor(doctorId, courseForDoctorFromRepo);
            return NoContent();
        }

        [HttpDelete("{doctorId}")]
        public IActionResult DeleteDoctor(int doctorId)
        {
            var doctorFromRepo = _doctorRepository.GetDoctor(doctorId);
            if (doctorFromRepo == null)
                return NotFound();
            _doctorRepository.DeleteDoctor(doctorFromRepo);
            return NoContent();
        }
    }
}
