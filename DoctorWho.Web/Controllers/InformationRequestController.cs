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
        // private readonly InformationRequestRepository;
        private readonly IMapper _mapper;


        [HttpGet(Name = "GetCurrentInformationRequests")]
        [HttpHead]
        public IActionResult GetCurrentInformationRequests(
         [FromHeader] Enumerations.AccessLevel auth,
         [FromHeader] Enumerations.NetworkType network,
         [FromHeader] int userId)
        {
            //Assume from the database
            var informationRequestDto = new InformationRequestDto()
            {
                AccessLevel = Enumerations.AccessLevel.Unknown,
                StartTime = new DateTime(2000, 1, 1),
                EndTime = new DateTime(3000, 12, 1), //or new DateTime(2000, 12, 1) for a different result
            };
            // switch()
            return Ok(new[] { informationRequestDto, informationRequestDto, informationRequestDto }); //returns IEnumerable 
        }

        [HttpPost()]
        public IActionResult CreateInformationRequest(
         [FromHeader] Enumerations.AccessLevel auth,
         [FromHeader] Enumerations.NetworkType network,
         [FromHeader] int userId)
        {
            //Assume from the database
            var informationRequestDto = new InformationRequestDto()
            {
                AccessLevel = Enumerations.AccessLevel.Unknown,
                StartTime = new DateTime(2000, 1, 1),
                EndTime = new DateTime(3000, 12, 1), //or new DateTime(2000, 12, 1) for a different result
            };
            return Ok(informationRequestDto);
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
