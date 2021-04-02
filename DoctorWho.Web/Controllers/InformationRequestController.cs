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
    [Route("api/informationRequest")]
    public class InformationRequestController : ControllerBase
    {
        // private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public InformationRequestController(IAuthorRepository authorRepository, IMapper mapper)
        {
            // _authorRepository = authorRepository ??
            //   throw new ArgumentNullException(nameof(AuthorRepository));
            // _mapper = mapper ??
            //   throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetCurrentInformationRequests")]
        [HttpHead]
        public IActionResult GetCurrentInformationRequests(
         [FromHeader] Enumerations.AccessLevel auth,
         [FromHeader] Enumerations.NetworkType network,
         [FromHeader] int userId)
        {
            // switch()
            return Ok(new
            {
                auth = auth,
                network = network,
                userId = userId
            });
        }

        [HttpPost()]
        public IActionResult CreateInformationRequest(
         [FromHeader] Enumerations.AccessLevel auth,
         [FromHeader] Enumerations.NetworkType network,
         [FromHeader] int userId)
        {
            return Ok();
        }

        [HttpPost("approve")]
        public ActionResult ApproveInformationRequest(
        [FromHeader] Enumerations.AccessLevel auth,
         [FromHeader] Enumerations.NetworkType network,
         [FromHeader] int userId,
         [FromBody] InformationRequestApprovalCreationDto informationRequestApprovalCreationDto)
        {
            return Ok(new { AccessRequestId = informationRequestApprovalCreationDto.AccessRequestId });
        }

    }
}
