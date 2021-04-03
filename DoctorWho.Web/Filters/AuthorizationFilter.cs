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

namespace DoctorWho.Web.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userId = int.Parse(context.HttpContext.Request.Headers["userId"][0]);
            // assume from the database for user with [userId]:
            Models.InformationRequestDto informationRequestDto = new Models.InformationRequestDto()
            {
                AccessLevel = Enumerations.AccessLevel.Unknown,
                StartTime = new DateTime(2000, 1, 1),
                EndTime = new DateTime(3000, 12, 1), //or new DateTime(2000, 12, 1) for a different result
            };
            DateTime currentDate = DateTime.Now;
            bool isEligibleDate = currentDate >= informationRequestDto.StartTime || currentDate <= informationRequestDto.EndTime;
            var auth = int.Parse(context.HttpContext.Request.Headers["auth"][0]);
            if (auth != (int)ApprovalStatus.Approved || !isEligibleDate)
                context.Result = new JsonResult(
                            new
                            {
                                Message = "You do not have permissions/The admin doesn't yet approve your request/requests",
                                RequestsIds = new[] { 1, 4, 7 },// assume from the database, after checking..
                            });
        }
    }
}
