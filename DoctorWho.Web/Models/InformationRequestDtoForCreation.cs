using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Models
{
    public class InformationRequestDtoForCreation
    {
        public Enumerations.AccessLevel AccessLevel { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
