using System.Net.Http;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using DoctorWho.Web.Enumerations;
using DoctorWho.Db.Contracts;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Filters
{
    public class DoctorNameRadictionActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
            // assume from the database:
            Models.InformationRequestDto informationRequestDto = new Models.InformationRequestDto()
            {
                AccessLevel = Enumerations.AccessLevel.Unknown,
                StartTime = new DateTime(2000, 1, 1),
                EndTime = new DateTime(2000, 12, 1), //or new DateTime(3000, 12, 1) for a different result
            };
            var myResult = (OkObjectResult)context.Result;
            var doctorDtoList = (IEnumerable<DoctorDto>)myResult.Value;
            var network = int.Parse(context.HttpContext.Request.Headers["network"][0]);
            if (network == (int)NetworkType.Internal && informationRequestDto.AccessLevel != AccessLevel.Redacted)
            {
                foreach (var doctor in doctorDtoList)
                    doctor.DoctorName = "Redacted";
            }
        }
    }
}
